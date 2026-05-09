using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS.Updater.Forms
{
    /// <summary>
    /// Custom styled dialog box for AgOpenGPS Updater.
    /// </summary>
    public partial class FormDialog : Form
    {
        private DialogResult _result = DialogResult.Cancel;

        public FormDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows a confirmation dialog.
        /// </summary>
        public static DialogResult ShowConfirm(Form parent, string title, string message, string okText = "Yes", string cancelText = "No")
        {
            using (var dialog = new FormDialog())
            {
                dialog.Text = title;
                dialog.lblMessage.Text = message;
                dialog.btnOK.Text = okText;
                dialog.btnCancel.Text = cancelText;
                dialog.lblIcon.Text = "?";
                dialog.panelIcon.BackColor = Color.FromArgb(27, 151, 160);
                dialog.StartPosition = FormStartPosition.CenterParent;

                // Auto-size based on message
                dialog.PerformLayout();

                // Adjust width if message is long
                using (var g = Graphics.FromHwnd(dialog.Handle))
                {
                    var size = g.MeasureString(message, dialog.lblMessage.Font);
                    int neededWidth = (int)Math.Ceiling(size.Width) + 120; // icon + padding
                    if (neededWidth > 550)
                    {
                        dialog.Width = Math.Min(neededWidth + 40, 800);
                    }
                }

                if (parent != null && !parent.IsDisposed)
                    dialog.ShowDialog(parent);
                else
                    dialog.ShowDialog();

                return dialog._result;
            }
        }

        /// <summary>
        /// Shows an information dialog.
        /// </summary>
        public static DialogResult ShowInfo(Form parent, string title, string message)
        {
            using (var dialog = new FormDialog())
            {
                dialog.Text = title;
                dialog.lblMessage.Text = message;
                dialog.btnOK.Text = "OK";
                dialog.btnCancel.Visible = false;
                dialog.lblIcon.Text = "i";
                dialog.panelIcon.BackColor = Color.FromArgb(27, 151, 160);
                dialog.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                dialog.btnOK.Location = new Point(280, 15);
                dialog.StartPosition = FormStartPosition.CenterParent;

                if (parent != null && !parent.IsDisposed)
                    dialog.ShowDialog(parent);
                else
                    dialog.ShowDialog();

                return dialog._result;
            }
        }

        /// <summary>
        /// Shows an error dialog.
        /// </summary>
        public static DialogResult ShowError(Form parent, string title, string message)
        {
            using (var dialog = new FormDialog())
            {
                dialog.Text = title;
                dialog.lblMessage.Text = message;
                dialog.btnOK.Text = "OK";
                dialog.btnCancel.Visible = false;
                dialog.lblIcon.Text = "!";
                dialog.panelIcon.BackColor = Color.FromArgb(220, 60, 60);
                dialog.btnOK.BackColor = Color.FromArgb(220, 60, 60);
                dialog.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                dialog.btnOK.Location = new Point(280, 15);
                dialog.StartPosition = FormStartPosition.CenterParent;

                if (parent != null && !parent.IsDisposed)
                    dialog.ShowDialog(parent);
                else
                    dialog.ShowDialog();

                return dialog._result;
            }
        }

        /// <summary>
        /// Shows a success dialog.
        /// </summary>
        public static DialogResult ShowSuccess(Form parent, string title, string message)
        {
            using (var dialog = new FormDialog())
            {
                dialog.Text = title;
                dialog.lblMessage.Text = message;
                dialog.btnOK.Text = "OK";
                dialog.btnCancel.Visible = false;
                dialog.lblIcon.Text = "✓";
                dialog.panelIcon.BackColor = Color.FromArgb(40, 167, 69);
                dialog.btnOK.BackColor = Color.FromArgb(40, 167, 69);
                dialog.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                dialog.btnOK.Location = new Point(280, 15);
                dialog.StartPosition = FormStartPosition.CenterParent;

                if (parent != null && !parent.IsDisposed)
                    dialog.ShowDialog(parent);
                else
                    dialog.ShowDialog();

                return dialog._result;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            _result = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Cancel;
            this.Close();
        }
    }
}
