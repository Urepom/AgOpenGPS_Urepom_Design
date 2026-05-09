using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgOpenGPS.Updater.Services
{
    /// <summary>
    /// Service for detecting USB drives and local update files.
    /// </summary>
    public class UsbUpdateService
    {
        private const string FilePrefix = "AgOpenGPS";

        /// <summary>
        /// Gets all removable drives that could contain the update file.
        /// </summary>
        public static DriveInfo[] GetRemovableDrives()
        {
            try
            {
                return DriveInfo.GetDrives()
                    .Where(d => d.DriveType == DriveType.Removable && d.IsReady)
                    .ToArray();
            }
            catch
            {
                return Array.Empty<DriveInfo>();
            }
        }

        /// <summary>
        /// Searches for AgOpenGPS*.zip on all removable drives.
        /// Returns the file path and version extracted from filename.
        /// </summary>
        public static (string FilePath, string Version) FindUpdateFile()
        {
            try
            {
                var drives = GetRemovableDrives();
                foreach (var drive in drives)
                {
                    // Check root directory first for exact AgOpenGPS.zip
                    var rootFiles = Directory.GetFiles(drive.Name, "*.zip")
                        .Where(f => Path.GetFileName(f).StartsWith(FilePrefix, StringComparison.OrdinalIgnoreCase));

                    foreach (var file in rootFiles.OrderBy(f => f))
                    {
                        if (IsValidUpdateFile(file, out string version))
                        {
                            return (file, version);
                        }
                    }

                    // Also check subdirectories
                    try
                    {
                        var allZipFiles = Directory.GetFiles(drive.Name, "*.zip", SearchOption.AllDirectories)
                            .Where(f => Path.GetFileName(f).StartsWith(FilePrefix, StringComparison.OrdinalIgnoreCase));

                        foreach (var file in allZipFiles.OrderBy(f => f))
                        {
                            if (IsValidUpdateFile(file, out string version))
                            {
                                return (file, version);
                            }
                        }
                    }
                    catch { }
                }

                return (null, null);
            }
            catch
            {
                return (null, null);
            }
        }

        /// <summary>
        /// Validates that the zip file contains AgOpenGPS.exe and extracts version from filename.
        /// </summary>
        private static bool IsValidUpdateFile(string zipPath, out string version)
        {
            version = null;

            try
            {
                // Check file size - must be reasonable
                var fileInfo = new FileInfo(zipPath);
                if (fileInfo.Length < 1024 * 100) // Less than 100KB is invalid
                    return false;

                // Extract version from filename (AgOpenGPS_6.8.1.zip or AgOpenGPS_v6.8.1.zip)
                string fileName = Path.GetFileNameWithoutExtension(zipPath);
                var match = Regex.Match(fileName, $@"^{Regex.Escape(FilePrefix)}[_-]?v?(\d+\.\d+\.\d+)", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    version = match.Groups[1].Value;
                }

                // Verify the zip contains AgOpenGPS.exe
                using (var archive = ZipFile.OpenRead(zipPath))
                {
                    bool hasExe = archive.Entries.Any(e =>
                        e.Name.Equals("AgOpenGPS.exe", StringComparison.OrdinalIgnoreCase));

                    if (!hasExe)
                        return false;

                    // If version not in filename, try to get it from the exe
                    if (string.IsNullOrEmpty(version))
                    {
                        var exeEntry = archive.Entries.FirstOrDefault(e =>
                            e.Name.Equals("AgOpenGPS.exe", StringComparison.OrdinalIgnoreCase));

                        if (exeEntry != null)
                        {
                            version = ExtractVersionFromExe(exeEntry);
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Extracts version from AgOpenGPS.exe by reading the executable.
        /// </summary>
        private static string ExtractVersionFromExe(ZipArchiveEntry exeEntry)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".exe");

                using (var stream = exeEntry.Open())
                using (var fs = File.Create(tempPath))
                {
                    stream.CopyTo(fs);
                }

                try
                {
                    var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(tempPath);
                    string fileVersion = fileVersionInfo.FileVersion;

                    if (!string.IsNullOrEmpty(fileVersion))
                    {
                        // Extract just the version number (may have trailing info)
                        var match = Regex.Match(fileVersion, @"^(\d+\.\d+\.\d+)");
                        if (match.Success)
                        {
                            return match.Groups[1].Value;
                        }
                        return fileVersion;
                    }
                }
                finally
                {
                    if (File.Exists(tempPath))
                        File.Delete(tempPath);
                }
            }
            catch { }

            return null;
        }

        /// <summary>
        /// Gets a user-friendly description of where the update file was found.
        /// </summary>
        public static string GetUpdateLocation(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            try
            {
                var drive = new DriveInfo(Path.GetPathRoot(filePath));
                string fileName = Path.GetFileName(filePath);
                string driveName = drive.VolumeLabel;

                if (string.IsNullOrEmpty(driveName))
                    driveName = drive.Name.TrimEnd('\\').ToUpper();

                return $"USB ({driveName}): {fileName}";
            }
            catch
            {
                return Path.GetFileName(filePath);
            }
        }

        /// <summary>
        /// Checks if a local update is available on USB.
        /// </summary>
        public static (bool Found, string FilePath, string Version, string Location, string Message) CheckForLocalUpdate()
        {
            try
            {
                var (filePath, version) = FindUpdateFile();

                if (filePath != null)
                {
                    var location = GetUpdateLocation(filePath);
                    var info = new FileInfo(filePath);

                    string versionText = string.IsNullOrEmpty(version) ? "Unknown" : version;
                    string message = $"Found: {Path.GetFileName(filePath)}\n" +
                                    $"Version: {versionText}\n" +
                                    $"Size: {FormatFileSize(info.Length)}\n" +
                                    $"Location: {location}";

                    return (true, filePath, version, location, message);
                }

                return (false, null, null, null,
                    "No update file found.\n\nPlace AgOpenGPS_X.Y.Z.zip in the root of your USB drive.");
            }
            catch (Exception ex)
            {
                return (false, null, null, null, $"Error checking USB: {ex.Message}");
            }
        }

        private static string FormatFileSize(long bytes)
        {
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;

            if (bytes < KB) return $"{bytes} B";
            if (bytes < MB) return $"{bytes / KB:F1} KB";
            if (bytes < GB) return $"{bytes / MB:F1} MB";
            return $"{bytes / GB:F1} GB";
        }
    }
}
