using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;
using AgOpenGPS.Properties;

namespace AgOpenGPS
{
    public partial class FormUpdate : Form
    {
        /// <param name="settingsFilePath">Usually Documents.Drive.Folder</param>
                //class variables
        private readonly FormGPS mf = null;

        string strWebVersion;
        string updatePath;
        string packageFile;
        string aogVStr, currentVersionStr;
        double clientVersion;
        bool download_ok = false;
        WebClient webClient;

        public FormUpdate(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            CheckForUpdates();
            InitializeComponent();
        }
        private void CheckForUpdates()
        {
            webClient = new WebClient();
            // URL du fichier version.txt
            Uri webVersion = new Uri("https://www.dropbox.com/s/uockdywlfvrqpxi/versionAOG.txt?dl=1");
            webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(webVersion);
        }

        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            strWebVersion = e.Result;


            string[] fullVers = strWebVersion.Split(',');
            double webV = double.Parse(fullVers[0], CultureInfo.InvariantCulture);
            webV += double.Parse(fullVers[1], CultureInfo.InvariantCulture) * 0.1;
            if (clientVersion + 0.0001 < webV)
            {
                SaveConfig.Checked = true;
                button1.Visible = true;
                progressBar1.Visible = true;
            }

        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            download_ok = true;
            Properties.Settings.Default.UP_setUpdate_MAJ = SaveConfig.Checked;
            this.BeginInvoke((MethodInvoker)delegate {
                Process.Start(packageFile);
                Application.Exit();
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {


            updatePath = mf.baseDirectory + "\\update\\" + strWebVersion.Replace(",", ".");
            // URL de la dernière version de l'application
            Uri package = new Uri("https://www.dropbox.com/s/zynr77hvlf69jpb/AOGUpdate.exe?dl=1");

            Directory.CreateDirectory(updatePath);
            packageFile = Path.Combine(updatePath, "update.exe");

            Thread thread = new Thread(() => {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                webClient.DownloadFileAsync(package, packageFile);
            });
            thread.Start();
            button1.Enabled = false;

        }

        private void SaveConfig_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Enabled == false && download_ok == false)
            {
                if (MessageBox.Show("Voulez-vous vraiment intérompre le téléchargement ?", "Confirmer la fermeture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SaveConfig.Checked = false;
                    webClient.CancelAsync();
                    e.Cancel = false;
                }
            }

        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {

            currentVersionStr = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
            LblVersion.Text = currentVersionStr;
            string[] fullVers = currentVersionStr.Split('.');
            double aogV = int.Parse(fullVers[0], CultureInfo.InvariantCulture);
            aogV += int.Parse(fullVers[1], CultureInfo.InvariantCulture) * 0.1;
            aogV += int.Parse(fullVers[2], CultureInfo.InvariantCulture) * 0.01;
            aogVStr = aogV.ToString();
            clientVersion = double.Parse(aogVStr);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
