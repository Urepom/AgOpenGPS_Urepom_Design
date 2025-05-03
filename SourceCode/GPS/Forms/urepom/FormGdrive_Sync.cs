using AgOpenGPS; // Ajout de l'espace de noms
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks; // Ajout pour Async
using System.Windows.Forms;

namespace AgOpenGPS // Garder le namespace du formulaire si c'est ce que vous souhaitez
{
    public partial class FormGdrive_Sync : Form
    {
        private string credentialsFilePath;
        private string localFolderPath;
        private string driveFolderName;
        private string applicationName;
        private int totalOperations;
        private int operationsCompleted;
        private GoogleDriveSynchronizer synchronizer; // Instance du synchroniseur

        public FormGdrive_Sync(Form callingForm)
        {
            InitializeComponent();
            // Charger les valeurs enregistrées au chargement du formulaire
            textBoxApplicationName.Text = Properties.Settings.Default.UP_ApplicationName;
            textBoxCredentialsPath.Text = Properties.Settings.Default.UP_CredentialsPath;
            textBoxLocalFolderPath.Text = Properties.Settings.Default.UP_LocalFolderPath;
            textBoxDriveFolderName.Text = Properties.Settings.Default.UP_DriveFolderName;

            progressBarSync.Minimum = 0;
            progressBarSync.Value = 0;
        }

