namespace AgOpenGPS
{
    partial class FormSynchro
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LocalFolder_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SyncFolder_button = new System.Windows.Forms.Button();
            this.Sync = new System.Windows.Forms.Button();
            this._bgwCopyOperation = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LocalFolder_button);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dossier AgOpenGPS";
            // 
            // LocalFolder_button
            // 
            this.LocalFolder_button.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.LocalFolder_button.Location = new System.Drawing.Point(16, 29);
            this.LocalFolder_button.Name = "LocalFolder_button";
            this.LocalFolder_button.Size = new System.Drawing.Size(210, 94);
            this.LocalFolder_button.TabIndex = 1;
            this.LocalFolder_button.UseVisualStyleBackColor = true;
            this.LocalFolder_button.Click += new System.EventHandler(this.LocalFolder_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SyncFolder_button);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(269, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dossier de sauvegarde";
            // 
            // SyncFolder_button
            // 
            this.SyncFolder_button.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.SyncFolder_button.Location = new System.Drawing.Point(18, 29);
            this.SyncFolder_button.Name = "SyncFolder_button";
            this.SyncFolder_button.Size = new System.Drawing.Size(210, 94);
            this.SyncFolder_button.TabIndex = 2;
            this.SyncFolder_button.UseVisualStyleBackColor = true;
            this.SyncFolder_button.Click += new System.EventHandler(this.SyncFolder_button_Click);
            // 
            // Sync
            // 
            this.Sync.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sync.Location = new System.Drawing.Point(18, 162);
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(496, 51);
            this.Sync.TabIndex = 4;
            this.Sync.Text = "Lancer la synchronisation";
            this.Sync.UseVisualStyleBackColor = true;
            this.Sync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormSynchro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 224);
            this.Controls.Add(this.Sync);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSynchro";
            this.ShowIcon = false;
            this.Text = "Synchronisation";
            this.Shown += new System.EventHandler(this.FormSynchro_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LocalFolder_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SyncFolder_button;
        private System.Windows.Forms.Button Sync;
        private System.ComponentModel.BackgroundWorker _bgwCopyOperation;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}