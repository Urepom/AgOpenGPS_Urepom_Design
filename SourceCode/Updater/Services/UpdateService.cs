using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AgOpenGPS.Updater.Models;

namespace AgOpenGPS.Updater.Services
{
    /// <summary>
    /// Core service for managing the update process.
    /// </summary>
    public class UpdateService
    {
        private const string AgOpenGPSProcessName = "AgOpenGPS";
        private const string AgIOProcessName = "AgIO";
        private const int MaxWaitSeconds = 10;

        /// <summary>
        /// Checks for updates and returns the release info if an update is available.
        /// </summary>
        public async Task<(bool HasUpdate, ReleaseInfo ReleaseInfo, string Message)> CheckForUpdate(
            string currentVersion, bool includePrerelease = false)
        {
            try
            {
                using (var githubService = new GithubReleaseService())
                {
                    var updateInfo = await githubService.CheckForUpdate(currentVersion, includePrerelease);

                    if (updateInfo != null)
                    {
                        return (
                            true,
                            updateInfo,
                            $"Update available: {updateInfo.Version} ({updateInfo.ReleaseType})"
                        );
                    }

                    return (false, null, "You're using the latest version. No update needed.");
                }
            }
            catch (Exception ex)
            {
                return (false, null, $"Failed to check for updates: {ex.Message}");
            }
        }

