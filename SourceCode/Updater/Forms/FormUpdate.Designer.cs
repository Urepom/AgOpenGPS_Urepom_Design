namespace AgOpenGPS.Updater.Forms
{
    partial class FormUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGitHubStatus = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnViewReleaseNotes = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.chkIncludePrerelease = new System.Windows.Forms.CheckBox();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.btnToggleSource = new System.Windows.Forms.Button();
            this.lblSourceInfo = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInstallUpdate = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.panelHeader.Controls.Add(this.lblGitHubStatus);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(750, 90);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "AgOpenGPS Updater";
            //
            // lblGitHubStatus
            //
            this.lblGitHubStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGitHubStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGitHubStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(10)))));
            this.lblGitHubStatus.Location = new System.Drawing.Point(630, 35);
            this.lblGitHubStatus.Name = "lblGitHubStatus";
            this.lblGitHubStatus.Size = new System.Drawing.Size(110, 40);
            this.lblGitHubStatus.TabIndex = 1;
            this.lblGitHubStatus.Text = "🔐 Official";
            this.lblGitHubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(230)))));
            this.panelMain.Controls.Add(this.btnViewReleaseNotes);
            this.panelMain.Controls.Add(this.lblProgressPercent);
            this.panelMain.Controls.Add(this.progressBar1);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.btnToggleSource);
            this.panelMain.Controls.Add(this.lblSourceInfo);
            this.panelMain.Controls.Add(this.btnCheckForUpdates);
            this.panelMain.Controls.Add(this.chkIncludePrerelease);
            this.panelMain.Controls.Add(this.lblLatestVersion);
            this.panelMain.Controls.Add(this.lblCurrentVersion);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 90);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(750, 430);
            this.panelMain.TabIndex = 1;
            //
            // lblCurrentVersion
            //
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.lblCurrentVersion.Location = new System.Drawing.Point(30, 30);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(192, 31);
            this.lblCurrentVersion.TabIndex = 0;
            this.lblCurrentVersion.Text = "Current Version: -";
            //
            // lblLatestVersion
            //
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLatestVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.lblLatestVersion.Location = new System.Drawing.Point(30, 70);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(179, 35);
            this.lblLatestVersion.TabIndex = 1;
            this.lblLatestVersion.Text = "Latest Version: -";
            //
            // chkIncludePrerelease
            //
            this.chkIncludePrerelease.AutoSize = true;
            this.chkIncludePrerelease.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIncludePrerelease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.chkIncludePrerelease.Location = new System.Drawing.Point(30, 125);
            this.chkIncludePrerelease.Name = "chkIncludePrerelease";
            this.chkIncludePrerelease.Size = new System.Drawing.Size(220, 28);
            this.chkIncludePrerelease.TabIndex = 2;
            this.chkIncludePrerelease.Text = "Include pre-release";
            this.chkIncludePrerelease.UseVisualStyleBackColor = true;
            //
            // btnToggleSource
            //
            this.btnToggleSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnToggleSource.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnToggleSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleSource.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleSource.ForeColor = System.Drawing.Color.White;
            this.btnToggleSource.Location = new System.Drawing.Point(550, 25);
            this.btnToggleSource.Name = "btnToggleSource";
            this.btnToggleSource.Size = new System.Drawing.Size(170, 40);
            this.btnToggleSource.TabIndex = 3;
            this.btnToggleSource.Text = "Use USB";
            this.btnToggleSource.UseVisualStyleBackColor = false;
            this.btnToggleSource.Click += new System.EventHandler(this.BtnToggleSource_Click);
            //
            // lblSourceInfo
            //
            this.lblSourceInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblSourceInfo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSourceInfo.Location = new System.Drawing.Point(30, 160);
            this.lblSourceInfo.Name = "lblSourceInfo";
            this.lblSourceInfo.Size = new System.Drawing.Size(690, 60);
            this.lblSourceInfo.TabIndex = 4;
            this.lblSourceInfo.Text = "Local: Place AgOpenGPS.zip in root of USB drive";
            this.lblSourceInfo.Visible = false;
            //
            // btnCheckForUpdates
            //
            this.btnCheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.btnCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckForUpdates.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckForUpdates.ForeColor = System.Drawing.Color.White;
            this.btnCheckForUpdates.Location = new System.Drawing.Point(30, 210);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(350, 70);
            this.btnCheckForUpdates.TabIndex = 5;
            this.btnCheckForUpdates.Text = "Check for Updates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = false;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.BtnCheckForUpdates_Click);
            //
            // btnViewReleaseNotes
            //
            this.btnViewReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewReleaseNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnViewReleaseNotes.Enabled = false;
            this.btnViewReleaseNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewReleaseNotes.ForeColor = System.Drawing.Color.White;
            this.btnViewReleaseNotes.Location = new System.Drawing.Point(400, 210);
            this.btnViewReleaseNotes.Name = "btnViewReleaseNotes";
            this.btnViewReleaseNotes.Size = new System.Drawing.Size(320, 70);
            this.btnViewReleaseNotes.TabIndex = 6;
            this.btnViewReleaseNotes.Text = "View Release Notes";
            this.btnViewReleaseNotes.UseVisualStyleBackColor = false;
            this.btnViewReleaseNotes.Click += new System.EventHandler(this.BtnViewReleaseNotes_Click);
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = false;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.lblStatus.Location = new System.Drawing.Point(30, 300);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(690, 60);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // progressBar1
            //
            this.progressBar1.Location = new System.Drawing.Point(30, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(690, 40);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            //
            // lblProgressPercent
            //
            this.lblProgressPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProgressPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.lblProgressPercent.Location = new System.Drawing.Point(30, 420);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(690, 80);
            this.lblProgressPercent.TabIndex = 9;
            this.lblProgressPercent.Text = "0%";
            this.lblProgressPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgressPercent.Visible = false;
            //
            // panelButtons
            //
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnInstallUpdate);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 520);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(30);
            this.panelButtons.Size = new System.Drawing.Size(750, 110);
            this.panelButtons.TabIndex = 2;
            //
            // btnInstallUpdate
            //
            this.btnInstallUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnInstallUpdate.Enabled = false;
            this.btnInstallUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallUpdate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInstallUpdate.ForeColor = System.Drawing.Color.White;
            this.btnInstallUpdate.Location = new System.Drawing.Point(420, 20);
            this.btnInstallUpdate.Name = "btnInstallUpdate";
            this.btnInstallUpdate.Size = new System.Drawing.Size(300, 70);
            this.btnInstallUpdate.TabIndex = 0;
            this.btnInstallUpdate.Text = "Install Update";
            this.btnInstallUpdate.UseVisualStyleBackColor = false;
            this.btnInstallUpdate.Click += new System.EventHandler(this.BtnInstallUpdate_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(30, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(250, 70);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnCancel_Click);
            //
            // FormUpdate
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(750, 630);
            this.ControlBox = false;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgOpenGPS Updater";
            this.Load += new System.EventHandler(this.FormUpdate_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGitHubStatus;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.CheckBox chkIncludePrerelease;
        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Button btnToggleSource;
        private System.Windows.Forms.Label lblSourceInfo;
        private System.Windows.Forms.Button btnInstallUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnViewReleaseNotes;
    }
}
