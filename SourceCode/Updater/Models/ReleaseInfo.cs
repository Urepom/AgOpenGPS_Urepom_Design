using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AgOpenGPS.Updater.Models
{
    /// <summary>
    /// Represents a GitHub Release.
    /// </summary>
    public class ReleaseInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("assets")]
        public List<ReleaseAsset> Assets { get; set; } = new List<ReleaseAsset>();

        /// <summary>
        /// Gets the display version (without 'v' prefix if present).
        /// </summary>
        public string Version => TagName?.TrimStart('v');

        /// <summary>
        /// Gets the type of release (Stable, Beta, Alpha, etc.).
        /// </summary>
        public string ReleaseType
        {
            get
            {
                if (!Prerelease) return "Stable";

                // Try to determine pre-release type from tag or name
                string tagLower = TagName?.ToLower() ?? "";
                if (tagLower.Contains("beta") || tagLower.Contains("b")) return "Beta";
                if (tagLower.Contains("alpha") || tagLower.Contains("a")) return "Alpha";
                if (tagLower.Contains("rc")) return "Release Candidate";
                return "Pre-release";
            }
        }
    }

    /// <summary>
    /// Represents a GitHub Release Asset.
    /// </summary>
    public class ReleaseAsset
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the formatted file size.
        /// </summary>
        public string FormattedSize
        {
            get
            {
                const long KB = 1024;
                const long MB = KB * 1024;

                if (Size < KB)
                    return $"{Size} B";
                if (Size < MB)
                    return $"{Size / (double)KB:F2} KB";
                return $"{Size / (double)MB:F2} MB";
            }
        }

        /// <summary>
        /// Checks if this asset is a zip file (suitable for update).
        /// </summary>
        public bool IsZipFile => Name != null && Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Checks if this asset is the main AgOpenGPS release.
        /// </summary>
        public bool IsMainRelease => Name != null && Name.IndexOf("AgOpenGPS", StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
