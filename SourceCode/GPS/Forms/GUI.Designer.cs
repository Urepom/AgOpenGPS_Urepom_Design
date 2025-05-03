﻿//Please, if you use this, share the improvements

using AgLibrary.Logging;
using AgOpenGPS.Core.Models;
using AgOpenGPS.Culture;
using AgOpenGPS.Helpers;
using AgOpenGPS.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public enum TractorBrand { AGOpenGPS, Case, Claas, Deutz, Fendt, JDeere, Kubota, Massey, NewHolland, Same, Steyr, Ursus, Valtra, JCB }
    public enum HarvesterBrand { AgOpenGPS, Case, Claas, JDeere, NewHolland }
    public enum ArticulatedBrand { AgOpenGPS, Case, Challenger, JDeere, NewHolland, Holder }

    public partial class FormGPS
    {
        //ABLines directory
        public string ablinesDirectory;
        public string fieldData, guidanceLineText;

        //colors for sections and field background
        public byte flagColor = 0;

        //how many cm off line per big pixel
        public int lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

        //polygon mode for section drawing
        public bool isDrawPolygons = false, isPauseFieldTextCounter = false;

        public CFeatureSettings featureSettings = new CFeatureSettings();

        public Color frameDayColor;
        public Color frameNightColor;
        public Color sectionColorDay;
        public Color fieldColorDay;
        public Color fieldColorNight;

        public Color textColorDay;
        public Color textColorNight;

        public bool isVehicleImage;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid etc
        public bool isMetric = true, isLightbarOn = true, isGridOn, isFullScreen;
        public bool isUTurnAlwaysOn, isCompassOn, isSpeedoOn, isSideGuideLines = true;
        public bool isPureDisplayOn = true, isSkyOn = true, isRollMeterOn = false, isTextureOn = true;
        public bool isDay = true, isDayTime = true, isBrightnessOn = true;
        public bool isLogElevation = false, isDirectionMarkers;
        public bool isKeyboardOn = true, isAutoStartAgIO = true, isSvennArrowOn = true;
        public bool isSectionlinesOn = true, isLineSmooth = true;

        public bool isLightBarNotSteerBar = false;
        //Ajout-modification MEmprou et SPailleau
        public bool issections_buttonOn = false;
        public bool islong_touchOn = Properties.Settings.Default.UP_setDisplay_islong_touchOn;
        bool work_track = false;
        //fin
        public bool isUTurnOn = true, isLateralOn = true, isNudgeOn = true;

        public int[] customColorsList = new int[16];

        //sunrise sunset
        public DateTime dateToday = DateTime.Today;
        public DateTime sunrise = DateTime.Now;
        public DateTime sunset = DateTime.Now;

        public bool isFlashOnOff = false, isPanFormVisible = false;
        public bool isPanelBottomHidden = false;

        public bool isKioskMode = false;
        public int makeUTurnCounter = 0;

        //makes nav panel disappear after 6 seconds
        private int navPanelCounter = 0, trackMethodPanelCounter = 0;
        public uint sentenceCounter = 0;
        public int guideLineCounter = 0;
        public int hardwareLineCounter = 0;
        public bool isHardwareMessages = false;

        private int currentFieldTextCounter = 0;

        //For field saving in background
        private int fileSaveCounter = 1;
        private int fileSaveAlwaysCounter = 1;
        private int fourSecondCounter = 0;
        private int traccarSecondCounter = 0;
        public int twoSecondCounter = 0;
        private int oneSecondCounter = 0;
        private int oneHalfSecondCounter = 0;

        public List<int> buttonOrder = new List<int>();

        //Timer triggers at 125 msec
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            if (sentenceCounter == 19)
            {
                Log.EventWriter("No GPS Warning - Lost GPS");
            }

            //Check for a newline char, if none then just return
            if (++sentenceCounter > 20)
            {
                ShowNoGPSWarning();
                //make sure settings and others can't be openend, the program is in standby
                toolStripDropDownButton1.Enabled = false;
                toolStripDropDownButton4.Enabled = false;
                btnJobMenu.Enabled = false;
                return;
            }
            else
            {
                //turn on buttons when GPS is active again (or SIM is enabled)
                toolStripDropDownButton1.Enabled = true;
                toolStripDropDownButton4.Enabled = true;
                btnJobMenu.Enabled = true;
            }

            ////////////////////////////////////////////// 10 second ///////////////////////////////////////////////////////
            //every 3 second update status
            if (fourSecondCounter >= 3)
            {
                if (!isPauseFieldTextCounter)
                {
                    if (++currentFieldTextCounter > 3) currentFieldTextCounter = 0;
                }

                if ((isBtnAutoSteerOn || manualBtnState == btnStates.On || autoBtnState == btnStates.Auto))
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                }

                //reset the counter
                fourSecondCounter = 0;

                //ajout memprou
                /*/
                if (isJobStarted)
                {
                    switch (currentFieldTextCounter)
                    {
                        case 0:
                            lblCurrentField.Text = gStr.gsField + ": " + displayFieldName;
                            break;

                        case 1:
                            if (bnd.bndList.Count > 0)
                            {
                                if (isMetric)
                                {
                                    lblCurrentField.Text = fd.AreaBoundaryLessInnersHectares
                                        + "  App: " + fd.WorkedHectares
                                        + "  Actual: " + fd.ActualAreaWorkedHectares
                                        + "  " + fd.WorkedAreaRemainPercentage
                                        + "  " + fd.WorkRateHectares;

                                }
                                else
                                {
                                    lblCurrentField.Text = fd.AreaBoundaryLessInnersAcres
                                        + "  App: " + fd.WorkedAcres
                                        + "  Actual: " + fd.ActualAreaWorkedAcres
                                        + "  " + fd.WorkedAreaRemainPercentage
                                        + "  " + fd.WorkRateAcres;
                                }
                            }
                            else
                            {
                                if (isMetric)
                                {
                                    lblCurrentField.Text = "App: "
                                + fd.WorkedHectares + " Actual: "
                                + fd.ActualAreaWorkedHectares + "  "
                                + fd.ActualOverlapPercent + "   "
                                + fd.WorkRateHectares;
                                }
                                else
                                {
                                    lblCurrentField.Text = fieldData + "App: "
                                + fd.WorkedAcres + "  Actual: "
                                + fd.ActualAreaWorkedAcres + " *"
                                + fd.ActualOverlapPercent + "   "
                                + fd.WorkRateAcres;
                                }
                            }
                            break;

                        case 2:
                            if (trk.idx > -1)
                                lblCurrentField.Text = "Line: " + trk.gArr[trk.idx].name;
                            else
                                lblCurrentField.Text = "Line: " + gStr.gsNoGuidanceLines;
                            break;

                        case 3:
                            lblCurrentField.Text = "";
                            break;


                        default:
                            break;
                    }

                    if (tram.displayMode == 0) 
                        tram.isRightManualOn = tram.isLeftManualOn = false;
                }
                else
                {
                    switch (currentFieldTextCounter)
                    {
                        case 0:
                            lblCurrentField.Text = (tool.width * m2FtOrM).ToString("N2") + unitsFtM + " - " + RegistrySettings.vehicleFileName;
                            break;

                        case 1:
                            lblCurrentField.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss ");
                            break;

                        case 2:
                            lblCurrentField.Text = "Lat: " + pn.latitude.ToString("N7") + "   Lon: " + pn.longitude.ToString("N7");
                            break;

                        case 3:
                            lblCurrentField.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss ");                            
                            break;

                        case 4:
                            lblCurrentField.Text = "";
                            break;

                        default:
                            break;
                    }
                }

                if (isPauseFieldTextCounter)
                {
                    lblCurrentField.Text = "\u23F8" + " " + lblCurrentField.Text;
                }
                else
                {
                    lblCurrentField.Text = "\u25B6" + " " + lblCurrentField.Text;
                }
                /*/
                //ajout memprou

                lblHz.Text = gpsHz.ToString("N1") + "Hz " + (int)(frameTime) + "\r\n" +
                FixQuality;
                lblTotalAppliedArea.Text = fd.WorkedHectares;
                lblWorkRemaining.Text = fd.WorkedAreaRemainHectares;
                lblTimeRemaining.Text = fd.TimeTillFinished + " H";
                lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss") + "\n\r" + DateTime.Now.ToString("ddd dd MMMM yyyy");

                PowerStatus status = SystemInformation.PowerStatus;
                string NiveauBatterie = status.BatteryLifePercent.ToString("P0");
                BatLevel.Text = NiveauBatterie;

                label1.Text = RegistrySettings.vehicleFileName + "\r\n" + (Math.Round(tool.width, 2)).ToString() + " m";
                if (ferti_vidange == false)
                {
                    p_240.pgn[p_240.LargeurHi] = unchecked((byte)(((short)tool.width) >> 8));
                    p_240.pgn[p_240.LargeurLo] = unchecked((byte)(((short)tool.width)));
                }

                if (tram.displayMode == 0)
                    tram.isRightManualOn = tram.isLeftManualOn = false;
                //fin

                //fix
                if (timerSim.Enabled && pn.fixQuality++ > 5) pn.fixQuality = 2;

                fileSaveAlwaysCounter += 3;
            }

            /////////////////////////////////////////////////////////   2 second  ////////////////////////////////////////
            //every 2 second update status
            if (twoSecondCounter >= 2)
            {
                //reset the counter
                twoSecondCounter = 0;

                //hide the Nav panel in 6  secs
                if (panelNavigation.Visible)
                {
                    if (navPanelCounter-- <= 0) panelNavigation.Visible = false;
                    lblHz.Text = gpsHz.ToString("N1") + " ~ " + (frameTime.ToString("N1")) + " " + FixQuality;
                }
            }//end every 2 seconds

            //every second update all status ///////////////////////////   1 1 1 1 1 1 ////////////////////////////
            if (oneSecondCounter >= 4)
            {
                //reset the counter
                oneSecondCounter = 0;

                //counter used for saving field in background - is actually 30 second
                fileSaveCounter++;

                //general counters
                twoSecondCounter++;
                fourSecondCounter++;
                //keeps autoTrack from changing too fast
                trk.autoTrack3SecTimer++;
                vehicle.deadZoneDelayCounter++;

                //ajout memprou lblFix.Text = FixQuality + "Age: " + pn.age.ToString("N1");
                //Ajout-modification MEmprou et SPailleau
                traccarSecondCounter++;
                lblAge.Text = "age: " + pn.age.ToString("N1");
                lbludpWatchCounts.Text = "Miss: " + missedSentenceCount.ToString();
                //fin

                switch (pn.fixQuality)
                {
                    case 4:
                        round_table12.BackColor = Color.PaleGreen; //ajout memprou
                        break;
                    case 5:
                        round_table12.BackColor = Color.Orange; //ajout memprou
                        break;
                    case 2:
                        round_table12.BackColor = Color.Yellow; //ajout memprou
                        break;
                    default:
                        round_table12.BackColor = Color.Red; //ajout memprou
                        break;
                }

                //statusbar flash red undefined headland
                if (timerSim.Enabled)
                {
                    if (mc.isOutOfBounds && panelSim.BackColor == Color.Transparent
                        || !mc.isOutOfBounds && panelSim.BackColor == Color.Tomato)
                    {
                        //Ajout-modification MEmprou et SPailleau
                        if (!mc.isOutOfBounds)
                        {
                            panel_top.BackColor = Color.Transparent;
                            label12.BackColor = Color.Transparent;
                            label13.BackColor = Color.Transparent;
                        }
                        else
                        {
                            panel_top.BackColor = Color.Tomato;
                            label12.BackColor = Color.Tomato;
                            label13.BackColor = Color.Tomato;
                        }
                        //fin
                    }
                }

                if (flp1.Visible)
                {
                    if (trackMethodPanelCounter-- < 1) flp1.Visible = false;
                }
            }

            //every half of a second update all status  ////////////////    0.5  0.5   0.5    0.5    /////////////////
            if (oneHalfSecondCounter >= 2)
            {
                //reset the counter
                oneHalfSecondCounter = 0;

                isFlashOnOff = !isFlashOnOff;

                //the main formgps windows

                //Make sure it is off when it should
                if (!ct.isContourBtnOn && trk.idx == -1 && isBtnAutoSteerOn)
                {
                    btnAutoSteer.PerformClick();
                    TimedMessageBox(2000, gStr.gsGuidanceStopped, gStr.gsNoGuidanceLines);
                    Log.EventWriter("Steer Safe Off, No Tracks, Idx -1");
                }


                //the main formgps window
                if (isMetric)  //metric or imperial
                {
                    lblSpeed.Text = SpeedKPH;
                    distanceToolBtn.Text = Math.Round(Convert.ToDecimal(fd.DistanceUserMeters), 1) + "\r\n" + fd.WorkedUserHectares;

                    //btnContour.Text = XTE; //cross track error

                }
                else  //Imperial Measurements
                {
                    lblSpeed.Text = SpeedMPH;
                    distanceToolBtn.Text = fd.DistanceUserFeet + "\r\n" + fd.WorkedUserAcres;

                    //btnContour.Text = InchXTE; //cross track error
                }
            } //end every 1/2 second

            //every fourth second update  ///////////////////////////   Fourth  ////////////////////////////
            {
                //reset the counter
                oneHalfSecondCounter++;
                oneSecondCounter++;
                makeUTurnCounter++;

                btnAutoSteerConfig.Text = SetSteerAngle + "\r\n" + ActualSteerAngle;

                secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;
            }
            //ajout max
            if (Settings.Default.UP_traccar == true && traccarSecondCounter >= Settings.Default.UP_frequence_traccar)
            {
                string Id = Settings.Default.UP_ID_traccar;
                string IP = Settings.Default.UP_adresse_traccar;
                string Port = Settings.Default.UP_port_traccar;
                double totalSecond = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                string lat = pn.latitude.ToString().Replace(",", ".");
                string lon = pn.longitude.ToString().Replace(",", ".");
                //MessageBox.Show(SpeedKPH);
                if ((manualBtnState == btnStates.On || autoBtnState == btnStates.Auto))
                {
                     work_track = true;
                }
                else
                {
                     work_track = false;
                }
                var request = (HttpWebRequest)WebRequest.Create("http://" + IP + ":" + Port + "/?id=" + Id + "&timestamp=" + ((int)totalSecond).ToString() + "&speed=" + SpeedKPH.ToString().Replace(",", ".") + "&lat=" + lat + "&lon=" + lon + "&tool=" + RegistrySettings.vehicleFileName + "\r\n" + (Math.Round(tool.width, 2)).ToString() + " m".ToString() + "&Work=" + work_track + "&Field=" + (currentFieldDirectory.Substring(0, currentFieldDirectory.Length) + "\r\n" + fd.AreaBoundaryLessInnersHectares + " ha").ToString() + "&AppliedArea=" + fd.WorkedHectares.ToString());
                var postData = "";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
     
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                traccarSecondCounter = 0;

                request.Abort();
            }//wait till timer fires again.
             //fin
        }
        public void LoadText()
        {
            enterSimCoordsToolStripMenuItem.Text = gStr.gsEnterSimCoords;
            aboutToolStripMenuItem.Text = gStr.gsAbout;
            menustripLanguage.Text = gStr.gsLanguage;

            simulatorOnToolStripMenuItem.Text = gStr.gsSimulatorOn;
            resetALLToolStripMenuItem.Text = gStr.gsResetAll;

            toolStripColors.Text = gStr.gsColors;
            toolStripSectionColors.Text = "Section " + gStr.gsColors;
            toolStripConfig.Text = gStr.gsConfiguration;
            toolStripSteerSettings.Text = gStr.gsAutoSteer;
            toolStripWorkingDirectories.Text = gStr.gsDirectories;
            toolStripAllSettings.Text = gStr.gsAllSettings;

            resetEverythingToolStripMenuItem.Text = gStr.gsResetAllForSure;
            steerChartStripMenu.Text = gStr.gsCharts;

            //Tools Menu
            SmoothABtoolStripMenu.Text = gStr.gsSmoothABCurve;
            guidelinesToolStripMenuItem.Text = gStr.gsExtraGuideLines;
            boundariesToolStripMenuItem.Text = gStr.gsBoundary;
            headlandToolStripMenuItem.Text = gStr.gsHeadland;
            headlandBuildToolStripMenuItem.Text = gStr.gsHeadland + " Builder";
            deleteContourPathsToolStripMenuItem.Text = gStr.gsDeleteContourPaths;
            deleteAppliedToolStripMenuItem.Text = gStr.gsDeleteAppliedArea;
            tramLinesMenuField.Text = gStr.gsTramLines;
            tramsMultiMenuField.Text = gStr.gsTramLines + " Builder";
            recordedPathStripMenu.Text = gStr.gsRecordedPathMenu;
            flagByLatLonToolStripMenuItem.Text = gStr.gsFlagByLatLon;
            boundaryToolToolStripMenu.Text = gStr.gsBoundary + " Tool";

            webcamToolStrip.Text = gStr.gsWebCam;
            offsetFixToolStrip.Text = gStr.gsOffsetFix;
            wizardsMenu.Text = gStr.gsWizards;
            steerWizardMenuItem.Text = gStr.gsSteerWizard;
            steerChartToolStripMenuItem.Text = gStr.gsSteerChart;
            headingChartToolStripMenuItem.Text = gStr.gsHeadingChart;
            xTEChartToolStripMenuItem.Text = gStr.gsXTEChart;
        }

        public void LoadSettings()
        {
            btnChangeMappingColor.Text = Program.Version;

            //metric settings
            isMetric = Settings.Default.setMenu_isMetric;
            //Ajout-modification MEmprou et SPailleau
            btnAdjLeftMain.Visible = Properties.Settings.Default.UP_SetArrowsRL;
            btnAdjRightMain.Visible = Properties.Settings.Default.UP_SetArrowsRL;
            issections_buttonOn = Settings.Default.UP_setDisplay_issections_buttonOn;
            long_touch();
            if (Properties.Settings.Default.UP_setVineMode)
            {
                cboxAutoSnapToPivot.Checked = true;
                trk.isAutoSnapToPivot = cboxAutoSnapToPivot.Checked;
                trackMethodPanelCounter = 1;
            }
            else
            {
                cboxAutoSnapToPivot.Checked = false;
                trk.isAutoSnapToPivot = cboxAutoSnapToPivot.Checked;
                trackMethodPanelCounter = 1;
            }
            //fin
            //kiosk mode
            isKioskMode = Settings.Default.setWindow_isKioskMode;
            if (isKioskMode) kioskModeToolStrip.Checked = true;
            else kioskModeToolStrip.Checked = false;

            //field menu
            boundariesToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isBoundaryOn;
            headlandToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHeadlandOn;
            headlandBuildToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHeadlandOn;
            tramLinesMenuField.Visible = Properties.Settings.Default.setFeatures.isTramOn;
            tramsMultiMenuField.Visible = Properties.Settings.Default.setFeatures.isTramOn;
            recordedPathStripMenu.Visible = Properties.Settings.Default.setFeatures.isRecPathOn;


            //tools menu
            SmoothABtoolStripMenu.Visible = Properties.Settings.Default.setFeatures.isABSmoothOn;
            deleteContourPathsToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHideContourOn;
            webcamToolStrip.Visible = Properties.Settings.Default.setFeatures.isWebCamOn;
            offsetFixToolStrip.Visible = Properties.Settings.Default.setFeatures.isOffsetFixOn;
            if (isSideGuideLines) guidelinesToolStripMenuItem.Checked = true;
            else guidelinesToolStripMenuItem.Checked = false;

            //left side
            btnStartAgIO.Visible = Properties.Settings.Default.setFeatures.isAgIOOn;

            //OGL control
            isUTurnOn = Properties.Settings.Default.setFeatures.isUTurnOn;
            isLateralOn = Properties.Settings.Default.setFeatures.isLateralOn;
            cboxpRowWidth.SelectedIndex = (Properties.Settings.Default.set_youSkipWidth - 1);
            btnYouSkipEnable.Image = Resources.YouSkipOff;
            isNudgeOn = Properties.Settings.Default.setFeatures.isABLineOn;

            isSectionlinesOn = Properties.Settings.Default.setDisplay_isSectionLinesOn;

            if (isMetric)
            {
                inchOrCm2m = 0.01;
                m2InchOrCm = 100.0;

                m2FtOrM = 1.0;
                ftOrMtoM = 1.0;

                inOrCm2Cm = 1.0;
                cm2CmOrIn = 1.0;

                unitsFtM = " m";
                unitsInCm = " cm";
                unitsInCmNS = "cm";
            }
            else
            {
                inchOrCm2m = glm.in2m;
                m2InchOrCm = glm.m2in;

                m2FtOrM = glm.m2ft;
                ftOrMtoM = glm.ft2m;

                inOrCm2Cm = 2.54;
                cm2CmOrIn = 0.394;

                unitsInCm = " in";
                unitsInCmNS = "in";
                unitsFtM = " ft";
            }

            udpWatchLimit = Properties.Settings.Default.SetGPS_udpWatchMsec;
            pn.headingTrueDualOffset = Properties.Settings.Default.setGPS_dualHeadingOffset;
            dualReverseDetectionDistance = Properties.Settings.Default.setGPS_dualReverseDetectionDistance;

            frameDayColor = Properties.Settings.Default.setDisplay_colorDayFrame.CheckColorFor255();
            frameNightColor = Properties.Settings.Default.setDisplay_colorNightFrame.CheckColorFor255();
            sectionColorDay = Properties.Settings.Default.setDisplay_colorSectionsDay.CheckColorFor255();
            fieldColorDay = Properties.Settings.Default.setDisplay_colorFieldDay.CheckColorFor255();
            fieldColorNight = Properties.Settings.Default.setDisplay_colorFieldNight.CheckColorFor255();

            //load up colors
            textColorDay = Settings.Default.setDisplay_colorTextDay.CheckColorFor255();
            textColorNight = Settings.Default.setDisplay_colorTextNight.CheckColorFor255();

            //load the string of custom colors
            string[] words = Properties.Settings.Default.setDisplay_customColors.Split(',');
            for (int i = 0; i < 16; i++)
            {
                Color test;
                customColorsList[i] = int.Parse(words[i], CultureInfo.InvariantCulture);
                test = Color.FromArgb(customColorsList[i]).CheckColorFor255();
                int iCol = (test.A << 24) | (test.R << 16) | (test.G << 8) | test.B;
                customColorsList[i] = iCol;
            }

            isTextureOn = Settings.Default.setDisplay_isTextureOn;
            isLogElevation = Settings.Default.setDisplay_isLogElevation;
            isLineSmooth = Properties.Settings.Default.setDisplay_isLineSmooth;

            isGridOn = Settings.Default.setMenu_isGridOn;
            isBrightnessOn = Settings.Default.setDisplay_isBrightnessOn;

            isCompassOn = Settings.Default.setMenu_isCompassOn;
            isSpeedoOn = Settings.Default.setMenu_isSpeedoOn;
            isSideGuideLines = Settings.Default.setMenu_isSideGuideLines;
            isSvennArrowOn = Settings.Default.setDisplay_isSvennArrowOn;

            isPureDisplayOn = Settings.Default.setMenu_isPureOn;

            isAutoStartAgIO = Settings.Default.setDisplay_isAutoStartAgIO;

            isDirectionMarkers = Settings.Default.setTool_isDirectionMarkers;

            panelNavigation.Location = new System.Drawing.Point(90, 100);
            panelDrag.Location = new System.Drawing.Point(87, 268);

            vehicle.VehicleConfig.Opacity = ((double)(Properties.Settings.Default.setDisplay_vehicleOpacity) * 0.01);
            isVehicleImage = Properties.Settings.Default.setDisplay_isVehicleImage;

            string directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            simulatorOnToolStripMenuItem.Checked = Settings.Default.setMenu_isSimulatorOn;
            if (simulatorOnToolStripMenuItem.Checked)
            {
                panelSim.Visible = true;
                timerSim.Enabled = true;
            }
            else
            {
                panelSim.Visible = false;
                timerSim.Enabled = false;
            }

            if (timerSim.Enabled) gpsHz = 10;

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            vehicle.VehicleConfig.Color = (ColorRgb)Settings.Default.setDisplay_colorVehicle.CheckColorFor255();

            isLightbarOn = Settings.Default.setMenu_isLightbarOn;
            isLightBarNotSteerBar = Settings.Default.setMenu_isLightbarNotSteerBar;
            //set up grid and lightbar

            isKeyboardOn = Settings.Default.setDisplay_isKeyboardOn;

            //if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "R";
            //else btnAutoSteer.Text = "M";

            if (bnd.isHeadlandOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
            else btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;

            //btnChangeMappingColor.BackColor = sectionColorDay;
            btnChangeMappingColor.Text = Program.Version;

            if (Properties.Settings.Default.setDisplay_isStartFullScreen)
            {
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
            else
            {
                isFullScreen = false;
            }

            if (!isKioskMode)
            {
                if (Properties.Settings.Default.setDisplay_isStartFullScreen)
                {
                    this.WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }
                else
                {
                    isFullScreen = false;
                }
            }

            //is rtk on?
            isRTK_AlarmOn = Properties.Settings.Default.setGPS_isRTK;
            isRTK_KillAutosteer = Properties.Settings.Default.setGPS_isRTK_KillAutoSteer;

            pn.ageAlarm = Properties.Settings.Default.setGPS_ageAlarm;

            isConstantContourOn = Properties.Settings.Default.setAS_isConstantContourOn;
            isSteerInReverse = Properties.Settings.Default.setAS_isSteerInReverse;

            guidanceLookAheadTime = Properties.Settings.Default.setAS_guidanceLookAheadTime;

            gyd.sideHillCompFactor = Properties.Settings.Default.setAS_sideHillComp;

            ahrs = new CAHRS();

            fd.UpdateFieldBoundaryGUIAreas();

            btnSection1Man.Visible = false;
            btnSection2Man.Visible = false;
            btnSection3Man.Visible = false;
            btnSection4Man.Visible = false;
            btnSection5Man.Visible = false;
            btnSection6Man.Visible = false;
            btnSection7Man.Visible = false;
            btnSection8Man.Visible = false;
            btnSection9Man.Visible = false;
            btnSection10Man.Visible = false;
            btnSection11Man.Visible = false;
            btnSection12Man.Visible = false;
            btnSection13Man.Visible = false;
            btnSection14Man.Visible = false;
            btnSection15Man.Visible = false;
            btnSection16Man.Visible = false;

            btnZone1.Visible = false;
            btnZone2.Visible = false;
            btnZone3.Visible = false;
            btnZone4.Visible = false;
            btnZone5.Visible = false;
            btnZone6.Visible = false;
            btnZone7.Visible = false;
            btnZone8.Visible = false;

            if (tool.isSectionsNotZones)
            {
                //Set width of section and positions for each section
                SectionSetPosition();

                //Calculate total width and each section width
                SectionCalcWidths();
                LineUpIndividualSectionBtns();
            }
            else
            {
                SectionCalcMulti();
                LineUpAllZoneButtons();
            }

            DisableYouTurnButtons();

            //which heading source is being used
            headingFromSource = Settings.Default.setGPS_headingFromWhichSource;

            //workswitch stuff
            mc.isRemoteWorkSystemOn = Settings.Default.setF_isRemoteWorkSystemOn;

            mc.isWorkSwitchActiveLow = Settings.Default.setF_isWorkSwitchActiveLow;
            mc.isWorkSwitchManualSections = Settings.Default.setF_isWorkSwitchManualSections;
            mc.isWorkSwitchEnabled = Settings.Default.setF_isWorkSwitchEnabled;

            mc.isSteerWorkSwitchEnabled = Settings.Default.setF_isSteerWorkSwitchEnabled;
            mc.isSteerWorkSwitchManualSections = Settings.Default.setF_isSteerWorkSwitchManualSections;

            minHeadingStepDist = Settings.Default.setF_minHeadingStepDistance;
            gpsMinimumStepDistance = Settings.Default.setGPS_minimumStepLimit;

            fd.workedAreaTotalUser = Settings.Default.setF_UserTotalArea;

            yt.uTurnSmoothing = Settings.Default.setAS_uTurnSmoothing;

            tool.halfWidth = (tool.width - tool.overlap) / 2.0;
            tool.contourWidth = (tool.width - tool.overlap) / 3.0;

            //load the lightbar resolution
            lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            isStanleyUsed = Properties.Settings.Default.setVehicle_isStanleyUsed;

            //main window first
            if (!isKioskMode)
            {
                //main window first
                if (Settings.Default.setWindow_Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    Location = Settings.Default.setWindow_Location;
                    Size = Settings.Default.setWindow_Size;
                }
                else if (Settings.Default.setWindow_Minimized)
                {
                    //WindowState = FormWindowState.Minimized;
                    Location = Settings.Default.setWindow_Location;
                    Size = Settings.Default.setWindow_Size;
                }
                else
                {
                    Location = Settings.Default.setWindow_Location;
                    Size = Settings.Default.setWindow_Size;
                }
            }

            if (!ScreenHelper.IsOnScreen(Bounds))
            {
                Top = 0;
                Left = 0;
            }

            if (isKioskMode)
            {
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
                //ajout memprou btnMaximizeMainForm.Visible = false;
                //ajout memprou btnMinimizeMainForm.Visible = false;
            }

            //night mode
            isDay = Properties.Settings.Default.setDisplay_isDayMode;
            isDay = !isDay;
            SwapDayNightMode();

            //load uturn properties
            yt = new CYouTurn(this);

            //ajout memprou lblNumCu.Visible = false;
            //ajout memprou lblNumCu.Text = "";

            words = Properties.Settings.Default.setDisplay_buttonOrder.Split(',');
            buttonOrder?.Clear();

            for (int i = 0; i < words.Length; i++)
            {
                buttonOrder.Add(int.Parse(words[i], CultureInfo.InvariantCulture));
            }

            bnd.isSectionControlledByHeadland = Properties.Settings.Default.setHeadland_isSectionControlled;
            //ajout memprou if (bnd.isSectionControlledByHeadland) cboxIsSectionControlled.Image = Properties.Resources.HeadlandSectionOn;
            //ajout memprou else cboxIsSectionControlled.Image = Properties.Resources.HeadlandSectionOff;

            //right side build
            PanelBuildRightMenu();

            PanelsAndOGLSize();
            PanelUpdateRightAndBottom();

            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();

            lblGuidanceLine.BringToFront();
            lblHardwareMessage.BringToFront();
            isHardwareMessages = Properties.Settings.Default.setDisplay_isHardwareMessages;

            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
            {
                btnChargeStatus.BackColor = Color.YellowGreen;
            }
            else
            {
                btnChargeStatus.BackColor = Color.LightCoral;
            }

            //jumpDistanceAlarm = Settings.Default.setGPS_jumpFixAlarmDistance;
        }

        public void PanelUpdateRightAndBottom()
        {
            if (isJobStarted)
            {
                int tracksTotal = 0, tracksVisible = 0;
                bool isHdl = false;

                bool isBnd = bnd.bndList.Count > 0;
                if (!isBnd) isHdl = isBnd;
                else isHdl = bnd.bndList[0].hdLine.Count > 0;

                bool istram = (tram.tramList.Count + tram.tramBndOuterArr.Count) > 0;

                for (int i = 0; i < trk.gArr.Count; i++)
                {
                    tracksTotal++;
                    if (trk.gArr[i].isVisible) tracksVisible++;
                }

                //ajout memprou btnContourLock.Visible = ct.isContourBtnOn;

                if (trk.idx > -1 || ct.isContourBtnOn)
                    btnAutoSteer.Enabled = true;
                else
                {
                    if (isBtnAutoSteerOn)
                    {
                        btnAutoSteer.PerformClick();
                        TimedMessageBox(2000, gStr.gsGuidanceStopped, gStr.gsNoGuidanceLines);
                        Log.EventWriter("Steer Safe Off, No Tracks, Idx -1");
                    }
                    btnAutoSteer.Enabled = false;
                }

                //ajout memprou btnAutoYouTurn.Visible = trk.idx > -1 && !ct.isContourBtnOn && isBnd;
                //ajout memprou btnCycleLines.Visible = tracksVisible > 1 && trk.idx > -1 && !ct.isContourBtnOn;
                //ajout memprou btnCycleLinesBk.Visible = tracksVisible > 1 && trk.idx > -1 && !ct.isContourBtnOn;
                //ajout memprou
                if (tracksVisible > 0 && trk.idx > -1 && !ct.isContourBtnOn)
                {
                    round_table1.Left = oglMain.Width - 225;
                    round_table4.Left = oglMain.Width - 150;
                    btnNudge.Visible = true;
                }
                else
                {
                    round_table1.Left = oglMain.Width - 85;
                    round_table4.Left = oglMain.Width - 85;
                    btnNudge.Visible = false;

                }
                //fin
                cboxpRowWidth.Visible = trk.idx > -1;
                btnYouSkipEnable.Visible = trk.idx > -1;

                //ajout memprou btnSnapToPivot.Visible = trk.idx > -1 && isNudgeOn;
                //ajout memprou btnAdjLeft.Visible = trk.idx > -1 && isNudgeOn;
                //ajout memprou btnAdjRight.Visible = trk.idx > -1 && isNudgeOn;

                //ajout memprou btnTramDisplayMode.Visible = istram;
                //ajout memprou btnHeadlandOnOff.Visible = isHdl;

                int sett = Properties.Settings.Default.setArdMac_setting0;
                //ajout memprou btnHydLift.Visible = (((sett & 2) == 2) && isHdl);

                //ajout memprou cboxIsSectionControlled.Visible = isHdl;

                //btnResetToolHeading.Visible = this.Width > 1190;
                /*/ memprou
                btnAutoTrack.Visible = tracksVisible > 1 && trk.idx > -1 && !ct.isContourBtnOn;

                if (trk.idx > -1 && trk.gArr.Count > 0 && !ct.isContourBtnOn)
                {
                    lblNumCu.Visible = true;
                    lblNumCu.Text = (trk.idx+1).ToString() + "/" + trk.gArr.Count.ToString();
                }
                else
                {
                    lblNumCu.Visible = false;
                    lblNumCu.Text = "";
                }
                /*/ //fin

                PanelSizeRightAndBottom();
            }
        }

        public void PanelBuildRightMenu()
        {
            /*/ //ajout memprou
            panelRight.Controls.Clear();

            for (int i = 0; i < buttonOrder.Count; i++)
            {
                switch (buttonOrder[i])
                {
                    case 0:
                        panelRight.Controls.Add(btnAutoSteer);
                        break;

                    case 1:
                        panelRight.Controls.Add(btnAutoYouTurn);
                        break;

                    case 2:
                        panelRight.Controls.Add(btnSectionMasterAuto);
                        break;

                    case 3:
                        panelRight.Controls.Add(btnSectionMasterManual);
                        break;

                    case 4:
                        panelRight.Controls.Add(btnAutoTrack);
                        break;

                    case 5:
                        panelRight.Controls.Add(btnCycleLinesBk);
                        break;

                    case 6:
                        panelRight.Controls.Add(btnCycleLines);
                        break;

                    case 7:
                        panelRight.Controls.Add(btnContour);
                        panelRight.Controls.Add(btnContourLock);
                        break;

                    default:
                        break;
                }
            }

            panelRight.Controls.Add(lblNumCu);

                        /*/ //fin
            //Ajout-modification MEmprou et SPailleau
            //fin
        }

        public void PanelSizeRightAndBottom()
        {
            /*/  ajout memprou
            btnResetToolHeading.Visible = false;
            int viz = 0;
            for (int i = 0; i < panelRight.Controls.Count; i++)
            {
                if (panelRight.Controls[i].Visible && panelRight.Controls[i] is Button) viz++;
            }

            if (viz == 0) return;

            int sizer = (Height - 140) / (viz);
            if (sizer > 120) { sizer = 120; }

            for (int i = 0; i < panelRight.Controls.Count; i++)
            {
                if (panelRight.Controls[i].Visible && panelRight.Controls[i] is Button)
                {
                    panelRight.Controls[i].Height = sizer;
                }
            }

            if (panelBottom.Visible)
            {
                viz = 0;
                for (int i = 0; i < panelBottom.Controls.Count; i++)
                {
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is Button)
                        viz++;
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is CheckBox)
                        viz++;
                }

                if (viz == 0) return;
                if (viz > 9 && Width < 1190)
                {
                    btnResetToolHeading.Visible = false;
                }
                else
                {
                    btnResetToolHeading.Visible = true;
                    viz++;
                }

                sizer = (Width - 185) / (viz);
                if (sizer > 150) { sizer = 150; }

                for (int i = 0; i < panelBottom.Controls.Count; i++)
                {
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is Button)
                        panelBottom.Controls[i].Width = sizer;
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is CheckBox)
                        panelBottom.Controls[i].Width = sizer;
                }

            }
            /*/ //fin
            btnFlag.Text = isStanleyUsed ? "S" : "P";
        }

        private void PanelsAndOGLSize()
        {
            /*/ //ajout memprou
            if (!isJobStarted)
            {
                panelBottom.Visible = false;
                panelRight.Visible = false;

                oglMain.Left = 80;
                oglMain.Width = this.Width - statusStripLeft.Width - 22; //22                
                oglMain.Height = this.Height - 60;
            }
            else
            {

                if (isPanelBottomHidden)
                {
                    panelBottom.Visible = false;
                    panelLeft.Visible = false;

                    oglMain.Left = 20;


                    oglMain.Width = this.Width - 98; //22

                    oglMain.Height = this.Height - 62;
                }
                else
                {
                    panelBottom.Visible = true;
                    panelRight.Visible = true;
                    panelLeft.Visible = true;
                    oglMain.Left = 80;

                    oglMain.Width = this.Width - statusStripLeft.Width - 92; //22

                    oglMain.Height = this.Height - 118;
                }
            }
            /*/ //fin
            PanelSizeRightAndBottom();

            if (tool.isSectionsNotZones)
            {
                LineUpIndividualSectionBtns();
            }
            else
            {
                LineUpAllZoneButtons();
            }
        }

        private void ZoomByMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.06;
                else camera.zoomValue += camera.zoomValue * 0.02;
                if (camera.zoomValue > 120) camera.zoomValue = 120;
                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
            else
            {
                if (camera.zoomValue <= 20)
                { if ((camera.zoomValue -= camera.zoomValue * 0.06) < 4.0) camera.zoomValue = 4.0; }
                else { if ((camera.zoomValue -= camera.zoomValue * 0.02) < 4.0) camera.zoomValue = 4.0; }

                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
        }

        public void SwapDayNightMode()
        {
            isDay = !isDay;
            if (isDay)
            {
                btnDayNightMode.Image = Properties.Resources.WindowNightMode;

                this.BackColor = frameDayColor;
                foreach (Control c in this.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }

                /*/ //ajout memprou foreach (Control c in panelRight.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }
                /*/

                foreach (Control c in panelNavigation.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }
                /*/ //ajout memprou
                foreach (Control c in panelControlBox.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }
                /*/

                btnChangeMappingColor.ForeColor = textColorDay;
            }
            else //nightmode
            {
                btnDayNightMode.Image = Properties.Resources.WindowDayMode;
                this.BackColor = frameNightColor;

                foreach (Control c in this.Controls)
                {
                    {
                        c.ForeColor = textColorNight;
                    }
                }

                /*/ //ajout memprou
                             foreach (Control c in panelRight.Controls)
                             {
                                 //if (c is Label || c is Button)
                                 {
                                     c.ForeColor = textColorNight;
                                 }
                             }
                             /*/

                foreach (Control c in panelNavigation.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorNight;
                    }
                }


                /*/ //ajout memprou
                 foreach (Control c in panelControlBox.Controls)
                 {
                     //if (c is Label || c is Button)
                     {
                         c.ForeColor = textColorNight;
                     }
                 }
                 /*/

                btnChangeMappingColor.ForeColor = textColorNight;
            }

            if (tool.isSectionsNotZones)
            {
                LineUpIndividualSectionBtns();
            }
            else
            {
                LineUpAllZoneButtons();
            }

            Properties.Settings.Default.setDisplay_isDayMode = isDay;
            Properties.Settings.Default.Save();
        }

        public void SaveFormGPSWindowSettings()
        {
            //save window settings
            if (WindowState == FormWindowState.Maximized)
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.setWindow_Location = Location;
                Settings.Default.setWindow_Size = Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = false;
            }
            else
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = true;
            }

            Settings.Default.setDisplay_camPitch = camera.camPitch;
            Properties.Settings.Default.setDisplay_camZoom = camera.zoomValue;

            Settings.Default.setF_UserTotalArea = fd.workedAreaTotalUser;

            //Settings.Default.setDisplay_panelSnapLocation = panelSnap.Location;
            Settings.Default.setDisplay_panelSimLocation = panelSim.Location;

            Settings.Default.Save();
        }

        public string FindDirection(double heading)
        {
            if (heading < 0) heading += glm.twoPI;

            heading = glm.toDegrees(heading);

            if (heading > 337.5 || heading < 22.5)
            {
                return (" " +  gStr.gsNorth + " ");
            }
            if (heading > 22.5 && heading < 67.5)
            {
                return (" " +  gStr.gsN_East + " ");
            }
            if (heading > 67.5 && heading < 111.5)
            {
                return (" " +  gStr.gsEast + " ");
            }
            if (heading > 111.5 && heading < 157.5)
            {
                return (" " +  gStr.gsS_East + " ");
            }
            if (heading > 157.5 && heading < 202.5)
            {
                return (" " +  gStr.gsSouth + " ");
            }
            if (heading > 202.5 && heading < 247.5)
            {
                return (" " +  gStr.gsS_West + " ");
            }
            if (heading > 247.5 && heading < 292.5)
            {
                return (" " +  gStr.gsWest + " ");
            }
            if (heading > 292.5 && heading < 337.5)
            {
                return (" " +  gStr.gsN_West + " ");
            }
            return (" ?? ");
        }

        //Mouse Clicks 
        private void oglMain_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                int centerX = oglMain.Width / 2;
                int centerY = oglMain.Height / 2;

                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = oglMain.PointToClient(Cursor.Position);

                if (isJobStarted)
                {
                    if (isBtnAutoSteerOn || yt.isYouTurnBtnOn)
                    {
                        //uturn and swap uturn direction
                        if (point.Y < 90 && point.Y > 30 && (trk.idx > -1)) //ajout max
                        {

                            double middle = oglMain.Width / 2 + oglMain.Width / 5; //ajout max (double)
                            if (point.X > middle - 80 && point.X < middle + 80)
                            {
                                SwapDirection();
                                yt.turnTooCloseTrigger = false;
                                yt.isTurnCreationTooClose = false;
                                return;
                            }

                            //k turn or u turn
                            middle = oglMain.Width / 2 + oglMain.Width / 5 + 140; //ajout max (double)
                            if (point.X > middle - 25 && point.X < middle + 25)
                            {
                                yt.uTurnStyle++;
                                if (yt.uTurnStyle > 1) yt.uTurnStyle = 0;
                                yt.ResetCreatedYouTurn();

                                Properties.Settings.Default.set_uTurnStyle = yt.uTurnStyle;
                                Properties.Settings.Default.Save();

                                return;
                            }

                            if (!isStanleyUsed)
                            {
                                //manual uturn triggering
                                middle = oglMain.Width / 2 - oglMain.Width / 6;//ajout memprou
                                if (point.X > middle - 140 && point.X < middle && isUTurnOn) //ajout memprou
                                {
                                    if (yt.isYouTurnTriggered)
                                    {
                                        yt.ResetYouTurn();
                                        return;//ajout max
                                    }
                                    else
                                    {
                                        if (vehicle.functionSpeedLimit > avgSpeed)
                                        {
                                            yt.isYouTurnTriggered = true;
                                            yt.BuildManualYouTurn(false, true);
                                        }
                                        else
                                        {
                                            SpeedLimitExceeded();
                                        }
                                        return;
                                    }
                                }

                                if (point.X > middle && point.X < middle + 140 && isUTurnOn) //ajout memprou
                                {
                                    if (yt.isYouTurnTriggered)
                                    {
                                        yt.ResetYouTurn();
                                        return;//ajout max
                                    }
                                    else
                                    {
                                        if (vehicle.functionSpeedLimit > avgSpeed)
                                        {
                                            yt.isYouTurnTriggered = true;
                                            yt.BuildManualYouTurn(true, true);
                                        }
                                        else
                                        {
                                            SpeedLimitExceeded();
                                        }

                                        return;
                                    }
                                }
                            }
                        }

                        //lateral
                        if (point.Y < 180 && point.Y > 120 && (trk.idx > -1)) //ajout memprou
                        {
                            int middle = oglMain.Width / 2 - oglMain.Width / 6;//ajout memprou
                            if (point.X > middle - 160 && point.X < middle && isLateralOn) //ajout memprou
                            {
                                if (vehicle.functionSpeedLimit > avgSpeed)
                                {
                                    yt.BuildManualYouLateral(false);
                                    yt.ResetYouTurn();
                                }
                                else
                                {
                                    SpeedLimitExceeded();
                                }

                                return;
                            }

                            if (point.X > middle && point.X < middle + 160 && isLateralOn) //ajout memprou
                            {
                                if (vehicle.functionSpeedLimit > avgSpeed)
                                {
                                    yt.BuildManualYouLateral(true);
                                    yt.ResetYouTurn();
                                }
                                else
                                {
                                    SpeedLimitExceeded();
                                }

                                return;
                            }
                        }
                    }

                    //ajout max
                    //pan and hide menus
                    if (point.X > oglMain.Width - 80) //ajout max
                    {
                        if (point.Y > 70 && point.Y < 102)
                        {
                            isPanFormVisible = true;
                            Form f = Application.OpenForms["FormPan"];

                            if (f != null)
                            {
                                f.Focus();
                                return;
                            }

                            Form form = new FormPan(this);
                            form.Show(this);

                            form.Top = this.Top + 90;
                            form.Left = round_table11.Left - 100; //ajout max
                            return;//ajout max
                        }

                        if (isJobStarted)
                        {
                            if (point.Y > oglMain.Height - 60 && point.Y < oglMain.Height - 30)
                            {
                                isPanelBottomHidden = !isPanelBottomHidden;
                                PanelsAndOGLSize();
                                return;
                            }
                        }
                    }
                    //fin

                    //tram override
                    int bottomSide = oglMain.Height / 5 + 25;

                    if (tool.isDisplayTramControl && (point.Y > (bottomSide-50) && point.Y < bottomSide))
                    {
                        if (point.X > centerX - 100 && point.X < centerX - 20)
                        {
                            tram.isLeftManualOn = !tram.isLeftManualOn;
                        }
                        if (point.X > centerX + 20 && point.X < centerX + 100)
                        {
                            tram.isRightManualOn = !tram.isRightManualOn;
                        }
                    }
                }

                //ajout memprou
                //zoom buttons
                if (point.X > oglMain.Width - 80)
                {
                    //---
                    if (point.Y < 202 && point.Y > 170)
                    {
                        if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.2;
                        else camera.zoomValue += camera.zoomValue * 0.1;
                        if (camera.zoomValue > 180) camera.zoomValue = 180;
                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }

                    //++
                    if (point.Y < 152 && point.Y > 120)
                    {
                        if (camera.zoomValue <= 20)
                        { if ((camera.zoomValue -= camera.zoomValue * 0.2) < 6.0) camera.zoomValue = 6.0; }
                        else { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 6.0) camera.zoomValue = 6.0; }

                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }
                }
                //fin

                //vehicle direcvtion reset
                if (point.X > centerX - 40 && point.X < centerX + 40
                    && point.Y > centerY - 60 && point.Y < centerY + 60)
                {
                    if (headingFromSource == "Dual") return;

                    Array.Clear(stepFixPts, 0, stepFixPts.Length);
                    isFirstHeadingSet = false;
                    isReverse = false;
                    TimedMessageBox(2000, "Reset Direction", "Drive Forward > 1.5 kmh");
                    Log.EventWriter("Direction Reset, Drive Forward");

                    return;
                }

                mouseX = point.X;
                mouseY = oglMain.Height - point.Y;

                //prevent flag selection if flag form is up
                Form fc = Application.OpenForms["Flags"];
                if (fc != null)
                {
                    fc.Focus();
                    return;
                }

                leftMouseDownOnOpenGL = true;
            }
        }
        private void SpeedLimitExceeded()
        {
            if (isMetric)
            {
                TimedMessageBox(2000, gStr.gsTooFast, gStr.gsSlowDownBelow + " "
                    + vehicle.functionSpeedLimit.ToString("N0") + " " + gStr.gsKMH);
            }
            else
            {
                TimedMessageBox(2000, gStr.gsTooFast, gStr.gsSlowDownBelow + " "
                    + (vehicle.functionSpeedLimit * 0.621371).ToString("N1") + " " + gStr.gsMPH);
            }

            Log.EventWriter("UTurn or Lateral Speed exceeded");

        }

        public void SwapDirection()
        {
            if (!yt.isYouTurnTriggered)
            {
                yt.isTurnLeft = !yt.isTurnLeft;
                yt.ResetCreatedYouTurn();
            }
            else if (yt.isYouTurnBtnOn)
                btnAutoYouTurn.PerformClick();
        }

        //Function to delete flag
        public void DeleteSelectedFlag()
        {
            //delete selected flag and set selected to none
            flagPts.RemoveAt(flagNumberPicked - 1);
            flagNumberPicked = 0;

            // re-sort the id's based on how many flags left
            int flagCnt = flagPts.Count;
            if (flagCnt > 0)
            {
                for (int i = 0; i < flagCnt; i++) flagPts[i].ID = i + 1;
            }
        }
        public void EnableYouTurnButtons()
        {
            yt.ResetYouTurn();
            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
        }
        public void DisableYouTurnButtons()
        {
            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            yt.ResetYouTurn();
        }

        private void ShowNoGPSWarning()
        {
            //update main window
            sentenceCounter = 300;
            oglMain.MakeCurrent();
            oglMain.Refresh();
        }
        //Ajout-modification MEmprou et SPailleau
        public void long_touch()
        {
            if (!Properties.Settings.Default.UP_setDisplay_islong_touchOn)
            {
                headlandToolStripMenuItem.Visible = true;
                deleteContourPathsToolStripMenuItem.Visible = true;
                tramLinesMenuField.Visible = true;
                //toolStripBtnMakeBndContour.Visible = true;

            }
            else
            {
                headlandToolStripMenuItem.Visible = false;
                deleteContourPathsToolStripMenuItem.Visible = false;
                tramLinesMenuField.Visible = false;
                //toolStripBtnMakeBndContour.Visible = false;
            }
        }
        #region Properties // ---------------------------------------------------------------------

        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude, 7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude, 7)); } }
        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string HDOP { get { return Convert.ToString(pn.hdop); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string GPSHeading { get { return (Math.Round(glm.toDegrees(gpsHeading), 1)) + "\u00B0"; } }
        public string FixQuality
        {
            get
            {
                if (pn.fixQuality == 0) return "Invalid: ";
                else if (pn.fixQuality == 1) return "GPS single: ";
                else if (pn.fixQuality == 2) return "DGPS: ";
                else if (pn.fixQuality == 3) return "PPS: ";
                else if (pn.fixQuality == 4) return "RTK fix: ";
                else if (pn.fixQuality == 5) return "RTK Float: ";
                else if (pn.fixQuality == 6) return "Estimate: ";
                else if (pn.fixQuality == 7) return "Man IP: ";
                else if (pn.fixQuality == 8) return "Sim: ";
                else return "Unknown: ";
            }
        }
        public string GyroInDegrees
        {
            get
            {
                if (ahrs.imuHeading != 99999)
                    return Math.Round(ahrs.imuHeading, 1) + "\u00B0";
                else return "-";
            }
        }
        public string RollInDegrees
        {
            get
            {
                if (ahrs.imuRoll != 88888)
                    return Math.Round((ahrs.imuRoll), 1) + "\u00B0";
                else return "-";
            }
        }
        public string SetSteerAngle { get { return ((double)(guidanceLineSteerAngle) * 0.01).ToString("N1"); } }
        public string ActualSteerAngle { get { return ((mc.actualSteerAngleDegrees) ).ToString("N1") ; } }

        //Metric and Imperial Properties
        public string SpeedMPH
        {
            get
            {
                if (avgSpeed > 2)
                    return (avgSpeed * 0.62137).ToString("N1");
                else
                    return(avgSpeed * 0.62137).ToString("N2");
            }
        }
        public string SpeedKPH
        {
            get
            {
                if (avgSpeed > 2)
                    return (avgSpeed).ToString("N1");
                else
                    return (avgSpeed).ToString("N2");
            }
        }

        public string FixOffset { get { return (pn.fixOffset.easting.ToString("N2") + ", " + pn.fixOffset.northing.ToString("N2")); } }
        public string FixOffsetInch { get { return ((pn.fixOffset.easting*glm.m2in).ToString("N0")+ ", " + (pn.fixOffset.northing*glm.m2in).ToString("N0")); } }

        public string Altitude { get { return Convert.ToString(Math.Round(pn.altitude,2)); } }
        public string AltitudeFeet { get { return Convert.ToString((Math.Round((pn.altitude * 3.28084),1))); } }
        public string DistPivotM
        {
            get
            {
                if (distancePivotToTurnLine > 0 )
                    return ((int)(distancePivotToTurnLine)) + " m";
                else return "--";
            }
        }
        public string DistPivotFt
        {
            get
            {
                if (distancePivotToTurnLine > 0 ) return (((int)(glm.m2ft * (distancePivotToTurnLine))) + " ft");
                else return "--";
            }
        }

        #endregion properties 

        //Load Bitmaps brand
        public Bitmap GetTractorBrand(TractorBrand brand)
        {
            switch (brand)
            {
                case TractorBrand.Case:
                    return Resources.z_TractorCase;
                case TractorBrand.Claas:
                    return Resources.z_TractorClaas;
                case TractorBrand.Deutz:
                    return Resources.z_TractorDeutz;
                case TractorBrand.Fendt:
                    return Resources.z_TractorFendt;
                case TractorBrand.JDeere:
                    return Resources.z_TractorJDeere;
                case TractorBrand.Kubota:
                    return Resources.z_TractorKubota;
                case TractorBrand.Massey:
                    return Resources.z_TractorMassey;
                case TractorBrand.NewHolland:
                    return Resources.z_TractorNH;
                case TractorBrand.Same:
                    return Resources.z_TractorSame;
                case TractorBrand.Steyr:
                    return Resources.z_TractorSteyr;
                case TractorBrand.Ursus:
                    return Resources.z_TractorUrsus;
                case TractorBrand.Valtra:
                    return Resources.z_TractorValtra;
                case TractorBrand.JCB:
                    return Resources.z_TractorJCB;
                default:
                    return Resources.z_TractorAoG;
            }
        }

        public Bitmap GetHarvesterBrand(HarvesterBrand brand)
        {
            switch (brand)
            {
                case HarvesterBrand.Case:
                    return Resources.z_HarvesterCase;
                case HarvesterBrand.Claas:
                    return Resources.z_HarvesterClaas;
                case HarvesterBrand.JDeere:
                    return Resources.z_HarvesterJD;
                case HarvesterBrand.NewHolland:
                    return Resources.z_HarvesterNH;
                default:
                    return Resources.z_HarvesterAoG;
            }
        }

        public Bitmap GetArticulatedBrandFront(ArticulatedBrand brand)
        {
            switch (brand)
            {
                case ArticulatedBrand.Case:
                    return Resources.z_ArticulatedFrontCase;
                case ArticulatedBrand.Challenger:
                    return Resources.z_ArticulatedFrontChallenger;
                case ArticulatedBrand.JDeere:
                    return Resources.z_ArticulatedFrontJDeere;
                case ArticulatedBrand.NewHolland:
                    return Resources.z_ArticulatedFrontNH;
                case ArticulatedBrand.Holder:
                    return Resources.z_ArticulatedFrontHolder;
                default:
                    return Resources.z_ArticulatedFrontAoG;
            }
        }
        
        public Bitmap GetArticulatedBrandRear(ArticulatedBrand brand)
        {
            switch (brand)
            {
                case ArticulatedBrand.Case:
                    return Resources.z_ArticulatedRearCase;
                case ArticulatedBrand.Challenger:
                    return Resources.z_ArticulatedRearChallenger;
                case ArticulatedBrand.JDeere:
                    return Resources.z_ArticulatedRearJDeere;
                case ArticulatedBrand.NewHolland:
                    return Resources.z_ArticulatedRearNH;
                case ArticulatedBrand.Holder:
                    return Resources.z_ArticulatedRearHolder;
                default:
                    return Resources.z_ArticulatedRearAoG;
            }
        }

    }//end class
}//end namespace