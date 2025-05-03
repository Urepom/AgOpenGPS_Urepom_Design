using AgOpenGPS; // Assurez-vous que cet espace de noms correspond à votre projet
using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS // Ou l'espace de noms que vous utilisez
{
    public partial class FormDropboxSync : Form
    {
        private string accessToken;
        private string localFolderPath;
        private string dropboxFolderPath;
        private DropboxSynchronizer synchronizer;

        public FormDropboxSync(Form callingForm)
        {
            InitializeComponent();
            // Charger les valeurs enregistrées au chargement du formulaire*
            textBoxAppKey.Text = Properties.Settings.Default.UP_Dropbox_AppKey;
            textBoxAccessToken.Text = Properties.Settings.Default.UP_Dropbox_AccessToken;
            textBoxLocalFolderPath.Text = Properties.Settings.Default.UP_Dropbox_LocalFolderPath;
            textBoxDropboxFolderName.Text = Properties.Settings.Default.UP_DropboxFolderName;

            progressBarSyncDropbox.Minimum = 0;
            progressBarSyncDropbox.Value = 0;
        }

        private void buttonBrowseLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Sélectionner le dossier local à synchroniser avec Dropbox";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLocalFolderPath.Text = folderBrowserDialog.SelectedPath;
                localFolderPath = folderBrowserDialog.SelectedPath;
                // Enregistrer immédiatement
                Properties.Settings.Default.UP_Dropbox_LocalFolderPath = localFolderPath;
                Properties.Settings.Default.Save();
            }
        }

        private async void buttonSynchronizeDropbox_Click(object sender, EventArgs e)
        {
            accessToken = textBoxAccessToken.Text;
            localFolderPath = textBoxLocalFolderPath.Text;
            dropboxFolderPath = textBoxDropboxFolderName.Text;

            // Enregistrer les valeurs avant la synchronisation
            Properties.Settings.Default.UP_Dropbox_AppKey = textBoxAppKey.Text;
            Properties.Settings.Default.UP_Dropbox_AccessToken = accessToken;
            Properties.Settings.Default.UP_Dropbox_LocalFolderPath = localFolderPath;
            Properties.Settings.Default.UP_DropboxFolderName = dropboxFolderPath;
            Properties.Settings.Default.Save();

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(localFolderPath) || string.IsNullOrEmpty(dropboxFolderPath))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de configuration Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(localFolderPath))
            {
                MessageBox.Show("Le dossier local spécifié est introuvable.", "Erreur de dossier local", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            synchronizer = new DropboxSynchronizer(localFolderPath, $"/{dropboxFolderPath.Trim('/')}", accessToken);
            synchronizer.SynchronizationProgressChanged += Synchronizer_SynchronizationProgressChanged;
            EnableUI(false);

            try
            {
                var localFiles = synchronizer.GetLocalFiles(localFolderPath);
                var dropboxFiles = await synchronizer.GetDropboxFilesAsync($"/{dropboxFolderPath.Trim('/')}");

                await synchronizer.UploadLocalToDropboxAsync(localFiles, dropboxFiles);
                await synchronizer.DownloadNewFromDropboxToLocalAsync(localFiles, dropboxFiles);

                MessageBox.Show("Synchronisation Dropbox terminée !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la synchronisation Dropbox : {ex.Message}", "Erreur Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableUI(true);
                synchronizer.SynchronizationProgressChanged -= Synchronizer_SynchronizationProgressChanged;
                progressBarSyncDropbox.Value = 0;
            }
        }

        private void Synchronizer_SynchronizationProgressChanged(object sender, DropboxSynchronizer.SynchronizationProgressEventArgs e)
        {
            if (progressBarSyncDropbox.InvokeRequired)
            {
                progressBarSyncDropbox.Invoke(new Action(() =>
                {
                    progressBarSyncDropbox.Maximum = e.TotalFiles;
                    progressBarSyncDropbox.Value = e.FilesProcessed;
                }));
            }
            else
            {
                progressBarSyncDropbox.Maximum = e.TotalFiles;
                progressBarSyncDropbox.Value = e.FilesProcessed;
            }
        }

        private void FormDropboxSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Enregistrer les valeurs lors de la fermeture du formulaire*
            Properties.Settings.Default.UP_Dropbox_AppKey = textBoxAppKey.Text;
            Properties.Settings.Default.UP_Dropbox_AccessToken = textBoxAccessToken.Text;
            Properties.Settings.Default.UP_Dropbox_LocalFolderPath = textBoxLocalFolderPath.Text;
            Properties.Settings.Default.UP_DropboxFolderName = textBoxDropboxFolderName.Text;
            Properties.Settings.Default.Save();
        }

        private void buttonGetAccessToken_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Veuillez obtenir un jeton d'accès manuel depuis la console des développeurs Dropbox.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("https://www.dropbox.com/developers/apps");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // HTML content for the instructions page
            string htmlContent = @"
<!DOCTYPE html>
<html lang=""fr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Configuration Dropbox - Instructions</title>
    <style>
        body { font-family: sans-serif; line-height: 1.6; margin: 20px; }
        h1 { color: #333; }
        strong { color: #555; }
        a { color: #007bff; text-decoration: none; }
        a:hover { text-decoration: underline; }
    </style>
</head>
<body>
    <h1>Configuration de la Synchronisation Dropbox</h1>
    <p>Pour utiliser la synchronisation Dropbox, vous devez d'abord configurer une application sur le site des développeurs Dropbox :</p>

    <h2>1. Créez une Application Dropbox :</h2>
    <p>
        Rendez-vous sur <a href=""https://www.dropbox.com/developers/apps"">https://www.dropbox.com/developers/apps</a> et connectez-vous avec votre compte Dropbox.<br>
        Cliquez sur 'Créer une application'. Choisissez 'Scoped access' et définissez les permissions nécessaires :
    </p>
    <ul>
        <li><strong>files.content.read :</strong> Permet de lire le contenu des fichiers.</li>
        <li><strong>files.content.write :</strong> Permet d'écrire et de supprimer des fichiers.</li>
        <li><strong>files.metadata.read :</strong> Permet de lire les métadonnées des fichiers et des dossiers.</li>
    </ul>
    <p>Donnez un nom à votre application.</p>

    <h2>2. Obtenez le Jeton d'Accès :</h2>
    <p>
        Sur la page de votre application, sous l'onglet 'Jeton d'accès généré', cliquez sur 'Générer' pour créer un jeton d'accès. Copiez ce jeton et collez-le dans le champ 'Jeton d'accès' de l'application.
    </p>

    <h2>3. Entrez les Informations dans l'Application :</h2>
    <p>Assurez-vous que le champ 'Jeton d'accès' est correctement rempli.</p>

    <h2>4. Sélectionnez vos Dossiers :</h2>
    <p>
        Cliquez sur 'Parcourir...' pour choisir le dossier sur votre ordinateur ('Dossier local à synchroniser').<br>
        Entrez le nom du dossier que vous souhaitez utiliser ou créer dans votre Dropbox ('Nom du dossier Dropbox').
    </p>

    <h2>5. Lancez la Synchronisation :</h2>
    <p>Une fois tous les champs configurés, cliquez sur 'Lancer la synchronisation Dropbox'.</p>
</body>
</html>";

            try
            {
                // Create a temporary HTML file
                string tempHtmlFilePath = Path.Combine(Path.GetTempPath(), "DropboxConfigInstructions.html");
                File.WriteAllText(tempHtmlFilePath, htmlContent);

                // Open the temporary file in the default web browser
                Process.Start(tempHtmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'ouverture des instructions : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableUI(bool enable)
        {
            buttonBrowseLocalFolder.Enabled = enable;
            textBoxLocalFolderPath.Enabled = enable;
            textBoxAccessToken.Enabled = enable;
            textBoxDropboxFolderName.Enabled = enable;
            buttonSynchronizeDropbox.Enabled = enable;
            buttonGetAccessToken.Enabled = enable;
        }
    }
}