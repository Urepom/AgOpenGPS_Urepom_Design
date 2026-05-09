using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AgOpenGPS.Controls;
using AgOpenGPS.Core.AgShare;
using AgOpenGPS.Core.Translations;
using AgOpenGPS.Properties;

namespace AgOpenGPS
{
    /// <summary>
    /// Form to configure AgShare server URL and API key, with live connection test and clipboard support.
    /// </summary>
    public partial class FormAgShareSettings : Form
    {
        private readonly AgShareClient _agShareClient;
        private Timer clipboardCheckTimer;

        public FormAgShareSettings(AgShareClient agShareClient)
        {
            _agShareClient = agShareClient;
            InitializeComponent();
        }

        // Load current settings and start clipboard monitoring
        private void FormAgShareSettings_Load(object sender, EventArgs e)
        {
            // Translations
            this.Text = gStr.gsAgShareSettings;
            labelApiKey.Text = gStr.gsAgShareApiKey + ":";
            label1.Text = gStr.gsAgShareServer + ":";
            buttonTestConnection.Text = gStr.gsAgShareTestConnection;
            btnPaste.Text = gStr.gsAgSharePaste;
            label2.Text = gStr.gsAgShareRegisterHere;
            buttonCancel.Text = gStr.gsCancel;
            labelStatus.Text = gStr.gsAgShareEnterDetails;
            labelButtonsHint.Text = gStr.gsAgShareButtonsHint;

            textBoxServer.Text = Settings.Default.AgShareServer;
            textBoxApiKey.Text = Settings.Default.AgShareApiKey;

            UpdateAgShareToggleButton();
            UpdateAgShareUploadButton();
            UpdateAgShareAutoLoadButton();

            btnPaste.Enabled = Clipboard.ContainsText();
            clipboardCheckTimer = new Timer();
            clipboardCheckTimer.Interval = 500;
            clipboardCheckTimer.Tick += ClipboardCheckTimer_Tick;
            clipboardCheckTimer.Start();

            // Event handlers to enable Save on text change
            textBoxApiKey.TextChanged += textBoxAnySetting_TextChanged;
            textBoxServer.TextChanged += textBoxAnySetting_TextChanged;

            // Disable TextboxServer for now until it's released
            textBoxServer.Enabled = true;
        }

        // Dispose timer when form closes
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (clipboardCheckTimer != null)
            {
                clipboardCheckTimer.Stop();
                clipboardCheckTimer.Dispose();
                clipboardCheckTimer = null;
            }
            base.OnFormClosed(e);
        }

        // Enable or disable the paste button based on clipboard content
        private void ClipboardCheckTimer_Tick(object sender, EventArgs e)
        {
            bool hasText = Clipboard.ContainsText();
            if (btnPaste.Enabled != hasText)
                btnPaste.Enabled = hasText;
        }

        // Test connection with current input values
        private async void buttonTestConnection_Click(object sender, EventArgs e)
        {
            labelStatus.Text = gStr.gsAgShareConnecting;
            labelStatus.ForeColor = Color.Gray;

            var baseUrl = textBoxServer.Text;
            var apiKey = textBoxApiKey.Text;

            var result = await AgShareClient.CheckApiAsync(baseUrl, apiKey);

            if (result.IsSuccessful)
            {
                labelStatus.Text = "✔ " + gStr.gsAgShareConnectionOk;
                labelStatus.ForeColor = Color.Green;
                buttonSave.Enabled = true;
            }
            else
            {
                string error = ConvertError(result.Error);
                labelStatus.Text = $"❌ {error}";
                labelStatus.ForeColor = Color.Red;
            }
        }

        private string ConvertError(AgShareError error)
        {
            switch (error)
            {
                case InvalidApiKeyError _:
                    return gStr.gsAgShareInvalidApiKey;
                case StatusCodeError statusCodeError:
                    return $"Status {statusCodeError.StatusCode}: {statusCodeError.Body}";
                case HttpRequestError httpRequestError:
                    return $"Error: {httpRequestError.Exception.Message}";
                default:
                    throw new InvalidOperationException($"Unknown {nameof(AgShareError)}: {error.GetType()}");
            }
        }

