namespace AgOpenGPS // Si vous avez choisi de mettre le formulaire dans le namespace AgOpenGPS
{
    partial class FormGdrive_Sync
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
            this.labelApplicationName = new System.Windows.Forms.Label();
            this.textBoxApplicationName = new System.Windows.Forms.TextBox();
            this.labelCredentialsPath = new System.Windows.Forms.Label();
            this.textBoxCredentialsPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseCredentials = new System.Windows.Forms.Button();
            this.labelLocalFolderPath = new System.Windows.Forms.Label();
            this.textBoxLocalFolderPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseLocalFolder = new System.Windows.Forms.Button();
            this.labelDriveFolderName = new System.Windows.Forms.Label();
            this.textBoxDriveFolderName = new System.Windows.Forms.TextBox();
            this.buttonSynchronize = new System.Windows.Forms.Button();
            this.progressBarSync = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelApplicationName
            // 
            this.labelApplicationName.AutoSize = true;
            this.labelApplicationName.Location = new System.Drawing.Point(24, 29);
            this.labelApplicationName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelApplicationName.Name = "labelApplicationName";
            this.labelApplicationName.Size = new System.Drawing.Size(292, 25);
            this.labelApplicationName.TabIndex = 0;
            this.labelApplicationName.Text = "Nom de l\'application Google :";
            // 
            // textBoxApplicationName
            // 
            this.textBoxApplicationName.Location = new System.Drawing.Point(354, 23);
            this.textBoxApplicationName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxApplicationName.Name = "textBoxApplicationName";
            this.textBoxApplicationName.Size = new System.Drawing.Size(586, 31);
            this.textBoxApplicationName.TabIndex = 1;
            this.textBoxApplicationName.Text = "AgOpenGPS";
            // 
            // labelCredentialsPath
            // 
            this.labelCredentialsPath.AutoSize = true;
            this.labelCredentialsPath.Location = new System.Drawing.Point(24, 79);
            this.labelCredentialsPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCredentialsPath.Name = "labelCredentialsPath";
            this.labelCredentialsPath.Size = new System.Drawing.Size(348, 25);
            this.labelCredentialsPath.TabIndex = 2;
            this.labelCredentialsPath.Text = "Chemin du fichier credentials.json :";
            // 
            // textBoxCredentialsPath
            // 
            this.textBoxCredentialsPath.Location = new System.Drawing.Point(354, 73);
            this.textBoxCredentialsPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxCredentialsPath.Name = "textBoxCredentialsPath";
            this.textBoxCredentialsPath.Size = new System.Drawing.Size(424, 31);
            this.textBoxCredentialsPath.TabIndex = 3;
            // 
            // buttonBrowseCredentials
            // 
            this.buttonBrowseCredentials.Location = new System.Drawing.Point(794, 69);
            this.buttonBrowseCredentials.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonBrowseCredentials.Name = "buttonBrowseCredentials";
            this.buttonBrowseCredentials.Size = new System.Drawing.Size(150, 44);
            this.buttonBrowseCredentials.TabIndex = 4;
            this.buttonBrowseCredentials.Text = "Parcourir...";
            this.buttonBrowseCredentials.UseVisualStyleBackColor = true;
            this.buttonBrowseCredentials.Click += new System.EventHandler(this.buttonBrowseCredentials_Click);
            // 
            // labelLocalFolderPath
            // 
            this.labelLocalFolderPath.AutoSize = true;
            this.labelLocalFolderPath.Location = new System.Drawing.Point(24, 129);
            this.labelLocalFolderPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLocalFolderPath.Name = "labelLocalFolderPath";
            this.labelLocalFolderPath.Size = new System.Drawing.Size(295, 25);
            this.labelLocalFolderPath.TabIndex = 5;
            this.labelLocalFolderPath.Text = "Dossier local à synchroniser :";
            // 
            // textBoxLocalFolderPath
            // 
            this.textBoxLocalFolderPath.Location = new System.Drawing.Point(354, 123);
            this.textBoxLocalFolderPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxLocalFolderPath.Name = "textBoxLocalFolderPath";
            this.textBoxLocalFolderPath.Size = new System.Drawing.Size(424, 31);
            this.textBoxLocalFolderPath.TabIndex = 6;
            // 
            // buttonBrowseLocalFolder
            // 
            this.buttonBrowseLocalFolder.Location = new System.Drawing.Point(794, 119);
            this.buttonBrowseLocalFolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonBrowseLocalFolder.Name = "buttonBrowseLocalFolder";
            this.buttonBrowseLocalFolder.Size = new System.Drawing.Size(150, 44);
            this.buttonBrowseLocalFolder.TabIndex = 7;
            this.buttonBrowseLocalFolder.Text = "Parcourir...";
            this.buttonBrowseLocalFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseLocalFolder.Click += new System.EventHandler(this.buttonBrowseLocalFolder_Click);
            // 
            // labelDriveFolderName
            // 
            this.labelDriveFolderName.AutoSize = true;
            this.labelDriveFolderName.Location = new System.Drawing.Point(24, 179);
            this.labelDriveFolderName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDriveFolderName.Name = "labelDriveFolderName";
            this.labelDriveFolderName.Size = new System.Drawing.Size(305, 25);
            this.labelDriveFolderName.TabIndex = 8;
            this.labelDriveFolderName.Text = "Nom du dossier Google Drive :";
            // 
            // textBoxDriveFolderName
            // 
            this.textBoxDriveFolderName.Location = new System.Drawing.Point(354, 173);
            this.textBoxDriveFolderName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxDriveFolderName.Name = "textBoxDriveFolderName";
            this.textBoxDriveFolderName.Size = new System.Drawing.Size(586, 31);
            this.textBoxDriveFolderName.TabIndex = 9;
            // 
            // buttonSynchronize
            // 
            this.buttonSynchronize.Location = new System.Drawing.Point(354, 240);
            this.buttonSynchronize.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSynchronize.Name = "buttonSynchronize";
            this.buttonSynchronize.Size = new System.Drawing.Size(300, 67);
            this.buttonSynchronize.TabIndex = 10;
            this.buttonSynchronize.Text = "Lancer la synchronisation";
            this.buttonSynchronize.UseVisualStyleBackColor = true;
            this.buttonSynchronize.Click += new System.EventHandler(this.buttonSynchronize_Click);
            // 
            // progressBarSync
            // 
            this.progressBarSync.Location = new System.Drawing.Point(30, 337);
            this.progressBarSync.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBarSync.Name = "progressBarSync";
            this.progressBarSync.Size = new System.Drawing.Size(914, 44);
            this.progressBarSync.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 53);
            this.button1.TabIndex = 13;
            this.button1.Text = "HELP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormGdrive_Sync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 404);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBarSync);
            this.Controls.Add(this.buttonSynchronize);
            this.Controls.Add(this.textBoxDriveFolderName);
            this.Controls.Add(this.labelDriveFolderName);
            this.Controls.Add(this.buttonBrowseLocalFolder);
            this.Controls.Add(this.textBoxLocalFolderPath);
            this.Controls.Add(this.labelLocalFolderPath);
            this.Controls.Add(this.buttonBrowseCredentials);
            this.Controls.Add(this.textBoxCredentialsPath);
            this.Controls.Add(this.labelCredentialsPath);
            this.Controls.Add(this.textBoxApplicationName);
            this.Controls.Add(this.labelApplicationName);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormGdrive_Sync";
            this.Text = "Configuration Synchronisation Google Drive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGdrive_Sync_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelApplicationName;
        private System.Windows.Forms.TextBox textBoxApplicationName;
        private System.Windows.Forms.Label labelCredentialsPath;
        private System.Windows.Forms.TextBox textBoxCredentialsPath;
        private System.Windows.Forms.Button buttonBrowseCredentials;
        private System.Windows.Forms.Label labelLocalFolderPath;
        private System.Windows.Forms.TextBox textBoxLocalFolderPath;
        private System.Windows.Forms.Button buttonBrowseLocalFolder;
        private System.Windows.Forms.Label labelDriveFolderName;
        private System.Windows.Forms.TextBox textBoxDriveFolderName;
        private System.Windows.Forms.Button buttonSynchronize;
        private System.Windows.Forms.ProgressBar progressBarSync;
        private System.Windows.Forms.Button button1;
    }
}