        private void buttonBrowseCredentials_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Sélectionner le fichier credentials.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCredentialsPath.Text = openFileDialog.FileName;
                credentialsFilePath = openFileDialog.FileName;
                // Enregistrer immédiatement
                Properties.Settings.Default.UP_CredentialsPath = credentialsFilePath;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonBrowseLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Sélectionner le dossier local à synchroniser";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLocalFolderPath.Text = folderBrowserDialog.SelectedPath;
                localFolderPath = folderBrowserDialog.SelectedPath;
                // Enregistrer immédiatement
                Properties.Settings.Default.UP_LocalFolderPath = localFolderPath;
                Properties.Settings.Default.Save();
            }
        }

        private async void buttonSynchronize_Click(object sender, EventArgs e)
        {
            applicationName = textBoxApplicationName.Text;
            credentialsFilePath = textBoxCredentialsPath.Text;
            localFolderPath = textBoxLocalFolderPath.Text;
            driveFolderName = textBoxDriveFolderName.Text;

            // Enregistrer les valeurs avant la synchronisation
            Properties.Settings.Default.UP_ApplicationName = applicationName;
            Properties.Settings.Default.UP_CredentialsPath = credentialsFilePath;
            Properties.Settings.Default.UP_LocalFolderPath = localFolderPath;
            Properties.Settings.Default.UP_DriveFolderName = driveFolderName;
            Properties.Settings.Default.Save();

            if (string.IsNullOrEmpty(applicationName) || string.IsNullOrEmpty(credentialsFilePath) || string.IsNullOrEmpty(localFolderPath) || string.IsNullOrEmpty(driveFolderName))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(credentialsFilePath))
            {
                MessageBox.Show("Le fichier credentials.json spécifié est introuvable.", "Erreur de fichier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(localFolderPath))
            {
                MessageBox.Show("Le dossier local spécifié est introuvable.", "Erreur de dossier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialisation du synchroniseur
            synchronizer = new AgOpenGPS.GoogleDriveSynchronizer(localFolderPath, driveFolderName, credentialsFilePath, applicationName);
            synchronizer.SynchronizationProgressChanged += Synchronizer_SynchronizationProgressChanged;

            try
            {
                progressBarSync.Style = ProgressBarStyle.Continuous;
                progressBarSync.MarqueeAnimationSpeed = 0;
                buttonSynchronize.Enabled = false;
                progressBarSync.Value = 0;
                operationsCompleted = 0;

                await synchronizer.InitializeAsync();

                var localFiles = synchronizer.GetLocalFiles(localFolderPath);
                var driveFiles = await synchronizer.GetDriveFilesAsync();

                totalOperations = localFiles.Count + driveFiles.Count(df => !localFiles.ContainsKey(df.Key) && df.Value.MimeType != "application/vnd.google-apps.folder");
                progressBarSync.Maximum = totalOperations;

                // Téléversement du local vers Drive (écraser si existe)
                await synchronizer.UploadLocalToDriveAsync(localFiles, driveFiles);

                // Téléchargement de Drive vers le local (si inexistant localement)
                await synchronizer.DownloadNewFromDriveToLocalAsync(localFiles, driveFiles);

                progressBarSync.Value = progressBarSync.Maximum;
                progressBarSync.Style = ProgressBarStyle.Blocks;
                MessageBox.Show("Synchronisation bidirectionnelle terminée (priorité locale pour l'upload, ajout depuis Drive) !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la synchronisation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonSynchronize.Enabled = true;
                progressBarSync.Style = ProgressBarStyle.Blocks;
                progressBarSync.Value = 0;
            }
        }

        private void Synchronizer_SynchronizationProgressChanged(object sender, GoogleDriveSynchronizer.SynchronizationProgressEventArgs e)
        {
            if (progressBarSync.InvokeRequired)
            {
                progressBarSync.Invoke(new Action(() =>
                {
                    if (e.TotalFiles > 0)
                    {
                        progressBarSync.Maximum = totalOperations;
                        progressBarSync.Value = Math.Min(progressBarSync.Maximum, e.FilesProcessed);
                    }
                    else
                    {
                        progressBarSync.Value = e.FilesProcessed;
                    }
                }));
            }
            else
            {
                if (e.TotalFiles > 0)
                {
                    progressBarSync.Maximum = totalOperations;
                    progressBarSync.Value = Math.Min(progressBarSync.Maximum, e.FilesProcessed);
                }
                else
                {
                    progressBarSync.Value = e.FilesProcessed;
                }
            }
        }

        private void FormGdrive_Sync_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Enregistrer les valeurs lors de la fermeture du formulaire
            Properties.Settings.Default.UP_ApplicationName = textBoxApplicationName.Text;
            Properties.Settings.Default.UP_CredentialsPath = textBoxCredentialsPath.Text;
            Properties.Settings.Default.UP_LocalFolderPath = textBoxLocalFolderPath.Text;
            Properties.Settings.Default.UP_DriveFolderName = textBoxDriveFolderName.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // HTML content for the Google Drive configuration instructions page
            string htmlContent = @"
<!DOCTYPE html>
<html lang=""fr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Configuration Google Drive - Instructions</title>
    <style>
        body { font-family: sans-serif; line-height: 1.6; margin: 20px; }
        h1 { color: #333; }
        h2 { color: #555; margin-top: 20px; }
        strong { color: #000; }
        a { color: #007bff; text-decoration: none; }
        a:hover { text-decoration: underline; }
        ul { margin-top: 5px; }
        li { margin-bottom: 5px; }
    </style>
</head>
<body>
    <h1>Configuration de la Synchronisation Google Drive</h1>
    <p>Pour configurer la synchronisation Google Drive, veuillez suivre les étapes suivantes :</p>

    <h2>1. Créer un projet dans la console Google Cloud Platform :</h2>
    <p>
        Accédez à la console Google Cloud Platform : <a href=""https://console.cloud.google.com/"">https://console.cloud.google.com/</a><br>
        Créez un nouveau projet si vous n'en avez pas déjà un.<br>
        Sélectionnez le projet.
    </p>

    <h2>2. Activer l'API Google Drive :</h2>
    <p>
        Dans le menu de navigation, allez dans ""APIs et services"" > ""Bibliothèque"".<br>
        Recherchez ""Google Drive API"" et cliquez dessus.<br>
        Cliquez sur ""Activer"".
    </p>

    <h2>3. Créer des identifiants OAuth 2.0 :</h2>
    <p>
        Dans le menu de navigation, allez dans ""APIs et services"" > ""Identifiants"".<br>
        Cliquez sur ""Créer des identifiants"" > ""ID client OAuth"".<br>
        Sélectionnez le type d'application ""Bureau"".<br>
        Donnez un nom à votre client OAuth (par exemple, ""AgOpenGPS Sync"").<br>
        Cliquez sur ""Créer"".
    </p>

    <h2>4. Télécharger le fichier JSON des identifiants :</h2>
    <p>
        Une fenêtre s'affichera avec votre ID client et votre secret client.<br>
        Cliquez sur le bouton ""Télécharger le fichier JSON"" (ou une icône de téléchargement).<br>
        Enregistrez ce fichier sous le nom <code>credentials.json</code> (ou un nom similaire) dans un emplacement accessible par votre application.
    </p>

    <h2>5. Configurer l'écran de consentement OAuth et publier l'application :</h2>
    <p>
        Dans le menu de navigation de la console Google Cloud Platform, allez dans ""APIs et services"" > ""Écran de consentement OAuth"".<br>
        Configurez l'écran de consentement (nom de l'application, e-mail, etc.).<br>
        Pour éviter le message ""Cette application n'est pas vérifiée par Google"", publiez votre application en cliquant sur ""Publier l'application"" (dans le menu audience).
    </p>

    <h2>6. Sélectionner le fichier credentials.json dans l'application :</h2>
    <p>
        Dans l'application AgOpenGPS, utilisez le bouton ""Parcourir"" à côté du champ ""Chemin du fichier credentials.json"" pour sélectionner le fichier que vous avez téléchargé.
    </p>

    <h2>7. Spécifier le dossier local :</h2>
    <p>
        Utilisez le bouton ""Parcourir"" à côté du champ ""Dossier local à synchroniser"" pour choisir le dossier de votre ordinateur que vous souhaitez synchroniser avec Google Drive.
    </p>

    <h2>8. Spécifier le nom du dossier Google Drive :</h2>
    <p>
        Entrez le nom du dossier que vous souhaitez utiliser (ou créer) sur votre Google Drive pour la synchronisation dans le champ ""Par exemple 'Nom du tracteur'"".
    </p>

    <h2>9. Nom de l'application :</h2>
    <p>
        Assurez-vous que le champ ""Nom de l'application"" contient un nom pour votre application (il est utilisé lors de l'autorisation).
    </p>

    <p>Une fois ces étapes suivies, vous devriez pouvoir utiliser le bouton ""Synchroniser"" pour lancer la synchronisation entre votre dossier local et le dossier Google Drive spécifié.</p>
</body>
</html>";

            try
            {
                // Create a temporary HTML file
                string tempHtmlFilePath = Path.Combine(Path.GetTempPath(), "GoogleDriveConfigInstructions.html");
                File.WriteAllText(tempHtmlFilePath, htmlContent);

                // Open the temporary file in the default web browser
                Process.Start(tempHtmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'ouverture des instructions : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }