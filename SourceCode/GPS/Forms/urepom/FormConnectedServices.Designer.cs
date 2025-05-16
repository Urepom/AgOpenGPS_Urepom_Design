namespace AgOpenGPS
{
    partial class FormConnectedServices
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Traccar_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dropbox_button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Gdrive_button = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Synchthing_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Traccar_button);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRACCAR";
            // 
            // Traccar_button
            // 
            this.Traccar_button.Image = global::AgOpenGPS.Properties.Resources.traccar_logo;
            this.Traccar_button.Location = new System.Drawing.Point(15, 39);
            this.Traccar_button.Name = "Traccar_button";
            this.Traccar_button.Size = new System.Drawing.Size(162, 94);
            this.Traccar_button.TabIndex = 1;
            this.Traccar_button.UseVisualStyleBackColor = true;
            this.Traccar_button.Click += new System.EventHandler(this.Traccar_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dropbox_button);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(220, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DROPBOX";
            // 
            // Dropbox_button
            // 
            this.Dropbox_button.Image = global::AgOpenGPS.Properties.Resources.dropbox_logo1;
            this.Dropbox_button.Location = new System.Drawing.Point(15, 39);
            this.Dropbox_button.Name = "Dropbox_button";
            this.Dropbox_button.Size = new System.Drawing.Size(162, 94);
            this.Dropbox_button.TabIndex = 1;
            this.Dropbox_button.UseVisualStyleBackColor = true;
            this.Dropbox_button.Click += new System.EventHandler(this.Dropbox_button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(12, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 160);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dossier synchronisé";
            // 
            // button1
            // 
            this.button1.Image = global::AgOpenGPS.Properties.Resources.FileExplorerWindows;
            this.button1.Location = new System.Drawing.Point(15, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 94);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Gdrive_button);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(426, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 160);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "G DRIVE";
            // 
            // Gdrive_button
            // 
            this.Gdrive_button.Image = global::AgOpenGPS.Properties.Resources.gdrive_logo;
            this.Gdrive_button.Location = new System.Drawing.Point(15, 39);
            this.Gdrive_button.Name = "Gdrive_button";
            this.Gdrive_button.Size = new System.Drawing.Size(162, 94);
            this.Gdrive_button.TabIndex = 1;
            this.Gdrive_button.UseVisualStyleBackColor = true;
            this.Gdrive_button.Click += new System.EventHandler(this.Gdrive_button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Synchthing_button);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(334, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(220, 160);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SYNCTHING";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // Synchthing_button
            // 
            this.Synchthing_button.Image = global::AgOpenGPS.Properties.Resources.syncthing_logo;
            this.Synchthing_button.Location = new System.Drawing.Point(15, 39);
            this.Synchthing_button.Name = "Synchthing_button";
            this.Synchthing_button.Size = new System.Drawing.Size(162, 94);
            this.Synchthing_button.TabIndex = 1;
            this.Synchthing_button.UseVisualStyleBackColor = true;
            this.Synchthing_button.Click += new System.EventHandler(this.Synchthing_button_Click);
            // 
            // FormConnectedServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(627, 345);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(638, 369);
            this.Name = "FormConnectedServices";
            this.Text = "Services connectés";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Traccar_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Dropbox_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Gdrive_button;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button Synchthing_button;
    }
}