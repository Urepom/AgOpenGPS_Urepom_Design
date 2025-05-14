using AgOpenGPS; // Assurez-vous que cet espace de noms correspond
using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net; // Nécessaire pour HttpListener, HttpListenerContext, HttpListenerException
using System.Threading; // Nécessaire pour CancellationTokenSource
using System.Threading.Tasks;
using System.Web; // Nécessaire pour HttpUtility.ParseQueryString (ajoutez la référence à System.Web)
using System.Windows.Forms;

namespace AgOpenGPS // Ou l'espace de noms que vous utilisez
{
    public partial class FormDropboxSync : Form
    {
        // Suppression des champs obsoletes
        // private string accessToken;
        // private DropboxClient _client;

        private string localFolderPath;
        private string dropboxFolderPath;

        private DropboxSynchronizer synchronizer;
        private DropboxTokenManager tokenManager;

        // --- NOUVEAUX MEMBRES POUR LA GESTION DU LISTENER HTTP ---
        private HttpListener httpListener;
        private CancellationTokenSource listenerCts; // Pour annuler la tâche d'écoute
        // Port fixe pour la redirection. Assurez-vous qu'il est libre et enregistré sur Dropbox.
        private const int RedirectPort = 8088;
        // URI de redirection complète. Assurez-vous qu'elle est enregistrée EXACTEMENT comme ceci sur Dropbox.
        private readonly string RedirectUri = $"http://localhost:{RedirectPort}/callback/";

        // Supposons que vous avez ajouté ces contrôles dans le Designer.cs
        // public TextBox textBoxAppKey;     // Existait déjà
        // public TextBox textBoxAppSecret;  // Nouveau
        // public Label labelLinkStatus;     // Nouveau
        // public Button buttonLinkAccount; // Nouveau
        // public Button buttonUnlinkAccount; // Nouveau
        // public Label labelLocalFolderPath; // Existait déjà
        // public TextBox textBoxLocalFolderPath; // Existait déjà
        // public Button buttonBrowseLocalFolder; // Existait déjà
        // public Label labelDropboxFolderName; // Existait déjà
        // public TextBox textBoxDropboxFolderName; // Existait déjà
        // public Button buttonSynchronizeDropbox; // Existait déjà
        // public ProgressBar progressBarSyncDropbox; // Existait déjà
        // public Button buttonGetAccessToken; // Existait déjà (fonction changée)
        // public Button button1;             // Existait déjà (bouton HELP)
        // Les contrôles pour coller le code (textBoxAuthCode, buttonPasteCode, etc.) sont supprimés ou cachés.


        public FormDropboxSync(Form callingForm)
        {
            InitializeComponent();

            // Charger les paramètres depuis les Settings (assurez-vous qu'ils existent dans Properties.Settings.settings)
            textBoxAppKey.Text = Properties.Settings.Default.UP_Dropbox_AppKey;
            textBoxAppSecret.Text = Properties.Settings.Default.UP_Dropbox_AppSecret; // Assurez-vous d'avoir ajouté UP_Dropbox_AppSecret
            textBoxLocalFolderPath.Text = Properties.Settings.Default.UP_Dropbox_LocalFolderPath;
            textBoxDropboxFolderName.Text = Properties.Settings.Default.UP_DropboxFolderName;

            // Initialiser la barre de progression
            progressBarSyncDropbox.Minimum = 0;
            progressBarSyncDropbox.Value = 0;

            // Initialiser Token Manager avec les clés de l'application
            tokenManager = new DropboxTokenManager(textBoxAppKey.Text, textBoxAppSecret.Text);
            // S'abonner à l'événement du TokenManager pour mettre à jour l'UI lors du changement de statut de liaison
            tokenManager.RefreshTokenAvailable += TokenManager_RefreshTokenAvailable;

            // --- Initialiser le listener HTTP ---
            // Le listener est créé une fois avec l'URI qu'il doit écouter.
            httpListener = new HttpListener();
            try
            {
                httpListener.Prefixes.Add(RedirectUri);
            }
            catch (UriFormatException uriEx)
            {
                // Gérer l'erreur si l'URI de redirection n'est pas valide (devrait être rare si la constante est correcte)
                MessageBox.Show($"Erreur de format d'URI pour le listener HTTP : {uriEx.Message}\nAssurez-vous que '{RedirectUri}' est une URI valide.", "Erreur de configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Le listener ne pourra pas démarrer, désactiver la fonction de liaison
                buttonLinkAccount.Enabled = false;
            }
            // ------------------------------------

            // Assurez-vous que ce gestionnaire est connecté dans le concepteur ou ici
            this.FormClosing += FormDropboxSync_FormClosing;


            // Mettre à jour l'état de l'UI basé sur si le compte est déjà lié
            UpdateLinkStatusUI();
        }

        // Gestionnaire de l'événement RefreshTokenAvailable du TokenManager
        private void TokenManager_RefreshTokenAvailable(object sender, string refreshToken)
        {
            // Cette méthode est appelée lorsque le jeton de rafraîchissement est obtenu ou effacé.
            // Elle doit mettre à jour l'UI sur le thread de l'UI.
            if (labelLinkStatus.InvokeRequired) // Vérifier si l'invocation est nécessaire
            {
                labelLinkStatus.Invoke(new Action(() => UpdateLinkStatusUI()));
            }
            else
            {
                UpdateLinkStatusUI(); // Mettre à jour directement si on est déjà sur le thread de l'UI
            }
        }


        // Méthode d'aide pour contrôler l'état des contrôles UI (adaptée pour le listener)
        private void UpdateLinkStatusUI()
        {
            // Vérifie l'état de liaison via le TokenManager
            bool linked = tokenManager.IsAccountLinked();

            // Met à jour le texte du label de statut
            labelLinkStatus.Text = linked ? "Dropbox Status: Linked" : "Dropbox Status: Not Linked";

            // Contrôle l'état des boutons
            // Le bouton Lier est actif si non lié ET si l'UI n'est pas désactivée par ailleurs (ex: pendant la sync)
            buttonLinkAccount.Enabled = !linked && (httpListener == null || !httpListener.IsListening); // Ne pas lier si déjà lié ou si le listener tourne
            buttonUnlinkAccount.Enabled = linked; // Le bouton Déconnecter est actif si lié
            // Le bouton Synchroniser est actif si lié ET si l'UI n'est pas désactivée par ailleurs (ex: pendant la sync)
            buttonSynchronizeDropbox.Enabled = linked && (httpListener == null || !httpListener.IsListening);


            // Cacher ou montrer les contrôles de collage si vous les avez laissés mais cachés
            // if (textBoxAuthCode != null) textBoxAuthCode.Visible = false;
            // if (buttonPasteCode != null) buttonPasteCode.Visible = false;
            // if (labelPasteCodeInstruction != null) labelPasteCodeInstruction.Visible = false;

            // Les champs Clé et Secret peuvent être modifiables même après la liaison, ou non.
            // textBoxAppKey.Enabled = !linked;
            // textBoxAppSecret.Enabled = !linked;
        }


        private void buttonBrowseLocalFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Sélectionner le dossier local à synchroniser avec Dropbox";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLocalFolderPath.Text = folderBrowserDialog.SelectedPath;
                localFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.UP_Dropbox_LocalFolderPath = localFolderPath;
                Properties.Settings.Default.Save();
            }
        }

