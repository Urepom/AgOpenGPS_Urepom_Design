using AgOpenGPS.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{

        public partial class FormSynchro : Form
    {
        public FormSynchro(FormGPS formGPS)
        {
            InitializeComponent();
        }

        private void FormSynchro_Load(object sender, EventArgs e)
        {
            FormGPS.DirectoryCopy(Settings.Default.setF_local, Settings.Default.setF_synchro, true);
            FormGPS.DirectoryCopy(Settings.Default.setF_synchro, Settings.Default.setF_local, true);
            Close();
        }
    }
}
