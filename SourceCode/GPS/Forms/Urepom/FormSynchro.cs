using AgOpenGPS.Properties;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgOpenGPS
{

    public partial class FormSynchro : Form
    {
        //private readonly FormGPS mf = null;
        int Count = 0, Count2 = 0;
        int no = 0;
        string sourceDirName, destDirName;
        public FormSynchro(Form callingForm)
        {
            //mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormSynchro_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void LocalFolder_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fsync = new FolderBrowserDialog();
            fsync.ShowNewFolderButton = true;
            fsync.Description = "Currently: " + Settings.Default.UP_setF_local;
            fsync.SelectedPath = Settings.Default.UP_setF_local;

            if (fsync.ShowDialog() == DialogResult.OK)
            {

                Settings.Default.UP_setF_local = fsync.SelectedPath;
                Settings.Default.Save();

                //restart program
                // MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                // Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FormGPS.DirectoryCopy(Settings.Default.UP_setF_local, Settings.Default.UP_setF_synchro, true);
            FormGPS.DirectoryCopy(Settings.Default.UP_setF_synchro, Settings.Default.UP_setF_local, true);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MessageBox.Show("Synchronisation terminée !", "Synchronisation");
        }

        private void SyncFolder_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fsync = new FolderBrowserDialog();
            fsync.ShowNewFolderButton = true;
            fsync.Description = "Currently: " + Settings.Default.UP_setF_synchro;
            fsync.SelectedPath = Settings.Default.UP_setF_synchro;

            if (fsync.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.UP_setF_synchro = fsync.SelectedPath;
                Settings.Default.Save();

                //restart program
                // MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                // Close();
            }
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

    }



}

