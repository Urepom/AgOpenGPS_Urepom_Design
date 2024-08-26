namespace AgOpenGPS
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
            this.LblVersion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LblUpdate = new System.Windows.Forms.Label();
            this.SaveConfig = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("MS Reference Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.Location = new System.Drawing.Point(10, 21);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(362, 72);
            this.LblVersion.TabIndex = 2;
            this.LblVersion.Text = "Version 1.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 121);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(764, 63);
            this.button1.TabIndex = 5;
            this.button1.Text = "Une nouvelle version est disponible, cliquer pour l\'installer !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 185);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(764, 33);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // LblUpdate
            // 
            this.LblUpdate.AutoSize = true;
            this.LblUpdate.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUpdate.Location = new System.Drawing.Point(130, 137);
            this.LblUpdate.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.LblUpdate.Name = "LblUpdate";
            this.LblUpdate.Size = new System.Drawing.Size(450, 29);
            this.LblUpdate.TabIndex = 7;
            this.LblUpdate.Text = "Vous disposez de la dernière version";
            // 
            // SaveConfig
            // 
            this.SaveConfig.AutoSize = true;
            this.SaveConfig.Location = new System.Drawing.Point(476, 56);
            this.SaveConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(308, 29);
            this.SaveConfig.TabIndex = 8;
            this.SaveConfig.Text = "Conserver ma configuration";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.CheckedChanged += new System.EventHandler(this.SaveConfig_CheckedChanged);
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 237);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblUpdate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormUpdate";
            this.Text = "FormUpdate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUpdate_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUpdate_FormClosed);
            this.Load += new System.EventHandler(this.FormUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LblUpdate;
        private System.Windows.Forms.CheckBox SaveConfig;
    }
}