using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormFertilisation : Form
    {
        public readonly FormGPS mf = null;

        public FormFertilisation(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nudDoseFerti_ValueChanged(object sender, EventArgs e)
        {
            mf.p_235.pgn[mf.p_235.DebitHi] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti) >> 8));
            mf.p_235.pgn[mf.p_235.DebitLo] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti)));
        }

        private void cboxFertiActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxFertiActive.Checked == true)
            {
                mf.Ferti_active = true;
                //cbox_auto.Checked = false;
                //cboxFertiActive.Checked = true;
                cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryStop;
                mf.p_235.pgn[mf.p_235.Ferti_On] = 1;
                mf.p_235.pgn[mf.p_235.Rincage] = 0;
                mf.p_235.pgn[mf.p_235.DebitHi] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti) >> 8));
                mf.p_235.pgn[mf.p_235.DebitLo] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti)));
                if (cbox_auto.Checked == true)
                {
                    cbox_auto.Checked = false;
                }
                if (cboxRincage.Checked == true)
                {
                    cboxRincage.Checked = false;
                }

            }
            else
            {
                mf.Ferti_active = false;
                //cboxFertiActive.Checked = false;
                cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
                mf.p_235.pgn[mf.p_235.Ferti_On] = 0;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (cbox_auto.Checked == true)
            {
                mf.ferti_auto = true;
                //mf.Ferti_active = true;
                //cbox_auto.Checked = true;
                //mf.p_235.pgn[mf.p_235.Ferti_On] = 1;
                mf.p_235.pgn[mf.p_235.Rincage] = 0;
                mf.p_235.pgn[mf.p_235.DebitHi] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti) >> 8));
                mf.p_235.pgn[mf.p_235.DebitLo] = unchecked((byte)(((short)Properties.Vehicle.Default.SetDoseFerti)));

                if (mf.autoBtnState == FormGPS.btnStates.Off)
                {
                    mf.btnSectionOffAutoOn.PerformClick();
                }

                if (cboxFertiActive.Checked == true)
                {
                    cboxFertiActive.Checked = false;
                }
                if (cboxRincage.Checked == true)
                {
                    cboxRincage.Checked = false;
                }

            }
            else
            {
                mf.ferti_auto = false;
                // mf.Ferti_active = false;
                //cbox_auto.Checked = false;
                mf.p_235.pgn[mf.p_235.Ferti_On] = 0;

            }
        }

        private void FormFertilisation_Load(object sender, EventArgs e)
        {
            nudDoseFerti.Value = Properties.Vehicle.Default.SetDoseFerti;
            numTimerRincage.Value = Properties.Vehicle.Default.SetTimerRincFerti;
            cboxFertiActive.Checked = mf.Ferti_active;
            cbox_auto.Checked = mf.ferti_auto;
        }

        private void cboxRincage_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxRincage.Checked == true)
            {
                timer1.Interval = Convert.ToInt32(numTimerRincage.Value) * 1000;
                timer1.Start();
                mf.p_235.pgn[mf.p_235.Rincage] = 1;
                if (cboxFertiActive.Checked == true)
                {
                    cboxFertiActive.Checked = false;
                }
                if (cbox_auto.Checked == true)
                {
                    cbox_auto.Checked = false;
                }
            }
            if (cboxRincage.Checked == false)
            {
                mf.p_235.pgn[mf.p_235.Rincage] = 0;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            cboxRincage.Checked = false;
            // if (cboxFertiActive.Checked ==false && cbox_auto.Checked == false)
            // {
            mf.ferti_rincage = false;
            mf.p_235.pgn[mf.p_235.Rincage] = 0;
            // }
        }

        private void numTimerRincage_ValueChanged(object sender, EventArgs e)
        {
            Properties.Vehicle.Default.SetTimerRincFerti = Convert.ToInt32(numTimerRincage.Value);
        }

        private void FormFertilisation_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.p_235.pgn[mf.p_235.Rincage] = 0;
            timer1.Stop();
        }

        private void nudDoseFerti_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.SetDoseFerti = nudDoseFerti.Value;
            }
        }

        private void numTimerRincage_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.SetTimerRincFerti = Convert.ToInt32(numTimerRincage.Value);
            }
        }
    }
}
