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
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbox_auto = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudDoseFerti = new AgOpenGPS.NudlessNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numTimerRincage = new AgOpenGPS.NudlessNumericUpDown();
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
            this.cboxvidange = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new AgOpenGPS.NudlessNumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoseFerti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerRincage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxFertiActive
            // 
            this.cboxFertiActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxFertiActive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxFertiActive.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxFertiActive.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxFertiActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxFertiActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxFertiActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
            this.cboxFertiActive.Location = new System.Drawing.Point(3, 20);
            this.cboxFertiActive.Margin = new System.Windows.Forms.Padding(0);
            this.cboxFertiActive.Name = "cboxFertiActive";
            this.cboxFertiActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxFertiActive.Size = new System.Drawing.Size(61, 50);
            this.cboxFertiActive.TabIndex = 453;
            this.cboxFertiActive.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxFertiActive.UseVisualStyleBackColor = false;
            this.cboxFertiActive.CheckedChanged += new System.EventHandler(this.cboxFertiActive_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbox_auto);
            this.groupBox1.Controls.Add(this.cboxFertiActive);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 74);
            this.groupBox1.TabIndex = 454;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(80, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 473;
            this.label11.Text = "Auto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 472;
            this.label10.Text = "Manuel";
            // 
            // cbox_auto
            // 
            this.cbox_auto.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_auto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbox_auto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cbox_auto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cbox_auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbox_auto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_auto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbox_auto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.cbox_auto.Location = new System.Drawing.Point(68, 20);
            this.cbox_auto.Margin = new System.Windows.Forms.Padding(0);
            this.cbox_auto.Name = "cbox_auto";
            this.cbox_auto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbox_auto.Size = new System.Drawing.Size(63, 50);
            this.cbox_auto.TabIndex = 456;
            this.cbox_auto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbox_auto.UseVisualStyleBackColor = false;
            this.cbox_auto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudDoseFerti);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(136, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 70);
            this.groupBox2.TabIndex = 455;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dose/ha";
            // 
            // nudDoseFerti
            // 
            this.nudDoseFerti.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDoseFerti.DecimalPlaces = 1;
            this.nudDoseFerti.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDoseFerti.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nudDoseFerti.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDoseFerti.InterceptArrowKeys = false;
            this.nudDoseFerti.Location = new System.Drawing.Point(0, 27);
            this.nudDoseFerti.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDoseFerti.Name = "nudDoseFerti";
            this.nudDoseFerti.ReadOnly = true;
            this.nudDoseFerti.Size = new System.Drawing.Size(81, 33);
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
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 30);
            this.label1.TabIndex = 469;
            this.label1.Text = "L";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numTimerRincage
            // 
            this.numTimerRincage.BackColor = System.Drawing.Color.AliceBlue;
            this.numTimerRincage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimerRincage.ForeColor = System.Drawing.Color.Navy;
            this.numTimerRincage.InterceptArrowKeys = false;
            this.numTimerRincage.Location = new System.Drawing.Point(4, 37);
            this.numTimerRincage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimerRincage.Name = "numTimerRincage";
            this.numTimerRincage.ReadOnly = true;
            this.numTimerRincage.Size = new System.Drawing.Size(64, 30);
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
            this.cboxRincage.ForeColor = System.Drawing.Color.Navy;
            this.cboxRincage.Location = new System.Drawing.Point(4, 4);
            this.cboxRincage.Name = "cboxRincage";
            this.cboxRincage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxRincage.Size = new System.Drawing.Size(97, 32);
            this.cboxRincage.TabIndex = 453;
            this.cboxRincage.Text = "Rincage";
            this.cboxRincage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxRincage.UseVisualStyleBackColor = false;
            this.cboxRincage.CheckedChanged += new System.EventHandler(this.cboxRincage_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(66, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 23);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 457;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 458;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 459;
            this.label5.Text = "label";
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 21);
            this.label6.TabIndex = 460;
            this.label6.Text = "Débit/ha :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 21);
            this.label7.TabIndex = 461;
            this.label7.Text = "Puissance (max 255) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 21);
            this.label8.TabIndex = 462;
            this.label8.Text = "Vol  :";
            // 
            // cboxvidange
            // 
            this.cboxvidange.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxvidange.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxvidange.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxvidange.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxvidange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxvidange.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxvidange.ForeColor = System.Drawing.Color.Black;
            this.cboxvidange.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxvidange.Location = new System.Drawing.Point(4, 4);
            this.cboxvidange.Name = "cboxvidange";
            this.cboxvidange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxvidange.Size = new System.Drawing.Size(97, 32);
            this.cboxvidange.TabIndex = 471;
            this.cboxvidange.Text = "Vidange";
            this.cboxvidange.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxvidange.UseVisualStyleBackColor = false;
            this.cboxvidange.CheckedChanged += new System.EventHandler(this.cboxvidange_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboxvidange);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.groupBox4.Location = new System.Drawing.Point(267, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(109, 70);
            this.groupBox4.TabIndex = 470;
            this.groupBox4.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.AliceBlue;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numericUpDown1.InterceptArrowKeys = false;
            this.numericUpDown1.Location = new System.Drawing.Point(4, 36);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(56, 30);
            this.numericUpDown1.TabIndex = 471;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.Click += new System.EventHandler(this.numericUpDown1_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 472;
            this.label9.Text = "L/min";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.51737F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.48263F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 67);
            this.tableLayoutPanel1.TabIndex = 471;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numTimerRincage);
            this.groupBox3.Controls.Add(this.cboxRincage);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F);
            this.groupBox3.Location = new System.Drawing.Point(267, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 76);
            this.groupBox3.TabIndex = 456;
            this.groupBox3.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Image = global::AgOpenGPS.Properties.Resources.ConS_ImplementHitch;
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox1.Location = new System.Drawing.Point(240, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(25, 59);
            this.checkBox1.TabIndex = 472;
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // FormFertilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 148);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormFertilisation";
            this.Text = "Fertilisation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFertilisation_FormClosed);
            this.Load += new System.EventHandler(this.FormFertilisation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDoseFerti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerRincage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cboxFertiActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDoseFerti;
        private System.Windows.Forms.CheckBox cbox_auto;
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
        private System.Windows.Forms.CheckBox cboxvidange;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}