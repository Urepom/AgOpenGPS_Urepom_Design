namespace AgOpenGPS
{
    partial class FormTraccar
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
            this.adresse_textbox = new System.Windows.Forms.TextBox();
            this.port_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ID_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.traccar_checkBox = new System.Windows.Forms.CheckBox();
            this.frequence_numeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frequence_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adresse du serveur";
            // 
            // adresse_textbox
            // 
            this.adresse_textbox.Location = new System.Drawing.Point(17, 32);
            this.adresse_textbox.Name = "adresse_textbox";
            this.adresse_textbox.Size = new System.Drawing.Size(200, 20);
            this.adresse_textbox.TabIndex = 1;
            this.adresse_textbox.Text = "demo.traccar.org";
            // 
            // port_textbox
            // 
            this.port_textbox.Location = new System.Drawing.Point(17, 78);
            this.port_textbox.Name = "port_textbox";
            this.port_textbox.Size = new System.Drawing.Size(200, 20);
            this.port_textbox.TabIndex = 3;
            this.port_textbox.Text = "5055";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port (OSMAND : 5055)";
            // 
            // ID_textbox
            // 
            this.ID_textbox.Location = new System.Drawing.Point(17, 124);
            this.ID_textbox.Name = "ID_textbox";
            this.ID_textbox.Size = new System.Drawing.Size(200, 20);
            this.ID_textbox.TabIndex = 5;
            this.ID_textbox.Text = "arion410";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID de l\'appareil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fréquence d\'actualisation de position";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // traccar_checkBox
            // 
            this.traccar_checkBox.AutoSize = true;
            this.traccar_checkBox.Location = new System.Drawing.Point(17, 211);
            this.traccar_checkBox.Name = "traccar_checkBox";
            this.traccar_checkBox.Size = new System.Drawing.Size(130, 17);
            this.traccar_checkBox.TabIndex = 11;
            this.traccar_checkBox.Text = "Activation du trackeur";
            this.traccar_checkBox.UseVisualStyleBackColor = true;
            // 
            // frequence_numeric
            // 
            this.frequence_numeric.Location = new System.Drawing.Point(17, 170);
            this.frequence_numeric.Name = "frequence_numeric";
            this.frequence_numeric.Size = new System.Drawing.Size(120, 20);
            this.frequence_numeric.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "sec";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "HELP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTraccar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.frequence_numeric);
            this.Controls.Add(this.traccar_checkBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ID_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.port_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adresse_textbox);
            this.Controls.Add(this.label1);
            this.Name = "FormTraccar";
            this.Text = "FormTraccar";
            this.Load += new System.EventHandler(this.FormTraccar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frequence_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox adresse_textbox;
        private System.Windows.Forms.TextBox port_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ID_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox traccar_checkBox;
        private System.Windows.Forms.NumericUpDown frequence_numeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}