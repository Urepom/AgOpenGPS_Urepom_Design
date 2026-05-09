using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS.Updater.Forms
{
    /// <summary>
    /// Dialog for displaying release notes.
    /// </summary>
    public partial class FormReleaseNotes : Form
    {
        public FormReleaseNotes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows release notes in a dialog.
        /// </summary>
        public static void ShowReleaseNotes(Form parent, string title, string version, string releaseNotes)
        {
            using (var dialog = new FormReleaseNotes())
            {
                dialog.Text = title;
                dialog.lblTitle.Text = $"Release Notes - {version}";
                dialog.txtNotes.Text = !string.IsNullOrEmpty(releaseNotes) ? releaseNotes : "No release notes available.";
                dialog.StartPosition = FormStartPosition.CenterParent;

                if (parent != null && !parent.IsDisposed)
                    dialog.ShowDialog(parent);
                else
                    dialog.ShowDialog();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
