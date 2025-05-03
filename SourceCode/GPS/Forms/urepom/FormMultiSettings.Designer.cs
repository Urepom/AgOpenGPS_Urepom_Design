namespace AgOpenGPS
{
    partial class FormMultiSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSettings = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseTargetFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clbTargetFiles = new System.Windows.Forms.CheckedListBox();
            this.btnCopySettings = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btnSelectSpecificSettings = new System.Windows.Forms.Button();
            this.btnSelectIMUSettings = new System.Windows.Forms.Button();
            this.btnSelectVehicleSettings = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fichier Source :";
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFile.Location = new System.Drawing.Point(117, 12);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.Size = new System.Drawing.Size(443, 20);
            this.txtSourceFile.TabIndex = 1;
            this.txtSourceFile.Leave += new System.EventHandler(this.txtSourceFile_Leave);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSource.Location = new System.Drawing.Point(566, 10);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Parcourir...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paramètres à copier :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvSettings
            // 
            this.dgvSettings.AllowUserToAddRows = false;
            this.dgvSettings.AllowUserToDeleteRows = false;
            this.dgvSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettings.Location = new System.Drawing.Point(184, 64);
            this.dgvSettings.Name = "dgvSettings";
            this.dgvSettings.RowHeadersWidth = 82;
            this.dgvSettings.Size = new System.Drawing.Size(457, 181);
            this.dgvSettings.TabIndex = 4;
            this.dgvSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettings_CellContentClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dossier Cible Vehicules:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetFolder.Location = new System.Drawing.Point(15, 271);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(154, 20);
            this.txtTargetFolder.TabIndex = 6;
            this.txtTargetFolder.TextChanged += new System.EventHandler(this.txtTargetFolder_TextChanged);
            this.txtTargetFolder.Leave += new System.EventHandler(this.txtTargetFolder_Leave);
            // 
            // btnBrowseTargetFolder
            // 
            this.btnBrowseTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTargetFolder.Location = new System.Drawing.Point(15, 297);
            this.btnBrowseTargetFolder.Name = "btnBrowseTargetFolder";
            this.btnBrowseTargetFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTargetFolder.TabIndex = 7;
            this.btnBrowseTargetFolder.Text = "Parcourir...";
            this.btnBrowseTargetFolder.UseVisualStyleBackColor = true;
            this.btnBrowseTargetFolder.Click += new System.EventHandler(this.btnBrowseTargetFolder_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fichiers Cibles :";
            // 
            // clbTargetFiles
            // 
            this.clbTargetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbTargetFiles.FormattingEnabled = true;
            this.clbTargetFiles.Location = new System.Drawing.Point(294, 251);
            this.clbTargetFiles.Name = "clbTargetFiles";
            this.clbTargetFiles.Size = new System.Drawing.Size(258, 154);
            this.clbTargetFiles.TabIndex = 9;
            // 
            // btnCopySettings
            // 
            this.btnCopySettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopySettings.BackColor = System.Drawing.Color.LightGreen;
            this.btnCopySettings.Location = new System.Drawing.Point(558, 251);
            this.btnCopySettings.Name = "btnCopySettings";
            this.btnCopySettings.Size = new System.Drawing.Size(83, 56);
            this.btnCopySettings.TabIndex = 10;
            this.btnCopySettings.Text = "Copier Paramètres";
            this.btnCopySettings.UseVisualStyleBackColor = false;
            this.btnCopySettings.Click += new System.EventHandler(this.btnCopySettings_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbStatus.Location = new System.Drawing.Point(1, 411);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(640, 77);
            this.rtbStatus.TabIndex = 11;
            this.rtbStatus.Text = "";
            // 
            // btnSelectSpecificSettings
            // 
            this.btnSelectSpecificSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectSpecificSettings.Location = new System.Drawing.Point(15, 44);
            this.btnSelectSpecificSettings.Name = "btnSelectSpecificSettings";
            this.btnSelectSpecificSettings.Size = new System.Drawing.Size(163, 34);
            this.btnSelectSpecificSettings.TabIndex = 12;
            this.btnSelectSpecificSettings.Text = "Sélectionner tous les paramètres AutoSteer";
            this.btnSelectSpecificSettings.UseVisualStyleBackColor = true;
            this.btnSelectSpecificSettings.Click += new System.EventHandler(this.btnSelectSpecificSettings_Click);
            // 
            // btnSelectIMUSettings
            // 
            this.btnSelectIMUSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectIMUSettings.Location = new System.Drawing.Point(15, 121);
            this.btnSelectIMUSettings.Name = "btnSelectIMUSettings";
            this.btnSelectIMUSettings.Size = new System.Drawing.Size(163, 34);
            this.btnSelectIMUSettings.TabIndex = 13;
            this.btnSelectIMUSettings.Text = "Sélectionner les paramètres IMU";
            this.btnSelectIMUSettings.UseVisualStyleBackColor = true;
            this.btnSelectIMUSettings.Click += new System.EventHandler(this.btnSelectIMUSettings_Click);
            // 
            // btnSelectVehicleSettings
            // 
            this.btnSelectVehicleSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectVehicleSettings.Location = new System.Drawing.Point(15, 81);
            this.btnSelectVehicleSettings.Name = "btnSelectVehicleSettings";
            this.btnSelectVehicleSettings.Size = new System.Drawing.Size(163, 34);
            this.btnSelectVehicleSettings.TabIndex = 14;
            this.btnSelectVehicleSettings.Text = "Sélectionner les paramètres du vehicule";
            this.btnSelectVehicleSettings.UseVisualStyleBackColor = true;
            this.btnSelectVehicleSettings.Click += new System.EventHandler(this.btnSelectVehicleSettings_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnselectAll.Location = new System.Drawing.Point(15, 161);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(163, 34);
            this.btnUnselectAll.TabIndex = 15;
            this.btnUnselectAll.Text = "Décocher tout";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(434, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(146, 22);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.Text = "Recherche";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.Location = new System.Drawing.Point(586, 39);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(55, 23);
            this.btnClearSearch.TabIndex = 17;
            this.btnClearSearch.Text = "Reset";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Recherche :";
            // 
            // FormMultiSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 489);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectVehicleSettings);
            this.Controls.Add(this.btnSelectIMUSettings);
            this.Controls.Add(this.btnSelectSpecificSettings);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.btnCopySettings);
            this.Controls.Add(this.clbTargetFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBrowseTargetFolder);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtSourceFile);
            this.Controls.Add(this.label1);
            this.Name = "FormMultiSettings";
            this.Text = "XML Settings Copier";
            this.Load += new System.EventHandler(this.FormMultiSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnBrowseTargetFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbTargetFiles;
        private System.Windows.Forms.Button btnCopySettings;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnSelectSpecificSettings; // Déclaration ajoutée
        private System.Windows.Forms.Button btnSelectIMUSettings;
        private System.Windows.Forms.Button btnSelectVehicleSettings;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label label5;
    }
}