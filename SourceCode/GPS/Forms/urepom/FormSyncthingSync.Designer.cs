namespace AgOpenGPS // Ou l'espace de noms que vous utilisez
{
    partial class FormSyncthingSync
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
            this.labelApiUrl = new System.Windows.Forms.Label();
            this.textBoxApiUrl = new System.Windows.Forms.TextBox();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.labelFolders = new System.Windows.Forms.Label();
            this.labelDevices = new System.Windows.Forms.Label();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonAddDevice = new System.Windows.Forms.Button();
            this.buttonRestartSyncthing = new System.Windows.Forms.Button();
            this.buttonRefreshStatus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelApiUrl
            // 
            this.labelApiUrl.AutoSize = true;
            this.labelApiUrl.Location = new System.Drawing.Point(9, 33);
            this.labelApiUrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApiUrl.Name = "labelApiUrl";
            this.labelApiUrl.Size = new System.Drawing.Size(55, 13);
            this.labelApiUrl.TabIndex = 0;
            this.labelApiUrl.Text = "API URL :";
            // 
            // textBoxApiUrl
            // 
            this.textBoxApiUrl.Location = new System.Drawing.Point(79, 32);
            this.textBoxApiUrl.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApiUrl.Name = "textBoxApiUrl";
            this.textBoxApiUrl.Size = new System.Drawing.Size(202, 20);
            this.textBoxApiUrl.TabIndex = 1;
            this.textBoxApiUrl.Text = "http://localhost:8384";
            // 
            // labelApiKey
            // 
            this.labelApiKey.AutoSize = true;
            this.labelApiKey.Location = new System.Drawing.Point(9, 54);
            this.labelApiKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(51, 13);
            this.labelApiKey.TabIndex = 2;
            this.labelApiKey.Text = "API Key :";
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(79, 53);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(202, 20);
            this.textBoxApiKey.TabIndex = 3;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(289, 32);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 36);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connecter";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(9, 75);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(103, 13);
            this.labelConnectionStatus.TabIndex = 5;
            this.labelConnectionStatus.Text = "Statut : Déconnecté";
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.Location = new System.Drawing.Point(10, 114);
            this.listBoxFolders.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(227, 186);
            this.listBoxFolders.TabIndex = 6;
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.Location = new System.Drawing.Point(245, 114);
            this.listBoxDevices.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new System.Drawing.Size(227, 186);
            this.listBoxDevices.TabIndex = 7;
            // 
            // labelFolders
            // 
            this.labelFolders.AutoSize = true;
            this.labelFolders.Location = new System.Drawing.Point(9, 97);
            this.labelFolders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFolders.Name = "labelFolders";
            this.labelFolders.Size = new System.Drawing.Size(98, 13);
            this.labelFolders.TabIndex = 8;
            this.labelFolders.Text = "Dossiers Partagés :";
            // 
            // labelDevices
            // 
            this.labelDevices.AutoSize = true;
            this.labelDevices.Location = new System.Drawing.Point(244, 97);
            this.labelDevices.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDevices.Name = "labelDevices";
            this.labelDevices.Size = new System.Drawing.Size(56, 13);
            this.labelDevices.TabIndex = 9;
            this.labelDevices.Text = "Appareils :";
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFolder.Location = new System.Drawing.Point(10, 319);
            this.buttonAddFolder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(100, 21);
            this.buttonAddFolder.TabIndex = 10;
            this.buttonAddFolder.Text = "Ajouter Dossier";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDevice.Location = new System.Drawing.Point(245, 319);
            this.buttonAddDevice.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Size = new System.Drawing.Size(100, 21);
            this.buttonAddDevice.TabIndex = 11;
            this.buttonAddDevice.Text = "Ajouter Appareil";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // buttonRestartSyncthing
            // 
            this.buttonRestartSyncthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRestartSyncthing.Location = new System.Drawing.Point(120, 319);
            this.buttonRestartSyncthing.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRestartSyncthing.Name = "buttonRestartSyncthing";
            this.buttonRestartSyncthing.Size = new System.Drawing.Size(115, 21);
            this.buttonRestartSyncthing.TabIndex = 12;
            this.buttonRestartSyncthing.Text = "Redémarrer Syncthing";
            this.buttonRestartSyncthing.UseVisualStyleBackColor = true;
            this.buttonRestartSyncthing.Click += new System.EventHandler(this.buttonRestartSyncthing_Click);
            // 
            // buttonRefreshStatus
            // 
            this.buttonRefreshStatus.Location = new System.Drawing.Point(374, 32);
            this.buttonRefreshStatus.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefreshStatus.Name = "buttonRefreshStatus";
            this.buttonRefreshStatus.Size = new System.Drawing.Size(95, 36);
            this.buttonRefreshStatus.TabIndex = 13;
            this.buttonRefreshStatus.Text = "Actualiser Statut";
            this.buttonRefreshStatus.UseVisualStyleBackColor = true;
            this.buttonRefreshStatus.Click += new System.EventHandler(this.buttonRefreshStatus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "INSTRUCTIONS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSyncthingInstructions_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 29);
            this.button2.TabIndex = 15;
            this.button2.Text = "Lancer SYNCTHING";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonLaunchSyncthing_Click);
            // 
            // FormSyncthingSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 350);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRefreshStatus);
            this.Controls.Add(this.buttonRestartSyncthing);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.labelDevices);
            this.Controls.Add(this.labelFolders);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.labelApiKey);
            this.Controls.Add(this.textBoxApiUrl);
            this.Controls.Add(this.labelApiUrl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSyncthingSync";
            this.Text = "Configuration Synchronisation Syncthing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSyncthingSync_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelApiUrl;
        private System.Windows.Forms.TextBox textBoxApiUrl;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Label labelFolders;
        private System.Windows.Forms.Label labelDevices;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonAddDevice;
        private System.Windows.Forms.Button buttonRestartSyncthing;
        private System.Windows.Forms.Button buttonRefreshStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
