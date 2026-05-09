using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AgLibrary.Logging;
using AgLibrary.Settings;
using AgOpenGPS;
using AgOpenGPS.Controls;
using AgOpenGPS.Core.Translations;
using AgOpenGPS.Properties;

namespace AgOpenGPS.Forms.Profiles
{
    public partial class FormConvertProfiles : Form
    {
        private readonly FormGPS _formGPS;

        // Toggle states
        private bool vehicleEnabled = true;
        private bool toolEnabled = true;

        public FormConvertProfiles(FormGPS formGPS)
        {
            _formGPS = formGPS;
            InitializeComponent();
        }

        private void FormConvertProfiles_Load(object sender, EventArgs e)
        {
            // Set localized form title and labels
            this.Text = gStr.gsConvertOldProfiles;
            labelTitle.Text = gStr.gsConvertOldProfilesTitle;
            labelExplanation.Text = gStr.gsConvertProfilesExplanation;
            labelStep1.Text = gStr.gsConvertStep1 + ": " + "Select an old profile file";
            labelStep2.Text = gStr.gsConvertStep2 + ": " + "Select to convert (Vehicle and/or Tool)";
            labelVehicleName.Text = gStr.gsVehicleProfileName + ":";
            labelToolName.Text = gStr.gsToolProfileName + ":";
            buttonClose.Text = gStr.gsClose;

            RefreshFileList();
            ClearDetails();
            UpdateToggleButtons();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (_formGPS?.isKeyboardOn == true)
            {
                ((TextBox)sender).ShowKeyboard(this);
                buttonConvert.Focus();
            }
        }

        private void RefreshFileList()
        {
            RefreshFileList(clearDetails: true);
        }

        private void RefreshFileList(bool clearDetails)
        {
            // Remember current selection
            string selectedName = null;
            if (listViewFiles.SelectedItems.Count > 0)
            {
                selectedName = listViewFiles.SelectedItems[0].Text;
            }

            listViewFiles.Items.Clear();

            string[] files = CSettingsMigration.GetConvertibleFiles();
            int convertedCount = 0;

            foreach (string name in files.OrderBy(n => n))
            {
                var item = new ListViewItem(name) { Name = name };
                // Color converted files green
                if (CSettingsMigration.IsConverted(name))
                {
                    item.BackColor = Color.LightGreen;
                    convertedCount++;
                }
                listViewFiles.Items.Add(item);
            }

            if (listViewFiles.Items.Count == 0)
            {
                labelStatus.Text = gStr.gsNoOldFormatFiles;
            }
            else
            {
                int unconverted = listViewFiles.Items.Count - convertedCount;
                labelStatus.Text = listViewFiles.Items.Count + " " + gStr.gsOldFiles + ": " +
                    convertedCount + " " + gStr.gsConverted + ", " + unconverted + " " + gStr.gsToConvert;
            }

            if (clearDetails)
            {
                ClearDetails();
            }
            else if (selectedName != null)
            {
                // Restore selection if item still exists
                foreach (ListViewItem item in listViewFiles.Items)
                {
                    if (item.Name == selectedName)
                    {
                        item.Selected = true;
                        item.Focused = true;
                        break;
                    }
                }
            }
        }

        private void ClearDetails()
        {
            textBoxVehicleName.Text = "";
            textBoxToolName.Text = "";
            vehicleEnabled = true;
            toolEnabled = true;
            panelDetails.Enabled = false;
            buttonConvert.Enabled = false;
            UpdateToggleButtons();
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                string selected = listViewFiles.SelectedItems[0].Text;
                textBoxVehicleName.Text = selected;
                textBoxToolName.Text = selected;
                vehicleEnabled = true;
                toolEnabled = true;
                panelDetails.Enabled = true;
                UpdateToggleButtons();
            }
            else
            {
                ClearDetails();
            }
        }

        private void btnToggleVehicle_Click(object sender, EventArgs e)
        {
            vehicleEnabled = !vehicleEnabled;
            UpdateToggleButtons();
            UpdateConvertButton();
        }

        private void btnToggleTool_Click(object sender, EventArgs e)
        {
            toolEnabled = !toolEnabled;
            UpdateToggleButtons();
            UpdateConvertButton();
        }

        private void UpdateToggleButtons()
        {
            // Vehicle button
            if (vehicleEnabled)
            {
                btnToggleVehicle.Text = gStr.gsImportVehicle;
                btnToggleVehicle.BackColor = Color.LightGreen;
                textBoxVehicleName.Enabled = true;
            }
            else
            {
                btnToggleVehicle.Text = gStr.gsNoImport;
                btnToggleVehicle.BackColor = Color.LightGray;
                textBoxVehicleName.Enabled = false;
            }

            // Tool button
            if (toolEnabled)
            {
                btnToggleTool.Text = gStr.gsImportTool;
                btnToggleTool.BackColor = Color.LightGreen;
                textBoxToolName.Enabled = true;
            }
            else
            {
                btnToggleTool.Text = gStr.gsNoImport;
                btnToggleTool.BackColor = Color.LightGray;
                textBoxToolName.Enabled = false;
            }
        }

        private void UpdateConvertButton()
        {
            // At least one of Vehicle or Tool must be selected
            bool hasSelection = listViewFiles.SelectedItems.Count > 0;
            bool vehicleValid = !vehicleEnabled || !string.IsNullOrWhiteSpace(textBoxVehicleName.Text);
            bool toolValid = !toolEnabled || !string.IsNullOrWhiteSpace(textBoxToolName.Text);
            bool atLeastOne = vehicleEnabled || toolEnabled;

            buttonConvert.Enabled = hasSelection && vehicleValid && toolValid && atLeastOne;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var pos = tb.SelectionStart;
            tb.Text = Regex.Replace(tb.Text, glm.fileRegex, "");
            tb.SelectionStart = pos;

            UpdateConvertButton();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;

            string sourceFile = listViewFiles.SelectedItems[0].Text;
            bool exportVehicle = vehicleEnabled;
            string vehicleName = exportVehicle ? textBoxVehicleName.Text.Trim() : null;
            bool exportTool = toolEnabled;
            string toolName = exportTool ? textBoxToolName.Text.Trim() : null;

            // Validate
            if (exportVehicle && string.IsNullOrEmpty(vehicleName)) return;
            if (exportTool && string.IsNullOrEmpty(toolName)) return;

            // Check for existing files - block duplicate names
            if (exportVehicle)
            {
                string vehiclePath = Path.Combine(RegistrySettings.vehiclesDirectory, vehicleName + ".xml");
                if (File.Exists(vehiclePath))
                {
                    FormDialog.Show(gStr.gsExists, gStr.gsVehicleAlreadyExists + " '" + vehicleName + "'", DialogSeverity.Error);
                    return;
                }
            }

            if (exportTool)
            {
                string toolPath = Path.Combine(RegistrySettings.toolsDirectory, toolName + ".xml");
                if (File.Exists(toolPath))
                {
                    FormDialog.Show(gStr.gsExists, gStr.gsToolAlreadyExists + " '" + toolName + "'", DialogSeverity.Error);
                    return;
                }
            }

            string confirmMsg = gStr.gsConvertFrom + " '" + sourceFile + "':\n\n";
            if (exportVehicle)
                confirmMsg += "  " + gStr.gsConvertVehicleLine + ": " + vehicleName + "\n";
            if (exportTool)
                confirmMsg += "  " + gStr.gsConvertToolLine + ": " + toolName + "\n";

            var confirm = FormDialog.ShowQuestion(gStr.gsConvertConfirm, confirmMsg);
            if (confirm != DialogResult.OK) return;

            var errors = new List<string>();

            // Convert Vehicle (optional)
            if (exportVehicle)
            {
                var vSettings = new VehicleSettings();
                var vResult = CSettingsMigration.MigrateVehicle(sourceFile, vehicleName, vSettings);
                if (vResult != LoadResult.Ok)
                {
                    errors.Add($"Vehicle: {vResult}");
                    Log.ErrorWriter(sourceFile, "Vehicle", vResult.ToString());
                }
            }

            // Convert Tool (optional)
            if (exportTool)
            {
                var tSettings = new ToolSettings();
                var tResult = CSettingsMigration.MigrateTool(sourceFile, toolName, tSettings);
                if (tResult != LoadResult.Ok)
                {
                    errors.Add($"Tool: {tResult}");
                    Log.ErrorWriter(sourceFile, "Tool", tResult.ToString());
                }
            }

            // One-time environment migration (if environment.xml doesn't exist yet)
            bool migratedEnvironment = false;
            string envPath = Path.Combine(RegistrySettings.environmentDirectory, "environment.xml");
            if (!File.Exists(envPath))
            {
                var eResult = CSettingsMigration.MigrateEnvironment(sourceFile, "environment");
                if (eResult == LoadResult.Ok)
                {
                    migratedEnvironment = true;
                    Log.EventWriter($"Environment migrated from '{sourceFile}'");
                }
                else
                {
                    errors.Add($"Environment: {eResult}");
                    Log.ErrorWriter(sourceFile, "Environment", eResult.ToString());
                }
            }

            if (errors.Count == 0)
            {
                // Mark old file as converted
                CSettingsMigration.MarkAsConverted(sourceFile);

                string logMsg = $"Converted '{sourceFile}' -> " +
                    (exportVehicle ? $"Vehicle:'{vehicleName}', " : "") +
                    (exportTool ? $"Tool:'{toolName}'" : "");
                if (migratedEnvironment)
                    logMsg += ", Environment: 'environment.xml' (one-time)";
                Log.EventWriter(logMsg);

                // If Environment was migrated, load it immediately
                if (migratedEnvironment)
                {
                    var loadResult = Properties.Settings.Default.Load();
                    if (loadResult == LoadResult.Ok)
                    {
                        _formGPS.LoadSettings();
                        Log.EventWriter("Environment settings loaded after migration");
                    }
                }

                string successMsg = "'" + sourceFile + "' " + gStr.gsConvertedSuccess;
                if (migratedEnvironment)
                    successMsg += "\n\n" + gStr.gsEnvironmentMigratedLoaded;

                FormDialog.Show(gStr.gsConversionComplete, successMsg, DialogSeverity.Info);

                // Refresh list to show converted file in green, keep form open for next conversion
                RefreshFileList(clearDetails: false);
            }
            else
            {
                Log.EventWriter($"Errors converting '{sourceFile}': {string.Join(", ", errors)}");
                FormDialog.Show(gStr.gsConversionErrors,
                    gStr.gsConversionErrorMsg + ": " + Environment.NewLine + string.Join("\n", errors), DialogSeverity.Warning);
            }
        }
    }
}
