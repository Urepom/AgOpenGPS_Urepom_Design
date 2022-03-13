namespace AgOpenGPS
{
    partial class FormFertilisation
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
            this.components = new System.ComponentModel.Container();
            this.cboxFertiActive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_auto = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudDoseFerti = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numTimerRincage = new System.Windows.Forms.NumericUpDown();
            this.cboxRincage = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoseFerti)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerRincage)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxFertiActive
            // 
            this.cboxFertiActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxFertiActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxFertiActive.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxFertiActive.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxFertiActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxFertiActive.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxFertiActive.ForeColor = System.Drawing.Color.Black;
            this.cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
            this.cboxFertiActive.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cboxFertiActive.Location = new System.Drawing.Point(6, 29);
            this.cboxFertiActive.Name = "cboxFertiActive";
            this.cboxFertiActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxFertiActive.Size = new System.Drawing.Size(100, 95);
            this.cboxFertiActive.TabIndex = 453;
            this.cboxFertiActive.Text = "Manuel";
            this.cboxFertiActive.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxFertiActive.UseVisualStyleBackColor = false;
            this.cboxFertiActive.CheckedChanged += new System.EventHandler(this.cboxFertiActive_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_auto);
            this.groupBox1.Controls.Add(this.cboxFertiActive);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 133);
            this.groupBox1.TabIndex = 454;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activation";
            // 
            // cbox_auto
            // 
            this.cbox_auto.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_auto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbox_auto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cbox_auto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cbox_auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbox_auto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_auto.ForeColor = System.Drawing.Color.Black;
            this.cbox_auto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOn;
            this.cbox_auto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbox_auto.Location = new System.Drawing.Point(112, 29);
            this.cbox_auto.Name = "cbox_auto";
            this.cbox_auto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbox_auto.Size = new System.Drawing.Size(100, 95);
            this.cbox_auto.TabIndex = 456;
            this.cbox_auto.Text = "Auto";
            this.cbox_auto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbox_auto.UseVisualStyleBackColor = false;
            this.cbox_auto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudDoseFerti);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(227, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 133);
            this.groupBox2.TabIndex = 455;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dose/ha";
            // 
            // nudDoseFerti
            // 
            this.nudDoseFerti.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDoseFerti.DecimalPlaces = 1;
            this.nudDoseFerti.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDoseFerti.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nudDoseFerti.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDoseFerti.InterceptArrowKeys = false;
            this.nudDoseFerti.Location = new System.Drawing.Point(6, 55);
            this.nudDoseFerti.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDoseFerti.Name = "nudDoseFerti";
            this.nudDoseFerti.ReadOnly = true;
            this.nudDoseFerti.Size = new System.Drawing.Size(131, 52);
            this.nudDoseFerti.TabIndex = 468;
            this.nudDoseFerti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDoseFerti.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudDoseFerti.ValueChanged += new System.EventHandler(this.nudDoseFerti_ValueChanged);
            this.nudDoseFerti.Click += new System.EventHandler(this.nudDoseFerti_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 42);
            this.label1.TabIndex = 469;
            this.label1.Text = "L";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numTimerRincage);
            this.groupBox3.Controls.Add(this.cboxRincage);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(404, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 133);
            this.groupBox3.TabIndex = 456;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rinçage";
            // 
            // numTimerRincage
            // 
            this.numTimerRincage.BackColor = System.Drawing.Color.AliceBlue;
            this.numTimerRincage.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimerRincage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numTimerRincage.InterceptArrowKeys = false;
            this.numTimerRincage.Location = new System.Drawing.Point(6, 94);
            this.numTimerRincage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimerRincage.Name = "numTimerRincage";
            this.numTimerRincage.ReadOnly = true;
            this.numTimerRincage.Size = new System.Drawing.Size(64, 33);
            this.numTimerRincage.TabIndex = 470;
            this.numTimerRincage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTimerRincage.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numTimerRincage.ValueChanged += new System.EventHandler(this.numTimerRincage_ValueChanged);
            this.numTimerRincage.Click += new System.EventHandler(this.numTimerRincage_Click);
            // 
            // cboxRincage
            // 
            this.cboxRincage.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRincage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxRincage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxRincage.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxRincage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRincage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRincage.ForeColor = System.Drawing.Color.Black;
            this.cboxRincage.Image = global::AgOpenGPS.Properties.Resources.ConS_ImplementSection;
            this.cboxRincage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cboxRincage.Location = new System.Drawing.Point(6, 29);
            this.cboxRincage.Name = "cboxRincage";
            this.cboxRincage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxRincage.Size = new System.Drawing.Size(100, 59);
            this.cboxRincage.TabIndex = 453;
            this.cboxRincage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxRincage.UseVisualStyleBackColor = false;
            this.cboxRincage.CheckedChanged += new System.EventHandler(this.cboxRincage_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 30);
            this.label2.TabIndex = 470;
            this.label2.Text = "sec";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 457;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 458;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 459;
            this.label5.Text = "label5";
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 460;
            this.label6.Text = "Débit de la pompe/ha :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(190, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 13);
            this.label7.TabIndex = 461;
            this.label7.Text = "Puissance pompe (max 255) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(418, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 462;
            this.label8.Text = "Volume :";
            // 
            // FormFertilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 168);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormFertilisation";
            this.Text = "Fertilisation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFertilisation_FormClosed);
            this.Load += new System.EventHandler(this.FormFertilisation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDoseFerti)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimerRincage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cboxFertiActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDoseFerti;
        private System.Windows.Forms.CheckBox cbox_auto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numTimerRincage;
        private System.Windows.Forms.CheckBox cboxRincage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}