        /// <summary>
        /// Downloads an update release to the specified path.
        /// </summary>
        public async Task<(bool Success, string DownloadPath, string Message)> DownloadUpdate(
            ReleaseInfo release, string targetDirectory, IProgress<double> progress = null)
        {
            try
            {
                // Find the appropriate asset (zip file)
                var asset = release.Assets.FirstOrDefault(a => a.IsZipFile && a.IsMainRelease);
                if (asset == null)
                {
                    // Fallback to any zip file
                    asset = release.Assets.FirstOrDefault(a => a.IsZipFile);
                }

                if (asset == null)
                {
                    return (false, null, "No suitable download asset found in this release.");
                }

                // Ensure target directory exists
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string downloadPath = Path.Combine(targetDirectory, Path.GetFileName(asset.Name));

                using (var githubService = new GithubReleaseService())
                {
                    await githubService.DownloadAsset(asset.BrowserDownloadUrl, downloadPath, progress);
                }

                return (true, downloadPath, $"Successfully downloaded {asset.Name}");
            }
            catch (Exception ex)
            {
                return (false, null, $"Download failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Mutex name to signal AgOpenGPS that updater is active (prevent shutdown during update).
        /// </summary>
        private const string UpdaterMutexName = "Global\\AgOpenGPS_Updater_Active";

        /// <summary>
        /// Closes AgOpenGPS and AgIO applications gracefully.
        /// Creates a mutex to prevent AgOpenGPS from shutting down the computer during update.
        /// </summary>
        public async Task<(bool Success, string Message)> CloseApplicationsAsync()
        {
            System.Threading.Mutex updaterMutex = null;
            try
            {
                // Create mutex to signal AgOpenGPS that updater is active
                // This prevents AgOpenGPS from shutting down the computer during update
                updaterMutex = new System.Threading.Mutex(true, UpdaterMutexName, out bool createdNew);
                if (!createdNew)
                {
                    // Another updater instance is already running
                    return (false, "Another updater instance is already running.");
                }

                bool agOpenClosed = await CloseProcessAsync(AgOpenGPSProcessName);
                bool agIOClosed = await CloseProcessAsync(AgIOProcessName);

                if (!agOpenClosed && !agIOClosed)
                {
                    updaterMutex.ReleaseMutex();
                    updaterMutex.Dispose();
                    return (true, "No applications were running.");
                }

                // Keep mutex alive during update - will be released when UpdateService is disposed
                // Store it for later disposal
                _updaterMutex = updaterMutex;
                updaterMutex = null; // Don't dispose here, will be disposed in cleanup

                return (true, "Applications closed successfully.");
            }
            catch (Exception ex)
            {
                updaterMutex?.Dispose();
                return (false, $"Failed to close applications: {ex.Message}");
            }
        }

        private System.Threading.Mutex _updaterMutex;

        /// <summary>
        /// Attempts to gracefully close a process by name.
        /// </summary>
        private async Task<bool> CloseProcessAsync(string processName)
        {
            var processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
                return true; // Process not running is considered successful

            bool allClosed = true;

            foreach (var process in processes)
            {
                try
                {
                    // Try graceful close first
                    if (!process.CloseMainWindow())
                    {
                        // If main window close didn't work, wait a bit and try Kill
                        await Task.Run(() => process.WaitForExit(2000));

                        if (!process.HasExited)
                        {
                            process.Kill();
                            await Task.Run(() => process.WaitForExit(5000));
                        }
                    }
                    else
                    {
                        // Wait for process to exit after graceful close
                        await Task.Run(() => process.WaitForExit(MaxWaitSeconds * 1000));

                        if (!process.HasExited)
                        {
                            process.Kill();
                            await Task.Run(() => process.WaitForExit(2000));
                        }
                    }
                }
                catch (Exception)
                {
                    allClosed = false;
                }
                finally
                {
                    try
                    {
                        process?.Dispose();
                    }
                    catch { }
                }
            }

            return allClosed;
        }

        /// <summary>
        /// Installs the update from the downloaded zip file.
        /// </summary>
        public async Task<(bool Success, string Message)> InstallUpdateAsync(string zipPath, string installPath, string currentVersion, IProgress<InstallProgress> progress = null)
        {
            string backupPath = null;

            try
            {
                // Validate inputs
                if (!File.Exists(zipPath))
                {
                    return (false, "Update file not found.");
                }

                if (!Directory.Exists(installPath))
                {
                    return (false, "Installation directory does not exist.");
                }

                // Step 1: Create backup
                progress?.Report(new InstallProgress { Phase = "Creating backup...", Percent = 0, OverallPercent = 0 });
                await Task.Run(() =>
                {
                    backupPath = CreateBackup(installPath, currentVersion);
                });

                // Step 2: Extract zip to temp
                progress?.Report(new InstallProgress { Phase = "Extracting files...", Percent = 0, OverallPercent = 20 });

                string tempExtractPath = await Task.Run(() =>
                {
                    return ExtractZipToTemp(zipPath);
                });

                progress?.Report(new InstallProgress { Phase = "Installing files...", Percent = 30, OverallPercent = 50 });

                // Step 3: Copy files with progress reporting
                var (success, errorMessage) = await CopyFilesWithProgressAsync(tempExtractPath, installPath, progress);

                // Clean up temp extraction
                try
                {
                    if (Directory.Exists(tempExtractPath))
                    {
                        Directory.Delete(tempExtractPath, true);
                    }
                }
                catch { }

                if (!success)
                {
                    // Restore from backup since extraction failed
                    if (!string.IsNullOrEmpty(backupPath) && Directory.Exists(backupPath))
                    {
                        try
                        {
                            await Task.Run(() => RestoreBackup(backupPath, installPath));
                            return (false, $"{errorMessage}\nBackup was restored.");
                        }
                        catch
                        {
                            return (false, $"{errorMessage}\nBackup restoration also failed!");
                        }
                    }
                    return (false, errorMessage);
                }

                // Success
                progress?.Report(new InstallProgress { Phase = "Complete!", Percent = 100, OverallPercent = 100 });
                return (true, $"Update installed successfully.\n{errorMessage}\nBackup: {new DirectoryInfo(backupPath).Name}");
            }
            catch (Exception ex)
            {
                // Try to restore from backup if something went wrong
                if (!string.IsNullOrEmpty(backupPath) && Directory.Exists(backupPath))
                {
                    try
                    {
                        await Task.Run(() => RestoreBackup(backupPath, installPath));
                        return (false, $"Update failed: {ex.Message}\nBackup was restored.");
                    }
                    catch
                    {
                        return (false, $"Update failed: {ex.Message}\nBackup restoration also failed!");
                    }
                }

                return (false, $"Update failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Progress information for installation.
        /// </summary>
        public class InstallProgress
        {
            public string Phase { get; set; }
            public int Percent { get; set; }
            public int OverallPercent { get; set; }
        }

        /// <summary>
        /// Extracts zip to temp folder (runs on background thread).
        /// </summary>
        private string ExtractZipToTemp(string zipPath)
        {
            string tempExtractPath = Path.Combine(Path.GetTempPath(), "AgOpenGPS_Update_Extract_" + Guid.NewGuid().ToString("N"));

            if (Directory.Exists(tempExtractPath))
            {
                Directory.Delete(tempExtractPath, true);
            }

            Directory.CreateDirectory(tempExtractPath);

            // Extract the zip file
            ZipFile.ExtractToDirectory(zipPath, tempExtractPath);

            return tempExtractPath;
        }

        /// <summary>
        /// Copies files from temp location to install path with progress reporting.
        /// </summary>
        private async Task<(bool Success, string ErrorMessage)> CopyFilesWithProgressAsync(string tempExtractPath, string installPath, IProgress<InstallProgress> progress)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // Check if the zip contains a single root folder (common with GitHub releases)
                    var rootDirs = Directory.GetDirectories(tempExtractPath);
                    string sourcePath = tempExtractPath;

                    if (rootDirs.Length == 1)
                    {
                        // Use the subfolder as source
                        sourcePath = rootDirs[0];
                    }

                    // Get all files to copy first (for progress calculation)
                    var allFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories).ToList();
                    int totalFiles = allFiles.Count;
                    int processedFiles = 0;

                    // Directories to preserve (don't overwrite)
                    string[] preserveDirs = { "Fields", "Profiles", "Logs", ".backup" };

                    // Files to skip (updater's own files - they're locked while running)
                    string[] skipFiles = {
                        "AgOpenGPS.Updater.exe",
                        "AgOpenGPS.Updater.exe.config",
                        "Newtonsoft.Json.dll",
                        "AgOpenGPS.Updater.pdb"
                    };

                    int copiedFiles = 0;
                    int skippedFiles = 0;
                    int lockedFiles = 0;
                    var skippedLockedFiles = new List<string>();

                    // Copy files from the zip to the installation directory
                    foreach (var file in allFiles)
                    {
                        // Get relative path from source
                        Uri sourceUri = new Uri(sourcePath + Path.DirectorySeparatorChar);
                        Uri fileUri = new Uri(file);
                        string relativePath = Uri.UnescapeDataString(sourceUri.MakeRelativeUri(fileUri).ToString().Replace('/', Path.DirectorySeparatorChar));

                        // Check if we should skip this file entirely (updater's own files)
                        bool shouldSkipFile = false;
                        foreach (var skipFile in skipFiles)
                        {
                            if (relativePath.Equals(skipFile, StringComparison.OrdinalIgnoreCase))
                            {
                                shouldSkipFile = true;
                                lockedFiles++;
                                skippedLockedFiles.Add(skipFile);
                                break;
                            }
                        }

                        if (shouldSkipFile)
                        {
                            processedFiles++;
                            continue;
                        }

                        // Check if we should preserve this file (in protected directories)
                        bool shouldPreserve = false;
                        foreach (var preserveDir in preserveDirs)
                        {
                            // Check if the file is in a preserved directory (at root level)
                            string[] pathParts = relativePath.Split(Path.DirectorySeparatorChar);
                            if (pathParts.Length > 0 && pathParts[0].Equals(preserveDir, StringComparison.OrdinalIgnoreCase))
                            {
                                shouldPreserve = true;
                                break;
                            }
                        }

                        if (shouldPreserve)
                        {
                            skippedFiles++;
                            processedFiles++;
                            continue;
                        }

                        // Destination file path
                        string destFile = Path.Combine(installPath, relativePath);
                        string destDir = Path.GetDirectoryName(destFile);

                        // Create destination directory if needed
                        if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                        {
                            Directory.CreateDirectory(destDir);
                        }

                        // Try to copy the file with retry for locked files
                        for (int retry = 0; retry < 3; retry++)
                        {
                            try
                            {
                                // Delete existing file if it exists
                                if (File.Exists(destFile))
                                {
                                    File.Delete(destFile);
                                }

                                // Copy the new file
                                File.Copy(file, destFile, false);
                                copiedFiles++;
                                break;
                            }
                            catch (IOException)
                            {
                                // File is locked, wait and retry
                                if (retry < 2)
                                {
                                    System.Threading.Thread.Sleep(500);
                                }
                                else
                                {
                                    // Last retry failed, skip this file
                                    lockedFiles++;
                                    skippedLockedFiles.Add(relativePath);
                                }
                            }
                            catch (Exception)
                            {
                                // Other exception, don't retry
                                throw;
                            }
                        }

                        processedFiles++;

                        // Report progress
                        int currentPercent = (processedFiles * 100) / totalFiles;
                        int overallPercent = 50 + (currentPercent / 2); // 50-100% range
                        progress?.Report(new InstallProgress
                        {
                            Phase = $"Installing... {currentPercent}%",
                            Percent = currentPercent,
                            OverallPercent = overallPercent
                        });
                    }

                    string message = $"Extracted {copiedFiles} files";
                    if (skippedFiles > 0)
                        message += $", skipped {skippedFiles} preserved files";
                    if (lockedFiles > 0)
                        message += $", {lockedFiles} locked files";

                    return (true, message);
                }
                catch (Exception ex)
                {
                    return (false, $"Installation failed: {ex.Message}");
                }
            });
        }

        /// <summary>
        /// Creates a backup of the installation directory with version number.
        /// </summary>
        private string CreateBackup(string installPath, string currentVersion)
        {
            // Sanitize version for folder name (remove invalid characters)
            string sanitizedVersion = currentVersion.Replace('-', '_').Replace('+', '.');
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupFolderName = $".backup_{sanitizedVersion}_{timestamp}";
            string backupPath = Path.Combine(installPath, backupFolderName);

            // Create new backup
            Directory.CreateDirectory(backupPath);

            // Copy all files and directories (except backup folders)
            foreach (var file in Directory.GetFiles(installPath, "*", SearchOption.TopDirectoryOnly))
            {
                string fileName = Path.GetFileName(file);
                // Skip backup folders
                if (!fileName.StartsWith(".backup", StringComparison.OrdinalIgnoreCase))
                {
                    string destFile = Path.Combine(backupPath, fileName);
                    File.Copy(file, destFile, true);
                }
            }

            foreach (var dir in Directory.GetDirectories(installPath, "*", SearchOption.TopDirectoryOnly))
            {
                string dirName = new DirectoryInfo(dir).Name;
                // Skip backup folders
                if (!dirName.StartsWith(".backup", StringComparison.OrdinalIgnoreCase))
                {
                    string destDir = Path.Combine(backupPath, dirName);
                    CopyDirectory(dir, destDir);
                }
            }

            // Clean up old backups (keep last 3)
            CleanupOldBackups(installPath, 3);

            return backupPath;
        }

        /// <summary>
        /// Copies a directory recursively.
        /// </summary>
        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, new DirectoryInfo(dir).Name);
                CopyDirectory(dir, destSubDir);
            }
        }

        /// <summary>
        /// Removes old backup folders, keeping only the specified number.
        /// </summary>
        private void CleanupOldBackups(string installPath, int keepCount)
        {
            try
            {
                var backupDirs = Directory.GetDirectories(installPath, ".backup_*", SearchOption.TopDirectoryOnly)
                    .OrderByDescending(d => new DirectoryInfo(d).CreationTime)
                    .ToList();

                // Remove backups beyond the keep count
                for (int i = keepCount; i < backupDirs.Count; i++)
                {
                    try
                    {
                        Directory.Delete(backupDirs[i], true);
                    }
                    catch { } // Skip if can't delete
                }
            }
            catch { }
        }

        /// <summary>
        /// Restores a backup if the update failed.
        /// </summary>
        private void RestoreBackup(string backupPath, string installPath)
        {
            if (!Directory.Exists(backupPath))
                return;

            // Files that might be locked (updater's own files)
            string[] lockedFiles = {
                "AgOpenGPS.Updater.exe",
                "AgOpenGPS.Updater.exe.config",
                "Newtonsoft.Json.dll"
            };

            // Delete current files (skip locked files and backup directories)
            foreach (var file in Directory.GetFiles(installPath, "*", SearchOption.TopDirectoryOnly))
            {
                string fileName = Path.GetFileName(file);
                // Skip files in backup directories
                if (!fileName.StartsWith(".backup", StringComparison.OrdinalIgnoreCase))
                {
                    bool isLockedFile = false;
                    foreach (var locked in lockedFiles)
                    {
                        if (fileName.Equals(locked, StringComparison.OrdinalIgnoreCase))
                        {
                            isLockedFile = true;
                            break;
                        }
                    }

                    if (!isLockedFile)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch { } // Skip if can't delete
                    }
                }
            }

            // Also try to delete subdirectories (except backup directories)
            foreach (var dir in Directory.GetDirectories(installPath, "*", SearchOption.TopDirectoryOnly))
            {
                string dirName = new DirectoryInfo(dir).Name;
                // Skip all backup directories (they start with .backup)
                if (!dirName.StartsWith(".backup", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch { } // Skip if can't delete
                }
            }

            // Restore files from backup
            foreach (var file in Directory.GetFiles(backupPath))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(installPath, fileName);

                // Skip updater's own files
                bool isLockedFile = false;
                foreach (var locked in lockedFiles)
                {
                    if (fileName.Equals(locked, StringComparison.OrdinalIgnoreCase))
                    {
                        isLockedFile = true;
                        break;
                    }
                }

                if (!isLockedFile)
                {
                    try
                    {
                        File.Copy(file, destFile, true);
                    }
                    catch { }
                }
            }

            // Restore directories from backup (skip internal .backup folders)
            foreach (var dir in Directory.GetDirectories(backupPath))
            {
                string dirName = new DirectoryInfo(dir).Name;
                string destDir = Path.Combine(installPath, dirName);

                // Skip restoring .backup directories (they shouldn't exist in backup anyway, but be safe)
                if (!dirName.StartsWith(".backup", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        if (Directory.Exists(destDir))
                        {
                            Directory.Delete(destDir, true);
                        }
                        CopyDirectory(dir, destDir);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Restarts the AgOpenGPS application.
        /// Releases the updater mutex before starting to allow AgOpenGPS to shutdown normally.
        /// </summary>
        public (bool Success, string Message) RestartApplication(string installPath, string arguments = null)
        {
            try
            {
                // Release updater mutex before restarting AgOpenGPS
                // This allows AgOpenGPS to shutdown normally if needed
                ReleaseUpdaterMutex();

                string exePath = Path.Combine(installPath, "AgOpenGPS.exe");

                if (!File.Exists(exePath))
                {
                    return (false, "AgOpenGPS.exe not found in installation directory.");
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = arguments ?? string.Empty,
                    UseShellExecute = true,
                    WorkingDirectory = installPath
                };

                Process.Start(startInfo);

                return (true, "AgOpenGPS restarted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to restart AgOpenGPS: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the current application path (where updater.exe is located).
        /// </summary>
        public static string GetCurrentApplicationPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Gets the current version from the executing assembly.
        /// </summary>
        public static string GetCurrentVersion()
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetEntryAssembly();
                if (assembly != null)
                {
                    var version = assembly.GetName().Version;
                    return version?.ToString() ?? "Unknown";
                }
            }
            catch { }

            return "Unknown";
        }

        /// <summary>
        /// Cleans up temporary update files.
        /// </summary>
        public void CleanupTempFiles()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                var tempDirs = Directory.GetDirectories(tempPath, "AgOpenGPS_Update_*");

                foreach (var dir in tempDirs)
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// Releases the updater mutex, allowing AgOpenGPS to shutdown normally.
        /// Call this after update is complete and before restarting AgOpenGPS.
        /// </summary>
        public void ReleaseUpdaterMutex()
        {
            if (_updaterMutex != null)
            {
                try
                {
                    _updaterMutex.ReleaseMutex();
                    _updaterMutex.Dispose();
                    _updaterMutex = null;
                }
                catch { }
            }
        }
    }
}
