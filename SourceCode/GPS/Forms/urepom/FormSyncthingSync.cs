using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Nécessaire pour Directory.Exists et File.Exists
using System.Net.Http; // Nécessaire pour HttpRequestException
using Microsoft.VisualBasic; // Nécessaire pour Interaction.InputBox (assurez-vous d'avoir ajouté la référence)
using System.Diagnostics; // Nécessaire pour Process.Start et Process.GetProcessesByName

namespace AgOpenGPS // Assurez-vous que l'espace de noms correspond
{
    public partial class FormSyncthingSync : Form
    {
        private SyncthingApiClient _syncthingClient;

        // Supposons que vous ayez ajouté ces contrôles dans le Designer.cs
        // public TextBox textBoxApiUrl;
        // public TextBox textBoxApiKey;
        // public Button buttonConnect;
        // public Label labelConnectionStatus;
        // public ListBox listBoxFolders; // Pour afficher les dossiers partagés
        // public ListBox listBoxDevices; // Pour afficher les appareils
        // public Button buttonAddFolder;
        // public Button buttonAddDevice;
        // public Button buttonRestartSyncthing;
        // public Button buttonRefreshStatus;
        // public Button buttonSyncthingInstructions; // <-- Nouveau bouton
        // public Button buttonLaunchSyncthing; // <-- Nouveau bouton de lancement


        public FormSyncthingSync(Form callingform)
        {
            InitializeComponent();

            // Charger les paramètres Syncthing depuis les Settings
            // Assurez-vous d'avoir ajouté UP_Syncthing_ApiUrl et UP_Syncthing_ApiKey dans Properties.Settings.settings
            textBoxApiUrl.Text = Properties.Settings.Default.UP_Syncthing_ApiUrl;
            textBoxApiKey.Text = Properties.Settings.Default.UP_Syncthing_ApiKey;

            // Mettre à jour l'UI au démarrage
            UpdateConnectionStatusUI(false);

            // Gérer la fermeture du formulaire pour libérer les ressources
            this.FormClosing += FormSyncthingSync_FormClosing;
        }

        // Gère le clic sur le bouton Connecter
        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            string apiUrl = textBoxApiUrl.Text;
            string apiKey = textBoxApiKey.Text;

            // Enregistrer les paramètres
            Properties.Settings.Default.UP_Syncthing_ApiUrl = apiUrl;
            Properties.Settings.Default.UP_Syncthing_ApiKey = apiKey;
            Properties.Settings.Default.Save();

            // Valider l'entrée
            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Veuillez entrer l'URL de l'API et la clé API Syncthing.", "Configuration manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateConnectionStatusUI(false);
                return;
            }

