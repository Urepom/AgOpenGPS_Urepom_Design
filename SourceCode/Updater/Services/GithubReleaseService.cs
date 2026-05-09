using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgOpenGPS.Updater.Models;
using Newtonsoft.Json;

namespace AgOpenGPS.Updater.Services
{
    /// <summary>
    /// Service for interacting with GitHub Releases API.
    /// </summary>
    public class GithubReleaseService : IDisposable
    {
        private const string DefaultOwner = "AgOpenGPS-Official";
        private const string DefaultRepository = "AgOpenGPS";
        private const string GithubApiUrl = "https://api.github.com";

        private readonly HttpClient _httpClient;
        private readonly string _owner;
        private readonly string _repository;

        public GithubReleaseService(string owner = null, string repository = null)
        {
            _owner = owner ?? DefaultOwner;
            _repository = repository ?? DefaultRepository;
            // Use provided token or fall back to default read-only token

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(GithubApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AgOpenGPS-Updater", "1.0"));

        }

        /// <summary>
        /// Gets the latest release from GitHub.
        /// </summary>
        /// <param name="includePrerelease">Whether to include pre-release versions.</param>
        /// <returns>The latest release info, or null if none found.</returns>
        public async Task<ReleaseInfo> GetLatestRelease(bool includePrerelease = false)
        {
            try
            {
                string url = $"/repos/{_owner}/{_repository}/releases";

                if (!includePrerelease)
                {
                    // For stable releases only, get the latest release
                    url = $"/repos/{_owner}/{_repository}/releases/latest";
                }

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                if (includePrerelease)
                {
                    // Parse as array and get the first non-draft release
                    var releases = JsonConvert.DeserializeObject<List<ReleaseInfo>>(content);
                    foreach (var release in releases)
                    {
                        if (!release.Draft)
                        {
                            return release;
                        }
                    }
                    return null;
                }
                else
                {
                    // Parse as single release
                    var release = JsonConvert.DeserializeObject<ReleaseInfo>(content);

                    // Don't return pre-releases if we only want stable
                    if (release != null && release.Prerelease)
                    {
                        // If the "latest" endpoint returns a prerelease (shouldn't happen),
                        // we need to find the latest stable one
                        return await GetLatestStableRelease();
                    }

                    return release;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to fetch releases from GitHub: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Failed to parse release data: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the latest stable release when the latest endpoint returns a prerelease.
        /// </summary>
        private async Task<ReleaseInfo> GetLatestStableRelease()
        {
            var response = await _httpClient.GetAsync($"/repos/{_owner}/{_repository}/releases");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var releases = JsonConvert.DeserializeObject<List<ReleaseInfo>>(content);

            foreach (var release in releases)
            {
                if (!release.Draft && !release.Prerelease)
                {
                    return release;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all releases (both stable and prerelease).
        /// </summary>
        public async Task<List<ReleaseInfo>> GetAllReleases()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/repos/{_owner}/{_repository}/releases");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var releases = JsonConvert.DeserializeObject<List<ReleaseInfo>>(content);

                // Filter out drafts
                releases.RemoveAll(r => r.Draft);

                return releases;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to fetch releases from GitHub: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets release information for a specific tag.
        /// </summary>
        public async Task<ReleaseInfo> GetReleaseByTag(string tag)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/repos/{_owner}/{_repository}/releases/tags/{tag}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ReleaseInfo>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to fetch release for tag '{tag}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Downloads an asset from a release.
        /// </summary>
        /// <param name="downloadUrl">The URL to download from.</param>
        /// <param name="destinationPath">Where to save the file.</param>
        /// <param name="progress">Optional progress reporter.</param>
        public async Task DownloadAsset(string downloadUrl, string destinationPath, IProgress<double> progress = null)
        {
            try
            {
                // Use a new client for download to handle large files better
                using (var downloadClient = new HttpClient())
                {
                    downloadClient.Timeout = TimeSpan.FromMinutes(10);

                    // Add User-Agent (required by GitHub)
                    downloadClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AgOpenGPS-Updater", "1.0"));

                    // NOTE: Don't add Authorization header for asset downloads!
                    // BrowserDownloadUrl points to a CDN (AWS/GitHub), not the GitHub API
                    // CDNs reject the Authorization header with 401 Unauthorized
                    // The asset URLs are public and don't need authentication

                    // Get the file size first
                    var headResponse = await downloadClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, downloadUrl));
                    headResponse.EnsureSuccessStatusCode();

                    long totalBytes = headResponse.Content.Headers.ContentLength ?? 0;

                    // Download the file
                    var response = await downloadClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    long totalBytesRead = 0;
                    var buffer = new byte[8192];

                    // Ensure directory exists
                    var directory = Path.GetDirectoryName(destinationPath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, true))
                    {
                        int bytesRead;
                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            if (progress != null && totalBytes > 0)
                            {
                                progress.Report((totalBytesRead * 100.0) / totalBytes);
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to download asset: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                throw new Exception($"Failed to save file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Downloads an asset to a memory stream.
        /// </summary>
        public async Task<byte[]> DownloadAssetToMemory(string downloadUrl, IProgress<double> progress = null)
        {
            try
            {
                using (var downloadClient = new HttpClient())
                {
                    downloadClient.Timeout = TimeSpan.FromMinutes(10);

                    // Add User-Agent (required by GitHub)
                    downloadClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AgOpenGPS-Updater", "1.0"));

                    // NOTE: Don't add Authorization header for asset downloads (see DownloadAsset)

                    var response = await downloadClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    long totalBytes = response.Content.Headers.ContentLength ?? 0;
                    long totalBytesRead = 0;

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var memoryStream = new MemoryStream())
                    {
                        var buffer = new byte[8192];
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            if (progress != null && totalBytes > 0)
                            {
                                progress.Report((totalBytesRead * 100.0) / totalBytes);
                            }
                        }

                        return memoryStream.ToArray();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to download asset: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Checks if there is a newer version available.
        /// </summary>
        /// <param name="currentVersion">The current version string.</param>
        /// <param name="includePrerelease">Whether to include prerelease versions.</param>
        /// <returns>The release info if an update is available, null otherwise.</returns>
        public async Task<ReleaseInfo> CheckForUpdate(string currentVersion, bool includePrerelease = false)
        {
            var latestRelease = await GetLatestRelease(includePrerelease);
            if (latestRelease == null)
                return null;

            // Parse current version
            if (!SemanticVersion.TryParse(currentVersion, out var currentSemVer))
                return null;

            // Parse latest version
            if (!SemanticVersion.TryParse(latestRelease.Version, out var latestSemVer))
                return null;

            // If including prereleases but current is also prerelease,
            // we should still update if the latest is newer
            if (latestSemVer > currentSemVer)
            {
                return latestRelease;
            }

            return null;
        }

        /// <summary>
        /// Checks if this service has an authentication token.
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