        // Gestionnaire du bouton "Lancer la synchronisation Dropbox"
        private async void buttonSynchronizeDropbox_Click(object sender, EventArgs e)
        {
            localFolderPath = textBoxLocalFolderPath.Text;
            dropboxFolderPath = textBoxDropboxFolderName.Text;

            // Enregistrer les paramètres de configuration (Clé, Secret, Chemins)
            Properties.Settings.Default.UP_Dropbox_AppKey = textBoxAppKey.Text;
            Properties.Settings.Default.UP_Dropbox_AppSecret = textBoxAppSecret.Text; // Assurez-vous d'avoir ajouté UP_Dropbox_AppSecret
            Properties.Settings.Default.UP_Dropbox_LocalFolderPath = localFolderPath;
            Properties.Settings.Default.UP_DropboxFolderName = dropboxFolderPath;
            // Le RefreshToken est sauvegardé par le TokenManager
            Properties.Settings.Default.Save();

            // Validation : Clé/Secret présents (doit être fait avant d'initialiser tokenManager)
            if (string.IsNullOrEmpty(textBoxAppKey.Text) || string.IsNullOrEmpty(textBoxAppSecret.Text))
            {
                MessageBox.Show("Veuillez entrer la clé et le secret de l'application Dropbox.", "Erreur de configuration Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assurer que le tokenManager utilise les clés actuelles
            tokenManager = new DropboxTokenManager(textBoxAppKey.Text, textBoxAppSecret.Text);
            // S'assurer qu'on est abonné à l'événement TokenManager (en évitant les abonnements multiples)
            tokenManager.RefreshTokenAvailable -= TokenManager_RefreshTokenAvailable; // Désabonner au cas où
            tokenManager.RefreshTokenAvailable += TokenManager_RefreshTokenAvailable; // Puis réabonner

            // Validation : Compte lié (nécessite un refresh token valide)
            if (!tokenManager.IsAccountLinked())
            {
                MessageBox.Show("Veuillez lier votre compte Dropbox d'abord (cliquez sur 'Lier le compte').", "Compte non lié", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Validation : Chemins de synchronisation
            if (string.IsNullOrEmpty(localFolderPath) || string.IsNullOrEmpty(dropboxFolderPath))
            {
                MessageBox.Show("Veuillez remplir tous les champs (Dossier local et Dossier Dropbox).", "Erreur de configuration Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation : Dossier local existe
            if (!Directory.Exists(localFolderPath))
            {
                MessageBox.Show("Le dossier local spécifié est introuvable.", "Erreur de dossier local", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DropboxClient client = null;

            EnableUI(false); // Désactiver l'UI pendant la sync
            progressBarSyncDropbox.Value = 0; // Réinitialiser la barre de progression


            try
            {
                // Obtenir un client authentifié (le TokenManager gère le rafraîchissement)
                client = await tokenManager.GetDropboxClientAsync();


                // Initialiser le synchronizer avec le client obtenu
                synchronizer = new DropboxSynchronizer(localFolderPath, $"/{dropboxFolderPath.Trim('/')}", client);
                synchronizer.SynchronizationProgressChanged += Synchronizer_SynchronizationProgressChanged;

                // Lancer la synchronisation
                var localFiles = synchronizer.GetLocalFiles(localFolderPath);
                var dropboxFiles = await synchronizer.GetDropboxFilesAsync($"/{dropboxFolderPath.Trim('/')}"); // Utilise le client interne du synchronizer

                await synchronizer.UploadLocalToDropboxAsync(localFiles, dropboxFiles);
                await synchronizer.DownloadNewFromDropboxToLocalAsync(localFiles, dropboxFiles);


                MessageBox.Show("Synchronisation Dropbox terminée !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ioEx)
            {
                // Gérer les erreurs d'authentification (ex: jeton de rafraîchissement invalide)
                MessageBox.Show($"Erreur d'authentification Dropbox : {ioEx.Message}\nVeuillez lier votre compte à nouveau.", "Erreur Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Le tokenManager a déjà appelé UnlinkAccount() en cas d'erreur de rafraîchissement critique.
            }
            catch (Exception ex)
            {
                // Gérer les autres erreurs générales pendant la synchronisation
                MessageBox.Show($"Une erreur s'est produite lors de la synchronisation Dropbox : {ex.Message}", "Erreur Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableUI(true); // Réactiver l'UI

                if (synchronizer != null)
                {
                    // Se désabonner de l'événement pour éviter les fuites de mémoire
                    synchronizer.SynchronizationProgressChanged -= Synchronizer_SynchronizationProgressChanged;
                    synchronizer = null; // Libérer la référence
                }
                progressBarSyncDropbox.Value = 0;

                // Mettre à jour l'état de l'UI (en cas d'erreur d'auth, l'état peut avoir changé)
                UpdateLinkStatusUI();
            }
        }

        // Gestionnaire de l'événement de progression (inchangé)
        private void Synchronizer_SynchronizationProgressChanged(object sender, DropboxSynchronizer.SynchronizationProgressEventArgs e)
        {
            if (progressBarSyncDropbox.InvokeRequired)
            {
                progressBarSyncDropbox.Invoke(new Action(() =>
                {
                    progressBarSyncDropbox.Maximum = e.TotalFiles > 0 ? e.TotalFiles : 1;
                    progressBarSyncDropbox.Value = Math.Max(0, Math.Min(progressBarSyncDropbox.Maximum, e.FilesProcessed));
                }));
            }
            else
            {
                progressBarSyncDropbox.Maximum = e.TotalFiles > 0 ? e.TotalFiles : 1;
                progressBarSyncDropbox.Value = Math.Max(0, Math.Min(progressBarSyncDropbox.Maximum, e.FilesProcessed));
            }
        }

        // Gestionnaire de la fermeture du formulaire (arrêter le listener)
        private void FormDropboxSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Enregistrer les paramètres
            Properties.Settings.Default.UP_Dropbox_AppKey = textBoxAppKey.Text;
            Properties.Settings.Default.UP_Dropbox_AppSecret = textBoxAppSecret.Text;
            Properties.Settings.Default.UP_Dropbox_LocalFolderPath = textBoxLocalFolderPath.Text;
            Properties.Settings.Default.UP_DropboxFolderName = textBoxDropboxFolderName.Text;
            // Le RefreshToken et l'état OAuth sont sauvegardés par le TokenManager
            Properties.Settings.Default.Save();


            // Arrêter le listener HTTP si il est en cours d'exécution
            StopHttpListener();

            // Se désabonner du TokenManager pour éviter les fuites de mémoire
            if (tokenManager != null)
            {
                tokenManager.RefreshTokenAvailable -= TokenManager_RefreshTokenAvailable;
                // Si TokenManager gère des ressources IDisposable, ajoutez IDisposable à TokenManager
                // et appelez tokenManager.Dispose(); ici. HttpListener est géré par StopHttpListener et est local.
            }
        }

        // Gestionnaire du bouton "Info Clés" (fonction changée)
        private void buttonGetAccessToken_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Pour lier votre compte Dropbox, vous avez besoin de la clé et du secret de votre application. Créez une application sur la console des développeurs Dropbox (https://www.dropbox.com/developers/apps), configurez les permissions (files.content.read, files.content.write, files.metadata.read), et surtout, ajoutez l'URI de redirection suivante dans les paramètres OAuth2 : " + RedirectUri + "\n\nUtilisez la clé et le secret affichés dans l'application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(new ProcessStartInfo("https://www.dropbox.com/developers/apps") { UseShellExecute = true });
        }

        // Gestionnaire du bouton "Instructions OAuth" (votre button1_Click)
        private void button1_Click(object sender, EventArgs e)
        {
            // Mettre à jour le contenu HTML pour décrire le processus de liaison automatique
            string htmlContent = $@"
<!DOCTYPE html>
<html lang='fr'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Configuration Dropbox - Instructions OAuth2 (Automatique)</title>
    <style>
        body {{ font-family: sans-serif; line-height: 1.6; margin: 20px; }}
        h1 {{ color: #333; }}
        strong {{ color: #555; }}
        a {{ color: #007bff; text-decoration: none; }}
        a:hover {{ text-decoration: underline; }}
        code {{ background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; }}
    </style>
</head>
<body>
    <h1>Configuration de la Synchronisation Dropbox (Méthode OAuth 2 Automatique)</h1>
    <p>Pour utiliser la synchronisation Dropbox, vous devez configurer une application et autoriser l'application à accéder à votre compte.</p>

    <h2>1. Créez une Application Dropbox :</h2>
    <p>
        Rendez-vous sur <a href='https://www.dropbox.com/developers/apps' target='_blank'>https://www.dropbox.com/developers/apps</a> et connectez-vous.<br>
        Cliquez sur 'Créer une application'. Choisissez <strong>'Scoped access'</strong> et le type d'accès aux fichiers (<strong>'App folder'</strong> ou <strong>'Full Dropbox'</strong>).
    </p>
    <p>Donnez un nom unique à votre application.</p>
     <p>Dans les paramètres de l'application, sous 'OAuth2', ajoutez l'<strong>URI de redirection</strong> suivante :</p>
     <p><code>{RedirectUri}</code></p>
     <p>Cliquez sur 'Add'.</p>
     <p> Configurez les<strong> Permissions</ strong > (Scopes)nécessaires : < strong > files.content.read </ strong >, < strong > files.content.write </ strong >, < strong > files.metadata.read </ strong >.Soumettez les permissions.</ p >

    <h2> 2.Récupérez la Clé et le Secret de l'Application :</h2>
    <p>
        Sur la page de votre application, trouvez 'App key' et 'App secret'.Copiez ces valeurs et collez-les dans les champs correspondants de l'application de synchronisation.
    </p >
    <h2> 3.Liez votre Compte Dropbox dans l'Application :</h2>
    <p>
         Dans l'application de synchronisation, entrez la Clé et le Secret de votre application.<br>
         Cliquez sur le bouton<strong>'Lier le compte Dropbox' </ strong >.Votre navigateur web s'ouvrira, vous dirigeant vers une page d'autorisation Dropbox.
    </p >
    <h2> 4.Autorisez l'Application :</h2>
    <p>
        Sur la page Dropbox, confirmez que vous autorisez votre application à accéder à votre compte.< br >
        Après autorisation, votre navigateur sera redirigé vers<code>{RedirectUri}</ code >.Votre application interceptera automatiquement cette redirection et terminera la liaison.Vous pourriez voir une page Ce site est inaccessible dans le navigateur juste après l'autorisation, ce qui est normal car le serveur local s'arrête rapidement une fois la redirection traitée.
    </p >
    <p> Une boîte de message dans l'application vous confirmera si la liaison a réussi.</p>
    <h2> 5.Configurez les Dossiers et Synchronisez :</ h2 >
    <p> Une fois le compte lié, sélectionnez votre dossier local et spécifiez le nom du dossier Dropbox. Cliquez sur 'Lancer la synchronisation'.</ p >
</ body >
</ html > ";

            try
            {
                string tempHtmlFilePath = Path.Combine(Path.GetTempPath(), "DropboxConfigInstructionsOAuth2Automatic.html");
                File.WriteAllText(tempHtmlFilePath, htmlContent);
                Process.Start(new ProcessStartInfo(tempHtmlFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'ouverture des instructions : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaire du bouton "Lier le compte Dropbox" (Nouveau bouton)
        private void buttonLinkAccount_Click(object sender, EventArgs e)
        {
            // S'assurer que Clé et Secret sont entrés
            if (string.IsNullOrEmpty(textBoxAppKey.Text) || string.IsNullOrEmpty(textBoxAppSecret.Text))
            {
                MessageBox.Show("Veuillez entrer la clé et le secret de l'application Dropbox avant de lier le compte.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Assurer que le tokenManager utilise les clés actuelles
            tokenManager = new DropboxTokenManager(textBoxAppKey.Text, textBoxAppSecret.Text);
            // S'assurer qu'on est abonné à l'événement TokenManager (en évitant les abonnements multiples)
            tokenManager.RefreshTokenAvailable -= TokenManager_RefreshTokenAvailable; // Désabonner au cas où
            tokenManager.RefreshTokenAvailable += TokenManager_RefreshTokenAvailable; // Puis réabonner


            // Arrêter le listener si il tournait encore pour une raison quelconque (ex: tentative précédente échouée)
            StopHttpListener();

            // Préparer pour démarrer le listener
            listenerCts = new CancellationTokenSource();

            try
            {
                // Démarrer la tâche d'écoute HTTP en arrière-plan
                Task listenerTask = Task.Run(() => ListenForOAuthCallback(listenerCts.Token));


                // Générer l'URL d'autorisation avec l'URI de redirection que le listener écoute
                string authUrl = tokenManager.GenerateAuthorizationUrl(RedirectUri);


                // Ouvrir le navigateur
                MessageBox.Show($"Votre navigateur va s'ouvrir pour vous connecter à Dropbox. Veuillez autoriser l'application.", "Autorisation Dropbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });

                // Mettre à jour l'UI pour indiquer qu'on attend la redirection
                if (labelLinkStatus.InvokeRequired) labelLinkStatus.Invoke(new Action(() => labelLinkStatus.Text = "Dropbox Status: En attente d'autorisation..."));
                else labelLinkStatus.Text = "Dropbox Status: En attente d'autorisation...";

                // Désactiver les boutons de liaison/sync/déliaison pendant le processus
                buttonLinkAccount.Enabled = false;
                buttonSynchronizeDropbox.Enabled = false;
                buttonUnlinkAccount.Enabled = false;
                // Garder les boutons info/help actifs si vous le souhaitez
                if (button1 != null) button1.Enabled = true;
                if (buttonGetAccessToken != null) buttonGetAccessToken.Enabled = true;


            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show($"Erreur de format d'URI pour l'autorisation : {uriEx.Message}\nAssurez-vous que l'URI de redirection '{RedirectUri}' est correctement configurée.", "Erreur de configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Mettre à jour l'état de l'UI en cas d'échec
                UpdateLinkStatusUI(); // Rétablit l'état basé sur IsAccountLinked() et si listener tourne
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de démarrer le processus de liaison ou d'ouvrir le navigateur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // S'assurer que le listener est arrêté en cas d'erreur au démarrage
                StopHttpListener(); // Ceci pourrait aussi déclencher l'erreur "aborted" si le listener était démarré.
                                    // Mettre à jour l'état de l'UI en cas d'échec
                UpdateLinkStatusUI(); // Rétablit l'état basé sur IsAccountLinked() et si listener tourne
            }
        }

        // Méthode qui tourne en arrière-plan pour écouter les requêtes HTTP
        // Note : Cette méthode devrait gérer les erreurs internes sans laisser la tâche planter.
        private async Task ListenForOAuthCallback(CancellationToken cancellationToken)
        {
            if (httpListener == null || !httpListener.Prefixes.Any())
            {
                // Gérer l'erreur si le listener n'est pas configuré (devrait être géré dans le constructeur)
                if (labelLinkStatus.InvokeRequired) labelLinkStatus.Invoke(new Action(() => labelLinkStatus.Text = "Dropbox Status: Erreur listener (config)"));
                return; // Sortir si non configuré
            }

            try
            {
                // Démarrer le listener. Peut lancer une HttpListenerException (Port déjà utilisé, Permission refusée)
                httpListener.Start();


                // Boucle d'écoute. On attend une ou plusieurs requêtes.
                // Pour le flux OAuth, on n'attend qu'une seule requête (le callback).
                // On peut sortir de la boucle après avoir traité la première requête.
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Attendre une requête entrante. GetContextAsync bloque jusqu'à réception ou arrêt du listener.
                    // Si Stop() est appelé ou le CancellationToken est annulé, GetContextAsync lèvera une exception.
                    HttpListenerContext context = null;
                    try
                    {
                        // Utiliser Task.Run pour appeler GetContextAsync et pouvoir l'attendre avec le token d'annulation.
                        // C'est une technique courante pour rendre GetContextAsync annulable via CancellationToken.
                        context = await Task.Run(() => httpListener.GetContextAsync(), cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        // Annulation demandée, c'est normal
                        break; // Sortir de la boucle si l'opération a été annulée
                    }
                    catch (HttpListenerException httpEx)
                    {
                        // Gérer les erreurs pendant l'attente ou la réception du contexte (ex: réseau)
                        if (httpEx.ErrorCode == 5) // Accès refusé
                        {
                            MessageBox.Show($"Erreur de permission pour démarrer le serveur local sur '{RedirectUri}'. Assurez-vous que l'URI est enregistrée correctement pour cet utilisateur (voir documentation HttpListener).", "Erreur de permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (httpEx.ErrorCode == 183) // Adresse déjà utilisée
                        {
                            MessageBox.Show($"Le port {RedirectPort} est déjà utilisé par une autre application. Veuillez fermer l'application qui utilise ce port ou modifier le code source pour utiliser un autre port.", "Erreur Port Occupé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // Pour le callback OAuth unique, toute erreur ici est critique. Sortons.
                        break; // Sortir de la boucle en cas d'erreur pendant l'attente/réception
                    }
                    catch (Exception ex)
                    {
                        // Gérer les autres erreurs inattendues pendant l'attente/réception
                        MessageBox.Show($"Une erreur inattendue s'est produite lors de l'attente de l'autorisation : {ex.Message}", "Erreur Serveur Local", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break; // Sortir pour éviter une boucle infinie d'erreurs
                    }


                    // Si on a reçu un contexte (et l'annulation n'a pas eu lieu juste après)
                    if (context != null)
                    {
                        // Traiter la requête (idéalement sur un autre thread pour ne pas bloquer la boucle d'écoute)
                        // On utilise async void pour ce gestionnaire car ProcessListenerRequest est async
                        // et on ne veut pas attendre la fin de son traitement ici dans la boucle d'écoute.
                        ProcessListenerRequest(context); // Appeler la méthode de traitement

                        // Pour le flux OAuth, on a reçu le callback attendu, on peut arrêter d'écouter.
                        break; // Sortir de la boucle après avoir traité la première requête de callback.
                    }
                    else
                    {
                        // Si context est null, et l'annulation n'a pas eu lieu, c'est un cas inattendu.
                        // Sortir pour éviter une boucle infinie
                        break;
                    }
                } // Fin de la boucle while
            }
            catch (HttpListenerException httpEx)
            {
                // Cette section gère les erreurs QUI SE PRODUISENT LORS DE httpListener.Start() ou avant l'attente.
                if (httpEx.ErrorCode == 5) // Accès refusé
                {
                    MessageBox.Show($"Erreur de permission pour démarrer le serveur local sur '{RedirectUri}'. Assurez-vous que l'URI est enregistrée correctement pour cet utilisateur (voir documentation HttpListener).", "Erreur de permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (httpEx.ErrorCode == 183) // Adresse déjà utilisée
                {
                    MessageBox.Show($"Le port {RedirectPort} est déjà utilisé par une autre application. Veuillez fermer l'application qui utilise ce port ou modifier le code source pour utiliser un autre port.", "Erreur Port Occupé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Une erreur inattendue s'est produite lors du démarrage du serveur local : {httpEx.Message}", "Erreur Serveur Local", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Mettre à jour l'UI sur le thread de l'UI en cas d'échec du listener au démarrage
                if (labelLinkStatus.InvokeRequired) labelLinkStatus.Invoke(new Action(() => labelLinkStatus.Text = "Dropbox Status: Erreur listener (start)"));
            }
            catch (OperationCanceledException)
            {
                // Annulation demandée avant même que GetContextAsync ne soit appelé ou très tôt.
                // C'est géré silencieusement ici.
            }
            catch (Exception ex)
            {
                // Gérer les autres erreurs inattendues
                MessageBox.Show($"Une erreur s'est produite dans la tâche du serveur local : {ex.Message}", "Erreur Serveur Local", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (labelLinkStatus.InvokeRequired) labelLinkStatus.Invoke(new Action(() => labelLinkStatus.Text = "Dropbox Status: Erreur listener (exception)"));
            }
            finally
            {
                // S'assurer que le listener est arrêté en sortant de la tâche
                StopHttpListener();

                // Mettre à jour l'UI pour refléter l'état final APRES que la tâche du listener est terminée.
                // Cela doit se faire sur le thread de l'UI.
                if (labelLinkStatus.InvokeRequired) labelLinkStatus.Invoke(new Action(() => UpdateLinkStatusUI()));
            }
        }

        // Traite une seule requête HTTP reçue par le listener (async void)
        private async void ProcessListenerRequest(HttpListenerContext context)
        {
            string code = null;
            string state = null;
            string error = null;

            try
            {
                // Analyser l'URL reçue
                var query = context.Request.Url.Query;
                // HttpUtility.ParseQueryString est dans System.Web.
                var queryParameters = HttpUtility.ParseQueryString(query);

                code = queryParameters["code"];
                state = queryParameters["state"];
                error = queryParameters["error"]; // Capture les erreurs (ex: user denied)


                // --- Envoyer une réponse au navigateur ---
                // C'est important pour que le navigateur sache que la requête est terminée.
                string responseString = "<html><body><h1>Autorisation Dropbox reçue.</h1><p>Vous pouvez fermer cette fenêtre de navigateur.</p></body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200; // OK
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close(); // IMPORTANT pour envoyer la réponse et fermer la connexion
                // --- Fin de l'envoi de réponse ---

                // *** LA LIGNE StopHttpListener() A ÉTÉ RETIRÉE ICI ***
                // La méthode StopHttpListener() est maintenant appelée uniquement
                // dans le bloc 'finally' de la tâche ListenForOAuthCallback.


                // Traiter le code ou l'erreur reçu
                if (!string.IsNullOrEmpty(error))
                {
                    // L'utilisateur a refusé l'autorisation ou une erreur s'est produite côté Dropbox
                    // Afficher un message d'erreur sur le thread de l'UI
                    if (this.InvokeRequired) this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"L'autorisation Dropbox a échoué ou a été refusée : {error}", "Erreur d'autorisation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    else
                    {
                        MessageBox.Show($"L'autorisation Dropbox a échoué ou a été refusée : {error}", "Erreur d'autorisation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // En cas de refus/erreur, on doit s'assurer que le compte n'apparaît pas comme lié
                    tokenManager.UnlinkAccount(); // Le RefreshTokenAvailable event mettra à jour l'UI
                }
                else if (!string.IsNullOrEmpty(code))
                {
                    // Code d'autorisation reçu, procéder à l'échange de jetons
                    // Appeler ExchangeCodeForTokensAsync. Elle mettra à jour le statut de liaison via l'événement.
                    // Utiliser await est correct ici car ProcessListenerRequest est async void, elle n'est pas attendue.
                    bool exchangeSuccess = await tokenManager.ExchangeCodeForTokensAsync(code, state, RedirectUri);

                    if (exchangeSuccess)
                    {
                        // Afficher un message de succès sur le thread de l'UI
                        if (this.InvokeRequired) this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Compte Dropbox lié avec succès ! Vous pouvez maintenant lancer la synchronisation.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                        else
                        {
                            MessageBox.Show("Compte Dropbox lié avec succès ! Vous pouvez maintenant lancer la synchronisation.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Si l'échange échoue, TokenManager.ExchangeCodeForTokensAsync a déjà appelé UnlinkAccount() et notifié l'UI.
                        // Afficher un message d'échec général sur le thread de l'UI
                        if (this.InvokeRequired) this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Échec de la liaison du compte Dropbox.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                        else
                        {
                            MessageBox.Show("Échec de la liaison du compte Dropbox.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Ni code ni erreur, réponse inattendue
                    if (this.InvokeRequired) this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Réponse d'autorisation Dropbox inattendue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    else
                    {
                        MessageBox.Show("Réponse d'autorisation Dropbox inattendue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // En cas de réponse inattendue, on s'assure que le compte n'est pas marqué comme lié.
                    tokenManager.UnlinkAccount();
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs inattendues lors du traitement de la requête
                if (this.InvokeRequired) this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Une erreur s'est produite lors du traitement de l'autorisation Dropbox : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                else
                {
                    MessageBox.Show($"Une erreur s'est produite lors du traitement de l'autorisation Dropbox : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // En cas d'erreur, on s'assure que le compte n'est pas marqué comme lié.
                tokenManager.UnlinkAccount(); // Ceci notifiera l'UI via l'événement
            }
            finally
            {
                // L'UI est mise à jour via l'événement RefreshTokenAvailable déclenché par UnlinkAccount ou ExchangeCodeForTokensAsync
            }
        }

        // Arrête le listener HTTP et annule la tâche d'écoute
        private void StopHttpListener()
        {
            if (httpListener != null && httpListener.IsListening)
            {
                // Signaler l'annulation à la tâche d'écoute
                if (listenerCts != null && !listenerCts.IsCancellationRequested)
                {
                    listenerCts.Cancel();
                }

                // Arrêter le listener. Cela fera sortir GetContextAsync() de son attente (avec une exception).
                try
                {
                    httpListener.Stop();
                }
                catch (ObjectDisposedException)
                {
                    // Le listener a déjà été disposé, c'est bon.
                }
                catch (Exception)
                {
                    // Gérer d'autres erreurs potentielles lors de l'arrêt
                }
            }

            // Libérer les ressources du CancellationTokenSource
            if (listenerCts != null)
            {
                listenerCts.Dispose();
                listenerCts = null;
            }
            // Vous pourriez choisir de Disposer HttpListener ici si vous le recréez à chaque liaison.
            // Actuellement, il est créé une fois dans le constructeur. Le laisser ainsi est correct.
        }

        // Méthode d'aide pour activer/désactiver les contrôles (ajustée pour le listener)
        private void EnableUI(bool enable)
        {
            // Ces contrôles sont toujours liés à l'entrée de base
            textBoxAppKey.Enabled = enable;
            textBoxAppSecret.Enabled = enable;
            textBoxLocalFolderPath.Enabled = enable;
            buttonBrowseLocalFolder.Enabled = enable;
            textBoxDropboxFolderName.Enabled = enable;

            // L'état des boutons de liaison/synchronisation est géré par UpdateLinkStatusUI
            // en fonction de l'état de liaison et si le listener tourne.
            // Donc, si 'enable' est true, UpdateLinkStatusUI sera appelée pour mettre à jour leur état final.
            // Si 'enable' est false, ils seront tous désactivés ici.

            if (!enable) // Désactiver tout (pour la sync)
            {
                // Désactiver tous les boutons liés à la sync/auth
                buttonLinkAccount.Enabled = false;
                buttonUnlinkAccount.Enabled = false;
                buttonSynchronizeDropbox.Enabled = false;
                // Garder les boutons info/help actifs
                if (button1 != null) button1.Enabled = true;
                if (buttonGetAccessToken != null) buttonGetAccessToken.Enabled = true;
            }
            else // Réactiver tout (après sync ou échec)
            {
                // buttonLinkAccount.Enabled = true; // Ceci sera géré par UpdateLinkStatusUI
                // buttonUnlinkAccount.Enabled = true; // Ceci sera géré par UpdateLinkStatusUI
                // buttonSynchronizeDropbox.Enabled = true; // Ceci sera géré par UpdateLinkStatusUI
                if (button1 != null) button1.Enabled = true;
                if (buttonGetAccessToken != null) buttonGetAccessToken.Enabled = true;
            }
        }

        // *** MÉTHODE buttonUnlinkAccount_Click MANQUANTE ***
        private void buttonUnlinkAccount_Click(object sender, EventArgs e)
        {
            // Appeler la méthode UnlinkAccount du TokenManager pour effacer les jetons
            tokenManager.UnlinkAccount();

            // Mettre à jour l'UI pour refléter l'état délié
            // UpdateLinkStatusUI() est déjà appelée par l'événement RefreshTokenAvailable
            // déclenché par tokenManager.UnlinkAccount().
        }
    }
}
