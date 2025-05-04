using AgOpenGPS.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace AgOpenGPS
{
    public partial class FormTraccar : Form
    {
        private readonly FormGPS mf = null;
        public FormTraccar(Form callingForm)
        {
            //mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.UP_adresse_traccar = adresse_textbox.Text;
            Settings.Default.UP_port_traccar = port_textbox.Text;
            Settings.Default.UP_ID_traccar = ID_textbox.Text;
            Settings.Default.UP_frequence_traccar = (int)frequence_numeric.Value;
            Settings.Default.UP_traccar = traccar_checkBox.Checked;
            this.Close();
        }

        private void FormTraccar_Load(object sender, EventArgs e)
        {
            adresse_textbox.Text = Settings.Default.UP_adresse_traccar;
            port_textbox.Text = Settings.Default.UP_port_traccar;
            ID_textbox.Text = Settings.Default.UP_ID_traccar;
            frequence_numeric.Value = Settings.Default.UP_frequence_traccar;
            traccar_checkBox.Checked = Settings.Default.UP_traccar;
    
    }

        private void button1_Click(object sender, EventArgs e)
        {
            // Chemin où le fichier HTML sera sauvegardé.
            // Il est recommandé d'utiliser un chemin temporaire ou un chemin dans le répertoire de l'application.
            string htmlFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "description_traccar.html");

            // Contenu HTML de la page de description.
            // Ce contenu est basé sur la description que nous avons générée précédemment,
            // avec l'ajout de la section sur la configuration Traccar.
            string htmlContent = @"
<!DOCTYPE html>
<html lang=""fr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Informations et Configuration Traccar</title>
    <script src=""https://cdn.tailwindcss.com""></script>
    <style>
        body {
            font-family: 'Inter', sans-serif;
            background-color: #f4f4f4;
            color: #333;
            line-height: 1.6;
            padding: 20px;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            background: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        h1, h2 {
            color: #0056b3;
            margin-bottom: 15px;
        }
        ul {
            list-style: disc;
            margin-left: 20px;
            margin-bottom: 20px;
        }
        li {
            margin-bottom: 10px;
        }
        code {
            background-color: #e9e9e9;
            padding: 2px 5px;
            border-radius: 4px;
            font-family: Consolas, Monaco, 'Andale Mono', 'Ubuntu Mono', monospace;
        }
        .step {
            margin-bottom: 20px;
            padding: 15px;
            background-color: #eef;
            border-left: 4px solid #0056b3;
            border-radius: 0 5px 5px 0;
        }
        .step h3 {
            margin-top: 0;
            color: #0056b3;
        }
    </style>
</head>
<body>

    <div class=""container"">
        <h1 class=""text-2xl font-bold mb-6"">Informations Traccar</h1>

        <p>Ce document fournit des informations sur la configuration du suivi Traccar dans l'application, les données envoyées au serveur, et la configuration requise côté serveur Traccar.</p>

        <hr class=""my-6"">

        <h2 class=""text-xl font-semibold mb-4"">Configuration Requise sur le Serveur Traccar :</h2>

        <p>Pour recevoir les données de suivi de cette application, vous devez configurer votre serveur Traccar. Voici les étapes générales à suivre :</p>

        <div class=""step"">
            <h3>Étape 1 : Ajouter un nouvel appareil</h3>
            <p>Connectez-vous à l'interface web de votre serveur Traccar (en général, accessible via un navigateur web à l'adresse de votre serveur et au port web de Traccar, par défaut 80 ou 443).</p>
            <p>Dans le menu, trouvez l'option pour ajouter un nouvel appareil. Cela se trouve souvent dans la section 'Appareils' ou 'Devices'.</p>
            </ div >
    
            <h3>Étape 2 : Configurer l'appareil</h3>
            <p>Lors de l'ajout ou de la modification de l'appareil, vous devrez spécifier les informations suivantes :</p>
            <ul>
                <li><strong>Nom :</strong> Donnez un nom descriptif à votre appareil(par exemple, 'Tracteur Arion 410').</li>
                <li><strong>Identifiant(Identifier) :</strong> C'est le champ le plus important. Vous devez entrer ici l'ID exact que vous utilisez dans l'application C# (celui que vous avez configuré dans le champ 'ID de l'appareil' et qui est envoyé via le paramètre <code>id</code> dans l'URL). Par exemple, <code>arion410</code>. Traccar utilise cet ID pour associer les données entrantes au bon appareil.</li>
                <li><strong>Protocole :</strong> Sélectionnez le protocole utilisé par l'application. Dans ce cas, il s'agit du protocole<strong>'OsmAnd'</strong>.</li>
            </ul>
            <p>Les autres paramètres peuvent généralement être laissés par défaut, ou configurés selon vos besoins spécifiques(groupes, etc.).</p>
        </div>

         <div class=""step"">
            <h3>Étape 3 : Vérifier le Port du Protocole</h3>
            <p>Assurez-vous que le port pour le protocole Osmand est ouvert et configuré correctement sur votre serveur Traccar.Le port par défaut pour Osmand est<strong>5055</strong>. Ce port doit être accessible depuis l'ordinateur exécutant l'application de suivi.</p>
            <p>Dans le fichier de configuration de Traccar(<code>traccar.xml</code>), assurez-vous que la ligne pour activer le protocole Osmand est présente et non commentée : <code>&lt;entry key = 'osmand.enable' & gt;true&lt;/entry&gt;</code>. Le port est généralement défini automatiquement lorsque le protocole est activé, mais vous pouvez le vérifier ou le spécifier explicitement si nécessaire(par exemple, <code>&lt; entry key = 'osmand.port' & gt;5055&lt;/entry&gt;</code>).</p>
        </div>

        <div class=""step"">
            <h3>Étape 4 : Réception des Attributs Personnalisés</h3>
            <p>Les attributs supplémentaires envoyés par l'application via l'URL du protocole Osmand (<code>tool</code>, <code>Work</code>, <code>Field</code>, <code>AppliedArea</code>) devraient être automatiquement reconnus et stockés par Traccar.Vous devriez pouvoir les visualiser dans les détails de la position de l'appareil dans l'interface web de Traccar une fois que l'application commence à envoyer des données.</p>
        </div>

        <p>Une fois ces étapes de configuration effectuées sur votre serveur Traccar, et que l'application est configurée avec l'adresse IP/nom de domaine et le port corrects de votre serveur, Traccar devrait commencer à recevoir et afficher les données de suivi de votre véhicule.</p>


        <hr class=""my-6"">

        <h2 class=""text-xl font-semibold mb-4"">Configuration Traccar dans l'Application :</h2>

        <p>L'interface de configuration Traccar vous permet de définir les paramètres nécessaires pour envoyer les données de suivi à votre serveur Traccar. Voici les éléments de configuration disponibles :</p>

        <ul>
            <li>
                <strong>Adresse du serveur</strong> : Champ de texte où vous devez entrer l'adresse IP ou le nom de domaine de votre serveur Traccar (par exemple, <code>demo.traccar.org</code>).
            </li>
            <li>
                <strong>Port(OSMAND : 5055)</strong> : Champ de texte pour spécifier le numéro de port utilisé par le protocole Osmand sur votre serveur Traccar.Le port par défaut pour Osmand est 5055.
            </li>
            <li>
                <strong>ID de l'appareil</strong> : Champ de texte où vous devez entrer l'identifiant unique que vous avez attribué à cet appareil dans Traccar(par exemple, <code>arion410</code>). Cet ID est utilisé par Traccar pour identifier le véhicule.
            </li>
            <li>
                <strong>Fréquence d'actualisation de position</strong> : Contrôle numérique pour définir l'intervalle de temps en secondes entre chaque envoi de position au serveur Traccar.
            </li>
            <li>
                <strong>Activation du trackeur</strong> : Case à cocher pour activer ou désactiver la fonction de suivi Traccar.
            </li>
        </ul>

        <p>Assurez-vous que ces paramètres correspondent à la configuration de votre serveur Traccar et de l'appareil que vous avez créé dans Traccar.</p>

        <hr class=""my-6"">

        <h2 class=""text-xl font-semibold mb-4"">Description des Données Envoyées à Traccar :</h2>

        <p>Lorsque le suivi est activé, l'application envoie les données suivantes à votre serveur Traccar via le protocole Osmand :</p>

        <ul>
            <li>
                <strong><code>id</code></strong> : Identifiant unique du véhicule ou de l'appareil dans Traccar.
            </li>
            <li>
                <strong><code>timestamp</code></strong> : Horodatage de la position.
            </li>
            <li>
                <strong><code>speed</code></strong> : Vitesse du véhicule en kilomètres par heure (KPH).
            </li>
            <li>
                <strong><code>lat</code></strong> : Latitude de la position.
            </li>
            <li>
                <strong><code>lon</code></strong> : Longitude de la position.
            </li>
            <li>
                <strong><code>tool</code></strong> : Nom de l'outil utilisé et sa largeur.
            </li>
             <li>
                <strong><code>Work</code></strong> : Statut du travail de l'outil.
            </li>
             <li>
                <strong><code>Field</code></strong> : Nom du champ ouvert et sa surface.
            </li>
             <li>
                <strong><code>AppliedArea</code></strong> : Superficie travaillée.
            </li>
        </ul>

        <p>Ces paramètres sont envoyés à l'adresse IP et au port spécifiés dans l'URL pour enregistrer la position et les informations associées du véhicule dans Traccar.</p>
    </div>

</body>
</html>";

        try
        {
            // Écrit le contenu HTML dans le fichier spécifié.
            // Le paramètre 'false' indique d'écraser le fichier s'il existe déjà.
            System.IO.File.WriteAllText(htmlFilePath, htmlContent);

            // Ouvre le fichier HTML avec l'application par défaut (navigateur web)
            Process.Start(htmlFilePath);
        }
        catch (Exception ex)
        {
            // Gère les exceptions potentielles (par exemple, permissions d'écriture, pas d'application associée aux fichiers .html)
            MessageBox.Show($"Une erreur s'est produite lors de la création ou de l'ouverture du fichier : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
}

    
    }
}