        // Save current values to settings
        private void buttonSave_Click(object sender, EventArgs e)
        {
            _agShareClient.UpdateSettings(textBoxServer.Text, textBoxApiKey.Text);

            Settings.Default.AgShareServer = textBoxServer.Text;
            Settings.Default.AgShareApiKey = textBoxApiKey.Text;
            Settings.Default.Save();

            labelStatus.Text = "✔ " + gStr.gsAgShareSaved;
            labelStatus.ForeColor = Color.Blue;
        }

        // Mark Save button active when text is edited
        private void textBoxAnySetting_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        // Update toggle button for upload-on/off
        private void UpdateAgShareToggleButton()
        {
            bool enabled = Settings.Default.AgShareEnabled;

            if (enabled)
            {
                btnToggleUpload.Image = Properties.Resources.UploadOn;
                btnToggleUpload.Text = gStr.gsAgShareActivated;
            }
            else
            {
                btnToggleUpload.Image = Properties.Resources.UploadOff;
                btnToggleUpload.Text = gStr.gsAgShareDeactivated;
                buttonSave.Enabled = true;
            }

            btnAutoUpload.Enabled = enabled;
            btnAutoLoad.Enabled = enabled;
        }

        // Toggle upload enabled state
        private void btnToggleUpload_Click(object sender, EventArgs e)
        {
            Settings.Default.AgShareEnabled = !Settings.Default.AgShareEnabled;
            UpdateAgShareToggleButton();
            Settings.Default.Save();
        }

        // Paste API key from clipboard
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textBoxApiKey.Text = Clipboard.GetText();
                Clipboard.Clear();
                btnPaste.Enabled = false;
            }
        }

        // Show onscreen keyboard for textBoxServer if enabled
        private void textBoxServer_Click(object sender, EventArgs e)
        {
            if (Settings.Default.setDisplay_isKeyboardOn)
            {
                FormGPS mf = this.Owner as FormGPS;
                if (mf != null)
                {
                    ((TextBox)sender).ShowKeyboard(this);
                    btnPaste.Focus();
                }
            }
        }

        // Open register link in default browser
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://agshare.agopengps.com/register",
                UseShellExecute = true
            });
        }

        private void btnDevelop_Click(object sender, EventArgs e)
        {
            textBoxServer.Enabled = true;
        }

        private void btnAutoLoad_Click(object sender, EventArgs e)
        {
            Settings.Default.AgShareAutoLoad = !Settings.Default.AgShareAutoLoad;
            UpdateAgShareAutoLoadButton();
            Settings.Default.Save();
            buttonSave.Enabled = true;
        }

        private void UpdateAgShareAutoLoadButton()
        {
            if (Settings.Default.AgShareAutoLoad)
            {
                btnAutoLoad.Image = Properties.Resources.DownloadAndUse;
                btnAutoLoad.Text = gStr.gsAgShareAutoLoad;
            }
            else
            {
                btnAutoLoad.Image = Properties.Resources.DownloadAll;
                btnAutoLoad.Text = gStr.gsAgShareLocalOnly;
            }
        }

        private void btnAutoUpload_Click(object sender, EventArgs e)
        {
            Settings.Default.AgShareUploadActive = !Settings.Default.AgShareUploadActive;
            UpdateAgShareUploadButton();
            buttonSave.Enabled = true;
        }

        private void UpdateAgShareUploadButton()
        {
            if (Settings.Default.AgShareUploadActive)
            {
                btnAutoUpload.Text = gStr.gsAgShareUploadOn;
                btnAutoUpload.Image = Resources.AutoUploadOn;
            }
            else
            {
                btnAutoUpload.Text = gStr.gsAgShareUploadOff;
                btnAutoUpload.Image = Resources.AutoUploadOff;
            }
        }
    }
}
