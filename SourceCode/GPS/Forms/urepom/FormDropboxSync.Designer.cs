namespace AgOpenGPS // Ou l'espace de noms que vous utilisez
{
    partial class FormDropboxSync
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAppKey = new System.Windows.Forms.Label();
            this.textBoxAppKey = new System.Windows.Forms.TextBox();
            this.labelLocalFolderPath = new System.Windows.Forms.Label();
            this.textBoxLocalFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseLocalFolder = new System.Windows.Forms.Button();
            this.labelDropboxFolderName = new System.Windows.Forms.Label();
            this.textBoxDropboxFolderName = new System.Windows.Forms.TextBox();
            this.buttonSynchronizeDropbox = new System.Windows.Forms.Button();
            this.progressBarSyncDropbox = new System.Windows.Forms.ProgressBar();
            this.labelAccessToken = new System.Windows.Forms.Label();
            this.textBoxAccessToken = new System.Windows.Forms.TextBox();
            this.buttonGetAccessToken = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAppKey
            // 
            this.labelAppKey.AutoSize = true;
            this.labelAppKey.Location = new System.Drawing.Point(24, 29);
            this.labelAppKey.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAppKey.Name = "labelAppKey";
            this.labelAppKey.Size = new System.Drawing.Size(182, 25);
            this.labelAppKey.TabIndex = 0;
            this.labelAppKey.Text = "Clé d\'application :";
            // 
            // textBoxAppKey
            // 
            this.textBoxAppKey.Location = new System.Drawing.Point(276, 23);
            this.textBoxAppKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxAppKey.Name = "textBoxAppKey";
            this.textBoxAppKey.Size = new System.Drawing.Size(664, 31);
            this.textBoxAppKey.TabIndex = 1;
            // 
            // labelLocalFolderPath
            // 
            this.labelLocalFolderPath.AutoSize = true;
            this.labelLocalFolderPath.Location = new System.Drawing.Point(24, 129);
            this.labelLocalFolderPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLocalFolderPath.Name = "labelLocalFolderPath";
            this.labelLocalFolderPath.Size = new System.Drawing.Size(295, 25);
            this.labelLocalFolderPath.TabIndex = 2;
            this.labelLocalFolderPath.Text = "Dossier local à synchroniser :";
            // 
            // textBoxLocalFolderPath
            // 
            this.textBoxLocalFolderPath.Location = new System.Drawing.Point(276, 123);
            this.textBoxLocalFolderPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxLocalFolderPath.Name = "textBoxLocalFolderPath";
            this.textBoxLocalFolderPath.Size = new System.Drawing.Size(502, 31);
            this.textBoxLocalFolderPath.TabIndex = 3;
            // 
            // buttonBrowseLocalFolder
            // 
            this.buttonBrowseLocalFolder.Location = new System.Drawing.Point(794, 119);
            this.buttonBrowseLocalFolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonBrowseLocalFolder.Name = "buttonBrowseLocalFolder";
            this.buttonBrowseLocalFolder.Size = new System.Drawing.Size(150, 44);
            this.buttonBrowseLocalFolder.TabIndex = 4;
            this.buttonBrowseLocalFolder.Text = "Parcourir...";
            this.buttonBrowseLocalFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseLocalFolder.Click += new System.EventHandler(this.buttonBrowseLocalFolder_Click);
            // 
            // labelDropboxFolderName
            // 
            this.labelDropboxFolderName.AutoSize = true;
            this.labelDropboxFolderName.Location = new System.Drawing.Point(24, 179);
            this.labelDropboxFolderName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDropboxFolderName.Name = "labelDropboxFolderName";
            this.labelDropboxFolderName.Size = new System.Drawing.Size(261, 25);
            this.labelDropboxFolderName.TabIndex = 5;
            this.labelDropboxFolderName.Text = "Nom du dossier Dropbox :";
            // 
            // textBoxDropboxFolderName
            // 
            this.textBoxDropboxFolderName.Location = new System.Drawing.Point(276, 173);
            this.textBoxDropboxFolderName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxDropboxFolderName.Name = "textBoxDropboxFolderName";
            this.textBoxDropboxFolderName.Size = new System.Drawing.Size(664, 31);
            this.textBoxDropboxFolderName.TabIndex = 6;
            // 
            // buttonSynchronizeDropbox
            // 
            this.buttonSynchronizeDropbox.Location = new System.Drawing.Point(276, 302);
            this.buttonSynchronizeDropbox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSynchronizeDropbox.Name = "buttonSynchronizeDropbox";
            this.buttonSynchronizeDropbox.Size = new System.Drawing.Size(300, 67);
            this.buttonSynchronizeDropbox.TabIndex = 7;
            this.buttonSynchronizeDropbox.Text = "Lancer la synchronisation Dropbox";
            this.buttonSynchronizeDropbox.UseVisualStyleBackColor = true;
            this.buttonSynchronizeDropbox.Click += new System.EventHandler(this.buttonSynchronizeDropbox_Click);
            // 
            // progressBarSyncDropbox
            // 
            this.progressBarSyncDropbox.Location = new System.Drawing.Point(30, 400);
            this.progressBarSyncDropbox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBarSyncDropbox.Name = "progressBarSyncDropbox";
            this.progressBarSyncDropbox.Size = new System.Drawing.Size(914, 44);
            this.progressBarSyncDropbox.TabIndex = 8;
            // 
            // labelAccessToken
            // 
            this.labelAccessToken.AutoSize = true;
            this.labelAccessToken.Location = new System.Drawing.Point(24, 79);
            this.labelAccessToken.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAccessToken.Name = "labelAccessToken";
            this.labelAccessToken.Size = new System.Drawing.Size(156, 25);
            this.labelAccessToken.TabIndex = 9;
            this.labelAccessToken.Text = "Jeton d\'accès :";
            // 
            // textBoxAccessToken
            // 
            this.textBoxAccessToken.Location = new System.Drawing.Point(276, 73);
            this.textBoxAccessToken.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxAccessToken.Name = "textBoxAccessToken";
            this.textBoxAccessToken.Size = new System.Drawing.Size(502, 31);
            this.textBoxAccessToken.TabIndex = 10;
            // 
            // buttonGetAccessToken
            // 
            this.buttonGetAccessToken.Location = new System.Drawing.Point(794, 69);
            this.buttonGetAccessToken.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonGetAccessToken.Name = "buttonGetAccessToken";
            this.buttonGetAccessToken.Size = new System.Drawing.Size(150, 44);
            this.buttonGetAccessToken.TabIndex = 11;
            this.buttonGetAccessToken.Text = "Obtenir...";
            this.buttonGetAccessToken.UseVisualStyleBackColor = true;
            this.buttonGetAccessToken.Click += new System.EventHandler(this.buttonGetAccessToken_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 53);
            this.button1.TabIndex = 12;
            this.button1.Text = "HELP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDropboxSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGetAccessToken);
            this.Controls.Add(this.textBoxAccessToken);
            this.Controls.Add(this.labelAccessToken);
            this.Controls.Add(this.progressBarSyncDropbox);
            this.Controls.Add(this.buttonSynchronizeDropbox);
            this.Controls.Add(this.textBoxDropboxFolderName);
            this.Controls.Add(this.labelDropboxFolderName);
            this.Controls.Add(this.buttonBrowseLocalFolder);
            this.Controls.Add(this.textBoxLocalFolderPath);
            this.Controls.Add(this.labelLocalFolderPath);
            this.Controls.Add(this.textBoxAppKey);
            this.Controls.Add(this.labelAppKey);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormDropboxSync";
            this.Text = "Configuration Synchronisation Dropbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDropboxSync_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAppKey;
        private System.Windows.Forms.TextBox textBoxAppKey;
        private System.Windows.Forms.Label labelLocalFolderPath;
        private System.Windows.Forms.TextBox textBoxLocalFolderPath;
        private System.Windows.Forms.Button buttonBrowseLocalFolder;
        private System.Windows.Forms.Label labelDropboxFolderName;
        private System.Windows.Forms.TextBox textBoxDropboxFolderName;
        private System.Windows.Forms.Button buttonSynchronizeDropbox;
        private System.Windows.Forms.ProgressBar progressBarSyncDropbox;
        private System.Windows.Forms.Label labelAccessToken;
        private System.Windows.Forms.TextBox textBoxAccessToken;
        private System.Windows.Forms.Button buttonGetAccessToken;
        private System.Windows.Forms.Button button1;
    }
}