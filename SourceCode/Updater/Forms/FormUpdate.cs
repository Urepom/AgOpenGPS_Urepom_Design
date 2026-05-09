using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgOpenGPS.Updater.Models;
using AgOpenGPS.Updater.Services;

namespace AgOpenGPS.Updater.Forms
{
    /// <summary>
    /// Main updater form for checking and installing AgOpenGPS updates.
    /// </summary>
    public partial class FormUpdate : Form
    {
        private readonly UpdateService _updateService;
        private string _currentVersion;
        private _updateSource currentSource;
        private string _installPath;
        private ReleaseInfo _availableUpdate;
        private string _localUpdatePath;
        private string _localUpdateVersion;
        private bool _isBusy;
        private bool _versionFromCommandLine;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isInstalling;

        private enum _updateSource { Web, Local }

        public FormUpdate(string currentVersion = null, string installPath = null)
        {
            InitializeComponent();

            _updateService = new UpdateService();
            _currentVersion = currentVersion ?? UpdateService.GetCurrentVersion();
            _installPath = installPath ?? UpdateService.GetCurrentApplicationPath();
            currentSource = _updateSource.Web;

            // Handle command line arguments
            ParseCommandLineArgs();
        }

        private void ParseCommandLineArgs()
        {
            var args = Environment.GetCommandLineArgs();

            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg.Equals("--current-version", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    _currentVersion = args[++i];
                    _versionFromCommandLine = true;
                }
                else if (arg.Equals("--install-path", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    _installPath = args[++i];
                }
                else if (arg.Equals("--include-prerelease", StringComparison.OrdinalIgnoreCase))
                {
                    chkIncludePrerelease.Checked = true;
                }
                else if (arg.Equals("--auto-check", StringComparison.OrdinalIgnoreCase))
                {
                    // Auto-check for updates on load
                    BeginInvoke(new Action(async () => await CheckForUpdatesAsync()));
                }
            }
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            // Check if updater was started by AgOpenGPS (version passed via command line)
            if (!_versionFromCommandLine)
            {
                // Show error dialog and close
                FormDialog.ShowError(this, "Updater Error",
                    "The updater must be started from AgOpenGPS.\n\n" +
                    "Please start AgOpenGPS first and use:\n" +
                    "Menu → Tools → Check for Updates\n\n" +
                    "This is required to detect your current version.");

                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            // Display current version
            lblCurrentVersion.Text = $"Current Version: {_currentVersion}";

            // Auto-detect local update
            bool foundLocal = CheckForLocalUpdate();

            // If local update found, switch to local and enable install
            if (foundLocal && _localUpdatePath != null)
            {
                currentSource = _updateSource.Local;
                string displayVersion = !string.IsNullOrEmpty(_localUpdateVersion) ? $"v{_localUpdateVersion}" : "Local";
                _availableUpdate = new ReleaseInfo
                {
                    TagName = _localUpdateVersion ?? "Local",
                    Name = $"Local File {displayVersion}",
                    Prerelease = false,
                    PublishedAt = File.GetLastWriteTime(_localUpdatePath),
                    HtmlUrl = null
                };
                UpdateUIState(true);
            }
            else
            {
                UpdateUIState(false);
            }

            UpdateSourceUI();
        }

        private bool CheckForLocalUpdate()
        {
            var (found, filePath, version, location, message) = UsbUpdateService.CheckForLocalUpdate();
            _localUpdatePath = filePath;
            _localUpdateVersion = version;

            lblSourceInfo.Text = message;
            lblSourceInfo.Visible = true;

            return found;
        }

        private void UpdateSourceUI()
        {
            if (currentSource == _updateSource.Web)
            {
                btnToggleSource.Text = "Use USB";
                btnToggleSource.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
                btnToggleSource.Enabled = true;
                btnCheckForUpdates.Enabled = !(_isInstalling && _isBusy);
                btnCheckForUpdates.Visible = true;

                if (_localUpdatePath != null && !string.IsNullOrEmpty(_localUpdateVersion))
                {
                    lblSourceInfo.Text = $"Web update (Local v{_localUpdateVersion} available)";
                }
                else if (_localUpdatePath != null)
                {
                    lblSourceInfo.Text = "Web update (Local update available)";
                }
                else
                {
                    lblSourceInfo.Text = "Web update (GitHub Releases)";
                }
            }
            else
            {
                btnToggleSource.Text = "Use Web";
                btnToggleSource.BackColor = System.Drawing.Color.FromArgb(27, 151, 160);
                btnToggleSource.Enabled = true;
                btnCheckForUpdates.Enabled = false;
                btnCheckForUpdates.Visible = false;

                if (_localUpdatePath != null)
                {
                    string versionText = !string.IsNullOrEmpty(_localUpdateVersion) ? $" v{_localUpdateVersion}" : "";
                    lblSourceInfo.Text = $"Local{versionText}: {Path.GetFileName(_localUpdatePath)}";
                }
                else
                {
                    lblSourceInfo.Text = "Local: No AgOpenGPS_*.zip found on USB";
                }
            }

            // Update button text and state
            if (_availableUpdate != null || _localUpdatePath != null)
            {
                btnInstallUpdate.Enabled = !(_isInstalling && _isBusy);
            }
            else
            {
                btnInstallUpdate.Enabled = false;
            }
        }

        private void BtnToggleSource_Click(object sender, EventArgs e)
        {
            // Toggle between Web and Local source
            if (currentSource == _updateSource.Web)
            {
                currentSource = _updateSource.Local;
            }
            else
            {
                currentSource = _updateSource.Web;
            }

            // Re-check for update from new source
            if (currentSource == _updateSource.Local)
            {
                CheckForLocalUpdate();

                // Create ReleaseInfo for local file if found
                if (_localUpdatePath != null)
                {
                    string displayVersion = !string.IsNullOrEmpty(_localUpdateVersion) ? $"v{_localUpdateVersion}" : "Local";
                    _availableUpdate = new ReleaseInfo
                    {
                        TagName = _localUpdateVersion ?? "Local",
                        Name = $"Local File {displayVersion}",
                        Prerelease = false,
                        PublishedAt = File.GetLastWriteTime(_localUpdatePath),
                        HtmlUrl = null
                    };

                    UpdateUIState(true);
                }
                else
                {
                    UpdateUIState(false);
                }
            }
            else
            {
                lblSourceInfo.Text = "Web update - Click Check for Updates";
                UpdateUIState(_availableUpdate != null);
            }

            UpdateSourceUI();
        }

        private void SetBusy(bool busy)
        {
            _isBusy = busy;

            btnCheckForUpdates.Enabled = !busy && !_isInstalling;
            btnInstallUpdate.Enabled = !busy && _availableUpdate != null && !_isInstalling;
            btnViewReleaseNotes.Enabled = !busy && _availableUpdate != null &&
                !string.IsNullOrEmpty(_availableUpdate.Body) && !_isInstalling;
            chkIncludePrerelease.Enabled = !busy && !_isInstalling;

            // Close button changes to Cancel when installing
            if (_isInstalling)
            {
                btnClose.Text = "Cancel";
                btnClose.BackColor = System.Drawing.Color.FromArgb(200, 60, 60); // Red
                btnClose.Enabled = true;
            }
            else
            {
                btnClose.Text = busy ? "Please wait..." : "Close";
                btnClose.BackColor = System.Drawing.Color.FromArgb(220, 80, 80); // Lighter red
                btnClose.Enabled = !busy;
            }
        }

        private void UpdateUIState(bool hasUpdate)
        {
            btnInstallUpdate.Enabled = hasUpdate && !_isInstalling;

            // Enable View Release Notes button if update has release notes
            btnViewReleaseNotes.Enabled = hasUpdate && _availableUpdate != null &&
                !string.IsNullOrEmpty(_availableUpdate.Body) && !_isInstalling;

            if (hasUpdate && _availableUpdate != null)
            {
                lblLatestVersion.Text = $"Latest Version: {_availableUpdate.Version} (New!)";
                lblLatestVersion.ForeColor = System.Drawing.Color.FromArgb(27, 151, 160);
            }
            else
            {
                lblLatestVersion.Text = "Latest Version: Up to date";
                lblLatestVersion.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            }
        }

        private void SetStatus(string message, bool isProgress = false, int progressPercent = 0)
        {
            // Update from UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(message, isProgress, progressPercent)));
                return;
            }

            lblStatus.Text = message;
            progressBar1.Visible = isProgress;
            lblProgressPercent.Visible = isProgress;

            if (isProgress)
            {
                progressBar1.Value = progressPercent;
                lblProgressPercent.Text = $"{progressPercent}%";
            }
            else
            {
                progressBar1.Value = 0;
                lblProgressPercent.Text = "0%";
            }
        }

