using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConnectedServices : Form
    {
        public readonly FormGPS mf = null;
        public FormConnectedServices(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void Traccar_button_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormTraccar"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }
            Form form = new FormTraccar(this);
            form.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormSynchro"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }
            Form form = new FormSynchro(this);
            form.Show(this);
        }

        private void Dropbox_button_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormDropboxSync"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }
            Form form = new FormDropboxSync(this);
            form.Show(this);
        }

        private void Gdrive_button_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGdrive_Sync"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }
            Form form = new FormGdrive_Sync(this);
            form.Show(this);
        }

        private void Synchthing_button_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormSyncthingSync"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }
            Form form = new FormSyncthingSync(this);
            form.Show(this);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
