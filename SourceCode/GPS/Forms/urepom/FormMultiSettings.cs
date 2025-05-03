using Amazon.Runtime.Telemetry.Metrics; // Conserver l'using de votre code
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml; // Assurez-vous que ce using est présent
using System.Xml.Linq;
using static Dropbox.Api.Paper.ListPaperDocsSortBy; // Conserver l'using de votre code
using static OpenTK.Graphics.OpenGL.GL; // Conserver l'using de votre code
using static System.Collections.Specialized.BitVector32; // Conserver l'using de votre code
using static System.Net.Mime.MediaTypeNames; // Conserver l'using de votre code
// using System.ComponentModel; // Plus nécessaire si INotifyPropertyChanged n'est pas utilisé

namespace AgOpenGPS // Utiliser votre namespace
{
    public partial class FormMultiSettings : Form
    {
        // Classe pour stocker temporairement les informations des paramètres
        // Pas besoin d'INotifyPropertyChanged pour la recherche manuelle, mais je le laisse commenté si vous voulez l'ajouter plus tard
        private class SettingInfo // : INotifyPropertyChanged
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    // if (_isSelected != value) // Ces vérifications ne sont nécessaires qu'avec INotifyPropertyChanged
                    // {
                    _isSelected = value;
                    // OnPropertyChanged(nameof(IsSelected));
                    // }
                }
            }
            public string Name { get; set; }
            // Nous stockerons la valeur brute (string ou XML)
            public string ValueString { get; set; }
            // Pour les valeurs sérialisées en XML, nous stockons l'élément XML
            public XElement ValueXml { get; set; }
            public string SerializeAs { get; set; }

            // public event PropertyChangedEventHandler PropertyChanged; // Pas nécessaire sans INotifyPropertyChanged

            // protected void OnPropertyChanged(string propertyName) // Pas nécessaire sans INotifyPropertyChanged
            // {
            //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // }
        }

        private List<SettingInfo> loadedSettings;

        // Le designer va déclarer les contrôles de recherche et les boutons de sélection/décochage/IMU/Véhicule
        // private System.Windows.Forms.Label label5; // Label pour la recherche
        // private System.Windows.Forms.TextBox txtSearch; // Champ de recherche
        // private System.Windows.Forms.Button btnClearSearch; // Bouton Effacer
        // ... autres boutons ...


        // Constructeur basé sur votre code
        public FormMultiSettings(Form callingForm)
        {
            InitializeComponent();
            InitializeDataGridView();
            // L'événement FormMultiSettings_Load gère le chargement initial
        }

        // Cette méthode est appelée après InitializeComponent
        private void InitializeDataGridView()
        {
            // Configurer les colonnes du DataGridView
            dgvSettings.AutoGenerateColumns = false;

            // Supprimer les colonnes existantes avant d'en ajouter
            dgvSettings.Columns.Clear();

            dgvSettings.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colSelect",
                HeaderText = "Sélectionner",
                // DataPropertyName = "IsSelected", // Plus de liaison automatique directe avec la liste
                Width = 70,
                ReadOnly = false // Permettre de cocher/décocher
            });

            dgvSettings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Nom du paramètre",
                // DataPropertyName = "Name", // Plus de liaison automatique directe
                ReadOnly = true, // Rendre la colonne non éditable
                Width = 200
            });

            dgvSettings.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colValue",
                HeaderText = "Valeur",
                // DataPropertyName = "ValueString", // Plus de liaison automatique directe
                ReadOnly = true, // Rendre la colonne non éditable
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Masquer les colonnes internes pour la sérialisation - elles ne sont plus directement nécessaires dans la grille
            // mais nous gardons l'idée pour référence si besoin de les rajouter plus tard
            // dgvSettings.Columns.Add(new DataGridViewTextBoxColumn
            // {
            //     Name = "colValueXml",
            //     DataPropertyName = "ValueXml",
            //     Visible = false
            // });
            // dgvSettings.Columns.Add(new DataGridViewTextBoxColumn
            // {
            //     Name = "colSerializeAs",
            //     DataPropertyName = "SerializeAs",
            //     Visible = false
            // });

            // Permettre la sélection de plusieurs lignes
            dgvSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ajouter un gestionnaire d'événement pour le CellFormatting si vous voulez afficher le XML différemment,
            // ou si DataPropertyName était utilisé (mais ce n'est plus le cas ici)
            // dgvSettings.CellFormatting += DgvSettings_CellFormatting;
        }


        // Bouton Parcourir Fichier Source
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                openFileDialog.Title = "Sélectionner le fichier XML source";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFile.Text = openFileDialog.FileName;
                    LoadSettings(openFileDialog.FileName);
                    dgvSettings.Tag = openFileDialog.FileName; // Conserver pour la logique de décochage dans ListTargetFiles
                }
            }
        }

        // Charge les paramètres du fichier XML source et affiche les lignes dans le DataGridView
        private void LoadSettings(string filePath)
        {
            loadedSettings = new List<SettingInfo>();
            rtbStatus.Clear();
            dgvSettings.Rows.Clear(); // Effacer les anciennes données
            dgvSettings.DataSource = null; // Détacher toute source de données précédente (même si pas de BindingSource, bonne pratique)
            txtSearch.Clear(); // Effacer la recherche et donc le filtre

            if (!File.Exists(filePath))
            {
                rtbStatus.AppendText($"Erreur: Le fichier source n\'existe pas : {filePath}\n");
                return;
            }

            try
            {
                XDocument doc = XDocument.Load(filePath);

                var settingsNode = doc.Descendants("AgOpenGPS.Properties.Settings").FirstOrDefault();

                if (settingsNode != null)
                {
                    var settings = settingsNode.Elements("setting");

                    foreach (var setting in settings)
                    {
                        string name = setting.Attribute("name")?.Value;
                        string serializeAs = setting.Attribute("serializeAs")?.Value;
                        XElement valueElement = setting.Element("value");

                        if (!string.IsNullOrEmpty(name) && valueElement != null)
                        {
                            SettingInfo settingInfo = new SettingInfo
                            {
                                IsSelected = false, // Non sélectionné par défaut
                                Name = name,
                                SerializeAs = serializeAs
                            };

                            if (serializeAs == "Xml")
                            {
                                settingInfo.ValueXml = valueElement.Elements().FirstOrDefault();
                                settingInfo.ValueString = settingInfo.ValueXml != null ? settingInfo.ValueXml.ToString(SaveOptions.DisableFormatting) : "<Empty XML Value>";
                            }
                            else
                            {
                                settingInfo.ValueString = valueElement.Value;
                                settingInfo.ValueXml = null;
                            }

                            loadedSettings.Add(settingInfo); // Ajouter à la liste interne
                        }
                    }

                    // Afficher TOUS les paramètres chargés initialement (pas de filtre)
                    DisplaySettings(loadedSettings); // Appeler une nouvelle méthode pour afficher

                    rtbStatus.AppendText($"Paramètres chargés depuis {Path.GetFileName(filePath)} ({loadedSettings.Count} trouvés).\n");
                }
                else
                {
                    rtbStatus.AppendText($"Erreur: Le nœud <AgOpenGPS.Properties.Settings> n'a pas été trouvé dans le fichier source.\n");
                }
            }
            catch (Exception ex)
            {
                rtbStatus.AppendText($"Erreur lors du chargement du fichier source: {ex.Message}\n");
            }
        }

        // Nouvelle méthode pour afficher une liste de SettingInfo dans le DataGridView
        private void DisplaySettings(List<SettingInfo> settingsToDisplay)
        {
            dgvSettings.Rows.Clear(); // Effacer les lignes actuelles

            foreach (var setting in settingsToDisplay)
            {
                // Ajouter une nouvelle ligne
                int rowIndex = dgvSettings.Rows.Add();
                DataGridViewRow row = dgvSettings.Rows[rowIndex];

                // Remplir les cellules. L'ordre doit correspondre à l'ordre des colonnes dans InitializeDataGridView
                row.Cells["colSelect"].Value = setting.IsSelected;
                row.Cells["colName"].Value = setting.Name;
                row.Cells["colValue"].Value = setting.ValueString;

                // Stocker la référence à l'objet SettingInfo dans le Tag de la ligne
                row.Tag = setting;
            }
            // rtbStatus.AppendText($"Affichage de {settingsToDisplay.Count} paramètres sur {loadedSettings.Count} total.\n"); // Peut devenir bruyant
        }


        // Bouton Parcourir Dossier Cible
        private void btnBrowseTargetFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Sélectionner le dossier contenant les fichiers XML cibles";
                folderBrowserDialog.ShowNewFolderButton = false;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtTargetFolder.Text = folderBrowserDialog.SelectedPath;
                    ListTargetFiles(folderBrowserDialog.SelectedPath);
                    clbTargetFiles.Tag = folderBrowserDialog.SelectedPath;
                }
            }
        }

        // Liste les fichiers XML dans le CheckedListBox
        private void ListTargetFiles(string folderPath)
        {
            clbTargetFiles.Items.Clear();
            if (!Directory.Exists(folderPath))
            {
                rtbStatus.AppendText($"Erreur: Le dossier cible n\'existe pas : {folderPath}\n");
                return;
            }

            string sourceFilePath = null;
            if (!string.IsNullOrWhiteSpace(txtSourceFile.Text) && File.Exists(txtSourceFile.Text))
            {
                sourceFilePath = Path.GetFullPath(txtSourceFile.Text);
            }

            try
            {
                string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");
                int fileCount = 0;
                foreach (string file in xmlFiles)
                {
                    string currentFilePath = Path.GetFullPath(file);
                    bool isSourceFile = !string.IsNullOrEmpty(sourceFilePath) &&
                                        string.Equals(sourceFilePath, currentFilePath, StringComparison.OrdinalIgnoreCase);

                    clbTargetFiles.Items.Add(Path.GetFileName(file), !isSourceFile);
                    fileCount++;
                }
                rtbStatus.AppendText($"Trouvé {fileCount} fichiers XML dans {Path.GetFileName(folderPath)}.\n");
            }
            catch (Exception ex)
            {
                rtbStatus.AppendText($"Erreur lors de la liste des fichiers cibles: {ex.Message}\n");
            }
        }

        // Bouton Copier Paramètres
        private void btnCopySettings_Click(object sender, EventArgs e)
        {
            // IMPORTANT: Utiliser la liste chargée originale (loadedSettings) car la grille peut être filtrée
            if (loadedSettings == null || loadedSettings.Count == 0)
            {
                MessageBox.Show("Aucun paramètre chargé depuis le fichier source.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // On prend les paramètres marqués comme sélectionnés dans la liste originale
            var settingsToCopy = loadedSettings.Where(s => s.IsSelected).ToList();

            if (settingsToCopy.Count == 0)
            {
                MessageBox.Show("Aucun paramètre sélectionné à copier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> targetFiles = new List<string>();
            for (int i = 0; i < clbTargetFiles.Items.Count; i++)
            {
                if (clbTargetFiles.GetItemChecked(i))
                {
                    targetFiles.Add(Path.Combine(txtTargetFolder.Text, clbTargetFiles.Items[i].ToString()));
                }
            }

            if (targetFiles.Count == 0)
            {
                MessageBox.Show("Aucun fichier cible sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rtbStatus.AppendText($"\nDébut de la copie de {settingsToCopy.Count} paramètres vers {targetFiles.Count} fichiers...\n");

            foreach (string targetFilePath in targetFiles)
            {
                try
                {
                    if (!File.Exists(targetFilePath))
                    {
                        rtbStatus.AppendText($"\nErreur: Fichier cible non trouvé: {Path.GetFileName(targetFilePath)}. Ignoré.\n");
                        continue;
                    }

                    XDocument targetDoc = XDocument.Load(targetFilePath);

                    var targetSettingsNode = targetDoc.Descendants("AgOpenGPS.Properties.Settings").FirstOrDefault();

                    if (targetSettingsNode == null)
                    {
                        var userSettingsNode = targetDoc.Descendants("userSettings").FirstOrDefault();
                        if (userSettingsNode != null)
                        {
                            targetSettingsNode = new XElement("AgOpenGPS.Properties.Settings");
                            userSettingsNode.Add(targetSettingsNode);
                            rtbStatus.AppendText($"\nCréé le nœud <AgOpenGPS.Properties.Settings> dans {Path.GetFileName(targetFilePath)}.\n");
                        }
                        else
                        {
                            rtbStatus.AppendText($"\nErreur: Le nœud <AgOpenGPS.Properties.Settings> ni <userSettings> n'ont été trouvés/créés dans le fichier cible: {Path.GetFileName(targetFilePath)}. Ignoré.\n");
                            continue;
                        }
                    }

                    foreach (var settingToCopy in settingsToCopy)
                    {
                        var targetSetting = targetSettingsNode.Elements("setting")
                                                              .FirstOrDefault(s => s.Attribute("name")?.Value == settingToCopy.Name);

                        if (targetSetting != null)
                        {
                            var targetValueElement = targetSetting.Element("value");
                            if (targetValueElement != null)
                            {
                                targetValueElement.RemoveAll();

                                if (settingToCopy.SerializeAs == "Xml" && settingToCopy.ValueXml != null)
                                {
                                    targetValueElement.Add(new XElement(settingToCopy.ValueXml));
                                }
                                else
                                {
                                    targetValueElement.Value = settingToCopy.ValueString;
                                }
                                if (settingToCopy.SerializeAs != null && settingToCopy.SerializeAs != "String")
                                {
                                    targetSetting.SetAttributeValue("serializeAs", settingToCopy.SerializeAs);
                                }
                                else
                                {
                                    targetSetting.Attribute("serializeAs")?.Remove();
                                }
                            }
                            else
                            {
                                rtbStatus.AppendText($"  - Avertissement: Le paramètre '{settingToCopy.Name}' dans {Path.GetFileName(targetFilePath)} n'a pas de nœud <value>. Non mis à jour.\n");
                            }
                        }
                        else
                        {
                            var newSetting = new XElement(
                                "setting",
                                new XAttribute("name", settingToCopy.Name),
                                new XElement("value")
                            );
                            if (settingToCopy.SerializeAs != null && settingToCopy.SerializeAs != "String")
                            {
                                newSetting.SetAttributeValue("serializeAs", settingToCopy.SerializeAs);
                            }
                            var newValueElement = newSetting.Element("value");
                            if (newValueElement != null)
                            {
                                if (settingToCopy.SerializeAs == "Xml" && settingToCopy.ValueXml != null)
                                {
                                    newValueElement.Add(new XElement(settingToCopy.ValueXml));
                                }
                                else
                                {
                                    newValueElement.Value = settingToCopy.ValueString;
                                }
                            }
                            targetSettingsNode.Add(newSetting);
                        }
                    }

                    var xmlWriterSettings = new XmlWriterSettings
                    {
                        Indent = true,
                        OmitXmlDeclaration = true
                    };

                    using (var xmlWriter = XmlWriter.Create(targetFilePath, xmlWriterSettings))
                    {
                        targetDoc.Save(xmlWriter);
                    }

                    rtbStatus.AppendText($"\nCopie terminée pour {Path.GetFileName(targetFilePath)}.\n");

                }
                catch (Exception ex)
                {
                    rtbStatus.AppendText($"\nErreur lors du traitement du fichier {Path.GetFileName(targetFilePath)}: {ex.Message}\n");
                }
            }

            rtbStatus.AppendText("\nProcessus de copie terminé.\n");
            MessageBox.Show("La copie des paramètres est terminée. Vérifiez la fenêtre de statut pour les détails.", "Terminé", MessageBoxButtons.OK);
        }

        // Gérer les clics sur la colonne checkbox dans le DataGridView
        private void dgvSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier si c'est la colonne 'Select' et que le clic est sur une cellule valide
            if (e.ColumnIndex == dgvSettings.Columns["colSelect"].Index && e.RowIndex >= 0)
            {
                // Obtenir la ligne cliquée
                DataGridViewRow row = dgvSettings.Rows[e.RowIndex];

                // Récupérer l'objet SettingInfo original stocké dans le Tag de la ligne
                SettingInfo settingInfo = row.Tag as SettingInfo;

                if (settingInfo != null)
                {
                    // Inverser l'état de sélection dans l'objet SettingInfo original
                    settingInfo.IsSelected = !settingInfo.IsSelected;

                    // Mettre à jour l'affichage de la case à cocher dans la grille (devrait être automatique ou nécessiter InvalidateCell)
                    // dgvSettings.InvalidateCell(e.ColumnIndex, e.RowIndex); // Forcer le redessin si nécessaire

                    // Optionnel: Si vous voulez que la liste affichée change après la sélection/déselection (e.g. si vous filtrez par sélection), ré-appliquer le filtre
                    // txtSearch_TextChanged(null, null); // Simulation pour rafraîchir la vue si un filtre est actif
                }
            }
        }

        // Gérer le changement de texte dans txtSourceFile
        private void txtSourceFile_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSourceFile.Text) && File.Exists(txtSourceFile.Text) && (dgvSettings.Tag == null || !dgvSettings.Tag.Equals(txtSourceFile.Text)))
            {
                LoadSettings(txtSourceFile.Text);
            }
        }

        // Gérer le changement de texte dans txtTargetFolder
        private void txtTargetFolder_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTargetFolder.Text) && Directory.Exists(txtTargetFolder.Text) && (clbTargetFiles.Tag == null || !clbTargetFiles.Tag.Equals(txtTargetFolder.Text)))
            {
                ListTargetFiles(txtTargetFolder.Text);
            }
        }

        // Bouton Sélectionner Paramètres Spécifiques (Stéréo/AutoSteer)
        private void btnSelectSpecificSettings_Click(object sender, EventArgs e)
        {
            if (loadedSettings == null || loadedSettings.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un fichier source XML.", "Information", MessageBoxButtons.OK);
                return;
            }

            HashSet<string> settingsToSelectNames = new HashSet<string>
            {
                "setVehicle_goalPointLookAheadHold",
                "setVehicle_goalPointLookAheadMult",
                "setVehicle_goalPointAcquireFactor",
                "stanleyHeadingErrorGain",
                "stanleyDistanceErrorGain",
                "stanleyIntegralGainAB",
                "purePursuitIntegralGainAB",
                "setVehicle_maxSteerAngle",
                "setAS_countsPerDegree",
                "setAS_ackerman",
                "setAS_wasOffset",
                "setAS_highSteerPWM",
                "setAS_lowSteerPWM",
                "setAS_Kp",
                "setAS_minSteerPWM",
                "setAS_deadZoneHeading",
                "setAS_deadZoneDelay",
                "setAS_ModeXTE",
                "setAS_ModeTime",
                "setWindow_steerSettingsLocation",
                "setAS_uTurnCompensation"
            };

            int selectedCount = 0;
            int foundCount = 0;

            // Parcourir la liste des paramètres chargés (l'originale)
            foreach (var setting in loadedSettings)
            {
                if (settingsToSelectNames.Contains(setting.Name))
                {
                    setting.IsSelected = true;
                    selectedCount++;
                    foundCount++;
                }
            }

            // Ré-afficher les paramètres pour mettre à jour les cases à cocher dans la vue actuelle (filtrée ou non)
            ApplyFilter(txtSearch.Text); // Appliquer le filtre courant ou afficher tout si recherche vide

            int notFoundCount = settingsToSelectNames.Count - foundCount;
            rtbStatus.AppendText($"\nSélection automatique terminée.\n");
            rtbStatus.AppendText($"  - {foundCount} paramètres de la liste cible trouvés et sélectionnés dans le fichier source.\n");
            if (notFoundCount > 0)
            {
                rtbStatus.AppendText($"  - {notFoundCount} paramètres de la liste cible n'ont pas été trouvés dans le fichier source chargé.\n");
                var foundNames = loadedSettings.Where(s => s.IsSelected).Select(s => s.Name).ToList();
                var missingNames = settingsToSelectNames.Except(foundNames).ToList();
                rtbStatus.AppendText($"    Non trouvés dans le source : {string.Join(", ", missingNames)}\n");
            }
            else if (foundCount == 0 && settingsToSelectNames.Count > 0)
            {
                rtbStatus.AppendText($"  - Aucun paramètre de la liste cible n'a été trouvé dans le fichier source chargé.\n");
            }
        }

        // Bouton Sélectionner Paramètres IMU
        private void btnSelectIMUSettings_Click(object sender, EventArgs e)
        {
            if (loadedSettings == null || loadedSettings.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un fichier source XML.", "Information", MessageBoxButtons.OK);
                return;
            }

            string prefixToSelect = "setIMU_";
            int selectedCount = 0;

            // Parcourir la liste chargée (l'originale)
            foreach (var setting in loadedSettings)
            {
                if (setting.Name != null && setting.Name.StartsWith(prefixToSelect, StringComparison.OrdinalIgnoreCase))
                {
                    setting.IsSelected = true;
                    selectedCount++;
                }
            }

            // Ré-afficher les paramètres
            ApplyFilter(txtSearch.Text);

            rtbStatus.AppendText($"\nSélection automatique terminée pour les paramètres '{prefixToSelect}*'.\n");
            rtbStatus.AppendText($"  - {selectedCount} paramètres trouvés et sélectionnés.\n");
            if (selectedCount == 0)
            {
                rtbStatus.AppendText($"  - Aucun paramètre trouvé commençant par '{prefixToSelect}'.\n");
            }
        }

        // Bouton Sélectionner Paramètres Véhicule
        private void btnSelectVehicleSettings_Click(object sender, EventArgs e)
        {
            if (loadedSettings == null || loadedSettings.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un fichier source XML.", "Information", MessageBoxButtons.OK);
                return;
            }

            string prefixToSelect = "setVehicle_";
            int selectedCount = 0;

            // Parcourir la liste chargée (l'originale)
            foreach (var setting in loadedSettings)
            {
                if (setting.Name != null && setting.Name.StartsWith(prefixToSelect, StringComparison.OrdinalIgnoreCase))
                {
                    setting.IsSelected = true;
                    selectedCount++;
                }
            }

            // Ré-afficher les paramètres
            ApplyFilter(txtSearch.Text);

            rtbStatus.AppendText($"\nSélection automatique terminée pour les paramètres '{prefixToSelect}*'.\n");
            rtbStatus.AppendText($"  - {selectedCount} paramètres trouvés et sélectionnés.\n");
            if (selectedCount == 0)
            {
                rtbStatus.AppendText($"  - Aucun paramètre trouvé commençant par '{prefixToSelect}'.\n");
            }
        }

        // Bouton Tout Décocher
        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            if (loadedSettings == null || loadedSettings.Count == 0)
            {
                return;
            }

            int previouslySelectedCount = loadedSettings.Count(s => s.IsSelected);

            // Parcourir la liste des paramètres chargés (l'originale) et tout décocher
            foreach (var setting in loadedSettings)
            {
                setting.IsSelected = false;
            }

            // Ré-afficher les paramètres
            ApplyFilter(txtSearch.Text);

            if (previouslySelectedCount > 0)
            {
                rtbStatus.AppendText($"\n{previouslySelectedCount} paramètres précédemment sélectionnés ont été décochés.\n");
            }
            else
            {
                rtbStatus.AppendText($"\nAucun paramètre n'était sélectionné.\n");
            }
        }

        // Gérer le changement de texte dans le champ de recherche
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(txtSearch.Text); // Appliquer le filtre chaque fois que le texte change
        }

        // Nouvelle méthode pour appliquer le filtre et mettre à jour l'affichage
        private void ApplyFilter(string searchTerm)
        {
            if (loadedSettings == null) return; // Ne rien faire si les paramètres ne sont pas chargés

            var filteredSettings = new List<SettingInfo>();
            string lowerSearchTerm = searchTerm.Trim().ToLower();

            if (string.IsNullOrEmpty(lowerSearchTerm))
            {
                // Si le terme de recherche est vide, afficher tous les paramètres chargés
                filteredSettings = loadedSettings;
                rtbStatus.AppendText($"\nFiltre de recherche supprimé. Affichage de tous les paramètres ({loadedSettings.Count}).\n");
            }
            else
            {
                // Filtrer la liste chargée
                filteredSettings = loadedSettings.Where(setting =>
                    setting.Name != null && setting.Name.ToLower().Contains(lowerSearchTerm) ||
                    setting.ValueString != null && setting.ValueString.ToLower().Contains(lowerSearchTerm)
                ).ToList();
                rtbStatus.AppendText($"\nFiltre appliqué: \"{searchTerm}\". Affiche {filteredSettings.Count} paramètres.\n");
            }

            // Mettre à jour le DataGridView avec les paramètres filtrés
            DisplaySettings(filteredSettings);
        }


        // Bouton pour effacer le champ de recherche et le filtre
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); // Ceci déclenchera txtSearch_TextChanged et appellera ApplyFilter avec un terme vide
        }

        // Votre méthode FormMultiSettings_Load
        private void FormMultiSettings_Load(object sender, EventArgs e)
        {

            if (RegistrySettings.vehicleFileName != "")
            {
                txtSourceFile.Text = Path.Combine(RegistrySettings.vehiclesDirectory, RegistrySettings.vehicleFileName + ".XML").ToString();
                // Appeler LoadSettings qui chargera et affichera
                LoadSettings(txtSourceFile.Text);
                dgvSettings.Tag = txtSourceFile.Text; // Conserver pour la logique de décochage dans ListTargetFiles
            }
            if (RegistrySettings.vehiclesDirectory != "")
            {
                txtTargetFolder.Text = RegistrySettings.vehiclesDirectory;
                // Appeler ListTargetFiles qui listera et décochera le source
                ListTargetFiles(RegistrySettings.vehiclesDirectory);
                clbTargetFiles.Tag = RegistrySettings.vehiclesDirectory; // Stocker le chemin chargé
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTargetFolder_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // Note: La classe RegistrySettings doit être définie ailleurs dans votre projet AgOpenGPS.
    // Elle est nécessaire pour que FormMultiSettings_Load compile.
    // Exemple (si elle était dans un fichier séparé ou le même namespace):
    // public static class RegistrySettings
    // {
    //     public static string vehicleFileName = ""; // Assurez-vous que ces propriétés sont définies et initialisées quelque part
    //     public static string vehiclesDirectory = "";
    // }
}