        private async void BtnCheckForUpdates_Click(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync();
        }

        private void BtnViewReleaseNotes_Click(object sender, EventArgs e)
        {
            if (_availableUpdate == null)
                return;

            string notes = !string.IsNullOrEmpty(_availableUpdate.Body)
                ? _availableUpdate.Body
                : "No release notes available.";

            FormReleaseNotes.ShowReleaseNotes(this, "AgOpenGPS Update", _availableUpdate.Version, notes);
        }

        private async System.Threading.Tasks.Task CheckForUpdatesAsync()
        {
            if (_isBusy)
                return;

            try
            {
                SetBusy(true);

                if (currentSource == _updateSource.Web)
                {
                    SetStatus("Checking GitHub releases...");
                    bool includePrerelease = chkIncludePrerelease.Checked;
                    var (hasUpdate, releaseInfo, message) = await _updateService.CheckForUpdate(
                        _currentVersion, includePrerelease);

                    _availableUpdate = releaseInfo;

                    if (hasUpdate && releaseInfo != null)
                    {
                        SetStatus($"Update available: {releaseInfo.Version} ({releaseInfo.ReleaseType})");
                        UpdateUIState(true);
                        UpdateSourceUI();
                    }
                    else
                    {
                        SetStatus(message);
                        UpdateUIState(false);
                    }
                }
                else // Local source
                {
                    SetStatus("Checking USB drive...");
                    await Task.Delay(500); // Brief pause for UI update

                    var (found, filePath, version, location, message) = UsbUpdateService.CheckForLocalUpdate();
                    _localUpdatePath = filePath;
                    _localUpdateVersion = version;

                    if (found)
                    {
                        string displayVersion = string.IsNullOrEmpty(version) ? "Local" : $"v{version}";
                        _availableUpdate = new ReleaseInfo
                        {
                            TagName = version ?? "Local",
                            Name = $"Local File {displayVersion}",
                            Prerelease = false,
                            PublishedAt = File.GetLastWriteTime(filePath),
                            HtmlUrl = null
                        };

                        SetStatus($"Local update found: {displayVersion}");
                        UpdateUIState(true);
                        UpdateSourceUI();
                    }
                    else
                    {
                        SetStatus("No update found on USB drive.");
                        UpdateUIState(false);
                        UpdateSourceUI();
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Error: {ex.Message}");
                UpdateUIState(false);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async void BtnInstallUpdate_Click(object sender, EventArgs e)
        {
            if (_availableUpdate == null)
                return;

            // Show confirmation dialog FIRST on UI thread
            string updateSource = currentSource == _updateSource.Web ? "GitHub" : "USB";
            string updateInfo = currentSource == _updateSource.Web
                ? $"{_availableUpdate.Version} ({_availableUpdate.ReleaseType})"
                : UsbUpdateService.GetUpdateLocation(_localUpdatePath);

            var result = FormDialog.ShowConfirm(
                this,
                "Install Update",
                $"Install update from {updateSource}?\n\nSource: {updateInfo}\n\nThis will:\n" +
                "• Close AgOpenGPS and AgIO\n" +
                "• Create a backup of your current installation\n" +
                "• Install the update\n" +
                "• Restart AgOpenGPS\n\n" +
                "Do you want to continue?",
                "Install",
                "Cancel");

            if (result != DialogResult.OK)
                return;

            // Prepare UI on UI thread BEFORE starting background work
            if (_isBusy)
                return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            _isInstalling = true;
            SetBusy(true);
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            // Start installation - runs on background thread, UI updates marshaled via Progress<T>
            await InstallUpdateAsync(_cancellationTokenSource.Token);
        }

        private async System.Threading.Tasks.Task InstallUpdateAsync(CancellationToken token)
        {
            try
            {

                // Step 1: Close applications
                SetStatus("Closing AgOpenGPS and AgIO...", true);
                progressBar1.Value = 10;

                var (closed, closeMsg) = await _updateService.CloseApplicationsAsync();
                if (!closed)
                {
                    // Non-fatal warning, continue
                    SetStatus($"Warning: {closeMsg}");
                }

                // Wait for applications to close
                await System.Threading.Tasks.Task.Delay(2000);
                SetStatus("Applications closed", true, 20);

                // Check for cancellation
                token.ThrowIfCancellationRequested();

                string downloadPath;

                if (currentSource == _updateSource.Web)
                {
                    // Step 2: Download from GitHub
                    string tempDir = Path.Combine(Path.GetTempPath(), "AgOpenGPS_Update");
                    SetStatus("Downloading from GitHub...", true, 30);

                    var progress = new Progress<double>(percent =>
                    {
                        int overallProgress = 30 + (int)(percent * 0.5); // 30-80% range
                        SetStatus($"Downloading... {(int)percent}%", true, overallProgress);
                    });

                    var (downloaded, dlPath, downloadMsg) = await _updateService.DownloadUpdate(
                        _availableUpdate, tempDir, progress);

                    token.ThrowIfCancellationRequested();

                    if (!downloaded)
                    {
                        ShowErrorFromBackground("Download Failed", $"Failed to download update:\n\n{downloadMsg}");
                        _isInstalling = false;
                        SetBusy(false);
                        SetStatus("Download failed");
                        return;
                    }

                    downloadPath = dlPath;

                    // Step 3: Install update with progress
                    SetStatus("Installing...", true, 85);
                }
                else
                {
                    // Local file - copy to temp first (like web update)
                    string tempDir = Path.Combine(Path.GetTempPath(), "AgOpenGPS_Update");
                    Directory.CreateDirectory(tempDir);

                    string tempFileName = Path.GetFileName(_localUpdatePath);
                    downloadPath = Path.Combine(tempDir, tempFileName);

                    // Copy with progress
                    SetStatus("Copying from USB...", true, 30);

                    try
                    {
                        var fileProgress = new Progress<double>(percent =>
                        {
                            int overallProgress = 30 + (int)(percent * 0.5); // 30-80% range
                            SetStatus($"Copying... {(int)percent}%", true, overallProgress);
                        });

                        await CopyFileWithProgressAsync(_localUpdatePath, downloadPath, fileProgress, token);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorFromBackground("Copy Failed", $"Failed to copy from USB:\n\n{ex.Message}");
                        _isInstalling = false;
                        SetBusy(false);
                        SetStatus("Copy failed");
                        return;
                    }

                    SetStatus("Installing...", true, 85);
                }

                // Install update with progress
                var installProgress = new Progress<UpdateService.InstallProgress>(progressInfo =>
                {
                    SetStatus(progressInfo.Phase, true, progressInfo.OverallPercent);
                });

                var (installed, installMsg) = await _updateService.InstallUpdateAsync(
                    downloadPath, _installPath, _currentVersion, installProgress);

                token.ThrowIfCancellationRequested();

                if (!installed)
                {
                    ShowErrorFromBackground("Installation Failed", $"Failed to install update:\n\n{installMsg}");
                    _isInstalling = false;
                    SetBusy(false);
                    SetStatus("Installation failed");
                    return;
                }

                // Clean up temp file (both web and local)
                try
                {
                    if (File.Exists(downloadPath))
                    {
                        File.Delete(downloadPath);
                    }
                }
                catch { }

                // Restart application
                SetStatus("Restarting...", true, 100);
                await System.Threading.Tasks.Task.Delay(1000);

                var (restarted, restartMsg) = _updateService.RestartApplication(_installPath);

                // Show success message briefly
                SetStatus("Complete! Restarting...");
                await System.Threading.Tasks.Task.Delay(2000);

                // Close updater
                this.Close();
            }
            catch (OperationCanceledException)
            {
                // User cancelled the operation
                _isInstalling = false;
                SetBusy(false);
                SetStatus("Cancelled");
                progressBar1.Visible = false;

                ShowInfoFromBackground("Cancelled", "Update was cancelled.");
            }
            catch (Exception ex)
            {
                _isInstalling = false;
                SetBusy(false);
                SetStatus($"Error: {ex.Message}");
                progressBar1.Visible = false;

                ShowErrorFromBackground("Error", $"An error occurred:\n\n{ex.Message}");
            }
        }

        private void ShowErrorFromBackground(string title, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => FormDialog.ShowError(this, title, message)));
            }
            else
            {
                FormDialog.ShowError(this, title, message);
            }
        }

        private void ShowInfoFromBackground(string title, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => FormDialog.ShowInfo(this, title, message)));
            }
            else
            {
                FormDialog.ShowInfo(this, title, message);
            }
        }

        private async System.Threading.Tasks.Task CopyFileWithProgressAsync(
            string sourcePath, string destPath, IProgress<double> progress, CancellationToken token)
        {
            const int bufferSize = 1024 * 1024; // 1MB buffer

            using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.SequentialScan))
            using (var destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, FileOptions.WriteThrough))
            {
                long totalBytes = sourceStream.Length;
                long copiedBytes = 0;
                byte[] buffer = new byte[bufferSize];

                int bytesRead;
                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    await destStream.WriteAsync(buffer, 0, bytesRead, token);
                    copiedBytes += bytesRead;

                    double percent = (double)copiedBytes / totalBytes * 100.0;
                    progress.Report(percent);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_isInstalling)
            {
                // Cancel the ongoing operation
                _cancellationTokenSource?.Cancel();
                SetStatus("Cancelling...");
            }
            else if (_isBusy)
            {
                // Busy but not installing - can't cancel
                FormDialog.ShowInfo(this, "Please Wait", "Please wait for the current operation to complete.");
            }
            else
            {
                // Just close the form
                this.Close();
            }
        }
    }
}
