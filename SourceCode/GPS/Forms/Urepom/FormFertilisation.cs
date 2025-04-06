using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgOpenGPS.Culture;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using AgOpenGPS.Controls;

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
            mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti) >> 8));
            mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti)));
        }

        private void cboxFertiActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxFertiActive.Checked == true)
            {
                if (cbox_auto.Checked == true)
                {
                    cbox_auto.Checked = false;
                }
                if (cboxRincage.Checked == true)
                {
                    cboxRincage.Checked = false;
                }
                if (cboxvidange.Checked == true)
                {
                    cboxvidange.Checked = false;
                }
                mf.ferti_auto = false;

                mf.Ferti_active = true;
                //cbox_auto.Checked = false;
                //cboxFertiActive.Checked = true;
                cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryStop;
                mf.p_240.pgn[mf.p_240.Ferti_On] = 1;
                mf.p_240.pgn[mf.p_240.Rincage] = 0;
                mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti) >> 8));
                mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti)));

            }
            else
            {
                mf.Ferti_active = false;
                //cboxFertiActive.Checked = false;
                cboxFertiActive.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
                mf.p_240.pgn[mf.p_240.Ferti_On] = 0;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (cbox_auto.Checked == true)
            {
                cbox_auto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOn;
                mf.ferti_auto = true;
                //mf.Ferti_active = true;
                //cbox_auto.Checked = true;
                mf.p_240.pgn[mf.p_240.Ferti_On] = 1;
                mf.p_240.pgn[mf.p_240.Rincage] = 0;
                mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti) >> 8));
                mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti)));

                if (mf.autoBtnState == btnStates.Off)
                {
                    mf.btnSectionMasterAuto.PerformClick();
                }

                if (cboxFertiActive.Checked == true)
                {
                    cboxFertiActive.Checked = false;
                }
                if (cboxRincage.Checked == true)
                {
                    cboxRincage.Checked = false;
                }
                if (cboxvidange.Checked == true)
                {
                    cboxvidange.Checked = false;
                }

            }
            else
            {
                cbox_auto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
                mf.ferti_auto = false;
                // mf.Ferti_active = false;
                //cbox_auto.Checked = false;
                mf.p_240.pgn[mf.p_240.Ferti_On] = 0;
                if (mf.autoBtnState == btnStates.Auto)
                {
                    mf.btnSectionMasterAuto.PerformClick();
                }

            }
        }

        private void FormFertilisation_Load(object sender, EventArgs e)
        {
            this.Width = 284;
            timer2.Start();
            nudDoseFerti.Value = Properties.Settings.Default.UP_SetDoseFerti;
            numTimerRincage.Value = Properties.Settings.Default.UP_SetTimerRincFerti;
            numericUpDown1.Value = (Properties.Settings.Default.UP_SetDoseFVidange / 60) * 3;
            cboxFertiActive.Checked = mf.Ferti_active;
            cbox_auto.Checked = mf.ferti_auto;

        }

        private void cboxRincage_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxRincage.Checked == true)
            {
                timer1.Interval = Convert.ToInt32(numTimerRincage.Value) * 1000;
                timer1.Start();
                mf.ferti_auto = false;
                mf.p_240.pgn[mf.p_240.Rincage] = 1;
                if (cboxFertiActive.Checked == true)
                {
                    cboxFertiActive.Checked = false;
                }
                if (cbox_auto.Checked == true)
                {
                    cbox_auto.Checked = false;
                }
                if (cboxvidange.Checked == true)
                {
                    cboxvidange.Checked = false;
                }

            }
            if (cboxRincage.Checked == false)
            {
                mf.p_240.pgn[mf.p_240.Rincage] = 0;
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
            mf.p_240.pgn[mf.p_240.Rincage] = 0;
            // }
        }

        private void numTimerRincage_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UP_SetTimerRincFerti = Convert.ToInt32(numTimerRincage.Value);
        }

        private void FormFertilisation_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.p_240.pgn[mf.p_240.Rincage] = 0;
            timer1.Stop();
        }

        private void nudDoseFerti_Click(object sender, EventArgs e)
        {
            if (((NudlessNumericUpDown)sender).ShowKeypad(this))
            {
                Properties.Settings.Default.UP_SetDoseFerti = nudDoseFerti.Value;
                mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti) >> 8));
                mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFerti)));
            }
        }

        private void numTimerRincage_Click(object sender, EventArgs e)
        {
            if (((NudlessNumericUpDown)sender).ShowKeypad(this))
            {
                Properties.Settings.Default.UP_SetTimerRincFerti = Convert.ToInt32(numTimerRincage.Value);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = (Math.Round((mf.Débit_Pompe_Ferti / ((mf.pn.speed * mf.tool.width) / 10)), 2)).ToString();
            label4.Text = mf.PWD_Pompe_Ferti.ToString();
            label5.Text = mf.Vol_Pompe_Ferti.ToString() + " l";
            timer2.Start();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.Width == 284)
            {
                checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.Width = 393;

            }
            else
            {
                checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Width = 284;
            }
        }

        private void cboxvidange_CheckedChanged(object sender, EventArgs e)
        {

            if (cboxvidange.Checked == true)
            {
                if (cboxFertiActive.Checked == true)
                {
                    cboxFertiActive.Checked = false;
                }
                if (cbox_auto.Checked == true)
                {
                    cbox_auto.Checked = false;
                }
                if (cboxRincage.Checked == true)
                {
                    cboxRincage.Checked = false;
                }
                mf.ferti_auto = false;

                mf.ferti_vidange = true;

                mf.p_240.pgn[mf.p_240.Rincage] = 0;
                mf.p_240.pgn[mf.p_240.Ferti_On] = 1;

                int largeur = 3;
                mf.p_240.pgn[mf.p_240.LargeurHi] = unchecked((byte)(((short)largeur) >> 8));
                mf.p_240.pgn[mf.p_240.LargeurLo] = unchecked((byte)(((short)largeur)));

                int speed = 100;
                mf.p_240.pgn[mf.p_240.speedHi] = unchecked((byte)(((short)speed) >> 8));
                mf.p_240.pgn[mf.p_240.speedLo] = unchecked((byte)(((short)speed)));

                mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange) >> 8));
                mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange)));

            }
            else
            {
                mf.p_240.pgn[mf.p_240.Ferti_On] = 0;
                mf.ferti_vidange = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UP_SetDoseFVidange = (numericUpDown1.Value * 60) / 3;
            mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange) >> 8));
            mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange)));
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            if (((NudlessNumericUpDown)sender).ShowKeypad(this))
            {
                Properties.Settings.Default.UP_SetDoseFVidange = (numericUpDown1.Value * 60) / 3;
                mf.p_240.pgn[mf.p_240.DebitHi] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange) >> 8));
                mf.p_240.pgn[mf.p_240.DebitLo] = unchecked((byte)(((short)Properties.Settings.Default.UP_SetDoseFVidange)));
            }
        }
    }
}
