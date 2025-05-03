﻿//Please, if you use this, share the improvements

using AgLibrary.Logging;
using AgOpenGPS.Controls;
using AgOpenGPS.Culture;
using AgOpenGPS.Helpers;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private bool isClosing = false;

        //constructor
        public FormConfig(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            tab1.Appearance = TabAppearance.FlatButtons;
            tab1.ItemSize = new Size(0, 1);
            tab1.SizeMode = TabSizeMode.Fixed;

            HideSubMenu();

            nudTrailingHitchLength.Controls[0].Enabled = false;
            nudDrawbarLength.Controls[0].Enabled = false;
            nudTankHitch.Controls[0].Enabled = false;
            nudTractorHitchLength.Controls[0].Enabled = false;

            nudLookAhead.Controls[0].Enabled = false;
            nudLookAheadOff.Controls[0].Enabled = false;
            nudTurnOffDelay.Controls[0].Enabled = false;
            nudOffset.Controls[0].Enabled = false;
            nudOverlap.Controls[0].Enabled = false;
            nudCutoffSpeed.Controls[0].Enabled = false;

            nudAntennaHeight.Controls[0].Enabled = false;
            nudAntennaOffset.Controls[0].Enabled = false;
            nudAntennaPivot.Controls[0].Enabled = false;
            nudVehicleTrack.Controls[0].Enabled = false;
            nudWheelbase.Controls[0].Enabled = false;

            nudMinCoverage.Controls[0].Enabled = false;
            nudDefaultSectionWidth.Controls[0].Enabled = false;

            nudSection01.Controls[0].Enabled = false;
            nudSection02.Controls[0].Enabled = false;
            nudSection03.Controls[0].Enabled = false;
            nudSection04.Controls[0].Enabled = false;
            nudSection05.Controls[0].Enabled = false;
            nudSection06.Controls[0].Enabled = false;
            nudSection07.Controls[0].Enabled = false;
            nudSection08.Controls[0].Enabled = false;
            nudSection09.Controls[0].Enabled = false;
            nudSection10.Controls[0].Enabled = false;
            nudSection11.Controls[0].Enabled = false;
            nudSection12.Controls[0].Enabled = false;
            nudSection13.Controls[0].Enabled = false;
            nudSection14.Controls[0].Enabled = false;
            nudSection15.Controls[0].Enabled = false;
            nudSection16.Controls[0].Enabled = false;
            nudNumberOfSections.Controls[0].Enabled = false;

            nudZone1To.Controls[0].Enabled = false;
            nudZone2To.Controls[0].Enabled = false;
            nudZone3To.Controls[0].Enabled = false;
            nudZone4To.Controls[0].Enabled = false;
            nudZone5To.Controls[0].Enabled = false;
            nudZone6To.Controls[0].Enabled = false;

            nudRaiseTime.Controls[0].Enabled = false;
            nudLowerTime.Controls[0].Enabled = false;

            nudUser1.Controls[0].Enabled = false;
            nudUser2.Controls[0].Enabled = false;
            nudUser3.Controls[0].Enabled = false;
            nudUser4.Controls[0].Enabled = false;

            nudTramWidth.Controls[0].Enabled = false;

            nudDualHeadingOffset.Controls[0].Enabled = false;
            nudDualReverseDistance.Controls[0].Enabled = false;

            nudOverlap.Controls[0].Enabled = false;
            nudOffset.Controls[0].Enabled = false;

            nudTrailingToolToPivotLength.Controls[0].Enabled = false;

            nudFixJumpDistance.Controls[0].Enabled = false;
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            //Ajout-modification MEmprou et SPailleau
            if (mf.config_tool == true)
            {
                btnFeatureHides.Visible = false;
                btnTram.Visible = false;
                btnMachineModule.Visible = false;
                //btnSteerModule.Visible = false;
                btnArduino.Visible = false;
                btnUTurn.Visible = false;
                btnDataSources.Visible = false;
                //btnSubGuidance.Visible = false;
                btnSubAntenna.Visible = false;
                btnSubDimensions.Visible = false;
                btnVehicle.Visible = false;
                btnDisplay.Visible = false;
                ShowSubMenu(panelToolSubMenu, btnTool);
            }
            else
            {
                btnFeatureHides.Visible = true;
                btnTram.Visible = true;
                btnMachineModule.Visible = true;
                //btnSteerModule.Visible = true;
                btnArduino.Visible = true;
                btnUTurn.Visible = true;
                btnDataSources.Visible = true;
                //btnSubGuidance.Visible = true;
                btnSubAntenna.Visible = true;
                btnSubDimensions.Visible = true;
                btnVehicle.Visible = true;
                btnDisplay.Visible = true;
            }
            //fin

            //since we reset, save current state
            mf.SaveFormGPSWindowSettings();

            //metric or imp on spinners min/maxes
            if (!mf.isMetric) FixMinMaxSpinners();

            //the pick a saved vehicle box
            UpdateVehicleListView();

            //tabTSections_Enter(this, e);
            lblVehicleToolWidth.Text = Convert.ToString((int)(mf.tool.width * 100 * mf.cm2CmOrIn));
            SectionFeetInchesTotalWidthLabelUpdate();

            tab1.SelectedTab = tabSummary;
            tboxVehicleNameSave.Focus();
            //Label translations
            //configload-save
            labelSaveAs.Text = gStr.gsSaveAs;
            labelNew.Text = gStr.gsNew;
            labelUnits.Text = gStr.gsUnit;
            labelWidth.Text = gStr.gsWidth;
            labelSections.Text = gStr.gsSections;
            labelOffset.Text = gStr.gsOffset;
            labelOverlap.Text = gStr.gsOverlap;
            labelLookAhead.Text = gStr.gsLookAhead;
            labelNudge.Text = gStr.gsNudge;
            labelTramW.Text = gStr.gsTramWidth;
            labelUnitsBottom.Text = gStr.gsUnit;
            labelToolWidthBottom.Text = gStr.gsWidth;
            labelOpen.Text = gStr.gsOpen;
            labelDelete.Text = gStr.gsDelete;
            //tractorconfig
            labelWheelBase.Text = gStr.gsWheelbase;
            labelVehicleGroupBox.Text = gStr.gsVehiclegroupbox;
            labelImage.Text = gStr.gsImage;
            labelOpacity.Text = gStr.gsOpacity;
            labelBoxAttachmentStyle.Text = gStr.gsAttachmentStyle;
            labelTractorUnits.Text = gStr.gsUnit;
            labelHitchLength.Text = gStr.gsHitchLength;
            labelWheelBase2.Text = gStr.gsWheelbase;
            labelTrack.Text = gStr.gsTrack;
            //antennadistanceconfig
            labelPivotDistance.Text = gStr.gsPivotDistance;
            labelAntHeight.Text = gStr.gsAntennaHeight;
            labelAntOffset.Text = gStr.gsAntennaOffset;
            labelLeft.Text = gStr.gsLeft;
            labelCenter.Text = gStr.gsCenter;
            labelRight.Text = gStr.gsRight;
            labelDualPositionOnRight.Text = gStr.gsDualpositionAntennaRight;
            //toolconfig
            labelToolOffset.Text = gStr.gsToolOffset;
            labelOverlapGap.Text = gStr.gsOverlapGap;   
            labelToolLeft.Text = gStr.gsToolLeft;   
            labelToolRight.Text = gStr.gsToolRight;
            labelOverlap2.Text = gStr.gsOverlap;
            labelGap.Text = gStr.gsGap;
            //sections
            labelZone1.Text = gStr.gsZone + 1;
            labelZone2.Text = gStr.gsZone + 2;
            labelZone3.Text = gStr.gsZone + 3;
            labelZone4.Text = gStr.gsZone + 4;
            labelZone5.Text = gStr.gsZone + 5;
            labelZone6.Text = gStr.gsZone + 6;
            labelZone7.Text = gStr.gsZone + 7;
            labelZone8.Text = gStr.gsZone + 8;
            labelZonesBox.Text = gStr.gsZones;
            labelSectionWidth.Text = gStr.gsWidth;
            labelNumOfSections.Text = gStr.gsSections;
            labelChoose.Text = gStr.gsChoose;
            labelBoundary.Text = gStr.gsBoundary;
            labelCoverage.Text = gStr.gsCoverage;
            //sectionswitches
            labelGroupWorkSwitch.Text = gStr.gsWorkSwitch;
            labelGroupSteerSwitch.Text = gStr.gsSteerSwitch;
            chkSelectWorkSwitch.Text = gStr.gsActive;
            chkSelectSteerSwitch.Text = gStr.gsActive;
            chkSetManualSections.Text = gStr.gsManual + gStr.gsSections;
            chkSetManualSectionsSteer.Text = gStr.gsManual + gStr.gsSections;
            chkSetAutoSections.Text = gStr.gsAuto + gStr.gsSections;
            chkSetAutoSectionsSteer.Text = gStr.gsAuto + gStr.gsSections;
            //sectiontiming
            labelLookAheadTiming.Text = gStr.gsLookAheadTiming;
            labelOnTime.Text = gStr.gsOn + "(secs)";
            labelOffTime.Text = gStr.gsOff + "(secs)";
            labelDelayTime.Text = gStr.gsTurnOffDelay + "(secs)";
            //antenna-imu configuration
            labelGboxDual.Text = gStr.gsDualAntennaSetting;
            labelGboxSingle.Text = gStr.gsSingleAntennaSetting;
            labelHeadingOffset.Text = gStr.gsHeadingOffset;
            labelReverseDistance.Text = gStr.gsReverseDistance;
            labelGpsStep.Text = gStr.gsGpsStep;
            labelFixAlarm.Text = gStr.gsFixAlarm;
            labelFixAlarmStop.Text = gStr.gsFixAlarmStop;
            labelFix2Fix.Text = gStr.gsFix2Fix;
            labelIMUFusion.Text = gStr.gsImuFusion;
            cboxIsReverseOn.Text = gStr.gsReverseSteer;
            //rollconfig
            labelRemoveOffset.Text = gStr.gsRemoveOffset;
            labelZeroRoll.Text = gStr.gsZeroRoll;
            labelInvertRoll.Text = gStr.gsInvertRoll;
            labelLess.Text = gStr.gsLess;
            labelMore.Text = gStr.gsMore;
            labelRollFilter.Text = gStr.gsRollFilter;
            //uturnconfig
            labelUturnExtend.Text = gStr.gsUturnExtension;
            labelUturnSmooth.Text = gStr.gsUturnSmooth;
            labelSendandSave.Text = gStr.gsSendAndSave;
            //hydraulicliftconfig
            labelGroupHyd.Text = gStr.gsHydraulicLiftConfig;
            labelEnable.Text = gStr.gsEnable;
            labelRaiseTime.Text = gStr.gsRaiseTime;
            labelLowTime.Text = gStr.gsLowerTime;
            labelPlantPop.Text = gStr.gsPlantPop;
            labelHydLiftSec.Text = gStr.gsHydraulicLiftLookAhead;
            labelUser1.Text = gStr.gsUser1;
            labelUser2.Text = gStr.gsUser2;
            labelUser3.Text = gStr.gsUser3;
            labelUser4.Text = gStr.gsUser4;
            labelHydLiftInvert.Text = gStr.gsInvertHydraulicRelays;
            labelSendSaveHydraulicLift.Text = gStr.gsSendAndSave;
            //tramsconfig
            labelTramWidth.Text = gStr.gsTramWidth;
            labelDisplay.Text = gStr.gsDisplay + "?";
            labelOverride.Text = gStr.gsOverride;
            //softbuttonsactivatorconfig
            labelFieldMenu.Text = gStr.gsFieldMenu;
            labelToolsMenu.Text = gStr.gsToolsMenu;
            labelScreenButtons.Text = gStr.gsScreenButtons;
            labelBottomMenu.Text = gStr.gsBottomMenu;
            labelRightMenu.Text = gStr.gsRightMenu;
            labelTramlineOnOff.Text = gStr.gsTramLines;
            labelHeadlandOnOff.Text = gStr.gsHeadland;
            labelBoundOnOff.Text = gStr.gsBoundary;
            labelRecPathOnOff.Text = gStr.gsRecordedPathMenu;
            labelABSmoothOnOff.Text = gStr.gsSmoothABCurve;
            labelContourOnOff.Text = gStr.gsContourOn;
            labelCamOnOff.Text = gStr.gsWebCam;
            labelOffsetFixOnOff.Text = gStr.gsOffsetFix;
            labelUturnOnOff.Text = gStr.gsUturn;
            labelLateralOnOff.Text = gStr.gsLateral;
            labelNudgeCtrlOnOff.Text = gStr.gsNudge;
            labelPowerLossOnOff.Text = gStr.gsPowerLoss;
            labelStartAgIO.Text = gStr.gsAutoStartAgIO;
            labelOffAgIO.Text = gStr.gsAutoOffAgIO;
            labelHardwareMessage.Text = gStr.gsHardwareMessages;
            labelSounds.Text = gStr.gsSound;
            labelAutosteerSoundOnOff.Text = gStr.gsAutoSteer;
            labelUturnSoundOnOff.Text = gStr.gsUturn;
            labelHydLiftSoundOnOff.Text = gStr.gsHydraulicLift;
            labelSectionSoundOnOff.Text = gStr.gsSections;
            //displaybuttonsconfig
            labelPolyOnOff.Text = gStr.gsPolygons;
            labelBrightnessOnOff.Text = gStr.gsBrightness;
            labelFieldTextureOnOff.Text = gStr.gsFieldTexture;
            labelLineSmoothOnOff.Text = gStr.gsLineSmooth;
            labelSpeedoOnOff.Text = gStr.gsSpeedo;
            labelSvenArrowOnOff.Text = gStr.gsSvennArrow;
            labelGridOnOff.Text = gStr.gsGrid;
            labelDirectionMarkOnOff.Text = gStr.gsDirectionMarkers;
            labelKeyboardOnOff.Text = gStr.gsKeyboard;
            labelFullscreenOnOff.Text = gStr.gsStartFullscreen;
            labelGuideLinesOnOff.Text = gStr.gsExtraGuideLines;
            labelSectionLinesOnOff.Text = gStr.gsSectionLines;
            labelElevationOnOff.Text = gStr.gsElevationlog;
            unitsGroupBox.Text = gStr.gsUnits;
            cboxIsAutoSwitchDualFixOn.Text = gStr.gsAutoSwitchDualFix;
            labelAutoSwitchDualFixSpeed.Text = gStr.gsAutoSwitchDualFixSpeed;

            UpdateSummary();

            if (!ScreenHelper.IsOnScreen(Bounds))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }

            //reload all the settings
            mf.LoadSettings();

            //save current vehicle
            Properties.Settings.Default.Save();
        }

        private void FixMinMaxSpinners()
        {
            nudTankHitch.Maximum = (Math.Round(nudTankHitch.Maximum / 2.54M));
            nudTankHitch.Minimum = Math.Round(nudTankHitch.Minimum / 2.54M);

            nudDrawbarLength.Maximum = Math.Round(nudDrawbarLength.Maximum / 2.54M);
            nudDrawbarLength.Minimum = Math.Round(nudDrawbarLength.Minimum / 2.54M);

            nudTrailingHitchLength.Maximum = Math.Round(nudTrailingHitchLength.Maximum / 2.54M);
            nudTrailingHitchLength.Minimum = Math.Round(nudTrailingHitchLength.Minimum / 2.54M);

            nudTractorHitchLength.Maximum = Math.Round(nudTractorHitchLength.Maximum / 2.54M);
            nudTractorHitchLength.Minimum = Math.Round(nudTractorHitchLength.Minimum / 2.54M);

            nudVehicleTrack.Maximum = Math.Round(nudVehicleTrack.Maximum / 2.54M);
            nudVehicleTrack.Minimum = Math.Round(nudVehicleTrack.Minimum / 2.54M);

            nudWheelbase.Maximum = Math.Round(nudWheelbase.Maximum / 2.54M);
            nudWheelbase.Minimum = Math.Round(nudWheelbase.Minimum / 2.54M);

            nudOverlap.Maximum = Math.Round(nudOverlap.Maximum / 2.54M);
            nudOverlap.Minimum = Math.Round(nudOverlap.Minimum / 2.54M);

            nudOffset.Maximum = Math.Round(nudOffset.Maximum / 2.54M);
            nudOffset.Minimum = Math.Round(nudOffset.Minimum / 2.54M);

            nudDefaultSectionWidth.Maximum = Math.Round(nudDefaultSectionWidth.Maximum / 2.54M);
            nudDefaultSectionWidth.Minimum = Math.Round(nudDefaultSectionWidth.Minimum / 3.0M);

            nudSection01.Maximum = Math.Round(nudSection01.Maximum / 2.54M);
            nudSection01.Minimum = Math.Round(nudSection01.Minimum / 2.54M);
            nudSection02.Maximum = Math.Round(nudSection02.Maximum / 2.54M);
            nudSection02.Minimum = Math.Round(nudSection02.Minimum / 2.54M);
            nudSection03.Maximum = Math.Round(nudSection03.Maximum / 2.54M);
            nudSection03.Minimum = Math.Round(nudSection03.Minimum / 2.54M);
            nudSection04.Maximum = Math.Round(nudSection04.Maximum / 2.54M);
            nudSection04.Minimum = Math.Round(nudSection04.Minimum / 2.54M);
            nudSection05.Maximum = Math.Round(nudSection05.Maximum / 2.54M);
            nudSection05.Minimum = Math.Round(nudSection05.Minimum / 2.54M);
            nudSection06.Maximum = Math.Round(nudSection06.Maximum / 2.54M);
            nudSection06.Minimum = Math.Round(nudSection06.Minimum / 2.54M);
            nudSection07.Maximum = Math.Round(nudSection07.Maximum / 2.54M);
            nudSection07.Minimum = Math.Round(nudSection07.Minimum / 2.54M);
            nudSection08.Maximum = Math.Round(nudSection08.Maximum / 2.54M);
            nudSection08.Minimum = Math.Round(nudSection08.Minimum / 2.54M);
            nudSection09.Maximum = Math.Round(nudSection09.Maximum / 2.54M);
            nudSection09.Minimum = Math.Round(nudSection09.Minimum / 2.54M);
            nudSection10.Maximum = Math.Round(nudSection10.Maximum / 2.54M);
            nudSection10.Minimum = Math.Round(nudSection10.Minimum / 2.54M);
            nudSection11.Maximum = Math.Round(nudSection11.Maximum / 2.54M);
            nudSection11.Minimum = Math.Round(nudSection11.Minimum / 2.54M);
            nudSection12.Maximum = Math.Round(nudSection12.Maximum / 2.54M);
            nudSection12.Minimum = Math.Round(nudSection12.Minimum / 2.54M);
            nudSection13.Maximum = Math.Round(nudSection13.Maximum / 2.54M);
            nudSection13.Minimum = Math.Round(nudSection13.Minimum / 2.54M);
            nudSection14.Maximum = Math.Round(nudSection14.Maximum / 2.54M);
            nudSection14.Minimum = Math.Round(nudSection14.Minimum / 2.54M);
            nudSection15.Maximum = Math.Round(nudSection15.Maximum / 2.54M);
            nudSection15.Minimum = Math.Round(nudSection15.Minimum / 2.54M);
            nudSection16.Maximum = Math.Round(nudSection16.Maximum / 2.54M);
            nudSection16.Minimum = Math.Round(nudSection16.Minimum / 2.54M);

            nudTramWidth.Minimum = Math.Round(nudTramWidth.Minimum / 2.54M);
            nudTramWidth.Maximum = Math.Round(nudTramWidth.Maximum / 2.54M);

            //Meters to feet
            nudTurnDistanceFromBoundary.Minimum = Math.Round(nudTurnDistanceFromBoundary.Minimum * 3.28M);
            nudTurnDistanceFromBoundary.Maximum = Math.Round(nudTurnDistanceFromBoundary.Maximum * 3.28M);

            nudOffset.Maximum = Math.Round(nudOffset.Maximum / 2.54M);
            nudOffset.Minimum = Math.Round(nudOffset.Minimum / 2.54M);
            nudOverlap.Maximum = Math.Round(nudOverlap.Maximum / 2.54M);
            nudOverlap.Minimum = Math.Round(nudOverlap.Minimum / 2.54M);

            nudTrailingToolToPivotLength.Maximum = Math.Round(nudTrailingToolToPivotLength.Maximum / 2.54M);
            nudTrailingToolToPivotLength.Minimum = Math.Round(nudTrailingToolToPivotLength.Minimum / 2.54M);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isClosing = true;
            Close();
        }

        private void tabSummary_Enter(object sender, EventArgs e)
        {
            SectionFeetInchesTotalWidthLabelUpdate();
            lblSummaryVehicleName.Text = RegistrySettings.vehicleFileName;
            UpdateSummary();
        }

        private void tabSummary_Leave(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                //btnVehicleSaveAs.Enabled = true;
                btnVehicleLoad.Enabled = true;
                btnVehicleDelete.Enabled = true;
            }
            else
            {
                //btnVehicleSaveAs.Enabled = false;
                btnVehicleLoad.Enabled = false;
                btnVehicleDelete.Enabled = false;
            }
        }

        private void tabDisplay_Enter(object sender, EventArgs e)
        {
            chkDisplayBrightness.Checked = mf.isBrightnessOn;
            chkDisplayFloor.Checked = mf.isTextureOn;
            chkDisplayGrid.Checked = mf.isGridOn;
            chkDisplaySpeedo.Checked = mf.isSpeedoOn;
            chkDisplayStartFullScreen.Checked = Properties.Settings.Default.setDisplay_isStartFullScreen;
            chkSvennArrow.Checked = mf.isSvennArrowOn;
            chkDisplayExtraGuides.Checked = mf.isSideGuideLines;
            chkDisplayPolygons.Checked = mf.isDrawPolygons;
            chkDisplayKeyboard.Checked = mf.isKeyboardOn;
            chkDisplayLogElevation.Checked = mf.isLogElevation;
            chkDirectionMarkers.Checked = Properties.Settings.Default.setTool_isDirectionMarkers;
            chkSectionLines.Checked = Properties.Settings.Default.setDisplay_isSectionLinesOn;
            chkLineSmooth.Checked = Properties.Settings.Default.setDisplay_isLineSmooth;

            //Ajout-modification MEmprou et SPailleau
            cBox_sections_button.Checked = mf.issections_buttonOn;
            cbox_long_touch.Checked = mf.islong_touchOn;
            Timer_kml.Checked = Properties.Settings.Default.UP_setTimer_KML;
            VineMode.Checked = Properties.Settings.Default.UP_setVineMode;
            ArrowsRL.Checked = Properties.Settings.Default.UP_SetArrowsRL;
            //fin

            if (mf.isMetric) rbtnDisplayMetric.Checked = true;
            else rbtnDisplayImperial.Checked = true;

            nudNumGuideLines.Value = mf.ABLine.numGuideLines;
        }

        private void tabDisplay_Leave(object sender, EventArgs e)
        {
            SaveDisplaySettings();
        }

        private void rbtnDisplayImperial_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Imperial");
            Log.EventWriter("Units To Imperial");

            mf.isMetric = false;
            Properties.Settings.Default.setMenu_isMetric = mf.isMetric;
            isClosing = true;
            Close();
        }

        private void rbtnDisplayMetric_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Metric");
            Log.EventWriter("Units to Metric");

            mf.isMetric = true;
            Properties.Settings.Default.setMenu_isMetric = mf.isMetric;
            isClosing = true;
            Close();
            //FormConfig_Load(this, e);
        }

        private void nudNumGuideLines_Click(object sender, EventArgs e)
        {
            if (((NudlessNumericUpDown)sender).ShowKeypad(this))
            {
                mf.ABLine.numGuideLines = (int)nudNumGuideLines.Value;
            }

        }

        private void nudAntennaHeight_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}