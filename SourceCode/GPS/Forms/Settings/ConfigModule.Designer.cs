﻿using System;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {

        #region Module Steer
        private void tabASteer_Enter(object sender, EventArgs e)
        {
            nudMaxCounts.Controls[0].Enabled = false;

            int sett = Properties.Vehicle.Default.setArdSteer_setting0;

            if ((sett & 1) == 0) chkInvertWAS.Checked = false;
            else chkInvertWAS.Checked = true;

            if ((sett & 2) == 0) chkSteerInvertRelays.Checked = false;
            else chkSteerInvertRelays.Checked = true;

            if ((sett & 4) == 0) chkInvertSteer.Checked = false;
            else chkInvertSteer.Checked = true;

            if ((sett & 8) == 0) cboxConv.Text = "Differential";
            else cboxConv.Text = "Single";

            if ((sett & 16) == 0) cboxMotorDrive.Text = "IBT2";
            else cboxMotorDrive.Text = "Cytron";

            if ((sett & 32) == 32) cboxSteerEnable.Text = "Switch";
            else if ((sett & 64) == 64) cboxSteerEnable.Text = "Button";
            else cboxSteerEnable.Text = "None";

            if ((sett & 128) == 0) cboxEncoder.Checked = false;
            else cboxEncoder.Checked = true;

            nudMaxCounts.Value = (decimal)Properties.Vehicle.Default.setArdSteer_maxPulseCounts;

            sett = Properties.Vehicle.Default.setArdSteer_setting1;

            if ((sett & 1) == 0) cboxDanfoss.Checked = false;
            else cboxDanfoss.Checked = true;

            if ((sett & 2) == 0) cboxPressureSensor.Checked = false;
            else cboxPressureSensor.Checked = true;

            if ((sett & 4) == 0) cboxCurrentSensor.Checked = false;
            else cboxCurrentSensor.Checked = true;

            if (cboxEncoder.Checked)
            {
                cboxPressureSensor.Checked = false;
                cboxCurrentSensor.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsEncoderCounts;
            }
            else if (cboxPressureSensor.Checked)
            {
                cboxEncoder.Checked = false;
                cboxCurrentSensor.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsPressureSensorValueLabel;
            }
            else if (cboxCurrentSensor.Checked)
            {
                cboxPressureSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsCurrentSensorValueLabel;
            }
            else
            {
                cboxPressureSensor.Checked = false;
                cboxCurrentSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = false;
                nudMaxCounts.Visible = false;
            }
        }

        private void tabASteer_Leave(object sender, EventArgs e)
        {
            pboxSendSteer.Visible = false;
        }

        private void btnSendToSteerArduino_Click(object sender, EventArgs e)
        {
            SaveSettings();
            mf.SendPgnToLoop(mf.p_251.pgn);
            pboxSendSteer.Visible = false;

            mf.TimedMessageBox(1000, gStr.gsAutoSteerPort, "Settings Sent To Steer Module");
        }

        private void nudMaxCounts_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendSteer.Visible = true;
            }
        }

        private void EnableAlert_Click(object sender, EventArgs e)
        {
            pboxSendSteer.Visible = true;

            if (sender is CheckBox)
            {
                var checkbox = (CheckBox)sender;

                if (!checkbox.Checked)
                {
                    cboxPressureSensor.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    cboxEncoder.Checked = false;
                    label61.Visible = false;
                    nudMaxCounts.Visible = false;
                    return;
                }

                if (checkbox == cboxPressureSensor)
                {
                    cboxEncoder.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;
                    label61.Text = gStr.gsPressureSensorValueLabel;
                }

                else if (checkbox == cboxCurrentSensor)
                {
                    cboxPressureSensor.Checked = false;
                    cboxEncoder.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;
                    label61.Text = gStr.gsCurrentSensorValueLabel;
                }
                else if (checkbox == cboxEncoder)
                {
                    cboxPressureSensor.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;

                    label61.Text = gStr.gsEncoderCounts;
                }
            }
        }

        private void SaveSettings()
        {

            int set = 1;
            int reset = 2046;
            int sett = 0;

            if (chkInvertWAS.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (chkSteerInvertRelays.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (chkInvertSteer.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxConv.Text == "Single") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxMotorDrive.Text == "Cytron") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxSteerEnable.Text == "Switch") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxSteerEnable.Text == "Button") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxEncoder.Checked) sett |= set;
            else sett &= reset;

            //set = (set << 1);
            //reset = (reset << 1);
            //reset = (reset + 1);
            //if ( ) sett |= set;
            //else sett &= reset;

            Properties.Vehicle.Default.setArdSteer_setting0 = (byte)sett;
            Properties.Vehicle.Default.setArdSteer_maxPulseCounts = (byte)nudMaxCounts.Value;
            Properties.Vehicle.Default.setArdMac_isDanfoss = cboxDanfoss.Checked;

            // Settings1
            set = 1;
            reset = 2046;
            sett = 0;

            if (cboxDanfoss.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxPressureSensor.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxCurrentSensor.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdSteer_setting1 = (byte)sett;

            Properties.Vehicle.Default.Save();

            mf.p_251.pgn[mf.p_251.set0] = Properties.Vehicle.Default.setArdSteer_setting0;
            mf.p_251.pgn[mf.p_251.set1] = Properties.Vehicle.Default.setArdSteer_setting1;
            mf.p_251.pgn[mf.p_251.maxPulse] = Properties.Vehicle.Default.setArdSteer_maxPulseCounts;
            mf.p_251.pgn[mf.p_251.minSpeed] = 5; //0.5 kmh

            if (Properties.Settings.Default.setAS_isAngVelGuidance)
                mf.p_251.pgn[mf.p_251.angVel] = 1;
            else mf.p_251.pgn[mf.p_251.angVel] = 0;

            pboxSendSteer.Visible = false;
        }

        #endregion
        private void Enable_AlertM_Click(object sender, EventArgs e)
        {
            pboxSendMachine.Visible = true;
        }

        #region Module MAchine

        private void tabAMachine_Enter(object sender, EventArgs e)
        {

            int sett = Properties.Vehicle.Default.setArdMac_setting0;

            if ((sett & 1) == 0) cboxMachInvertRelays.Checked = false;
            else cboxMachInvertRelays.Checked = true;

            if ((sett & 2) == 0) cboxIsHydOn.Checked = false;
            else cboxIsHydOn.Checked = true;

            if (cboxIsHydOn.Checked)
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOn;
                nudHydLiftLookAhead.Enabled = true;
                nudLowerTime.Enabled = true;
                nudRaiseTime.Enabled = true;
            }
            else
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOff;
                nudHydLiftLookAhead.Enabled = false;
                nudLowerTime.Enabled = false;
                nudRaiseTime.Enabled = false;
            }

            nudRaiseTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydRaiseTime;
            nudLowerTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydLowerTime;

            nudUser1.Value = Properties.Vehicle.Default.setArdMac_user1;
            nudUser2.Value = Properties.Vehicle.Default.setArdMac_user2;
            nudUser3.Value = Properties.Vehicle.Default.setArdMac_user3;
            nudUser4.Value = Properties.Vehicle.Default.setArdMac_user4;

            btnSendMachinePGN.Focus();

            nudHydLiftLookAhead.Value = (decimal)Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead;
        }
        private void tabAMachine_Leave(object sender, EventArgs e)
        {
            pboxSendMachine.Visible = false;
        }

        private void nudHydLiftSecs_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudRaiseTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudLowerTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudUser1_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudUser2_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudUser3_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudUser4_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }
        private void cboxIsHydOn_CheckStateChanged(object sender, EventArgs e)
        {
            if (cboxIsHydOn.Checked)
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOn;
                nudHydLiftLookAhead.Enabled = true;
                nudLowerTime.Enabled = true;
                nudRaiseTime.Enabled = true;
            }
            else
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOff;
                nudHydLiftLookAhead.Enabled = false;
                nudLowerTime.Enabled = false;
                nudRaiseTime.Enabled = false;
            }
            //pboxSendMachine.Visible = true;
        }

        private void SaveSettingsMachine()
        {
            int set = 1;
            int reset = 2046;
            int sett = 0;

            if (cboxMachInvertRelays.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxIsHydOn.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdMac_setting0 = (byte)sett;
            Properties.Vehicle.Default.setArdMac_hydRaiseTime = (byte)nudRaiseTime.Value;
            Properties.Vehicle.Default.setArdMac_hydLowerTime = (byte)nudLowerTime.Value;

            Properties.Vehicle.Default.setArdMac_user1 = (byte)nudUser1.Value;
            Properties.Vehicle.Default.setArdMac_user2 = (byte)nudUser2.Value;
            Properties.Vehicle.Default.setArdMac_user3 = (byte)nudUser3.Value;
            Properties.Vehicle.Default.setArdMac_user4 = (byte)nudUser4.Value;

            Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead = (double)nudHydLiftLookAhead.Value;
            mf.vehicle.hydLiftLookAheadTime = Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead;

            mf.p_238.pgn[mf.p_238.set0] = (byte)sett;
            mf.p_238.pgn[mf.p_238.raiseTime] = (byte)nudRaiseTime.Value;
            mf.p_238.pgn[mf.p_238.lowerTime] = (byte)nudLowerTime.Value;

            mf.p_238.pgn[mf.p_238.user1] = (byte)nudUser1.Value;
            mf.p_238.pgn[mf.p_238.user2] = (byte)nudUser2.Value;
            mf.p_238.pgn[mf.p_238.user3] = (byte)nudUser3.Value;
            mf.p_238.pgn[mf.p_238.user4] = (byte)nudUser4.Value;

            mf.SendPgnToLoop(mf.p_238.pgn);
            pboxSendMachine.Visible = false;
        }

        private void btnSendMachinePGN_Click(object sender, EventArgs e)
        {
            SaveSettingsMachine();

            Properties.Vehicle.Default.Save();

            mf.TimedMessageBox(1000, gStr.gsMachinePort, gStr.gsSentToMachineModule);

            pboxSendMachine.Visible = false;
        }

        #endregion

        #region Relay Config

        private string[] words;

        private void tabRelay_Enter(object sender, EventArgs e)
        {
            pboxSendRelay.Visible = false;

            string[] wordsList = { "-","Section 1","Section 2","Section 3","Section 4","Section 5","Section 6","Section 7",
                    "Section 8","Section 9","Section 10","Section 11","Section 12","Section 13","Section 14","Section 15",
                    "Section 16","Hyd Up","Hyd Down","Tramline","Geo Stop"};

            cboxPin0.Items.Clear(); cboxPin0.Items.AddRange(wordsList);
            cboxPin1.Items.Clear(); cboxPin1.Items.AddRange(wordsList);
            cboxPin2.Items.Clear(); cboxPin2.Items.AddRange(wordsList);
            cboxPin3.Items.Clear(); cboxPin3.Items.AddRange(wordsList);
            cboxPin4.Items.Clear(); cboxPin4.Items.AddRange(wordsList);
            cboxPin5.Items.Clear(); cboxPin5.Items.AddRange(wordsList);
            cboxPin6.Items.Clear(); cboxPin6.Items.AddRange(wordsList);
            cboxPin7.Items.Clear(); cboxPin7.Items.AddRange(wordsList);
            cboxPin8.Items.Clear(); cboxPin8.Items.AddRange(wordsList);
            cboxPin9.Items.Clear(); cboxPin9.Items.AddRange(wordsList);

            cboxPin10.Items.Clear(); cboxPin10.Items.AddRange(wordsList);
            cboxPin11.Items.Clear(); cboxPin11.Items.AddRange(wordsList);
            cboxPin12.Items.Clear(); cboxPin12.Items.AddRange(wordsList);
            cboxPin13.Items.Clear(); cboxPin13.Items.AddRange(wordsList);
            cboxPin14.Items.Clear(); cboxPin14.Items.AddRange(wordsList);
            cboxPin15.Items.Clear(); cboxPin15.Items.AddRange(wordsList);
            cboxPin16.Items.Clear(); cboxPin16.Items.AddRange(wordsList);
            cboxPin17.Items.Clear(); cboxPin17.Items.AddRange(wordsList);
            cboxPin18.Items.Clear(); cboxPin18.Items.AddRange(wordsList);
            cboxPin19.Items.Clear(); cboxPin19.Items.AddRange(wordsList);

            cboxPin20.Items.Clear(); cboxPin20.Items.AddRange(wordsList);
            cboxPin21.Items.Clear(); cboxPin21.Items.AddRange(wordsList);
            cboxPin22.Items.Clear(); cboxPin22.Items.AddRange(wordsList);
            cboxPin23.Items.Clear(); cboxPin23.Items.AddRange(wordsList);

            words = Properties.Settings.Default.setRelay_pinConfig.Split(',');

            cboxPin0.SelectedIndex = int.Parse(words[0]);
            cboxPin1.SelectedIndex = int.Parse(words[1]);
            cboxPin2.SelectedIndex = int.Parse(words[2]);
            cboxPin3.SelectedIndex = int.Parse(words[3]);
            cboxPin4.SelectedIndex = int.Parse(words[4]);
            cboxPin5.SelectedIndex = int.Parse(words[5]);
            cboxPin6.SelectedIndex = int.Parse(words[6]);
            cboxPin7.SelectedIndex = int.Parse(words[7]);
            cboxPin8.SelectedIndex = int.Parse(words[8]);
            cboxPin9.SelectedIndex = int.Parse(words[9]);
            cboxPin10.SelectedIndex = int.Parse(words[10]);
            cboxPin11.SelectedIndex = int.Parse(words[11]);
            cboxPin12.SelectedIndex = int.Parse(words[12]);
            cboxPin13.SelectedIndex = int.Parse(words[13]);
            cboxPin14.SelectedIndex = int.Parse(words[14]);
            cboxPin15.SelectedIndex = int.Parse(words[15]);
            cboxPin16.SelectedIndex = int.Parse(words[16]);
            cboxPin17.SelectedIndex = int.Parse(words[17]);
            cboxPin18.SelectedIndex = int.Parse(words[18]);
            cboxPin19.SelectedIndex = int.Parse(words[19]);
            cboxPin20.SelectedIndex = int.Parse(words[20]);
            cboxPin21.SelectedIndex = int.Parse(words[21]);
            cboxPin22.SelectedIndex = int.Parse(words[22]);
            cboxPin23.SelectedIndex = int.Parse(words[23]);
        }

        private void tabRelay_Leave(object sender, EventArgs e)
        {
            pboxSendRelay.Visible = false;
        }

        private void btnSendRelayConfigPGN_Click(object sender, EventArgs e)
        {
            SaveSettingsRelay();
            SendRelaySettingsToMachineModule();

            mf.TimedMessageBox(1000, gStr.gsMachinePort, gStr.gsSentToMachineModule);

            pboxSendRelay.Visible = false;
        }

        private void SaveSettingsRelay()
        {
            StringBuilder bob = new StringBuilder();

            bob.Append(cboxPin0.SelectedIndex.ToString() + ",")
               .Append(cboxPin1.SelectedIndex.ToString() + ",")
               .Append(cboxPin2.SelectedIndex.ToString() + ",")
               .Append(cboxPin3.SelectedIndex.ToString() + ",")
               .Append(cboxPin4.SelectedIndex.ToString() + ",")
               .Append(cboxPin5.SelectedIndex.ToString() + ",")
               .Append(cboxPin6.SelectedIndex.ToString() + ",")
               .Append(cboxPin7.SelectedIndex.ToString() + ",")
               .Append(cboxPin8.SelectedIndex.ToString() + ",")
               .Append(cboxPin9.SelectedIndex.ToString() + ",")
               .Append(cboxPin10.SelectedIndex.ToString() + ",")
               .Append(cboxPin11.SelectedIndex.ToString() + ",")
               .Append(cboxPin12.SelectedIndex.ToString() + ",")
               .Append(cboxPin13.SelectedIndex.ToString() + ",")
               .Append(cboxPin14.SelectedIndex.ToString() + ",")
               .Append(cboxPin15.SelectedIndex.ToString() + ",")
               .Append(cboxPin16.SelectedIndex.ToString() + ",")
               .Append(cboxPin17.SelectedIndex.ToString() + ",")
               .Append(cboxPin18.SelectedIndex.ToString() + ",")
               .Append(cboxPin19.SelectedIndex.ToString() + ",")
               .Append(cboxPin20.SelectedIndex.ToString() + ",")
               .Append(cboxPin21.SelectedIndex.ToString() + ",")
               .Append(cboxPin22.SelectedIndex.ToString() + ",")
               .Append(cboxPin23.SelectedIndex.ToString());

            Properties.Settings.Default.setRelay_pinConfig = bob.ToString();

            //save settings
            Properties.Settings.Default.Save();
            pboxSendRelay.Visible = false;

        }

        private void SendRelaySettingsToMachineModule()
        {
            words = Properties.Settings.Default.setRelay_pinConfig.Split(',');

            //load the pgn
            mf.p_236.pgn[mf.p_236.pin0] = (byte)int.Parse(words[0]);
            mf.p_236.pgn[mf.p_236.pin1] = (byte)int.Parse(words[1]);
            mf.p_236.pgn[mf.p_236.pin2] = (byte)int.Parse(words[2]);
            mf.p_236.pgn[mf.p_236.pin3] = (byte)int.Parse(words[3]);
            mf.p_236.pgn[mf.p_236.pin4] = (byte)int.Parse(words[4]);
            mf.p_236.pgn[mf.p_236.pin5] = (byte)int.Parse(words[5]);
            mf.p_236.pgn[mf.p_236.pin6] = (byte)int.Parse(words[6]);
            mf.p_236.pgn[mf.p_236.pin7] = (byte)int.Parse(words[7]);
            mf.p_236.pgn[mf.p_236.pin8] = (byte)int.Parse(words[8]);
            mf.p_236.pgn[mf.p_236.pin9] = (byte)int.Parse(words[9]);

            mf.p_236.pgn[mf.p_236.pin10] = (byte)int.Parse(words[10]);
            mf.p_236.pgn[mf.p_236.pin11] = (byte)int.Parse(words[11]);
            mf.p_236.pgn[mf.p_236.pin12] = (byte)int.Parse(words[12]);
            mf.p_236.pgn[mf.p_236.pin13] = (byte)int.Parse(words[13]);
            mf.p_236.pgn[mf.p_236.pin14] = (byte)int.Parse(words[14]);
            mf.p_236.pgn[mf.p_236.pin15] = (byte)int.Parse(words[15]);
            mf.p_236.pgn[mf.p_236.pin16] = (byte)int.Parse(words[16]);
            mf.p_236.pgn[mf.p_236.pin17] = (byte)int.Parse(words[17]);
            mf.p_236.pgn[mf.p_236.pin18] = (byte)int.Parse(words[18]);
            mf.p_236.pgn[mf.p_236.pin19] = (byte)int.Parse(words[19]);

            mf.p_236.pgn[mf.p_236.pin20] = (byte)int.Parse(words[20]);
            mf.p_236.pgn[mf.p_236.pin21] = (byte)int.Parse(words[21]);
            mf.p_236.pgn[mf.p_236.pin22] = (byte)int.Parse(words[22]);
            mf.p_236.pgn[mf.p_236.pin23] = (byte)int.Parse(words[23]);
            mf.SendPgnToLoop(mf.p_236.pgn);

        }

        private void btnRelaySetDefaultConfig_Click(object sender, EventArgs e)
        {
            pboxSendRelay.Visible = true;

            cboxPin0.SelectedIndex = 1;
            cboxPin1.SelectedIndex = 2;
            cboxPin2.SelectedIndex = 3;
            cboxPin3.SelectedIndex = 0;
            cboxPin4.SelectedIndex = 0;
            cboxPin5.SelectedIndex = 0;
            cboxPin6.SelectedIndex = 0;
            cboxPin7.SelectedIndex = 0;
            cboxPin8.SelectedIndex = 0;
            cboxPin9.SelectedIndex = 0;
            cboxPin10.SelectedIndex = 0;
            cboxPin11.SelectedIndex = 0;
            cboxPin12.SelectedIndex = 0;
            cboxPin13.SelectedIndex = 0;
            cboxPin14.SelectedIndex = 0;
            cboxPin15.SelectedIndex = 0;
            cboxPin16.SelectedIndex = 0;
            cboxPin17.SelectedIndex = 0;
            cboxPin18.SelectedIndex = 0;
            cboxPin19.SelectedIndex = 0;
            cboxPin20.SelectedIndex = 0;
            cboxPin21.SelectedIndex = 0;
            cboxPin22.SelectedIndex = 0;
            cboxPin23.SelectedIndex = 0;
        }

        private void btnRelayResetConfigToNone_Click(object sender, EventArgs e)
        {
            pboxSendRelay.Visible = true;

            cboxPin0.SelectedIndex = 0;
            cboxPin1.SelectedIndex = 0;
            cboxPin2.SelectedIndex = 0;
            cboxPin3.SelectedIndex = 0;
            cboxPin4.SelectedIndex = 0;
            cboxPin5.SelectedIndex = 0;
            cboxPin6.SelectedIndex = 0;
            cboxPin7.SelectedIndex = 0;
            cboxPin8.SelectedIndex = 0;
            cboxPin9.SelectedIndex = 0;
            cboxPin10.SelectedIndex = 0;
            cboxPin11.SelectedIndex = 0;
            cboxPin12.SelectedIndex = 0;
            cboxPin13.SelectedIndex = 0;
            cboxPin14.SelectedIndex = 0;
            cboxPin15.SelectedIndex = 0;
            cboxPin16.SelectedIndex = 0;
            cboxPin17.SelectedIndex = 0;
            cboxPin18.SelectedIndex = 0;
            cboxPin19.SelectedIndex = 0;
            cboxPin20.SelectedIndex = 0;
            cboxPin21.SelectedIndex = 0;
            cboxPin22.SelectedIndex = 0;
            cboxPin23.SelectedIndex = 0;
        }

        private void cboxPin0_Click(object sender, EventArgs e)
        {
            pboxSendRelay.Visible = true;
        }

        #endregion


        #region Uturn Enter-Leave

        private void tabUTurn_Enter(object sender, EventArgs e)
        {
            UpdateUturnText();

            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();

            double bob = Properties.Vehicle.Default.set_youTurnDistanceFromBoundary * mf.m2FtOrM;
            if (bob < 0.2) bob = 0.2;
            nudTurnDistanceFromBoundary.Value = (decimal)(Math.Round(bob, 2));

            lblFtMUTurn.Text = mf.unitsFtM;
        }

        private void tabUTurn_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_uTurnSmoothing = mf.yt.uTurnSmoothing;
            Properties.Vehicle.Default.set_youTurnExtensionLength = mf.yt.youTurnStartOffset;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            mf.bnd.BuildTurnLines();
            mf.yt.ResetCreatedYouTurn();
        }

        #endregion

        #region Uturn controls
        private void UpdateUturnText()
        {
            if (mf.isMetric)
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            }
            else
            {
                lblDistance.Text = Math.Abs((int)(mf.yt.youTurnStartOffset * glm.m2ft)).ToString() + " ft";
            }
        }

        private void nudTurnDistanceFromBoundary_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.yt.uturnDistanceFromBoundary = (double)nudTurnDistanceFromBoundary.Value * mf.ftOrMtoM;
                Properties.Vehicle.Default.set_youTurnDistanceFromBoundary = mf.yt.uturnDistanceFromBoundary;
            }
        }

        private void btnTriggerDistanceDn_Click(object sender, EventArgs e)
        {
            mf.yt.uturnDistanceFromBoundary--;
            if (mf.yt.uturnDistanceFromBoundary < 0.1) mf.yt.uturnDistanceFromBoundary = 0.1;
            UpdateUturnText();
        }

        private void btnTriggerDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.uturnDistanceFromBoundary++ > 50) mf.yt.uturnDistanceFromBoundary = 50;
            UpdateUturnText();
        }

        private void btnDistanceDn_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset-- < 4) mf.yt.youTurnStartOffset = 3;
            UpdateUturnText();
        }

        private void btnDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset++ > 49) mf.yt.youTurnStartOffset = 50;
            UpdateUturnText();
        }
        private void btnTurnSmoothingDown_Click(object sender, EventArgs e)
        {
            mf.yt.uTurnSmoothing -= 2;
            if (mf.yt.uTurnSmoothing < 4) mf.yt.uTurnSmoothing = 4;
            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();
        }

        private void btnTurnSmoothingUp_Click(object sender, EventArgs e)
        {
            mf.yt.uTurnSmoothing += 2;
            if (mf.yt.uTurnSmoothing > 18) mf.yt.uTurnSmoothing = 18;
            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();
        }

        #endregion

        #region Tram
        private void tabTram_Enter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setTool_isTramOuter)
            {
                rbtnTramOuter.Checked = true;
                rbtnTramInner.Checked = false;
            }
            else
            {
                rbtnTramOuter.Checked = false;
                rbtnTramInner.Checked = true;
            }
            lblTramWidthUnits.Text = mf.unitsInCm;

            nudTramWidth.Value = (int)(Math.Abs(Properties.Settings.Default.setTram_tramWidth) * mf.m2InchOrCm);

            cboxTramOnBackBuffer.Checked = Properties.Settings.Default.setTram_isTramOnBackBuffer;
        }

        private void tabTram_Leave(object sender, EventArgs e)
        {
            if (rbtnTramOuter.Checked) Properties.Settings.Default.setTool_isTramOuter = true;
            else Properties.Settings.Default.setTool_isTramOuter = false;

            if (cboxTramOnBackBuffer.Checked) Properties.Settings.Default.setTram_isTramOnBackBuffer = true;
            else Properties.Settings.Default.setTram_isTramOnBackBuffer = false;
            mf.isTramOnBackBuffer = Properties.Settings.Default.setTram_isTramOnBackBuffer;

            mf.tram.isOuter = Properties.Settings.Default.setTool_isTramOuter;

            Properties.Settings.Default.Save();

        }
        private void nudTramWidth_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tram.tramWidth = (double)nudTramWidth.Value * mf.inchOrCm2m;
                Properties.Settings.Default.setTram_tramWidth = mf.tram.tramWidth;
            }
        }

        #endregion

    }
}