            // Initialiser le client API
            try
            {
                // Libérer l'ancien client si il existe
                _syncthingClient?.Dispose();
                _syncthingClient = new SyncthingApiClient(apiUrl, apiKey);

                // Tenter de se connecter et d'obtenir des informations pour vérifier la connexion
                labelConnectionStatus.Text = "Statut : Connexion en cours...";
                EnableUI(false); // Désactiver l'UI pendant la tentative de connexion

                var systemInfo = await _syncthingClient.GetSystemInfoAsync();

                // Si la connexion réussit, mettre à jour l'UI
                MessageBox.Show($"Connexion Syncthing réussie ! Mon ID : {systemInfo.MyID}", "Connexion établie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateConnectionStatusUI(true);
                EnableUI(true); // Réactiver l'UI

                // Charger les listes de dossiers et d'appareils après connexion réussie
                await LoadSyncthingDataAsync();

            }
            catch (Exception ex)
            {
                // Gérer les erreurs de connexion
                MessageBox.Show($"Échec de la connexion à l'API Syncthing : {ex.Message}", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateConnectionStatusUI(false);
                EnableUI(true); // Réactiver l'UI
                _syncthingClient?.Dispose(); // Libérer le client si créé
                _syncthingClient = null;
                listBoxFolders.Items.Clear(); // Nettoyer les listes en cas d'échec
                listBoxDevices.Items.Clear();
            }
        }

        // Méthode pour charger et afficher les dossiers et appareils
        private async Task LoadSyncthingDataAsync()
        {
            if (_syncthingClient == null) return;

            try
            {
                // Charger les dossiers
                var folders = await _syncthingClient.GetFoldersAsync();
                listBoxFolders.Items.Clear();

                // Pour chaque dossier, obtenir son statut et l'afficher
                foreach (var folder in folders)
                {
                    string folderStatusText = "Statut inconnu"; // Statut par défaut en cas d'erreur
                    try
                    {
                        // Obtient le statut spécifique pour ce dossier
                        var status = await _syncthingClient.GetFolderStatusAsync(folder.Id);
                        folderStatusText = status.State; // Utilise la propriété State de l'objet FolderStatus
                    }
                    catch (Exception statusEx)
                    {
                        // Gérer les erreurs lors de l'obtention du statut d'un dossier
                        System.Diagnostics.Debug.WriteLine($"Erreur lors de l'obtention du statut du dossier {folder.Id}: {statusEx.Message}");
                        folderStatusText = $"Erreur: {statusEx.Message}";
                    }

                    // Ajoute l'information combinée à la ListBox
                    listBoxFolders.Items.Add($"{folder.Label} ({folder.Id}) - {folderStatusText}");
                }


                // Charger les appareils (cette partie reste similaire)
                var devices = await _syncthingClient.GetDevicesAsync();
                listBoxDevices.Items.Clear();

                // Charger les statuts de connexion pour les appareils
                var connections = await _syncthingClient.GetConnectionsAsync();
                // Mettre à jour l'affichage des appareils avec le statut de connexion
                listBoxDevices.Items.Clear(); // Effacer pour ré-ajouter avec statut
                foreach (var device in devices)
                {
                    string status = "Déconnecté";
                    if (connections.Details != null && connections.Details.TryGetValue(device.DeviceID, out ConnectionDetails details))
                    {
                        status = details.Connected ? "Connecté" : "Déconnecté";
                    }
                    listBoxDevices.Items.Add($"{device.Name} ({device.DeviceID}) - {status}");
                }


            }
            catch (Exception ex)
            {
                // Gérer les erreurs générales de chargement des données (ex: connexion API perdue)
                MessageBox.Show($"Échec du chargement des données Syncthing : {ex.Message}", "Erreur de données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // En cas d'erreur, déconnecter l'API client
                _syncthingClient?.Dispose();
                _syncthingClient = null;
                UpdateConnectionStatusUI(false);
                // Nettoyer les listes en cas d'échec
                listBoxFolders.Items.Clear();
                listBoxDevices.Items.Clear();
            }
        }


        // Gère le clic sur le bouton Actualiser le statut
        private async void buttonRefreshStatus_Click(object sender, EventArgs e)
        {
            if (_syncthingClient == null) return;

            labelConnectionStatus.Text = "Statut : Actualisation...";
            EnableUI(false);

            try
            {
                // Ré-obtenir les informations système pour vérifier que l'API est toujours accessible
                var systemInfo = await _syncthingClient.GetSystemInfoAsync();
                labelConnectionStatus.Text = "Statut : Connecté"; // Si GetSystemInfoAsync réussit, l'API est accessible

                // Recharger les données pour afficher les statuts actuels
                await LoadSyncthingDataAsync();

            }
            catch (Exception ex)
            {
                // Si l'actualisation échoue, la connexion est probablement perdue
                MessageBox.Show($"Échec de l'actualisation du statut Syncthing : {ex.Message}", "Erreur d'actualisation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _syncthingClient?.Dispose();
                _syncthingClient = null;
                UpdateConnectionStatusUI(false);
                listBoxFolders.Items.Clear();
                listBoxDevices.Items.Clear();
            }
            finally
            {
                EnableUI(true);
            }
        }


        // Gère le clic sur le bouton Ajouter un dossier
        private async void buttonAddFolder_Click(object sender, EventArgs e)
        {
            if (_syncthingClient == null) return;

            // Dans une vraie application, vous auriez un formulaire pour entrer les détails du nouveau dossier (ID, Label, Path, Type)
            // Pour cet exemple, nous allons utiliser des valeurs factices ou demander à l'utilisateur via un simple InputBox
            string folderId = "MonNouveauDossierID"; // Doit être unique
            string folderLabel = "Mon Nouveau Dossier";
            string folderPath = @"C:\Chemin\Vers\Mon\Dossier"; // Chemin réel sur la machine locale
            string folderType = "sendreceive"; // ou "sendonly", "receiveonly"

            // Demander à l'utilisateur le chemin du dossier local
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = $"Sélectionnez le dossier local pour le dossier Syncthing '{folderLabel}'";
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Ajout de dossier annulé.", "Annulé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            folderPath = folderBrowserDialog.SelectedPath;

            // Demander l'ID et le Label du dossier
            string inputId = Interaction.InputBox("Entrez l'ID unique du dossier Syncthing (ex: MonDossierXYZ)", "Ajouter Dossier", folderId);
            if (string.IsNullOrEmpty(inputId)) return;
            folderId = inputId;

            string inputLabel = Interaction.InputBox("Entrez le Label (nom affiché) du dossier Syncthing", "Ajouter Dossier", folderLabel);
            if (string.IsNullOrEmpty(inputLabel)) return;
            folderLabel = inputLabel;


            // Validation simple
            if (string.IsNullOrEmpty(folderId) || string.IsNullOrEmpty(folderLabel) || string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Informations de dossier invalides ou dossier local introuvable.", "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                EnableUI(false);
                labelConnectionStatus.Text = "Statut : Ajout de dossier...";

                // Créer l'objet Folder à ajouter
                var newFolder = new Folder
                {
                    Id = folderId,
                    Label = folderLabel,
                    Path = folderPath,
                    Type = folderType, // Vous pourriez aussi demander le type à l'utilisateur
                    Devices = new List<FolderDevice>() // Liste vide par défaut, les appareils seront liés plus tard
                };

                await _syncthingClient.AddFolderAsync(newFolder);

                MessageBox.Show($"Dossier '{folderLabel}' ({folderId}) ajouté. Un redémarrage de Syncthing est nécessaire.", "Dossier ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Proposer de redémarrer Syncthing
                if (MessageBox.Show("Syncthing doit être redémarré pour appliquer les changements. Redémarrer maintenant ?", "Redémarrage requis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await RestartSyncthingAsync(); // Appel à la méthode de redémarrage
                }
                else
                {
                    // Si pas de redémarrage, actualiser l'UI sans le nouveau dossier actif
                    await LoadSyncthingDataAsync(); // Charge l'état actuel (sans le nouveau dossier actif)
                    UpdateConnectionStatusUI(true); // Reste connecté mais indique qu'un redémarrage est nécessaire
                    labelConnectionStatus.Text += " (Redémarrage Syncthing requis)";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Échec de l'ajout du dossier : {ex.Message}", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableUI(true);
            }
        }


        // Gère le clic sur le bouton Ajouter un appareil
        private async void buttonAddDevice_Click(object sender, EventArgs e)
        {
            if (_syncthingClient == null) return;

            // Dans une vraie application, vous auriez un formulaire pour entrer les détails du nouvel appareil (Device ID, Name, Addresses)
            // Le Device ID est la clé publique de l'autre instance Syncthing
            string deviceId = "ENTREZ_DEVICE_ID_ICI"; // L'ID de l'appareil distant
            string deviceName = "Nom de l'appareil distant"; // Un nom pour identifier l'appareil
            string deviceAddress = "dynamic"; // ou tcp://ip:port, quic://ip:port, etc.

            // Demander l'ID de l'appareil distant
            string inputDeviceId = Interaction.InputBox("Entrez l'ID de l'appareil Syncthing distant (la longue chaîne de caractères)", "Ajouter Appareil", deviceId);
            if (string.IsNullOrEmpty(inputDeviceId)) return;
            deviceId = inputDeviceId;

            // Demander le nom de l'appareil
            string inputDeviceName = Interaction.InputBox("Entrez un nom pour identifier cet appareil distant", "Ajouter Appareil", deviceName);
            if (string.IsNullOrEmpty(inputDeviceName)) return;
            deviceName = inputDeviceName;

            // Demander l'adresse (optionnel, 'dynamic' est souvent suffisant)
            string inputDeviceAddress = Interaction.InputBox("Entrez l'adresse de l'appareil (ex: dynamic, tcp://ip:port). Laissez 'dynamic' si vous n'êtes pas sûr.", "Ajouter Appareil", deviceAddress);
            if (string.IsNullOrEmpty(inputDeviceAddress)) return;
            deviceAddress = inputDeviceAddress;


            // Validation simple
            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(deviceName))
            {
                MessageBox.Show("ID de l'appareil et Nom sont requis.", "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                EnableUI(false);
                labelConnectionStatus.Text = "Statut : Ajout d'appareil...";

                // Créer l'objet Device à ajouter
                var newDevice = new Device
                {
                    DeviceID = deviceId,
                    Name = deviceName,
                    Addresses = new List<string> { inputDeviceAddress } // Utilise inputDeviceAddress ici
                    // Ajoutez d'autres propriétés par défaut si nécessaire (ex: Compression = "metadata")
                };

                await _syncthingClient.AddDeviceAsync(newDevice);

                MessageBox.Show($"Appareil '{deviceName}' ({deviceId}) ajouté. Un redémarrage de Syncthing est nécessaire.", "Appareil ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Proposer de redémarrer Syncthing
                if (MessageBox.Show("Syncthing doit être redémarré pour appliquer les changements. Redémarrer maintenant ?", "Redémarrage requis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await RestartSyncthingAsync(); // Appel à la méthode de redémarrage
                }
                else
                {
                    // Si pas de redémarrage, actualiser l'UI sans le nouvel appareil actif
                    await LoadSyncthingDataAsync(); // Charge l'état actuel (sans le nouvel appareil actif)
                    UpdateConnectionStatusUI(true); // Reste connecté mais indique qu'un redémarrage est nécessaire
                    labelConnectionStatus.Text += " (Redémarrage Syncthing requis)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Échec de l'ajout de l'appareil : {ex.Message}", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableUI(true);
            }
        }

        // Gère le clic sur le bouton Redémarrer Syncthing
        private async void buttonRestartSyncthing_Click(object sender, EventArgs e)
        {
            if (_syncthingClient == null) return;

            EnableUI(false);
            labelConnectionStatus.Text = "Statut : Redémarrage de Syncthing...";

            try
            {
                await RestartSyncthingAsync(); // Appel à la méthode de redémarrage
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Échec du redémarrage de Syncthing : {ex.Message}", "Erreur de redémarrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _syncthingClient?.Dispose();
                _syncthingClient = null;
                UpdateConnectionStatusUI(false);
                listBoxFolders.Items.Clear();
                listBoxDevices.Items.Clear();
            }
            finally
            {
                EnableUI(true);
            }
        }

        // *** DÉFINITION DE LA MÉTHODE RestartSyncthingAsync ***
        private async Task RestartSyncthingAsync()
        {
            if (_syncthingClient == null)
            {
                MessageBox.Show("Client Syncthing non initialisé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await _syncthingClient.RestartSyncthingAsync();
                MessageBox.Show("Syncthing a été redémarré avec succès.", "Redémarrage réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Attendre un court instant pour que Syncthing redémarre et soit à nouveau accessible
                await Task.Delay(5000); // Attendre 5 secondes (peut nécessiter un ajustement)

                // Tenter de se reconnecter et de charger les données
                // Simuler un clic sur le bouton Connecter pour re-vérifier la connexion et charger les données
                buttonConnect_Click(this, EventArgs.Empty); // Appel non bloquant
            }
            catch (Exception ex)
            {
                // Gérer les erreurs spécifiques au redémarrage
                MessageBox.Show($"Échec du redémarrage de Syncthing via l'API : {ex.Message}", "Erreur Redémarrage API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // En cas d'échec du redémarrage, la connexion est probablement rompue
                _syncthingClient?.Dispose();
                _syncthingClient = null;
                UpdateConnectionStatusUI(false);
                listBoxFolders.Items.Clear();
                listBoxDevices.Items.Clear();
            }
        }

        // *** MÉTHODE POUR LE BOUTON D'INSTRUCTIONS ***
        private void buttonSyncthingInstructions_Click(object sender, EventArgs e)
        {
            // Contenu HTML pour les instructions de configuration Syncthing
            string htmlContent = @"
<!DOCTYPE html>
<html lang='fr'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Instructions de Configuration Syncthing</title>
    <style>
        body { font-family: sans-serif; line-height: 1.6; margin: 20px; }
        h1, h2 { color: #333; }
        strong { color: #555; }
        a { color: #007bff; text-decoration: none; }
        a:hover { text-decoration: underline; }
        code { background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; }
        pre { background-color: #e9e9e9; padding: 10px; border-radius: 5px; overflow-x: auto; }
    </style>
</head>
<body>
    <h1>Configuration de Syncthing pour la Synchronisation</h1>
    <p>Cette application utilise l'API de Syncthing pour gérer la synchronisation de vos fichiers.</p>

    <h2>1. Installez Syncthing</h2>
    <p>Si ce n'est pas déjà fait, téléchargez et installez Syncthing sur tous les PCs que vous souhaitez synchroniser. Vous pouvez le trouver sur le site officiel : <a href='https://syncthing.net/downloads/' target='_blank'>https://syncthing.net/downloads/</a></p>
    <p>Lancez Syncthing. L'interface web s'ouvrira généralement dans votre navigateur à l'adresse <code>http://localhost:8384</code>.</p>

    <h2>2. Configurez l'Interface Web et l'API</h2>
    <p>Dans l'interface web de Syncthing (<code>http://localhost:8384</code>) :</p>
    <ul>
        <li>Allez dans <strong>Actions</strong> > <strong>Paramètres</strong>.</li>
        <li>Dans l'onglet <strong>Général</strong>, faites défiler vers le bas pour trouver la section <strong>Clé d'API</strong>.</li>
        <li>Cochez la case <strong>Activer l'API</strong> à côté de la clé.</li>
        <li>Copiez la <strong>Clé d'API</strong> affichée.</li>
        <li>Cliquez sur <strong>Enregistrer</strong> en bas de la page.</li>
    </ul>

    <h2>3. Configurez l'Application AgOpenGPS</h2>
    <p>Dans la fenêtre de configuration Syncthing de l'application :</p>
    <ul>
        <li>Entrez l'<strong>API URL</strong>. Si vous n'avez pas changé le port par défaut, ce sera généralement <code>http://localhost:8384</code>.</li>
        <li>Collez la <strong>Clé API</strong> que vous avez copiée depuis l'interface web de Syncthing.</li>
        <li>Cliquez sur le bouton <strong>Connecter</strong>. Le statut devrait passer à 'Connecté'.</li>
    </ul>

    <h2>4. Ajoutez des Appareils et des Dossiers</h2>
    <p>Pour synchroniser des fichiers entre plusieurs PCs, vous devez :</p>
    <ul>
        <li>Ajouter les autres PCs en tant qu'<strong>Appareils distants</strong> dans Syncthing sur chaque machine. Pour cela, vous aurez besoin de l'ID de chaque appareil (visible dans l'interface web de Syncthing sous <strong>Actions</strong> > <strong>Afficher l'ID</strong>).</li>
        <li>Partager des <strong>Dossiers</strong> entre ces appareils. Vous définissez un dossier sur un PC, puis vous le partagez avec les appareils distants que vous avez ajoutés.</li>
    </ul>
    <p>Vous pouvez utiliser les boutons <strong>Ajouter Dossier</strong> et <strong>Ajouter Appareil</strong> dans cette application pour configurer cela via l'API, mais il est souvent plus simple de faire la configuration initiale des appareils et des partages de dossiers via l'interface web de Syncthing.</p>
    <p><strong>Important :</strong> Après avoir ajouté un dossier ou un appareil via l'API, vous devrez généralement <strong>Redémarrer Syncthing</strong> pour que les changements soient pris en compte.</p>

    <h2>5. Gérez la Synchronisation</h2>
    <p>Une fois les appareils connectés et les dossiers partagés, Syncthing commencera la synchronisation. Vous pouvez surveiller le statut (synchronisé, en cours, etc.) dans l'interface web de Syncthing ou en utilisant le bouton <strong>Actualiser Statut</strong> dans cette application.</p>

    <h2>Exemple de Clé API :</h2>
    <pre>ABCDEFG-HIJKLMN-OPQRSTU-VWXYZAB-CDEFGHJ-KLMNPQR-STUVWXY-ZABCDEF</pre>
    <p>Votre clé sera différente.</p>

</body>
</html>";

            try
            {
                // Sauvegarder le contenu HTML dans un fichier temporaire
                string tempHtmlFilePath = Path.Combine(Path.GetTempPath(), "SyncthingConfigInstructions.html");
                File.WriteAllText(tempHtmlFilePath, htmlContent);

                // Ouvrir le fichier HTML dans le navigateur par default
                Process.Start(new ProcessStartInfo(tempHtmlFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'ouverture des instructions : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // *** MÉTHODE POUR LANCER SYNCTHING ***
        private void buttonLaunchSyncthing_Click(object sender, EventArgs e)
        {
            // Vérifier si un processus Syncthing est déjà en cours d'exécution
            Process[] syncthingProcesses = Process.GetProcessesByName("syncthing"); // Le nom du processus est généralement "syncthing" ou "syncthing.exe" sans l'extension

            if (syncthingProcesses.Length > 0)
            {
                // Syncthing est déjà en cours d'exécution
                MessageBox.Show("Syncthing semble déjà être en cours d'exécution.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionnel : Ouvrir l'interface web si Syncthing est déjà lancé
                // string syncthingWebUIUrl = "http://localhost:8384";
                // try
                // {
                //     Process.Start(new ProcessStartInfo(syncthingWebUIUrl) { UseShellExecute = true });
                // }
                // catch (Exception webEx)
                // {
                //      MessageBox.Show($"Syncthing est en cours d'exécution, mais impossible d'ouvrir l'interface web : {webEx.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // }

                return; // Sortir de la méthode
            }


            // Lire le chemin de l'exécutable depuis les paramètres
            string syncthingPath = Properties.Settings.Default.UP_Syncthing_ExecutablePath;

            // Vérifier si le chemin existe et si le fichier existe
            if (string.IsNullOrEmpty(syncthingPath) || !File.Exists(syncthingPath))
            {
                // Si le chemin n'est pas défini ou invalide, demander à l'utilisateur de localiser l'exécutable
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Syncthing Executable|syncthing.exe";
                openFileDialog.Title = "Localiser l'exécutable Syncthing (syncthing.exe)";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // L'utilisateur a sélectionné un fichier, sauvegarder le chemin
                    syncthingPath = openFileDialog.FileName;
                    Properties.Settings.Default.UP_Syncthing_ExecutablePath = syncthingPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    // L'utilisateur a annulé la boîte de dialogue
                    MessageBox.Show("Lancement de Syncthing annulé. Le chemin de l'exécutable n'a pas été spécifié.", "Annulé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Sortir de la méthode si l'utilisateur annule
                }
            }

            // Tenter de lancer le processus Syncthing avec le chemin trouvé ou sélectionné
            try
            {
                Process.Start(new ProcessStartInfo(syncthingPath) { UseShellExecute = true });

                // Optionnel : Afficher un message à l'utilisateur
                // MessageBox.Show("Syncthing a été lancé (ou une nouvelle fenêtre de l'interface web a été ouverte).", "Lancement Syncthing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception noSyncthingEx)
            {
                // Gère le cas où le fichier exécutable n'est pas trouvé (même après sélection, peu probable si File.Exists a réussi)
                MessageBox.Show($"Impossible de lancer Syncthing. Le fichier exécutable n'a pas été trouvé ou l'accès est refusé : {syncthingPath}\n\nVeuillez vérifier les permissions ou relocaliser l'exécutable.", "Erreur de lancement Syncthing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Gère les autres erreurs potentielles lors du lancement du processus
                MessageBox.Show($"Une erreur inattendue s'est produite lors du lancement de Syncthing : {ex.Message}", "Erreur de lancement Syncthing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Met à jour les éléments UI en fonction de l'état de la connexion
        private void UpdateConnectionStatusUI(bool isConnected)
        {
            labelConnectionStatus.Text = isConnected ? "Statut : Connecté" : "Statut : Déconnecté";
            buttonConnect.Enabled = !isConnected; // Peut se connecter si déconnecté
            buttonRefreshStatus.Enabled = isConnected; // Peut actualiser si connecté
            buttonAddFolder.Enabled = isConnected; // Peut ajouter si connecté
            buttonAddDevice.Enabled = isConnected; // Peut ajouter si connecté
            buttonRestartSyncthing.Enabled = isConnected; // Peut redémarrer si connecté
            listBoxFolders.Enabled = isConnected;
            listBoxDevices.Enabled = isConnected;
            // buttonSyncthingInstructions.Enabled = true; // Le bouton d'instructions est toujours actif
            // buttonLaunchSyncthing.Enabled = true; // Le bouton de lancement est toujours actif (ou géré par EnableUI)
        }

        // Active/désactive tous les contrôles du formulaire (sauf ceux qui doivent rester actifs)
        private void EnableUI(bool enable)
        {
            // Les contrôles de connexion sont gérés par UpdateConnectionStatusUI
            // buttonConnect.Enabled = enable;
            // buttonRefreshStatus.Enabled = enable;
            // buttonAddFolder.Enabled = enable;
            // buttonAddDevice.Enabled = enable;
            // buttonRestartSyncthing.Enabled = enable;

            textBoxApiUrl.Enabled = enable;
            textBoxApiKey.Enabled = enable;
            listBoxFolders.Enabled = enable; // Peut-être aussi géré par UpdateConnectionStatusUI
            listBoxDevices.Enabled = enable; // Peut-être aussi géré par UpdateConnectionStatusUI

            // Le bouton d'instructions et de lancement restent toujours actifs
            if (button1 != null) button1.Enabled = true;
            if (button2 != null) button2.Enabled = true;


            // Ajoutez d'autres contrôles si nécessaire
        }


        // Gère la fermeture du formulaire pour libérer les ressources
        private void FormSyncthingSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Enregistrer les paramètres
            Properties.Settings.Default.UP_Syncthing_ApiUrl = textBoxApiUrl.Text;
            Properties.Settings.Default.UP_Syncthing_ApiKey = textBoxApiKey.Text;
            Properties.Settings.Default.Save();

            // Libérer le client API si il existe
            _syncthingClient?.Dispose();
        }

        // *** MÉTHODE buttonUnlinkAccount_Click MANQUANTE ***
        private void buttonUnlinkAccount_Click(object sender, EventArgs e)
        {
            // Appeler la méthode UnlinkAccount du TokenManager pour effacer les jetons
            // Cette méthode n'est pas pertinente pour Syncthing, c'est une erreur de copier/coller.
            // Ce bouton n'existe pas dans le formulaire Syncthing.
            // Si ce bouton existe dans un autre formulaire, il doit appeler la logique de déconnexion de ce système.

            // Si ce code est dans FormDropboxSync.cs, alors il est correct.
            // Si ce code est dans FormSyncthingSync.cs, il est incorrect.
            // Le formulaire Syncthing n'a pas de bouton "Délier le compte Dropbox".

            // Étant donné la question précédente sur buttonUnlinkAccount_Click,
            // il semble que nous soyons revenus au contexte du formulaire Dropbox.
            // Si vous êtes bien dans FormSyncthingSync, cette méthode ne devrait pas exister.

            // Si vous voulez une méthode pour "déconnecter" l'API Syncthing,
            // cela impliquerait simplement de disposer le client API et de mettre à jour l'UI.
            // Il n'y a pas de concept de "délier le compte" au sens OAuth pour Syncthing.

            // Je vais supposer que vous travaillez sur FormSyncthingSync.cs
            // et que cette méthode est une erreur. Elle devrait être supprimée.
        }
    }
}
