//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Media;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace AgOpenGPS
{
    //the main form object
    public partial class FormGPS : Form
    {
        //To bring forward AgIO if running
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]        
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        //----SPailleau
        //Création de variables pour location et size avec les valeurs respectives de oglzoom de la session précédente 
        //car la winform initialization InitializeComponent() réinitialise sa position
        //Utilisation de ces variables dans FormGPS_Load (plus bas)
        public int oglZoom_LocationX = Properties.Settings.Default.OGLZoom_Location.X;
        public int oglZoom_LocationY = Properties.Settings.Default.OGLZoom_Location.Y;
        public int oglZoom_SizeWidth = Properties.Settings.Default.OGLZoom_Size.Width;
        public int oglZoom_SizeHeight = Properties.Settings.Default.OGLZoom_Size.Height;
        //----

        #region // Class Props and instances

        //list of vec3 points of Dubins shortest path between 2 points - To be converted to RecPt
        public List<vec3> flagDubinsList = new List<vec3>();

        //maximum sections available
        public const int MAXSECTIONS = 17;

        //How many boundaries allowed
        public const int MAXBOUNDARIES = 6;

        //How many headlands allowed
        public const int MAXHEADS = 6;

        //The base directory where AgOpenGPS will be stored and fields and vehicles branch from
        public string baseDirectory;

        //current directory of vehicle
        public string vehiclesDirectory, vehicleFileName = "";

        //current directory of tools
        public string toolsDirectory, toolFileName = "";

        //current directory of Environments
        public string envDirectory, envFileName = "";

        //current fields and field directory
        public string fieldsDirectory, currentFieldDirectory, displayFieldName;

        private bool leftMouseDownOnOpenGL; //mousedown event in opengl window
        public int flagNumberPicked = 0;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAutoSteerBtnOn, isLidarBtnOn = true;

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false, isLogElevation = false;

        //texture holders
        public uint[] texture;

        //the currentversion of software
        public string currentVersionStr, inoVersionStr;
        public int inoVersionInt;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        public double secondsSinceStart;

        //private readonly Stopwatch swDraw = new Stopwatch();
        //swDraw.Reset();
        //swDraw.Start();
        //swDraw.Stop();
        //label3.Text = ((double) swDraw.ElapsedTicks / (double) System.Diagnostics.Stopwatch.Frequency * 1000).ToString();

        //Time to do fix position update and draw routine
        public double frameTime = 0;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swHz = new Stopwatch();

        //Time to do fix position update and draw routine
        private double HzTime = 5;

        //For field saving in background
        private int minuteCounter = 1;
        private int tenMinuteCounter = 1;

        //whether or not to use Stanley control
        public bool isStanleyUsed = true;

        //used to update the screen status bar etc
        private int displayUpdateHalfSecondCounter = 0, displayUpdateOneSecondCounter = 0, displayUpdateOneFifthCounter = 0, displayUpdateThreeSecondCounter = 0;

        private int threeSecondCounter = 0, threeSeconds = 0;
        private int oneSecondCounter = 0, oneSecond = 0;
        private int oneHalfSecondCounter = 0, oneHalfSecond = 0;
        private int oneFifthSecondCounter = 0, oneFifthSecond = 0;

        public int pbarSteer, pbarMachine, pbarUDP;

        public double nudNumber = 0;

        public double m2InchOrCm, inchOrCm2m, m2FtOrM, ftOrMtoM, cm2CmOrIn, inOrCm2Cm;
        public string unitsFtM, unitsInCm;

        //used by filePicker Form to return picked file and directory
        public string filePickerFileAndDirectory;

        //private int fiveSecondCounter = 0, fiveSeconds = 0;

        //the autoManual drive button. Assume in Auto
        public bool isInAutoDrive = true;

        //isGPSData form up
        public bool isGPSSentencesOn = false;

        /// <summary>
        /// create the scene camera
        /// </summary>
        public CCamera camera = new CCamera();

        /// <summary>
        /// create world grid
        /// </summary>
        public CWorldGrid worldGrid;

        /// <summary>
        /// The NMEA class that decodes it
        /// </summary>
        public CNMEA pn;

        /// <summary>
        /// an array of sections, so far 16 section + 1 fullWidth Section
        /// </summary>
        public CSection[] section;

        /// <summary>
        /// AB Line object
        /// </summary>
        public CABLine ABLine;

        /// <summary>
        /// TramLine class for boundary and settings
        /// </summary>
        public CTram tram;


        /// <summary>
        /// Contour Mode Instance
        /// </summary>
        public CContour ct;

        /// <summary>
        /// ABCurve instance
        /// </summary>
        public CABCurve curve;

        /// <summary>
        /// Auto Headland YouTurn
        /// </summary>
        public CYouTurn yt;

        /// <summary>
        /// Our vehicle only
        /// </summary>
        public CVehicle vehicle;

        /// <summary>
        /// Just the tool attachment that includes the sections
        /// </summary>
        public CTool tool;
        
        /// <summary>
        /// All the structs for recv and send of information out ports
        /// </summary>
        public CModuleComm mc;

        /// <summary>
        /// The boundary object
        /// </summary>
        public CBoundary bnd;

        /// <summary>
        /// The boundary object
        /// </summary>
        public CTurn turn;

        /// <summary>
        /// The headland created
        /// </summary>
        public CHead hd;

        /// <summary>
        /// The internal simulator
        /// </summary>
        public CSim sim;

        /// <summary>
        /// Resource manager for gloabal strings
        /// </summary>
        public ResourceManager _rm;

        /// <summary>
        /// Heading, Roll, Pitch, GPS, Properties
        /// </summary>
        public CAHRS ahrs;

        /// <summary>
        /// Recorded Path
        /// </summary>
        public CRecordedPath recPath;

        /// <summary>
        /// Most of the displayed field data for GUI
        /// </summary>
        public CFieldData fd;

        /// <summary>
        /// Class containing workswitch functionality
        /// </summary>
        public CWorkSwitch workSwitch;

        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndBoundaryAlarm;

        private void stripBtnConfig_Click(object sender, EventArgs e)
        {
            using (var form = new FormConfig(this))
            {
                form.ShowDialog(this);
            }
        }

        private void btnStanleyPure_Click(object sender, EventArgs e)
        {
            isStanleyUsed = !isStanleyUsed;

            if (isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

            Properties.Vehicle.Default.setVehicle_isStanleyUsed = isStanleyUsed;
            Properties.Vehicle.Default.Save();
        }


        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndHydraulicLift;

        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndHydraulicLower;

        private void roundButton1_Click(object sender, EventArgs e)
        {

            if (ABLine.isBtnABLineOn)
            {
                ABLine.SnapABLine();
            }
            else if (curve.isBtnCurveOn)
            {
                curve.SnapABCurve();
            }
            else
            {
                var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                form.Show(this);
            }
        }

        private void panel_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbarNtripMenu_Click(object sender, EventArgs e)
        {

        }

        private void NTRIPBytesMenu_Click(object sender, EventArgs e)
        {

        }

        private void round_table10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new FormTool_config(this))
            {
                form.ShowDialog(this);
            }
        }

        private void contextMenuStrip_headlane_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            GetHeadland();
            contextMenuStrip_headlane.Close();
        }

        private void contextMenuStrip_tram_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            curve.isOkToAddPoints = false;

            if (ct.isContourBtnOn) btnContour.PerformClick();

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form99 = new FormTram(this);
                form99.Show(this);
                form99.Left = Width - 275;
                form99.Top = 100;
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form97 = new FormTramCurve(this);
                form97.Show(this);
                form97.Left = Width - 275;
                form97.Top = 100;
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                form.Show(this);
                //panelRight.Enabled = true;
                //ABLine.isEditing = false;
                return;
            }
            contextMenuStrip_tram.Close();
        }

        private void contextMenuStrip_contour_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them.
            using (var form = new FormMakeBndCon(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
            contextMenuStrip_contour.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormTool_config(this))
            {
                form.ShowDialog(this);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }

            FolderBrowserDialog fsync = new FolderBrowserDialog();
            fsync.ShowNewFolderButton = true;
            fsync.Description = "Currently: " + Settings.Default.setF_local;
            fsync.SelectedPath = Settings.Default.setF_local;

            if (fsync.ShowDialog() == DialogResult.OK)
            {

                    Settings.Default.setF_local = fsync.SelectedPath;
                    Settings.Default.Save();

                //restart program
               // MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
               // Close();
            }
        }

        private void dossierDeSynchronisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }

            FolderBrowserDialog fsync = new FolderBrowserDialog();
            fsync.ShowNewFolderButton = true;
            fsync.Description = "Currently: " + Settings.Default.setF_synchro;
            fsync.SelectedPath = Settings.Default.setF_synchro;

            if (fsync.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.setF_synchro = fsync.SelectedPath;
                Settings.Default.Save();

                //restart program
                // MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                // Close();
            }
        }

        private void btn_synchro_Click(object sender, EventArgs e)
        {
            if (Settings.Default.setF_local != "Default" & Settings.Default.setF_synchro != "Default")
            {
                using (var form = new FormSynchro(this))
                {
                    form.ShowDialog(this);
                }
                //DirectoryCopy(Settings.Default.setF_local, Settings.Default.setF_synchro, true);
                //DirectoryCopy(Settings.Default.setF_synchro, Settings.Default.setF_local, true);

                TimedMessageBox(1000,"Synchronisation terminée !","Synchronisation") ;
            }
            else
            {
                MessageBox.Show("Veuillez d'abord sélectionner un dossier local un dossier de synchronisation !");
            }
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {
            if (panelNavigation.Visible)
            {
                panelNavigation.Visible = false;
            }
            else
            {
                
                panelNavigation.Visible = true;
                navPanelCounter = 2;
                panelNavigation.BringToFront();
            }
        }

        private void deleteAppliedAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                if (autoBtnState == btnStates.Off && manualBtnState == btnStates.Off)
                {

                    DialogResult result3 = MessageBox.Show(gStr.gsDeleteAllContoursAndSections,
                        gStr.gsDeleteForSure,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (result3 == DialogResult.Yes)
                    {
                        //FileCreateElevation();

                        //turn auto button off
                        autoBtnState = btnStates.Off;
                        btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                        //turn section buttons all OFF and zero square meters
                        for (int j = 0; j < MAXSECTIONS; j++)
                        {
                            section[j].isAllowedOn = false;
                            section[j].manBtnState = manBtn.On;
                        }

                        //turn manual button off
                        manualBtnState = btnStates.Off;
                        btnManualOffOn.Image = Properties.Resources.ManualOff;

                        //Update the button colors and text
                        ManualAllBtnsUpdate();

                        //enable disable manual buttons
                        LineUpManualBtns();

                        //clear out the contour Lists
                        ct.StopContourLine(pivotAxlePos);
                        ct.ResetContour();
                        fd.workedAreaTotal = 0;

                        //clear the section lists
                        for (int j = 0; j < MAXSECTIONS; j++)
                        {
                            //clean out the lists
                            section[j].patchList?.Clear();
                            section[j].triangleList?.Clear();
                        }
                        patchSaveList?.Clear();

                        FileCreateContour();
                        FileCreateSections();

                    }
                    else
                    {
                        TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
                    }
                }
                else
                {
                    TimedMessageBox(1500, "Sections are on", "Turn Auto or Manual Off First");
                }
            }
        }

        private void statusStripLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnStartAgIO_Click_1(object sender, EventArgs e)
        {
            Process[] processName = Process.GetProcessesByName("AgIO");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgIO.exe";
                try
                {
                    //TimedMessageBox(2000, "Please Wait", "Starting AgIO");
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = strPath;
                    //processInfo.ErrorDialog = true;
                    //processInfo.UseShellExecute = false;
                    processInfo.WorkingDirectory = Path.GetDirectoryName(strPath);
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find AgIO");
                }
            }
            else
            {
                //Set foreground window
                ShowWindow(processName[0].MainWindowHandle, 9);
                SetForegroundWindow(processName[0].MainWindowHandle);
            }
        }

        private void btnpTiltUp_Click(object sender, EventArgs e)
        {

        }

        private void btnStanleyPure_Click_1(object sender, EventArgs e)
        {
            isStanleyUsed = !isStanleyUsed;

            if (isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

            Properties.Vehicle.Default.setVehicle_isStanleyUsed = isStanleyUsed;
            Properties.Vehicle.Default.Save();
        }

        private void panel_top_Click(object sender, EventArgs e)
        {
      
        }

        private void oglMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblSpeed_Click_1(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                if (round_StatusStrip1.Visible)
                {
                    round_StatusStrip1.Visible = false;
                    round_table10.Visible = false;
                    round_table7.Visible = false;
                    round_table8.Visible = false;
                    round_table9.Visible = false;
                    round_table1.Visible = false;
                    round_table4.Visible = false;
                    round_table3.Visible = false;
                    round_table2.Visible = false;
                    round_table6.Visible = false;
                    round_table12.Visible = false;
                    statusStripLeft.Visible = false;
                }
                else
                {
                    round_StatusStrip1.Visible = true;
                    round_table10.Visible = true;
                    round_table7.Visible = true;
                    round_table8.Visible = true;
                    round_table9.Visible = true;
                    round_table1.Visible = true;
                    round_table4.Visible = true;
                    round_table3.Visible = true;
                    round_table2.Visible = true;
                    round_table6.Visible = true;
                    round_table12.Visible = true;
                    statusStripLeft.Visible = true;
                }
            }
        }

        private void lbludpWatchCounts_Click(object sender, EventArgs e)
        {

        }

        private void BatLevel_Click(object sender, EventArgs e)
        {
            //----SPailleau - Affiche niveau charge batterie
            String RC = System.Environment.NewLine;
            PowerStatus status = SystemInformation.PowerStatus;
            string NiveauBatterie = status.BatteryLifePercent.ToString("P0");

            double TempsRestantSeconde = status.BatteryLifeRemaining;
            string TempsRestantHM;
            TimeSpan ts = TimeSpan.FromSeconds(TempsRestantSeconde);
            if (ts.Minutes.ToString().Length == 1) TempsRestantHM = ts.Hours + "h0" + ts.Minutes;
            else TempsRestantHM = ts.Hours + "h" + ts.Minutes;

            string EtatAlim = status.PowerLineStatus.ToString();
            String MessageBatt;
            if (EtatAlim == "Online")
            {
                EtatAlim = "En charge";
                MessageBatt = NiveauBatterie + " | " + EtatAlim; //Pas d'estimation de temps restant si Online
            }
            else
            {
                EtatAlim = "Débranchée";
                MessageBatt = NiveauBatterie + " | " + "Temps restant : " + TempsRestantHM + " | " + EtatAlim;
            }

            TimedMessageBox(3000, "Infos batterie", MessageBatt);
            //----
        }

        private void SteerSettings_Click(object sender, EventArgs e)
        {
            //Ajout SPailleau - Original code : check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show(this);
        }

        //Ajout SPailleau
        private void btnAdjLeftMain_Click(object sender, EventArgs e)
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    ABLine.MoveABLine(-dist);

                    //FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    curve.MoveABCurve(-dist);

                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }
        }

        //Ajout SPailleau
        private void btnAdjRightMain_Click(object sender, EventArgs e)
        {
            
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    ABLine.MoveABLine(dist);
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;
                    curve.MoveABCurve(dist);

                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }
        }

        private void oglZoom_Move(object sender, EventArgs e)
        {
            //----SPailleau - Enregistre la position de la fenêtre
            Properties.Settings.Default.OGLZoom_Location = oglZoom.Location;
            Properties.Settings.Default.OGLZoom_Size = oglZoom.Size;
            //----Fin
        }

        /// <summary>
        /// The font class
        /// </summary>
        public CFont font;

        /// <summary>
        /// The new steer algorithms
        /// </summary>
        public CGuidance gyd;

        #endregion // Class Props and instances

        // Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            CheckSettingsNotNull();


            //ControlExtension.Draggable(panelSnap, true);
            ControlExtension.Draggable(oglZoom, true);
            //ControlExtension.Draggable(panelSim, true);

            setWorkingDirectoryToolStripMenuItem.Text = gStr.gsDirectories;
            enterSimCoordsToolStripMenuItem.Text = gStr.gsEnterSimCoords;
            aboutToolStripMenuItem.Text = gStr.gsAbout;
            menustripLanguage.Text = gStr.gsLanguage;


            simulatorOnToolStripMenuItem.Text = gStr.gsSimulatorOn;

            resetALLToolStripMenuItem.Text = gStr.gsResetAll;
            colorsToolStripMenuItem1.Text = gStr.gsColors;
            topFieldViewToolStripMenuItem.Text = gStr.gsTopFieldView;

            resetEverythingToolStripMenuItem.Text = gStr.gsResetAllForSure;

            steerChartStripMenu.Text = gStr.gsSteerChart;

            //Tools Menu
            toolStripMenuItem9.Text = gStr.gsField;
            SmoothABtoolStripMenu.Text = gStr.gsSmoothABCurve;
            toolStripBtnMakeBndContour.Text = gStr.gsMakeBoundaryContours;
            boundariesToolStripMenuItem.Text = gStr.gsBoundary;
            headlandToolStripMenuItem.Text = gStr.gsHeadland;
            deleteContourPathsToolStripMenuItem.Text = gStr.gsDeleteContourPaths;
            deleteAppliedAreaToolStripMenuItem.Text = gStr.gsDeleteAppliedArea;
            //deleteForSureToolStripMenuItem.Text = gStr.gsAreYouSure;
            webcamToolStrip.Text = gStr.gsWebCam;
            //googleEarthFlagsToolStrip.Text = gStr.gsGoogleEarth;
            offsetFixToolStrip.Text = gStr.gsOffsetFix;

            //btnChangeMappingColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            //time keeper
            secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

            //build the gesture structures
            //SetupStructSizes();

            //create the world grid
            worldGrid = new CWorldGrid(this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(this);

            tool = new CTool(this);

            //create a new section and set left and right positions
            //created whether used or not, saves restarting program

            section = new CSection[MAXSECTIONS];
            for (int j = 0; j < MAXSECTIONS; j++) section[j] = new CSection(this);

            //our NMEA parser
            pn = new CNMEA(this);

            //create the ABLine instance
            ABLine = new CABLine(this);

            //new instance of contour mode
            ct = new CContour(this);

            //new instance of contour mode
            curve = new CABCurve(this);

            ////new instance of auto headland turn
            yt = new CYouTurn(this);

            //module communication
            mc = new CModuleComm();

            //boundary object
            bnd = new CBoundary(this);

            //Turn object
            turn = new CTurn(this);

            //headland object
            hd = new CHead( this);

            //nmea simulator built in.
            sim = new CSim(this);

            ////all the attitude, heading, roll, pitch reference system
            ahrs = new CAHRS();

            //A recorded path
            recPath = new CRecordedPath(this);

            //fieldData all in one place
            fd = new CFieldData(this);

            //start the stopwatch
            //swFrame.Start();

            //instance of tram
            tram = new CTram(this);

            //resource for gloabal language strings
            _rm = new ResourceManager("AgOpenGPS.gStr", Assembly.GetExecutingAssembly());

            // Access to workswitch functionality
            workSwitch = new CWorkSwitch(this);

            //access to font class
            font = new CFont(this);

            //the new steer algorithms
            gyd = new CGuidance(this);
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            this.MouseWheel += ZoomByMouseWheel;
            round_table5.Left = this.Width / 2 - round_table5.Width / 2;
            //roundButton1.Left = this.Width / 2 - roundButton1.Width / 2;
            panel_top.Left = this.Width / 2 - panel_top.Width / 2 + 3;

            //----SPailleau
            SnapCenterMain.Left = this.Width / 2 - SnapCenterMain.Width / 2;
            SnapCenterMain.Top = round_table5.Top - SnapCenterMain.Height - 5;

            btnAdjLeftMain.Left = (this.Width / 2 - round_table5.Width / 2) - 70;
            btnAdjLeftMain.Top = round_table5.Top + 5;

            btnAdjRightMain.Left = (this.Width / 2 + round_table5.Width / 2) - btnAdjRightMain.Width + 70;
            btnAdjRightMain.Top = round_table5.Top + 5;
            //----

            label1.Visible = false;
            round_table1.Visible = false;
            round_table4.Visible = false;
            round_table3.Visible = false;
            round_table2.Visible = false;
            round_table6.Visible = false;
            round_table8.Visible = false;
            round_StatusStrip1.Width = 176;
            toolStripStatusLabel2.Visible = false;
            round_table10.Width = 176;
            round_table9.Width = 176;
            cboxpRowWidth.Visible = false;
            btnYouSkipEnable.Visible = false;
            if (!Properties.Settings.Default.setDisplay_islong_touchOn)
            {
                headlandToolStripMenuItem.Visible = true;
                deleteContourPathsToolStripMenuItem.Visible = true;
                tramLinesMenuField.Visible = true;
                toolStripBtnMakeBndContour.Visible = true;

            }

            //start udp server is required
                StartLoopbackServer();

            //boundaryToolStripBtn.Enabled = false;
            FieldMenuButtonEnableDisable(false);
            
            //panelRight.Enabled = false;

            //oglMain.Left = 75;
            //oglMain.Width = this.Width - statusStripLeft.Width - 84;

            panelSim.Left = 100;
            panelSim.Width = Width - 300;

            timer2.Enabled = true;
            //panel1.BringToFront();
            pictureboxStart.BringToFront();
            pictureboxStart.Dock = System.Windows.Forms.DockStyle.Fill;

            //set the language to last used
            SetLanguage(Settings.Default.setF_culture);

            currentVersionStr = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            string[] fullVers = currentVersionStr.Split('.');
            int inoV = int.Parse(fullVers[0], CultureInfo.InvariantCulture);
            inoV += int.Parse(fullVers[1], CultureInfo.InvariantCulture);
            inoV += int.Parse(fullVers[2], CultureInfo.InvariantCulture);
            inoVersionInt = inoV;
            inoVersionStr = inoV.ToString();


            if (Settings.Default.setF_workingDirectory == "Default")
                baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\";
            else baseDirectory = Settings.Default.setF_workingDirectory + "\\AgOpenGPS\\";

            //get the fields directory, if not exist, create
            fieldsDirectory = baseDirectory + "Fields\\";
            string dir = Path.GetDirectoryName(fieldsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //get the fields directory, if not exist, create
            vehiclesDirectory = baseDirectory + "Vehicles\\";
            dir = Path.GetDirectoryName(vehiclesDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //get the abLines directory, if not exist, create
            ablinesDirectory = baseDirectory + "ABLines\\";
            dir = Path.GetDirectoryName(fieldsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //make sure current field directory exists, null if not
            currentFieldDirectory = Settings.Default.setF_CurrentDir;

            string curDir;
            if (currentFieldDirectory != "")
            {
                curDir = fieldsDirectory + currentFieldDirectory + "//";
                dir = Path.GetDirectoryName(curDir);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    currentFieldDirectory = "";
                    Settings.Default.setF_CurrentDir = "";
                    Settings.Default.Save();
                }
            }
                // load all the gui elements in gui.designer.cs
                LoadSettings();

            if (Settings.Default.setMenu_isOGLZoomOn == 1)
                topFieldViewToolStripMenuItem.Checked = true;
            else topFieldViewToolStripMenuItem.Checked = false;

            //ajout max
            /*
            oglZoom.Width = 160;
            oglZoom.Height = 160;
            oglZoom.Left = 0;
            oglZoom.Top = 68;
            */

            //----SPailleau - On applique la position de la session précédente
            oglZoom.Width = oglZoom_SizeWidth;
            oglZoom.Height = oglZoom_SizeHeight;
            oglZoom.Left = oglZoom_LocationX;
            oglZoom.Top = oglZoom_LocationY;
            //On enregistre la position dans user.config
            Properties.Settings.Default.OGLZoom_Location = oglZoom.Location;
            Properties.Settings.Default.OGLZoom_Size = oglZoom.Size;
            //----Fin

            if (!topFieldViewToolStripMenuItem.Checked)
            {
                oglZoom.SendToBack();
            }

            //Start AgIO process
            Process[] processName = Process.GetProcessesByName("AgIO");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgIO.exe";
                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = strPath,
                        WorkingDirectory = Path.GetDirectoryName(strPath)
                    };
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find AgIO");
                }
            }
            //nmea limiter
            udpWatch.Start();
        }
        //form is closing so tidy up and save settings
        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isJobStarted)
            {
                if (autoBtnState == btnStates.Auto)
                {
                    TimedMessageBox(2000, "Safe Shutdown", gStr.gsTurnoffAutoSectionControl);
                    e.Cancel = true;
                    return;
                }

                if (manualBtnState == btnStates.On)
                {
                    TimedMessageBox(2000, "Safe Shutdown", gStr.gsTurnoffAutoSectionControl);
                    e.Cancel = true;
                    return;
                }


                bool closing = true;
                int choice = SaveOrNot(closing);

                if (choice == 1)
                {
                    e.Cancel = true;
                    return;
                }

                //Save, return, cancel save
                if (isJobStarted)
                {
                    if (choice == 3)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else if (choice == 0)
                    {
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();

                        FileSaveEverythingBeforeClosingField();

                        displayFieldName = gStr.gsNone;
                        //shutdown and reset all module data
                        mc.ResetAllModuleCommValues();
                    }
                }
            }     

            SaveFormGPSWindowSettings();

            if (sendToAppSocket != null)
            {
                try
                {
                    sendToAppSocket.Shutdown(SocketShutdown.Both);
                }
                catch { }
                finally { sendToAppSocket.Close(); }
            }

            if (recvFromAppSocket != null)
            {
                try
                {
                    recvFromAppSocket.Shutdown(SocketShutdown.Both);
                }
                catch { }
                finally { recvFromAppSocket.Close(); }
            }
            //save current vehicle
            SettingsIO.ExportAll(vehiclesDirectory + vehicleFileName + ".XML");
        }

        //called everytime window is resized, clean up button positions
        private void FormGPS_Resize(object sender, EventArgs e)
        {
            FixPanelsAndMenus(true);
            if (isGPSPositionInitialized) SetZoom();
            btn_synchro.Left = menuStrip1.Right - 82;
            btn_synchro.Top = menuStrip1.Top + 2;
        }

        // Load Bitmaps And Convert To Textures

        public enum textures : uint
        {
            SkyDay, Floor, Font,
            Turn, TurnCancel, TurnManual,
            Compass, Speedo, SpeedoNeedle,
            Lift, SkyNight, SteerPointer,
            SteerDot, Tractor, QuestionMark,
            FrontWheels, FourWDFront, FourWDRear,
            Harvester
        }

        public void CheckSettingsNotNull()
        {
            if (Settings.Default.setFeatures == null)
            {
                Settings.Default.setFeatures = new CFeatureSettings();
            }
        }

            public void LoadGLTextures() 
        {
            GL.Enable(EnableCap.Texture2D);

            Bitmap[] oglTextures = new Bitmap[]
            {
                Properties.Resources.z_SkyDay,Properties.Resources.z_Floor,Properties.Resources.z_Font, 
                Properties.Resources.z_Turn,Properties.Resources.z_TurnCancel,Properties.Resources.z_TurnManual,
                Properties.Resources.z_Compass,Properties.Resources.z_Speedo,Properties.Resources.z_SpeedoNeedle,
                Properties.Resources.z_Lift,Properties.Resources.z_SkyNight,Properties.Resources.z_SteerPointer,
                Properties.Resources.z_SteerDot,Properties.Resources.z_Tractor,Properties.Resources.z_QuestionMark,
                Properties.Resources.z_FrontWheels,Properties.Resources.z_4WDFront,Properties.Resources.z_4WDRear,
                Properties.Resources.z_Harvester
            };
                    
            texture = new uint[oglTextures.Length];

            for (int h = 0; h < oglTextures.Length; h++)
            {
                using (Bitmap bitmap = oglTextures[h])
                {
                    GL.GenTextures(1, out texture[h]);
                    GL.BindTexture(TextureTarget.Texture2D, texture[h]);
                    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                    bitmap.UnlockBits(bitmapData);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                }
            }
        }

        public void SwapDirection()
        {
            if (!yt.isYouTurnTriggered)
            {
                //is it turning right already?
                if (yt.isYouTurnRight)
                {
                    yt.isYouTurnRight = false;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    yt.ResetCreatedYouTurn();
                }
                else
                {
                    //make it turn the other way
                    yt.isYouTurnRight = true;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    yt.ResetCreatedYouTurn();
                }
            }
            else
            {
                if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
            }
        }

        private void BuildMachineByte()
        {
            int set = 1;
            int reset = 2046;
            p_254.pgn[p_254.sc1to8] = (byte)0;
            p_254.pgn[p_254.sc9to16] = (byte)0;

            int machine = 0;

            //check if super section is on
            if (section[tool.numOfSections].isSectionOn)
            {
                for (int j = 0; j < tool.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    machine |= set;
                    set <<= 1;
                }
            }

            else
            {
                for (int j = 0; j < MAXSECTIONS; j++)
                {
                    //set if on, reset bit if off
                    if (section[j].isSectionOn) machine |= set;
                    else machine &= reset;

                    //move set and reset over 1 bit left
                    set <<= 1;
                    reset <<= 1;
                    reset += 1;
                }
            }

            //sections in autosteer
            p_254.pgn[p_254.sc9to16] = unchecked((byte)(machine >> 8));
            p_254.pgn[p_254.sc1to8] = unchecked((byte)machine);

            //tram byte
            //p_254.pgn[p_254.tram] = unchecked((byte)tram.controlByte);

            //machine pgn
            p_239.pgn[p_239.sc9to16] = p_254.pgn[p_254.sc9to16];
            p_239.pgn[p_239.sc1to8] = p_254.pgn[p_254.sc1to8];
            p_239.pgn[p_239.tram] = unchecked((byte)tram.controlByte);

            //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
        }

        //dialog for requesting user to save or cancel
        public int SaveOrNot(bool closing)
        {
            CloseTopMosts();

            using (var form = new FormSaveOrNot(closing))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK) return 0;      //Save and Exit
                if (result == DialogResult.Ignore) return 1;   //Ignore
                if (result == DialogResult.Yes) return 2;      //Save As
                return 3;  // oops something is really busted
            }
        }

        //make the start picture disappear
        private void timer2_Tick(object sender, EventArgs e)
        {
                this.Controls.Remove(pictureboxStart);
                pictureboxStart.Dispose();
                //panel1.SendToBack();
                timer2.Enabled = false;
                timer2.Dispose();
        }

        public bool KeypadToNUD(NumericUpDown sender, Form owner)
        {
            sender.BackColor = Color.Red;
            using (var form = new FormNumeric((double)sender.Minimum, (double)sender.Maximum, (double)sender.Value))
            {
                var result = form.ShowDialog(owner);
                if (result == DialogResult.OK)
                {
                    sender.Value = (decimal)form.ReturnValue;
                    sender.BackColor = Color.AliceBlue;
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    sender.BackColor = Color.AliceBlue;
                }
                return false;
            }
        }

        public void KeyboardToText(TextBox sender, Form owner)
        {
            sender.BackColor = Color.Red;
            using (var form = new FormKeyboard(sender.Text))
            {
                var result = form.ShowDialog(owner);
                if (result == DialogResult.OK)
                {
                    sender.Text = form.ReturnString;
                }
            }
            sender.BackColor = Color.AliceBlue;
        }

        //function to set section positions
        public void SectionSetPosition()
        {
            section[0].positionLeft = (double)Vehicle.Default.setSection_position1 + Vehicle.Default.setVehicle_toolOffset;
            section[0].positionRight = (double)Vehicle.Default.setSection_position2 + Vehicle.Default.setVehicle_toolOffset;

            section[1].positionLeft = (double)Vehicle.Default.setSection_position2 + Vehicle.Default.setVehicle_toolOffset;
            section[1].positionRight = (double)Vehicle.Default.setSection_position3 + Vehicle.Default.setVehicle_toolOffset;

            section[2].positionLeft = (double)Vehicle.Default.setSection_position3 + Vehicle.Default.setVehicle_toolOffset;
            section[2].positionRight = (double)Vehicle.Default.setSection_position4 + Vehicle.Default.setVehicle_toolOffset;

            section[3].positionLeft = (double)Vehicle.Default.setSection_position4 + Vehicle.Default.setVehicle_toolOffset;
            section[3].positionRight = (double)Vehicle.Default.setSection_position5 + Vehicle.Default.setVehicle_toolOffset;

            section[4].positionLeft = (double)Vehicle.Default.setSection_position5 + Vehicle.Default.setVehicle_toolOffset;
            section[4].positionRight = (double)Vehicle.Default.setSection_position6 + Vehicle.Default.setVehicle_toolOffset;

            section[5].positionLeft = (double)Vehicle.Default.setSection_position6 + Vehicle.Default.setVehicle_toolOffset;
            section[5].positionRight = (double)Vehicle.Default.setSection_position7 + Vehicle.Default.setVehicle_toolOffset;

            section[6].positionLeft = (double)Vehicle.Default.setSection_position7 + Vehicle.Default.setVehicle_toolOffset;
            section[6].positionRight = (double)Vehicle.Default.setSection_position8 + Vehicle.Default.setVehicle_toolOffset;

            section[7].positionLeft = (double)Vehicle.Default.setSection_position8 + Vehicle.Default.setVehicle_toolOffset;
            section[7].positionRight = (double)Vehicle.Default.setSection_position9 + Vehicle.Default.setVehicle_toolOffset;

            section[8].positionLeft = (double)Vehicle.Default.setSection_position9 + Vehicle.Default.setVehicle_toolOffset;
            section[8].positionRight = (double)Vehicle.Default.setSection_position10 + Vehicle.Default.setVehicle_toolOffset;

            section[9].positionLeft = (double)Vehicle.Default.setSection_position10 + Vehicle.Default.setVehicle_toolOffset;
            section[9].positionRight = (double)Vehicle.Default.setSection_position11 + Vehicle.Default.setVehicle_toolOffset;

            section[10].positionLeft = (double)Vehicle.Default.setSection_position11 + Vehicle.Default.setVehicle_toolOffset;
            section[10].positionRight = (double)Vehicle.Default.setSection_position12 + Vehicle.Default.setVehicle_toolOffset;

            section[11].positionLeft = (double)Vehicle.Default.setSection_position12 + Vehicle.Default.setVehicle_toolOffset;
            section[11].positionRight = (double)Vehicle.Default.setSection_position13 + Vehicle.Default.setVehicle_toolOffset;

            section[12].positionLeft = (double)Vehicle.Default.setSection_position13 + Vehicle.Default.setVehicle_toolOffset;
            section[12].positionRight = (double)Vehicle.Default.setSection_position14 + Vehicle.Default.setVehicle_toolOffset;

            section[13].positionLeft = (double)Vehicle.Default.setSection_position14 + Vehicle.Default.setVehicle_toolOffset;
            section[13].positionRight = (double)Vehicle.Default.setSection_position15 + Vehicle.Default.setVehicle_toolOffset;

            section[14].positionLeft = (double)Vehicle.Default.setSection_position15 + Vehicle.Default.setVehicle_toolOffset;
            section[14].positionRight = (double)Vehicle.Default.setSection_position16 + Vehicle.Default.setVehicle_toolOffset;

            section[15].positionLeft = (double)Vehicle.Default.setSection_position16 + Vehicle.Default.setVehicle_toolOffset;
            section[15].positionRight = (double)Vehicle.Default.setSection_position17 + Vehicle.Default.setVehicle_toolOffset;
        }

        //function to calculate the width of each section and update
        public void SectionCalcWidths()
        {
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].sectionWidth = (section[j].positionRight - section[j].positionLeft);
                section[j].rpSectionPosition = 250 + (int)(Math.Round(section[j].positionLeft * 10, 0, MidpointRounding.AwayFromZero));
                section[j].rpSectionWidth = (int)(Math.Round(section[j].sectionWidth * 10, 0, MidpointRounding.AwayFromZero));
            }

            //calculate tool width based on extreme right and left values
            tool.toolWidth = Math.Abs(section[0].positionLeft) + Math.Abs(section[tool.numOfSections - 1].positionRight);

            //left and right tool position
            tool.toolFarLeftPosition = section[0].positionLeft;
            tool.toolFarRightPosition = section[tool.numOfSections - 1].positionRight;

            //now do the full width section
            section[tool.numOfSections].sectionWidth = tool.toolWidth;
            section[tool.numOfSections].positionLeft = tool.toolFarLeftPosition;
            section[tool.numOfSections].positionRight = tool.toolFarRightPosition;

            //find the right side pixel position
            tool.rpXPosition = 250 + (int)(Math.Round(tool.toolFarLeftPosition * 10, 0, MidpointRounding.AwayFromZero));
            tool.rpWidth = (int)(Math.Round(tool.toolWidth * 10, 0, MidpointRounding.AwayFromZero));
        }

        //request a new job
        public void JobNew()
        {
            if (Settings.Default.setMenu_isOGLZoomOn == 1)
            {
                //ajout max
                oglZoom.BringToFront();
                /*
                oglZoom.Width = 160;
                oglZoom.Height = 160;
                oglZoom.Left = 0;
                oglZoom.Top = 68;
                */
                //----SPailleau - Applique la position enregistrée
                oglZoom.Location = Properties.Settings.Default.OGLZoom_Location;
                oglZoom.Size = Properties.Settings.Default.OGLZoom_Size;
                //----Fin
            }

            //SendSteerSettingsOutAutoSteerPort();
            isJobStarted = true;
            startCounter = 0;

            btnManualOffOn.Enabled = true;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            btnSectionOffAutoOn.Enabled = true;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            btnSection1Man.BackColor = Color.Red;
            btnSection2Man.BackColor = Color.Red;
            btnSection3Man.BackColor = Color.Red;
            btnSection4Man.BackColor = Color.Red;
            btnSection5Man.BackColor = Color.Red;
            btnSection6Man.BackColor = Color.Red;
            btnSection7Man.BackColor = Color.Red;
            btnSection8Man.BackColor = Color.Red;
            btnSection9Man.BackColor = Color.Red;
            btnSection10Man.BackColor = Color.Red;
            btnSection11Man.BackColor = Color.Red;
            btnSection12Man.BackColor = Color.Red;
            btnSection13Man.BackColor = Color.Red;
            btnSection14Man.BackColor = Color.Red;
            btnSection15Man.BackColor = Color.Red;
            btnSection16Man.BackColor = Color.Red;

            btnSection1Man.Enabled = true;
            btnSection2Man.Enabled = true;
            btnSection3Man.Enabled = true;
            btnSection4Man.Enabled = true;
            btnSection5Man.Enabled = true;
            btnSection6Man.Enabled = true;
            btnSection7Man.Enabled = true;
            btnSection8Man.Enabled = true;
            btnSection9Man.Enabled = true;
            btnSection10Man.Enabled = true;
            btnSection11Man.Enabled = true;
            btnSection12Man.Enabled = true;
            btnSection13Man.Enabled = true;
            btnSection14Man.Enabled = true;
            btnSection15Man.Enabled = true;
            btnSection16Man.Enabled = true;


            btnABLine.Enabled = true;
            btnContour.Enabled = true;
            btnCurve.Enabled = true;
            btnMakeLinesFromBoundary.Enabled = true;
            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLines.Enabled = true;

            ABLine.abHeading = 0.00;
            btnAutoSteer.Enabled = true;

            DisableYouTurnButtons();
            btnFlag.Enabled = true;

            LineUpManualBtns();

            //update the menu
            this.menustripLanguage.Enabled = false;
            //panelRight.Enabled = true;
            //boundaryToolStripBtn.Enabled = true;

            FieldMenuButtonEnableDisable(true);
            FixPanelsAndMenus(true);
            SetZoom();
        }

        public void FieldMenuButtonEnableDisable(bool isOn)
        {
            SmoothABtoolStripMenu.Enabled = isOn;
            toolStripBtnMakeBndContour.Enabled = isOn;
            boundariesToolStripMenuItem.Enabled = isOn;
            headlandToolStripMenuItem.Enabled = isOn;
            deleteContourPathsToolStripMenuItem.Enabled = isOn;
            tramLinesMenuField.Enabled = isOn;
            recordedPathStripMenu.Enabled = isOn;
            btnMakeLinesFromBoundary.Enabled = isOn;
            btnFlag.Visible = isOn;

            //panelRight.Visible = isOn;
            //panelAB.Visible = isOn;

            lblFieldStatus.Visible = isOn;
            lblFieldDataTopField.Visible = isOn;
            lblFieldDataTopDone.Visible = isOn;
            lblFieldDataTopRemain.Visible = isOn;

            //roundButton1.Visible = true; //Commenté SPailleau (ancien bouton)
            cboxpRowWidth.Visible = true;
            btnYouSkipEnable.Visible = true;
        }

        //close the current job
        public void JobClose()
        {
            //reset field offsets
            pn.fixOffset.easting = 0;
            pn.fixOffset.northing = 0;

            //turn off headland
            hd.isOn = false;
            btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
            btnHeadlandOnOff.Visible = true;

            //make sure hydraulic lift is off
            p_239.pgn[p_239.hydLift] = 0;
            vehicle.isHydLiftOn = false;
            btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
            btnHydLift.Visible = true;

            //zoom gone
            oglZoom.SendToBack();

            //clean all the lines
            bnd.bndArr?.Clear();
            turn.turnArr?.Clear();
            hd.headArr[0].hdLine?.Clear();

            //panelRight.Enabled = false;
            FieldMenuButtonEnableDisable(false);

            menustripLanguage.Enabled = true;
            isJobStarted = false;

            //turn section buttons all OFF
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].isAllowedOn = false;
                section[j].manBtnState = manBtn.On;
            }

            //fix ManualOffOnAuto buttons
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            //fix auto button
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            //Update the button colors and text
            ManualAllBtnsUpdate();

            //enable disable manual buttons
            LineUpManualBtns();

            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;
            btnSection6Man.Enabled = false;
            btnSection7Man.Enabled = false;
            btnSection8Man.Enabled = false;
            btnSection9Man.Enabled = false;
            btnSection10Man.Enabled = false;
            btnSection11Man.Enabled = false;
            btnSection12Man.Enabled = false;
            btnSection13Man.Enabled = false;
            btnSection14Man.Enabled = false;
            btnSection15Man.Enabled = false;
            btnSection16Man.Enabled = false;

            btnSection1Man.BackColor = Color.Silver;
            btnSection2Man.BackColor = Color.Silver;
            btnSection3Man.BackColor = Color.Silver;
            btnSection4Man.BackColor = Color.Silver;
            btnSection5Man.BackColor = Color.Silver;
            btnSection6Man.BackColor = Color.Silver;
            btnSection7Man.BackColor = Color.Silver;
            btnSection8Man.BackColor = Color.Silver;
            btnSection9Man.BackColor = Color.Silver;
            btnSection10Man.BackColor = Color.Silver;
            btnSection11Man.BackColor = Color.Silver;
            btnSection12Man.BackColor = Color.Silver;
            btnSection13Man.BackColor = Color.Silver;
            btnSection14Man.BackColor = Color.Silver;
            btnSection15Man.BackColor = Color.Silver;
            btnSection16Man.BackColor = Color.Silver;

            //clear the section lists
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //clean out the lists
                section[j].patchList?.Clear();
                section[j].triangleList?.Clear();
            }

            //clear the flags
            flagPts.Clear();

            //ABLine
            btnABLine.Enabled = false;
            btnABLine.Image = Properties.Resources.ABLineOff;
            ABLine.isBtnABLineOn = false;
            ABLine.DeleteAB();
            ABLine.lineArr?.Clear();
            ABLine.numABLineSelected = 0;
            tram.tramArr?.Clear();
            tram.tramList?.Clear();

            //curve line
            btnCurve.Enabled = false;
            btnCurve.Image = Properties.Resources.CurveOff;
            curve.isBtnCurveOn = false;
            curve.isCurveSet = false;
            curve.ResetCurveLine();
            curve.curveArr?.Clear();
            curve.numCurveLineSelected = 0;

            //clean up tram
            tram.displayMode = 0;
            tram.tramBndInnerArr?.Clear();
            tram.tramBndOuterArr?.Clear();

            //clear out contour and Lists
            btnContour.Enabled = false;
            //btnContourPriority.Enabled = false;
            roundButton1.Image = Properties.Resources.SnapToPivot;
            ct.ResetContour();
            ct.isContourBtnOn = false;
            btnContour.Image = Properties.Resources.ContourOff;
            ct.isContourOn = false;

            btnMakeLinesFromBoundary.Enabled = false;
            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLines.Enabled = false;

            //AutoSteer
            //btnAutoSteer.Enabled = false;
            isAutoSteerBtnOn = false;
            btnAutoSteer.Image = Properties.Resources.AutoSteerOff;

            //auto YouTurn shutdown
            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            btnAutoYouTurn.Enabled = false;

            btnMakeLinesFromBoundary.Visible = true;

            yt.ResetYouTurn();
            DisableYouTurnButtons();

            //reset acre and distance counters
            fd.workedAreaTotal = 0;

            //reset boundaries
            bnd.ResetBoundaries();

            //reset turn lines
            turn.ResetTurnLines();

            //reset GUI areas
            fd.UpdateFieldBoundaryGUIAreas();

            //reset all Port Module values
            mc.ResetAllModuleCommValues();

            displayFieldName = gStr.gsNone;
            FixTramModeButton();

            recPath.recList?.Clear();
            recPath.shortestDubinsList?.Clear();
            recPath.shuttleDubinsList?.Clear();

            FixPanelsAndMenus(false);
            SetZoom();
        }

        //Does the logic to process section on off requests
        private void ProcessSectionOnOffRequests()
        {
            {
                double mapFactor = 1 + ((double)(100 - tool.minCoverage) * 0.01);
                for (int j = 0; j < tool.numOfSections + 1; j++)
                {
                    //SECTIONS - 


                    if (section[j].sectionOnRequest)
                        section[j].isSectionOn = true;

                    if (!section[j].sectionOffRequest) section[j].sectionOffTimer = (int)((double)fixUpdateHz * tool.turnOffDelay);

                    if (section[j].sectionOffTimer > 0) section[j].sectionOffTimer--;

                    if (section[j].sectionOffRequest & section[j].sectionOffTimer == 0)
                    {
                        if (section[j].isSectionOn) section[j].isSectionOn = false;
                    }

                    //MAPPING - 

                    //easy just turn it on
                    if (section[j].mappingOnRequest)
                    {
                        if (!section[j].isMappingOn && isMapping) section[j].TurnMappingOn(); //**************************************** un comment to enable mappping again
                    }

                    //turn off
                    double sped = 1 / ((pn.speed+3) * 0.5);
                    if (sped < 0.3) sped = 0.3;

                    //keep setting the timer so full when ready to turn off
                    if (!section[j].mappingOffRequest)
                        section[j].mappingOffTimer = (int)(fixUpdateHz * mapFactor * sped + ((double)fixUpdateHz * tool.turnOffDelay));

                    //decrement the off timer
                    if (section[j].mappingOffTimer > 0) section[j].mappingOffTimer--;

                    //if Off mapping timer is zero, turn off the section, reset everything
                    if (section[j].mappingOffTimer == 0 && section[j].mappingOffRequest)
                    {
                        if (section[j].isMappingOn) section[j].TurnMappingOff();
                        section[j].mappingOffRequest = false;
                    }

                    #region notes
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    //if (section[j].sectionOnRequest && !section[j].sectionOnOffCycle)
                    //{
                    //    section[j].sectionOnTimer = (int)(pn.speed * section[j].lookAheadOn) + 1;
                    //    if (section[j].sectionOnTimer > fixUpdateHz + 3) section[j].sectionOnTimer = fixUpdateHz + 3;
                    //    section[j].sectionOnOffCycle = true;
                    //}

                    ////reset the ON request
                    //section[j].sectionOnRequest = false;

                    ////decrement the timer if not zero
                    //if (section[j].sectionOnTimer > 0)
                    //{
                    //    //turn the section ON if not and decrement timer
                    //    section[j].sectionOnTimer--;
                    //    if (!section[j].isSectionOn) section[j].isSectionOn = true;

                    //    //keep resetting the section OFF timer while the ON is active
                    //    //section[j].sectionOffTimer = (int)(fixUpdateHz * tool.toolTurnOffDelay);
                    //}
                    //if (!section[j].sectionOffRequest) 
                    //    section[j].sectionOffTimer = (int)(fixUpdateHz * tool.turnOffDelay);

                    ////decrement the off timer
                    //if (section[j].sectionOffTimer > 0 && section[j].sectionOnTimer == 0) section[j].sectionOffTimer--;

                    ////Turn OFF
                    ////if Off section timer is zero, turn off the section
                    //if (section[j].sectionOffTimer == 0 && section[j].sectionOnTimer == 0 && section[j].sectionOffRequest)
                    //{
                    //    if (section[j].isSectionOn) section[j].isSectionOn = false;
                    //    //section[j].sectionOnOffCycle = false;
                    //    section[j].sectionOffRequest = false;
                    //    //}
                    //}
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    //if (section[j].mappingOnRequest && !section[j].mappingOnOffCycle)
                    //{
                    //    section[j].mappingOnTimer = (int)(fixUpdateHz * 1) + 1;
                    //    section[j].mappingOnOffCycle = true;
                    //}

                    ////reset the ON request
                    //section[j].mappingOnRequest = false;

                    //decrement the timer if not zero
                    #endregion notes
                }
            }
        }

        //take the distance from object and convert to camera data
        public void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) camera.gridZoom = 2000;
            else if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) camera.gridZoom = 2012*2;
            else if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) camera.gridZoom = 1006 *2;
            else if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) camera.gridZoom = 503 *2;
            else if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) camera.gridZoom = 201.2 *2;
            else if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) camera.gridZoom = 100.6 *2;
            else if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) camera.gridZoom = 50.3 *2;
            else if (camera.camSetDistance >= -250 && camera.camSetDistance < -150) camera.gridZoom = 25.15 *2;
            else if (camera.camSetDistance >= -150 && camera.camSetDistance < -50) camera.gridZoom = 10.06 *2;
            else if (camera.camSetDistance >= -50 && camera.camSetDistance < -1) camera.gridZoom = 5.03 *2;
            //1.216 2.532
            oglMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView((float)fovy, oglMain.AspectRatio, 1f, (float)(camDistanceFactor * camera.camSetDistance));
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        //All the files that need to be saved when closing field or app
        private void FileSaveEverythingBeforeClosingField()
        {
            //turn off contour line if on
            if (ct.isContourOn) ct.StopContourLine(pivotAxlePos);

            //turn off all the sections
            for (int j = 0; j < tool.numOfSections + 1; j++)
            {
                if (section[j].isMappingOn) section[j].TurnMappingOff();
                section[j].sectionOnOffCycle = false;
                section[j].sectionOffRequest = false;
            }

            //FileSaveHeadland();
            FileSaveBoundary();
            FileSaveSections();
            FileSaveContour();
            FileSaveFieldKML();

            JobClose();
            Text = "AgOpenGPS";
        }

        //an error log called by all try catches
        public void WriteErrorLog(string strErrorText)
        {
            try
            {
                //set up file and folder if it doesn't exist
                const string strFileName = "Error Log.txt";
                //string strPath = Application.StartupPath;

                //Write out the error appending to existing
                File.AppendAllText(baseDirectory + "\\" + strFileName, strErrorText + " - " +
                    DateTime.Now.ToString() + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in WriteErrorLog: " + ex.Message, "Error Logging", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //message box pops up with info then goes away
        public void TimedMessageBox(int timeout, string s1, string s2)
        {
            var form = new FormTimedMessage(timeout, s1, s2);
            form.Show(this);
        }
    }//class FormGPS
}//namespace AgOpenGPS

/*The order is:
 *
 * The watchdog timer times out and runs this function tmrWatchdog_tick().
 * 50 times per second so statusUpdateCounter counts to 25 and updates strip menu etc at 2 hz
 * it also makes sure there is new sentences showing up otherwise it shows **** No GGA....
 * saveCounter ticks 2 x per second, used at end of draw routine every minute to save a backup of field
 * then ScanForNMEA function checks for a complete sentence if contained in pn.rawbuffer
 * if not it comes right back and waits for next watchdog trigger and starts all over
 * if a new sentence is there, UpdateFix() is called
 * Right away CalculateLookAhead(), no skips, is called to determine lookaheads and trigger distances to save triangles plotted
 * Then UpdateFix() continues.
 * Hitch, pivot, antenna locations etc and directions are figured out if trigDistance is triggered
 * When that is done, DoRender() is called on the visible OpenGL screen and its draw routine _draw is run
 * before triangles are drawn, frustum cull figures out how many of the triangles should be drawn
 * When its all the way thru, it triggers the sectioncontrol Draw, its frustum cull, and determines if sections should be on
 * ProcessSectionOnOffRequests() runs and that does the section on off magic
 * SectionControlToArduino() runs and spits out the port machine control based on sections on or off
 * If field needs saving (1.5 minute since last time) field is saved
 * Now the program is "Done" and waits for the next watchdog trigger, determines if a new sentence is available etc
 * and starts all over from the top.
 */