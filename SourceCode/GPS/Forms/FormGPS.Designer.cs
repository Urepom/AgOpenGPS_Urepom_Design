using System.Windows.Forms;

namespace AgOpenGPS
{
    partial class FormGPS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
            this.contextMenuStripOpenGL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.googleEarthOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFlag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFlagRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagGrn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagYel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuFlagForm = new System.Windows.Forms.ToolStripMenuItem();
            this.oglZoom = new OpenTK.GLControl();
            this.panelDrag = new System.Windows.Forms.TableLayoutPanel();
            this.btnPathGoStop = new System.Windows.Forms.Button();
            this.btnPickPath = new System.Windows.Forms.Button();
            this.btnPathRecordStop = new System.Windows.Forms.Button();
            this.btnResumePath = new System.Windows.Forms.Button();
            this.btnSwapABRecordedPath = new System.Windows.Forms.Button();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbarSteerAngle = new System.Windows.Forms.HScrollBar();
            this.btnSection8Man = new System.Windows.Forms.Button();
            this.btnSection7Man = new System.Windows.Forms.Button();
            this.btnSection6Man = new System.Windows.Forms.Button();
            this.btnSection5Man = new System.Windows.Forms.Button();
            this.btnSection4Man = new System.Windows.Forms.Button();
            this.btnSection3Man = new System.Windows.Forms.Button();
            this.btnSection2Man = new System.Windows.Forms.Button();
            this.btnSection1Man = new System.Windows.Forms.Button();
            this.btnSection9Man = new System.Windows.Forms.Button();
            this.btnSection10Man = new System.Windows.Forms.Button();
            this.btnSection11Man = new System.Windows.Forms.Button();
            this.btnSection12Man = new System.Windows.Forms.Button();
            this.oglMain = new OpenTK.GLControl();
            this.oglBack = new OpenTK.GLControl();
            this.panelSim = new System.Windows.Forms.TableLayoutPanel();
            this.btnSpeedDn = new ProXoft.WinForms.RepeatButton();
            this.btnSimSpeedUp = new ProXoft.WinForms.RepeatButton();
            this.btnSimSetSpeedToZero = new System.Windows.Forms.Button();
            this.btnSimReverseDirection = new System.Windows.Forms.Button();
            this.btnSection16Man = new System.Windows.Forms.Button();
            this.btnSection15Man = new System.Windows.Forms.Button();
            this.btnSection14Man = new System.Windows.Forms.Button();
            this.btnSection13Man = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnGrid = new System.Windows.Forms.Button();
            this.btnTiltDn = new System.Windows.Forms.Button();
            this.btnTiltUp = new System.Windows.Forms.Button();
            this.btnBrightnessDn = new System.Windows.Forms.Button();
            this.btnBrightnessUp = new System.Windows.Forms.Button();
            this.btnDayNightMode = new System.Windows.Forms.Button();
            this.btnN2D = new System.Windows.Forms.Button();
            this.btn3D = new System.Windows.Forms.Button();
            this.btn2D = new System.Windows.Forms.Button();
            this.btnZone1 = new System.Windows.Forms.Button();
            this.btnZone2 = new System.Windows.Forms.Button();
            this.btnZone3 = new System.Windows.Forms.Button();
            this.btnZone4 = new System.Windows.Forms.Button();
            this.btnZone5 = new System.Windows.Forms.Button();
            this.btnZone6 = new System.Windows.Forms.Button();
            this.btnZone7 = new System.Windows.Forms.Button();
            this.btnZone8 = new System.Windows.Forms.Button();
            this.lblGuidanceLine = new System.Windows.Forms.Label();
            this.flp1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip_btnNudge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip_headlane = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_tram = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_contour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_btnBuildTracks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_lblhz = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_SnapCenterMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_top = new AgOpenGPS.Round_panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblTotalAppliedArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWorkRemaining = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.round_table12 = new AgOpenGPS.Round_table();
            this.btnChargeStatus = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbludpWatchCounts = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.BatLevel = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHz = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.round_table11 = new AgOpenGPS.Round_table();
            this.btnMaximizeMainForm = new System.Windows.Forms.Button();
            this.btnMinimizeMainForm = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.round_Menu1 = new AgOpenGPS.Round_Menu();
            this.dzzdzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menustripLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDeutsch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageLatvian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageLithuanian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageHungarian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageNorsk = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDutch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguagePortugese = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguagePolish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFinnish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSerbie = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSlovak = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageUkranian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageTurkish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatorOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterSimCoordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.kioskModeToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miseÀJourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nozzleAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNavigationSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.Connected_services = new System.Windows.Forms.ToolStripDropDownButton();
            this.round_table6 = new AgOpenGPS.Round_table();
            this.btnFlag = new System.Windows.Forms.Button();
            this.round_table4 = new AgOpenGPS.Round_table();
            this.btnABDraw = new System.Windows.Forms.Button();
            this.btnNudge = new System.Windows.Forms.Button();
            this.round_table3 = new AgOpenGPS.Round_table();
            this.btnHeadlandOnOff = new System.Windows.Forms.Button();
            this.btnContour = new System.Windows.Forms.Button();
            this.round_table2 = new AgOpenGPS.Round_table();
            this.btnTramDisplayMode = new System.Windows.Forms.Button();
            this.round_table1 = new AgOpenGPS.Round_table();
            this.btnBuildTracks = new System.Windows.Forms.Button();
            this.btnAutoTrack = new System.Windows.Forms.Button();
            this.btnCycleLines = new System.Windows.Forms.Button();
            this.round_table5 = new AgOpenGPS.Round_table();
            this.btnSectionMasterAuto = new System.Windows.Forms.Button();
            this.btnSectionMasterManual = new System.Windows.Forms.Button();
            this.btnChangeMappingColor = new System.Windows.Forms.Button();
            this.round_StatusStrip2 = new AgOpenGPS.Round_StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.distanceToolBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.wizardsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.steerWizardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steerChartStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.steerChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headingChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xTEChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rollCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContourPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetFixToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SmoothABtoolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSteerSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAllSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripWorkingDirectories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGPSData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripColors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSectionColors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripHotkeys = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartAgIO = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAutoSteerConfig = new System.Windows.Forms.ToolStripDropDownButton();
            this.round_StatusStrip1 = new AgOpenGPS.Round_StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnJobMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteAppliedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryToolToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.headlandBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagByLatLonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordedPathStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.headlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramsMultiMenuField = new System.Windows.Forms.ToolStripMenuItem();
            this.tramLinesMenuField = new System.Windows.Forms.ToolStripMenuItem();
            this.round_table10 = new AgOpenGPS.Round_StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.round_table9 = new AgOpenGPS.Round_table();
            this.btnAutoYouTurn = new System.Windows.Forms.Button();
            this.btnYouSkipEnable = new System.Windows.Forms.Button();
            this.cboxpRowWidth = new System.Windows.Forms.ComboBox();
            this.round_table8 = new AgOpenGPS.Round_table();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHydLift = new System.Windows.Forms.Button();
            this.round_table7 = new AgOpenGPS.Round_table();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnResetToolHeading = new System.Windows.Forms.Button();
            this.lblHardwareMessage = new System.Windows.Forms.Label();
            this.cboxAutoSnapToPivot = new System.Windows.Forms.CheckBox();
            this.SnapCenterMain = new System.Windows.Forms.Button();
            this.btnAdjRightMain = new System.Windows.Forms.Button();
            this.btnAdjLeftMain = new System.Windows.Forms.Button();
            this.contextMenuStripOpenGL.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            this.panelDrag.SuspendLayout();
            this.panelSim.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.round_table12.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.round_table11.SuspendLayout();
            this.round_Menu1.SuspendLayout();
            this.round_table6.SuspendLayout();
            this.round_table4.SuspendLayout();
            this.round_table3.SuspendLayout();
            this.round_table2.SuspendLayout();
            this.round_table1.SuspendLayout();
            this.round_table5.SuspendLayout();
            this.round_StatusStrip2.SuspendLayout();
            this.round_StatusStrip1.SuspendLayout();
            this.round_table10.SuspendLayout();
            this.round_table9.SuspendLayout();
            this.round_table8.SuspendLayout();
            this.round_table7.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripOpenGL
            // 
            this.contextMenuStripOpenGL.AutoSize = false;
            this.contextMenuStripOpenGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.googleEarthOpenGLContextMenu});
            this.contextMenuStripOpenGL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripOpenGL.Name = "contextMenuStripOpenGL";
            this.contextMenuStripOpenGL.Size = new System.Drawing.Size(72, 160);
            this.contextMenuStripOpenGL.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOpenGL_Opening);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(68, 6);
            // 
            // googleEarthOpenGLContextMenu
            // 
            this.googleEarthOpenGLContextMenu.AutoSize = false;
            this.googleEarthOpenGLContextMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.googleEarthOpenGLContextMenu.Name = "googleEarthOpenGLContextMenu";
            this.googleEarthOpenGLContextMenu.Size = new System.Drawing.Size(70, 70);
            this.googleEarthOpenGLContextMenu.Text = ".";
            this.googleEarthOpenGLContextMenu.Click += new System.EventHandler(this.googleEarthOpenGLContextMenu_Click);
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 250;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // contextMenuStripFlag
            // 
            this.contextMenuStripFlag.AutoSize = false;
            this.contextMenuStripFlag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contextMenuStripFlag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFlagRed,
            this.toolStripMenuFlagGrn,
            this.toolStripMenuFlagYel,
            this.toolStripSeparator12,
            this.toolStripMenuFlagForm});
            this.contextMenuStripFlag.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripFlag.Name = "contextMenuStripFlag";
            this.contextMenuStripFlag.Size = new System.Drawing.Size(72, 312);
            // 
            // toolStripMenuItemFlagRed
            // 
            this.toolStripMenuItemFlagRed.AutoSize = false;
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Image = global::AgOpenGPS.Properties.Resources.FlagYel;
            this.toolStripMenuItemFlagRed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemFlagRed.Name = "toolStripMenuItemFlagRed";
            this.toolStripMenuItemFlagRed.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuItemFlagRed.Text = ".";
            this.toolStripMenuItemFlagRed.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripMenuFlagGrn
            // 
            this.toolStripMenuFlagGrn.AutoSize = false;
            this.toolStripMenuFlagGrn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagGrn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagGrn.Image = global::AgOpenGPS.Properties.Resources.FlagGrn;
            this.toolStripMenuFlagGrn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagGrn.Name = "toolStripMenuFlagGrn";
            this.toolStripMenuFlagGrn.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagGrn.Text = ".";
            this.toolStripMenuFlagGrn.Click += new System.EventHandler(this.toolStripMenuGrn_Click);
            // 
            // toolStripMenuFlagYel
            // 
            this.toolStripMenuFlagYel.AutoSize = false;
            this.toolStripMenuFlagYel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagYel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagYel.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.toolStripMenuFlagYel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagYel.Text = ".";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuItemFlagRed_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(68, 6);
            // 
            // toolStripMenuFlagForm
            // 
            this.toolStripMenuFlagForm.Image = global::AgOpenGPS.Properties.Resources.FileEditName;
            this.toolStripMenuFlagForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagForm.Name = "toolStripMenuFlagForm";
            this.toolStripMenuFlagForm.Size = new System.Drawing.Size(228, 70);
            this.toolStripMenuFlagForm.Text = "toolStripMenuItem3";
            this.toolStripMenuFlagForm.Click += new System.EventHandler(this.toolStripMenuFlagForm_Click);
            // 
            // oglZoom
            // 
            this.oglZoom.BackColor = System.Drawing.Color.Black;
            this.oglZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oglZoom.Location = new System.Drawing.Point(122, 63);
            this.oglZoom.Margin = new System.Windows.Forms.Padding(0);
            this.oglZoom.Name = "oglZoom";
            this.oglZoom.Size = new System.Drawing.Size(41, 44);
            this.oglZoom.TabIndex = 182;
            this.oglZoom.VSync = false;
            this.oglZoom.Load += new System.EventHandler(this.oglZoom_Load);
            this.oglZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.oglZoom_Paint);
            this.oglZoom.Resize += new System.EventHandler(this.oglZoom_Resize);
            // 
            // panelDrag
            // 
            this.panelDrag.BackColor = System.Drawing.Color.White;
            this.panelDrag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDrag.ColumnCount = 1;
            this.panelDrag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDrag.Controls.Add(this.btnPathGoStop, 0, 0);
            this.panelDrag.Controls.Add(this.btnPickPath, 0, 3);
            this.panelDrag.Controls.Add(this.btnPathRecordStop, 0, 2);
            this.panelDrag.Controls.Add(this.btnResumePath, 0, 1);
            this.panelDrag.Controls.Add(this.btnSwapABRecordedPath, 0, 4);
            this.panelDrag.Location = new System.Drawing.Point(424, 103);
            this.panelDrag.Name = "panelDrag";
            this.panelDrag.RowCount = 6;
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelDrag.Size = new System.Drawing.Size(64, 381);
            this.panelDrag.TabIndex = 445;
            this.panelDrag.Visible = false;
            // 
            // btnPathGoStop
            // 
            this.btnPathGoStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPathGoStop.BackColor = System.Drawing.Color.Transparent;
            this.btnPathGoStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPathGoStop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPathGoStop.FlatAppearance.BorderSize = 0;
            this.btnPathGoStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathGoStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathGoStop.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPathGoStop.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
            this.btnPathGoStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPathGoStop.Location = new System.Drawing.Point(0, 0);
            this.btnPathGoStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathGoStop.Name = "btnPathGoStop";
            this.btnPathGoStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPathGoStop.Size = new System.Drawing.Size(64, 61);
            this.btnPathGoStop.TabIndex = 468;
            this.btnPathGoStop.UseVisualStyleBackColor = false;
            this.btnPathGoStop.Click += new System.EventHandler(this.btnPathGoStop_Click);
            // 
            // btnPickPath
            // 
            this.btnPickPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPickPath.BackColor = System.Drawing.Color.Transparent;
            this.btnPickPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPickPath.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPickPath.FlatAppearance.BorderSize = 0;
            this.btnPickPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickPath.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPickPath.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnPickPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPickPath.Location = new System.Drawing.Point(0, 227);
            this.btnPickPath.Margin = new System.Windows.Forms.Padding(0);
            this.btnPickPath.Name = "btnPickPath";
            this.btnPickPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPickPath.Size = new System.Drawing.Size(64, 61);
            this.btnPickPath.TabIndex = 471;
            this.btnPickPath.UseVisualStyleBackColor = false;
            this.btnPickPath.Click += new System.EventHandler(this.btnPickPath_Click);
            // 
            // btnPathRecordStop
            // 
            this.btnPathRecordStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPathRecordStop.BackColor = System.Drawing.Color.Transparent;
            this.btnPathRecordStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPathRecordStop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPathRecordStop.FlatAppearance.BorderSize = 0;
            this.btnPathRecordStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathRecordStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathRecordStop.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPathRecordStop.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnPathRecordStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPathRecordStop.Location = new System.Drawing.Point(0, 149);
            this.btnPathRecordStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathRecordStop.Name = "btnPathRecordStop";
            this.btnPathRecordStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPathRecordStop.Size = new System.Drawing.Size(64, 61);
            this.btnPathRecordStop.TabIndex = 470;
            this.btnPathRecordStop.UseVisualStyleBackColor = false;
            this.btnPathRecordStop.Click += new System.EventHandler(this.btnPathRecordStop_Click);
            // 
            // btnResumePath
            // 
            this.btnResumePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResumePath.BackColor = System.Drawing.Color.Transparent;
            this.btnResumePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResumePath.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnResumePath.FlatAppearance.BorderSize = 0;
            this.btnResumePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumePath.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumePath.ForeColor = System.Drawing.Color.Red;
            this.btnResumePath.Image = global::AgOpenGPS.Properties.Resources.pathResumeStart;
            this.btnResumePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResumePath.Location = new System.Drawing.Point(0, 76);
            this.btnResumePath.Margin = new System.Windows.Forms.Padding(0);
            this.btnResumePath.Name = "btnResumePath";
            this.btnResumePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnResumePath.Size = new System.Drawing.Size(64, 64);
            this.btnResumePath.TabIndex = 472;
            this.btnResumePath.UseVisualStyleBackColor = false;
            this.btnResumePath.Click += new System.EventHandler(this.btnResumePath_Click);
            // 
            // btnSwapABRecordedPath
            // 
            this.btnSwapABRecordedPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSwapABRecordedPath.BackColor = System.Drawing.Color.Transparent;
            this.btnSwapABRecordedPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSwapABRecordedPath.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSwapABRecordedPath.FlatAppearance.BorderSize = 0;
            this.btnSwapABRecordedPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapABRecordedPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapABRecordedPath.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSwapABRecordedPath.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapABRecordedPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapABRecordedPath.Location = new System.Drawing.Point(0, 293);
            this.btnSwapABRecordedPath.Margin = new System.Windows.Forms.Padding(0);
            this.btnSwapABRecordedPath.Name = "btnSwapABRecordedPath";
            this.btnSwapABRecordedPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSwapABRecordedPath.Size = new System.Drawing.Size(64, 61);
            this.btnSwapABRecordedPath.TabIndex = 470;
            this.btnSwapABRecordedPath.UseVisualStyleBackColor = false;
            this.btnSwapABRecordedPath.Click += new System.EventHandler(this.btnSwapABRecordedPath_Click);
            // 
            // btnResetSim
            // 
            this.btnResetSim.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSim.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSim.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSim.Location = new System.Drawing.Point(4, 4);
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.Size = new System.Drawing.Size(66, 34);
            this.btnResetSim.TabIndex = 164;
            this.btnResetSim.Text = "Reset";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // btnResetSteerAngle
            // 
            this.btnResetSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSteerAngle.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSteerAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetSteerAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSteerAngle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSteerAngle.Location = new System.Drawing.Point(77, 4);
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.Size = new System.Drawing.Size(66, 34);
            this.btnResetSteerAngle.TabIndex = 162;
            this.btnResetSteerAngle.Text = ">0<";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            this.btnResetSteerAngle.Click += new System.EventHandler(this.btnResetSteerAngle_Click);
            // 
            // timerSim
            // 
            this.timerSim.Enabled = true;
            this.timerSim.Interval = 93;
            this.timerSim.Tick += new System.EventHandler(this.timerSim_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(334, 62);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // hsbarSteerAngle
            // 
            this.hsbarSteerAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsbarSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarSteerAngle.LargeChange = 20;
            this.hsbarSteerAngle.Location = new System.Drawing.Point(158, 1);
            this.hsbarSteerAngle.Maximum = 800;
            this.hsbarSteerAngle.Name = "hsbarSteerAngle";
            this.hsbarSteerAngle.Size = new System.Drawing.Size(218, 40);
            this.hsbarSteerAngle.TabIndex = 179;
            this.hsbarSteerAngle.Value = 400;
            this.hsbarSteerAngle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSteerAngle_Scroll);
            // 
            // btnSection8Man
            // 
            this.btnSection8Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection8Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection8Man.Enabled = false;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection8Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection8Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection8Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection8Man.Location = new System.Drawing.Point(817, 243);
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection8Man.TabIndex = 125;
            this.btnSection8Man.Text = "8";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection7Man
            // 
            this.btnSection7Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection7Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection7Man.Enabled = false;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection7Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection7Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection7Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection7Man.Location = new System.Drawing.Point(817, 216);
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection7Man.TabIndex = 126;
            this.btnSection7Man.Text = "7";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection6Man
            // 
            this.btnSection6Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection6Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection6Man.Enabled = false;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection6Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection6Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection6Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection6Man.Location = new System.Drawing.Point(817, 189);
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection6Man.TabIndex = 127;
            this.btnSection6Man.Text = "6";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection5Man
            // 
            this.btnSection5Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection5Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection5Man.Enabled = false;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection5Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection5Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection5Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection5Man.Location = new System.Drawing.Point(817, 162);
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection5Man.TabIndex = 103;
            this.btnSection5Man.Text = "5";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection4Man
            // 
            this.btnSection4Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection4Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection4Man.Enabled = false;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection4Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection4Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection4Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection4Man.Location = new System.Drawing.Point(817, 136);
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection4Man.TabIndex = 102;
            this.btnSection4Man.Text = "4";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection3Man
            // 
            this.btnSection3Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection3Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection3Man.Enabled = false;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection3Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection3Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection3Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection3Man.Location = new System.Drawing.Point(817, 110);
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection3Man.TabIndex = 101;
            this.btnSection3Man.Text = "3";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection2Man
            // 
            this.btnSection2Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection2Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection2Man.Enabled = false;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection2Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection2Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection2Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection2Man.Location = new System.Drawing.Point(817, 83);
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection2Man.TabIndex = 100;
            this.btnSection2Man.Text = "2";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection1Man
            // 
            this.btnSection1Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection1Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection1Man.Enabled = false;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection1Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection1Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection1Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection1Man.Location = new System.Drawing.Point(817, 56);
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection1Man.TabIndex = 99;
            this.btnSection1Man.Text = "1";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection9Man
            // 
            this.btnSection9Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection9Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection9Man.Enabled = false;
            this.btnSection9Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection9Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection9Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection9Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection9Man.Location = new System.Drawing.Point(777, 56);
            this.btnSection9Man.Name = "btnSection9Man";
            this.btnSection9Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection9Man.TabIndex = 174;
            this.btnSection9Man.Text = "9";
            this.btnSection9Man.UseVisualStyleBackColor = false;
            this.btnSection9Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection10Man
            // 
            this.btnSection10Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection10Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection10Man.Enabled = false;
            this.btnSection10Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection10Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection10Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection10Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection10Man.Location = new System.Drawing.Point(777, 83);
            this.btnSection10Man.Name = "btnSection10Man";
            this.btnSection10Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection10Man.TabIndex = 175;
            this.btnSection10Man.Text = "10";
            this.btnSection10Man.UseVisualStyleBackColor = false;
            this.btnSection10Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection11Man
            // 
            this.btnSection11Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection11Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection11Man.Enabled = false;
            this.btnSection11Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection11Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection11Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection11Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection11Man.Location = new System.Drawing.Point(777, 110);
            this.btnSection11Man.Name = "btnSection11Man";
            this.btnSection11Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection11Man.TabIndex = 176;
            this.btnSection11Man.Text = "11";
            this.btnSection11Man.UseVisualStyleBackColor = false;
            this.btnSection11Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection12Man
            // 
            this.btnSection12Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection12Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection12Man.Enabled = false;
            this.btnSection12Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection12Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection12Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection12Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection12Man.Location = new System.Drawing.Point(777, 136);
            this.btnSection12Man.Name = "btnSection12Man";
            this.btnSection12Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection12Man.TabIndex = 177;
            this.btnSection12Man.Text = "12";
            this.btnSection12Man.UseVisualStyleBackColor = false;
            this.btnSection12Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // oglMain
            // 
            this.oglMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oglMain.BackColor = System.Drawing.Color.Black;
            this.oglMain.ContextMenuStrip = this.contextMenuStripOpenGL;
            this.oglMain.Location = new System.Drawing.Point(-2, -4);
            this.oglMain.Margin = new System.Windows.Forms.Padding(0);
            this.oglMain.Name = "oglMain";
            this.oglMain.Size = new System.Drawing.Size(1006, 737);
            this.oglMain.TabIndex = 180;
            this.oglMain.VSync = false;
            this.oglMain.Load += new System.EventHandler(this.oglMain_Load);
            this.oglMain.Paint += new System.Windows.Forms.PaintEventHandler(this.oglMain_Paint);
            this.oglMain.DoubleClick += new System.EventHandler(this.btnJobMenu_Click);
            this.oglMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglMain_MouseDown);
            this.oglMain.Resize += new System.EventHandler(this.oglMain_Resize);
            // 
            // oglBack
            // 
            this.oglBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oglBack.BackColor = System.Drawing.Color.Black;
            this.oglBack.ForeColor = System.Drawing.Color.Transparent;
            this.oglBack.Location = new System.Drawing.Point(122, 70);
            this.oglBack.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.oglBack.Name = "oglBack";
            this.oglBack.Size = new System.Drawing.Size(500, 250);
            this.oglBack.TabIndex = 181;
            this.oglBack.VSync = false;
            this.oglBack.Load += new System.EventHandler(this.oglBack_Load);
            this.oglBack.Paint += new System.Windows.Forms.PaintEventHandler(this.oglBack_Paint);
            this.oglBack.Resize += new System.EventHandler(this.oglBack_Resize);
            // 
            // panelSim
            // 
            this.panelSim.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSim.BackColor = System.Drawing.Color.Transparent;
            this.panelSim.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelSim.ColumnCount = 9;
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.panelSim.Controls.Add(this.btnSpeedDn, 5, 0);
            this.panelSim.Controls.Add(this.btnSimSpeedUp, 7, 0);
            this.panelSim.Controls.Add(this.btnResetSim, 0, 0);
            this.panelSim.Controls.Add(this.btnSimSetSpeedToZero, 6, 0);
            this.panelSim.Controls.Add(this.btnResetSteerAngle, 1, 0);
            this.panelSim.Controls.Add(this.hsbarSteerAngle, 3, 0);
            this.panelSim.Controls.Add(this.btnSimReverseDirection, 8, 0);
            this.panelSim.Location = new System.Drawing.Point(195, 529);
            this.panelSim.Name = "panelSim";
            this.panelSim.RowCount = 1;
            this.panelSim.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSim.Size = new System.Drawing.Size(759, 42);
            this.panelSim.TabIndex = 325;
            // 
            // btnSpeedDn
            // 
            this.btnSpeedDn.BackColor = System.Drawing.Color.Transparent;
            this.btnSpeedDn.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnSpeedDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpeedDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpeedDn.FlatAppearance.BorderSize = 0;
            this.btnSpeedDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeedDn.Location = new System.Drawing.Point(391, 4);
            this.btnSpeedDn.Name = "btnSpeedDn";
            this.btnSpeedDn.Size = new System.Drawing.Size(88, 34);
            this.btnSpeedDn.TabIndex = 533;
            this.btnSpeedDn.UseVisualStyleBackColor = false;
            this.btnSpeedDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSpeedDn_MouseDown);
            // 
            // btnSimSpeedUp
            // 
            this.btnSimSpeedUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSimSpeedUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnSimSpeedUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSimSpeedUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSimSpeedUp.FlatAppearance.BorderSize = 0;
            this.btnSimSpeedUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimSpeedUp.Location = new System.Drawing.Point(559, 4);
            this.btnSimSpeedUp.Name = "btnSimSpeedUp";
            this.btnSimSpeedUp.Size = new System.Drawing.Size(88, 34);
            this.btnSimSpeedUp.TabIndex = 532;
            this.btnSimSpeedUp.UseVisualStyleBackColor = false;
            this.btnSimSpeedUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSimSpeedUp_MouseDown);
            // 
            // btnSimSetSpeedToZero
            // 
            this.btnSimSetSpeedToZero.BackColor = System.Drawing.Color.Transparent;
            this.btnSimSetSpeedToZero.BackgroundImage = global::AgOpenGPS.Properties.Resources.AutoStop;
            this.btnSimSetSpeedToZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSimSetSpeedToZero.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimSetSpeedToZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimSetSpeedToZero.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSimSetSpeedToZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSimSetSpeedToZero.Location = new System.Drawing.Point(486, 4);
            this.btnSimSetSpeedToZero.Name = "btnSimSetSpeedToZero";
            this.btnSimSetSpeedToZero.Size = new System.Drawing.Size(52, 34);
            this.btnSimSetSpeedToZero.TabIndex = 453;
            this.btnSimSetSpeedToZero.UseVisualStyleBackColor = false;
            this.btnSimSetSpeedToZero.Click += new System.EventHandler(this.btnSimSetSpeedToZero_Click);
            // 
            // btnSimReverseDirection
            // 
            this.btnSimReverseDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimReverseDirection.BackColor = System.Drawing.Color.Transparent;
            this.btnSimReverseDirection.BackgroundImage = global::AgOpenGPS.Properties.Resources.Youturn80;
            this.btnSimReverseDirection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSimReverseDirection.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimReverseDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimReverseDirection.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSimReverseDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSimReverseDirection.Location = new System.Drawing.Point(687, 4);
            this.btnSimReverseDirection.Name = "btnSimReverseDirection";
            this.btnSimReverseDirection.Size = new System.Drawing.Size(35, 34);
            this.btnSimReverseDirection.TabIndex = 537;
            this.btnSimReverseDirection.UseVisualStyleBackColor = false;
            this.btnSimReverseDirection.Click += new System.EventHandler(this.btnSimReverseDirection_Click);
            // 
            // btnSection16Man
            // 
            this.btnSection16Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection16Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection16Man.Enabled = false;
            this.btnSection16Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection16Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection16Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection16Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection16Man.Location = new System.Drawing.Point(777, 243);
            this.btnSection16Man.Name = "btnSection16Man";
            this.btnSection16Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection16Man.TabIndex = 448;
            this.btnSection16Man.Text = "16";
            this.btnSection16Man.UseVisualStyleBackColor = false;
            this.btnSection16Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection15Man
            // 
            this.btnSection15Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection15Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection15Man.Enabled = false;
            this.btnSection15Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection15Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection15Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection15Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection15Man.Location = new System.Drawing.Point(777, 216);
            this.btnSection15Man.Name = "btnSection15Man";
            this.btnSection15Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection15Man.TabIndex = 449;
            this.btnSection15Man.Text = "15";
            this.btnSection15Man.UseVisualStyleBackColor = false;
            this.btnSection15Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection14Man
            // 
            this.btnSection14Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection14Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection14Man.Enabled = false;
            this.btnSection14Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection14Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection14Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection14Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection14Man.Location = new System.Drawing.Point(777, 189);
            this.btnSection14Man.Name = "btnSection14Man";
            this.btnSection14Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection14Man.TabIndex = 450;
            this.btnSection14Man.Text = "14";
            this.btnSection14Man.UseVisualStyleBackColor = false;
            this.btnSection14Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // btnSection13Man
            // 
            this.btnSection13Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection13Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection13Man.Enabled = false;
            this.btnSection13Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection13Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection13Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection13Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection13Man.Location = new System.Drawing.Point(777, 162);
            this.btnSection13Man.Name = "btnSection13Man";
            this.btnSection13Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection13Man.TabIndex = 451;
            this.btnSection13Man.Text = "13";
            this.btnSection13Man.UseVisualStyleBackColor = false;
            this.btnSection13Man.Click += new System.EventHandler(this.btnSectionXMan_Click);
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelNavigation.ColumnCount = 2;
            this.panelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNavigation.Controls.Add(this.btnGrid, 1, 3);
            this.panelNavigation.Controls.Add(this.btnTiltDn, 0, 0);
            this.panelNavigation.Controls.Add(this.btnTiltUp, 1, 0);
            this.panelNavigation.Controls.Add(this.btnBrightnessDn, 0, 4);
            this.panelNavigation.Controls.Add(this.btnBrightnessUp, 1, 4);
            this.panelNavigation.Controls.Add(this.btnDayNightMode, 0, 3);
            this.panelNavigation.Controls.Add(this.btnN2D, 0, 2);
            this.panelNavigation.Controls.Add(this.btn3D, 1, 1);
            this.panelNavigation.Controls.Add(this.btn2D, 0, 1);
            this.panelNavigation.Location = new System.Drawing.Point(527, 63);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.RowCount = 5;
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelNavigation.Size = new System.Drawing.Size(179, 460);
            this.panelNavigation.TabIndex = 468;
            this.panelNavigation.Visible = false;
            // 
            // btnGrid
            // 
            this.btnGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGrid.BackColor = System.Drawing.Color.Transparent;
            this.btnGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrid.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnGrid.FlatAppearance.BorderSize = 0;
            this.btnGrid.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrid.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrid.Image = global::AgOpenGPS.Properties.Resources.GridRotate;
            this.btnGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGrid.Location = new System.Drawing.Point(94, 280);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(80, 83);
            this.btnGrid.TabIndex = 567;
            this.btnGrid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrid.UseVisualStyleBackColor = false;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // btnTiltDn
            // 
            this.btnTiltDn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTiltDn.BackColor = System.Drawing.Color.Transparent;
            this.btnTiltDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTiltDn.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTiltDn.FlatAppearance.BorderSize = 0;
            this.btnTiltDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiltDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiltDn.Image = global::AgOpenGPS.Properties.Resources.TiltDown;
            this.btnTiltDn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTiltDn.Location = new System.Drawing.Point(16, 18);
            this.btnTiltDn.Name = "btnTiltDn";
            this.btnTiltDn.Size = new System.Drawing.Size(57, 55);
            this.btnTiltDn.TabIndex = 543;
            this.btnTiltDn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTiltDn.UseVisualStyleBackColor = false;
            this.btnTiltDn.Click += new System.EventHandler(this.btnTiltDn_Click);
            // 
            // btnTiltUp
            // 
            this.btnTiltUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTiltUp.BackColor = System.Drawing.Color.Transparent;
            this.btnTiltUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTiltUp.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTiltUp.FlatAppearance.BorderSize = 0;
            this.btnTiltUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiltUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiltUp.Image = global::AgOpenGPS.Properties.Resources.TiltUp;
            this.btnTiltUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTiltUp.Location = new System.Drawing.Point(105, 18);
            this.btnTiltUp.Name = "btnTiltUp";
            this.btnTiltUp.Size = new System.Drawing.Size(57, 55);
            this.btnTiltUp.TabIndex = 544;
            this.btnTiltUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTiltUp.UseVisualStyleBackColor = false;
            this.btnTiltUp.Click += new System.EventHandler(this.btnTiltUp_Click);
            // 
            // btnBrightnessDn
            // 
            this.btnBrightnessDn.BackColor = System.Drawing.Color.Transparent;
            this.btnBrightnessDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrightnessDn.FlatAppearance.BorderSize = 0;
            this.btnBrightnessDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrightnessDn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrightnessDn.Image = global::AgOpenGPS.Properties.Resources.BrightnessDn;
            this.btnBrightnessDn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrightnessDn.Location = new System.Drawing.Point(3, 371);
            this.btnBrightnessDn.Name = "btnBrightnessDn";
            this.btnBrightnessDn.Size = new System.Drawing.Size(83, 75);
            this.btnBrightnessDn.TabIndex = 474;
            this.btnBrightnessDn.Text = "20%";
            this.btnBrightnessDn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrightnessDn.UseVisualStyleBackColor = false;
            this.btnBrightnessDn.Click += new System.EventHandler(this.btnBrightnessDn_Click);
            // 
            // btnBrightnessUp
            // 
            this.btnBrightnessUp.BackColor = System.Drawing.Color.Transparent;
            this.btnBrightnessUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrightnessUp.FlatAppearance.BorderSize = 0;
            this.btnBrightnessUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrightnessUp.Image = global::AgOpenGPS.Properties.Resources.BrightnessUp;
            this.btnBrightnessUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrightnessUp.Location = new System.Drawing.Point(92, 371);
            this.btnBrightnessUp.Name = "btnBrightnessUp";
            this.btnBrightnessUp.Size = new System.Drawing.Size(84, 75);
            this.btnBrightnessUp.TabIndex = 473;
            this.btnBrightnessUp.UseVisualStyleBackColor = false;
            this.btnBrightnessUp.Click += new System.EventHandler(this.btnBrightnessUp_Click);
            // 
            // btnDayNightMode
            // 
            this.btnDayNightMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDayNightMode.BackColor = System.Drawing.Color.Transparent;
            this.btnDayNightMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDayNightMode.FlatAppearance.BorderSize = 0;
            this.btnDayNightMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDayNightMode.Image = global::AgOpenGPS.Properties.Resources.WindowNightMode;
            this.btnDayNightMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDayNightMode.Location = new System.Drawing.Point(16, 294);
            this.btnDayNightMode.Name = "btnDayNightMode";
            this.btnDayNightMode.Size = new System.Drawing.Size(57, 55);
            this.btnDayNightMode.TabIndex = 452;
            this.btnDayNightMode.UseVisualStyleBackColor = false;
            this.btnDayNightMode.Click += new System.EventHandler(this.btnDayNightMode_Click);
            // 
            // btnN2D
            // 
            this.btnN2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnN2D.BackColor = System.Drawing.Color.Transparent;
            this.btnN2D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnN2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnN2D.FlatAppearance.BorderSize = 0;
            this.btnN2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnN2D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN2D.Image = global::AgOpenGPS.Properties.Resources.CameraNorth2D;
            this.btnN2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnN2D.Location = new System.Drawing.Point(16, 202);
            this.btnN2D.Name = "btnN2D";
            this.btnN2D.Size = new System.Drawing.Size(57, 55);
            this.btnN2D.TabIndex = 470;
            this.btnN2D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnN2D.UseVisualStyleBackColor = false;
            this.btnN2D.Click += new System.EventHandler(this.btnN2D_Click);
            // 
            // btn3D
            // 
            this.btn3D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3D.BackColor = System.Drawing.Color.Transparent;
            this.btn3D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn3D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn3D.FlatAppearance.BorderSize = 0;
            this.btn3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3D.Image = global::AgOpenGPS.Properties.Resources.Camera3D64;
            this.btn3D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn3D.Location = new System.Drawing.Point(105, 110);
            this.btn3D.Name = "btn3D";
            this.btn3D.Size = new System.Drawing.Size(57, 55);
            this.btn3D.TabIndex = 471;
            this.btn3D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn3D.UseVisualStyleBackColor = false;
            this.btn3D.Click += new System.EventHandler(this.btn3D_Click);
            // 
            // btn2D
            // 
            this.btn2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2D.BackColor = System.Drawing.Color.Transparent;
            this.btn2D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn2D.FlatAppearance.BorderSize = 0;
            this.btn2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2D.Image = global::AgOpenGPS.Properties.Resources.Camera2D64;
            this.btn2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn2D.Location = new System.Drawing.Point(16, 110);
            this.btn2D.Name = "btn2D";
            this.btn2D.Size = new System.Drawing.Size(57, 55);
            this.btn2D.TabIndex = 469;
            this.btn2D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn2D.UseVisualStyleBackColor = false;
            this.btn2D.Click += new System.EventHandler(this.btn2D_Click);
            // 
            // btnZone1
            // 
            this.btnZone1.BackColor = System.Drawing.Color.Silver;
            this.btnZone1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone1.Enabled = false;
            this.btnZone1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone1.Location = new System.Drawing.Point(712, 56);
            this.btnZone1.Name = "btnZone1";
            this.btnZone1.Size = new System.Drawing.Size(59, 25);
            this.btnZone1.TabIndex = 496;
            this.btnZone1.Text = "1";
            this.btnZone1.UseVisualStyleBackColor = false;
            this.btnZone1.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone2
            // 
            this.btnZone2.BackColor = System.Drawing.Color.Silver;
            this.btnZone2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone2.Enabled = false;
            this.btnZone2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone2.Location = new System.Drawing.Point(712, 82);
            this.btnZone2.Name = "btnZone2";
            this.btnZone2.Size = new System.Drawing.Size(59, 25);
            this.btnZone2.TabIndex = 497;
            this.btnZone2.Text = "2";
            this.btnZone2.UseVisualStyleBackColor = false;
            this.btnZone2.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone3
            // 
            this.btnZone3.BackColor = System.Drawing.Color.Silver;
            this.btnZone3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone3.Enabled = false;
            this.btnZone3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone3.Location = new System.Drawing.Point(712, 108);
            this.btnZone3.Name = "btnZone3";
            this.btnZone3.Size = new System.Drawing.Size(59, 25);
            this.btnZone3.TabIndex = 498;
            this.btnZone3.Text = "3";
            this.btnZone3.UseVisualStyleBackColor = false;
            this.btnZone3.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone4
            // 
            this.btnZone4.BackColor = System.Drawing.Color.Silver;
            this.btnZone4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone4.Enabled = false;
            this.btnZone4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone4.Location = new System.Drawing.Point(712, 134);
            this.btnZone4.Name = "btnZone4";
            this.btnZone4.Size = new System.Drawing.Size(59, 25);
            this.btnZone4.TabIndex = 499;
            this.btnZone4.Text = "4";
            this.btnZone4.UseVisualStyleBackColor = false;
            this.btnZone4.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone5
            // 
            this.btnZone5.BackColor = System.Drawing.Color.Silver;
            this.btnZone5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone5.Enabled = false;
            this.btnZone5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone5.Location = new System.Drawing.Point(712, 160);
            this.btnZone5.Name = "btnZone5";
            this.btnZone5.Size = new System.Drawing.Size(59, 25);
            this.btnZone5.TabIndex = 500;
            this.btnZone5.Text = "5";
            this.btnZone5.UseVisualStyleBackColor = false;
            this.btnZone5.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone6
            // 
            this.btnZone6.BackColor = System.Drawing.Color.Silver;
            this.btnZone6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone6.Enabled = false;
            this.btnZone6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone6.Location = new System.Drawing.Point(712, 186);
            this.btnZone6.Name = "btnZone6";
            this.btnZone6.Size = new System.Drawing.Size(59, 25);
            this.btnZone6.TabIndex = 501;
            this.btnZone6.Text = "6";
            this.btnZone6.UseVisualStyleBackColor = false;
            this.btnZone6.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone7
            // 
            this.btnZone7.BackColor = System.Drawing.Color.Silver;
            this.btnZone7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone7.Enabled = false;
            this.btnZone7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone7.Location = new System.Drawing.Point(712, 212);
            this.btnZone7.Name = "btnZone7";
            this.btnZone7.Size = new System.Drawing.Size(59, 25);
            this.btnZone7.TabIndex = 503;
            this.btnZone7.Text = "7";
            this.btnZone7.UseVisualStyleBackColor = false;
            this.btnZone7.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // btnZone8
            // 
            this.btnZone8.BackColor = System.Drawing.Color.Silver;
            this.btnZone8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone8.Enabled = false;
            this.btnZone8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone8.Location = new System.Drawing.Point(712, 238);
            this.btnZone8.Name = "btnZone8";
            this.btnZone8.Size = new System.Drawing.Size(59, 25);
            this.btnZone8.TabIndex = 504;
            this.btnZone8.Text = "8";
            this.btnZone8.UseVisualStyleBackColor = false;
            this.btnZone8.Click += new System.EventHandler(this.btnZoneX_Click);
            // 
            // lblGuidanceLine
            // 
            this.lblGuidanceLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGuidanceLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuidanceLine.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidanceLine.Location = new System.Drawing.Point(211, 66);
            this.lblGuidanceLine.Name = "lblGuidanceLine";
            this.lblGuidanceLine.Size = new System.Drawing.Size(583, 83);
            this.lblGuidanceLine.TabIndex = 538;
            this.lblGuidanceLine.Text = "This is the line description";
            this.lblGuidanceLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGuidanceLine.Visible = false;
            // 
            // flp1
            // 
            this.flp1.AutoSize = true;
            this.flp1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp1.Location = new System.Drawing.Point(222, 484);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(0, 0);
            this.flp1.TabIndex = 539;
            // 
            // contextMenuStrip_btnNudge
            // 
            this.contextMenuStrip_btnNudge.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_btnNudge.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_btnNudge.Opening += new System.ComponentModel.CancelEventHandler(this.btnRefNudge_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.AutoSize = true;
            this.panelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(912, 714);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(0, 0);
            this.panelBottom.TabIndex = 540;
            // 
            // contextMenuStrip_headlane
            // 
            this.contextMenuStrip_headlane.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_headlane.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_headlane.Opening += new System.ComponentModel.CancelEventHandler(this.headlandToolStripMenuItem_Click);
            // 
            // contextMenuStrip_tram
            // 
            this.contextMenuStrip_tram.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_tram.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_tram.Opening += new System.ComponentModel.CancelEventHandler(this.tramLinesMenuField_Click);
            // 
            // contextMenuStrip_contour
            // 
            this.contextMenuStrip_contour.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_contour.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_contour.Opening += new System.ComponentModel.CancelEventHandler(this.deleteContourPathsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(81, 60);
            this.toolStripMenuItem1.Text = "      ";
            // 
            // contextMenuStrip_btnBuildTracks
            // 
            this.contextMenuStrip_btnBuildTracks.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_btnBuildTracks.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_btnBuildTracks.Opening += new System.ComponentModel.CancelEventHandler(this.btnTracksOff_Click);
            // 
            // contextMenuStrip_lblhz
            // 
            this.contextMenuStrip_lblhz.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_lblhz.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_lblhz.Opening += new System.ComponentModel.CancelEventHandler(this.lblHz_Click);
            // 
            // contextMenuStrip_SnapCenterMain
            // 
            this.contextMenuStrip_SnapCenterMain.Name = "contextMenuStrip_headlane";
            this.contextMenuStrip_SnapCenterMain.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_SnapCenterMain.Opening += new System.ComponentModel.CancelEventHandler(this.btnSnapToPivot_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(448, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(19, 30);
            this.label13.TabIndex = 566;
            this.label13.Text = "|";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label13.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(535, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(18, 30);
            this.label12.TabIndex = 565;
            this.label12.Text = "|";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label12.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // panel_top
            // 
            this.panel_top.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_top.BackColor = System.Drawing.Color.Transparent;
            this.panel_top.ColumnCount = 4;
            this.panel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.panel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.panel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.panel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.panel_top.Controls.Add(this.lblSpeed, 1, 0);
            this.panel_top.Controls.Add(this.lblTotalAppliedArea, 0, 0);
            this.panel_top.Controls.Add(this.label4, 0, 1);
            this.panel_top.Controls.Add(this.lblWorkRemaining, 2, 0);
            this.panel_top.Controls.Add(this.label5, 2, 1);
            this.panel_top.Controls.Add(this.lblTimeRemaining, 3, 0);
            this.panel_top.Location = new System.Drawing.Point(278, 1);
            this.panel_top.Name = "panel_top";
            this.panel_top.RowCount = 2;
            this.panel_top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.28571F));
            this.panel_top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.71429F));
            this.panel_top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel_top.Size = new System.Drawing.Size(444, 42);
            this.panel_top.TabIndex = 560;
            this.panel_top.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 19F, System.Drawing.FontStyle.Bold);
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(184, 0);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(34, 0, 0, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel_top.SetRowSpan(this.lblSpeed, 2);
            this.lblSpeed.Size = new System.Drawing.Size(73, 40);
            this.lblSpeed.TabIndex = 454;
            this.lblSpeed.Text = "38,8";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpeed.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // lblTotalAppliedArea
            // 
            this.lblTotalAppliedArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalAppliedArea.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAppliedArea.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAppliedArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalAppliedArea.Location = new System.Drawing.Point(25, 2);
            this.lblTotalAppliedArea.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalAppliedArea.Name = "lblTotalAppliedArea";
            this.lblTotalAppliedArea.Size = new System.Drawing.Size(99, 17);
            this.lblTotalAppliedArea.TabIndex = 453;
            this.lblTotalAppliedArea.Text = "22.6";
            this.lblTotalAppliedArea.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalAppliedArea.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(25, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 454;
            this.label4.Text = " Travaillé";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // lblWorkRemaining
            // 
            this.lblWorkRemaining.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblWorkRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkRemaining.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblWorkRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWorkRemaining.Location = new System.Drawing.Point(263, 2);
            this.lblWorkRemaining.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkRemaining.Name = "lblWorkRemaining";
            this.lblWorkRemaining.Size = new System.Drawing.Size(100, 17);
            this.lblWorkRemaining.TabIndex = 314;
            this.lblWorkRemaining.Text = "22,06 ha";
            this.lblWorkRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWorkRemaining.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.panel_top.SetColumnSpan(this.label5, 2);
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(301, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 455;
            this.label5.Text = "Restant ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimeRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTimeRemaining.Location = new System.Drawing.Point(363, 2);
            this.lblTimeRemaining.Margin = new System.Windows.Forms.Padding(0);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(81, 17);
            this.lblTimeRemaining.TabIndex = 468;
            this.lblTimeRemaining.Text = "22:06 H";
            this.lblTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimeRemaining.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // round_table12
            // 
            this.round_table12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.round_table12.AutoSize = true;
            this.round_table12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.round_table12.ColumnCount = 4;
            this.round_table12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.round_table12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.round_table12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.round_table12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.round_table12.Controls.Add(this.btnChargeStatus, 1, 1);
            this.round_table12.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.round_table12.Controls.Add(this.BatLevel, 0, 1);
            this.round_table12.Controls.Add(this.lblDateTime, 0, 0);
            this.round_table12.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.round_table12.Controls.Add(this.lblHz, 2, 0);
            this.round_table12.Controls.Add(this.tableLayoutPanel1, 3, 1);
            this.round_table12.Location = new System.Drawing.Point(675, 654);
            this.round_table12.Name = "round_table12";
            this.round_table12.RowCount = 1;
            this.round_table12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.round_table12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.round_table12.Size = new System.Drawing.Size(370, 63);
            this.round_table12.TabIndex = 559;
            // 
            // btnChargeStatus
            // 
            this.btnChargeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChargeStatus.BackColor = System.Drawing.Color.Silver;
            this.btnChargeStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChargeStatus.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChargeStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChargeStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChargeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChargeStatus.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChargeStatus.Image = global::AgOpenGPS.Properties.Resources.ChargeIndicator;
            this.btnChargeStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChargeStatus.Location = new System.Drawing.Point(123, 45);
            this.btnChargeStatus.Name = "btnChargeStatus";
            this.btnChargeStatus.Size = new System.Drawing.Size(42, 15);
            this.btnChargeStatus.TabIndex = 538;
            this.btnChargeStatus.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.72414F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.17241F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lbludpWatchCounts, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblAge, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblRed, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(174, 45);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(145, 15);
            this.tableLayoutPanel3.TabIndex = 524;
            // 
            // lbludpWatchCounts
            // 
            this.lbludpWatchCounts.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbludpWatchCounts.AutoSize = true;
            this.lbludpWatchCounts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbludpWatchCounts.Location = new System.Drawing.Point(30, 0);
            this.lbludpWatchCounts.Name = "lbludpWatchCounts";
            this.lbludpWatchCounts.Size = new System.Drawing.Size(15, 14);
            this.lbludpWatchCounts.TabIndex = 254;
            this.lbludpWatchCounts.Text = "0";
            // 
            // lblAge
            // 
            this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAge.Location = new System.Drawing.Point(75, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(15, 14);
            this.lblAge.TabIndex = 493;
            this.lblAge.Text = "0";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRed
            // 
            this.lblRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRed.AutoSize = true;
            this.lblRed.BackColor = System.Drawing.Color.Transparent;
            this.lblRed.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed.Location = new System.Drawing.Point(96, 4);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(28, 11);
            this.lblRed.TabIndex = 543;
            this.lblRed.Text = "100%";
            this.lblRed.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRed.Visible = false;
            // 
            // BatLevel
            // 
            this.BatLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BatLevel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatLevel.Location = new System.Drawing.Point(33, 43);
            this.BatLevel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BatLevel.Name = "BatLevel";
            this.BatLevel.Size = new System.Drawing.Size(84, 18);
            this.BatLevel.TabIndex = 512;
            this.BatLevel.Text = "100%";
            this.BatLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.round_table12.SetColumnSpan(this.lblDateTime, 2);
            this.lblDateTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDateTime.Location = new System.Drawing.Point(0, 3);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(165, 36);
            this.lblDateTime.TabIndex = 252;
            this.lblDateTime.Text = "21:08\r\nmer. 26 may 2021";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(325, 39);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.94118F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.05882F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel2.TabIndex = 512;
            // 
            // lblHz
            // 
            this.lblHz.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHz.BackColor = System.Drawing.Color.Transparent;
            this.lblHz.ContextMenuStrip = this.contextMenuStrip_lblhz;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblHz.Image = global::AgOpenGPS.Properties.Resources.GPSQuality;
            this.lblHz.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblHz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHz.Location = new System.Drawing.Point(168, 2);
            this.lblHz.Margin = new System.Windows.Forms.Padding(0);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(154, 38);
            this.lblHz.TabIndex = 253;
            this.lblHz.Text = "5 Hz 32\r\nGPS Single";
            this.lblHz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHz.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(366, 42);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 254;
            // 
            // round_table11
            // 
            this.round_table11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.round_table11.ColumnCount = 5;
            this.round_table11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.84032F));
            this.round_table11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.15434F));
            this.round_table11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.24528F));
            this.round_table11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.90566F));
            this.round_table11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.round_table11.Controls.Add(this.btnMaximizeMainForm, 2, 0);
            this.round_table11.Controls.Add(this.btnMinimizeMainForm, 1, 0);
            this.round_table11.Controls.Add(this.btnShutdown, 3, 0);
            this.round_table11.Location = new System.Drawing.Point(798, 7);
            this.round_table11.Name = "round_table11";
            this.round_table11.RowCount = 1;
            this.round_table11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table11.Size = new System.Drawing.Size(349, 58);
            this.round_table11.TabIndex = 558;
            // 
            // btnMaximizeMainForm
            // 
            this.btnMaximizeMainForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMaximizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMaximize;
            this.btnMaximizeMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaximizeMainForm.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMaximizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMaximizeMainForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizeMainForm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizeMainForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMaximizeMainForm.Location = new System.Drawing.Point(71, 3);
            this.btnMaximizeMainForm.Name = "btnMaximizeMainForm";
            this.btnMaximizeMainForm.Size = new System.Drawing.Size(50, 52);
            this.btnMaximizeMainForm.TabIndex = 482;
            this.btnMaximizeMainForm.UseVisualStyleBackColor = false;
            this.btnMaximizeMainForm.Click += new System.EventHandler(this.btnMaximizeMainForm_Click);
            // 
            // btnMinimizeMainForm
            // 
            this.btnMinimizeMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMinimize;
            this.btnMinimizeMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMinimizeMainForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeMainForm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeMainForm.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimizeMainForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinimizeMainForm.Location = new System.Drawing.Point(26, 3);
            this.btnMinimizeMainForm.Name = "btnMinimizeMainForm";
            this.btnMinimizeMainForm.Size = new System.Drawing.Size(39, 52);
            this.btnMinimizeMainForm.TabIndex = 481;
            this.btnMinimizeMainForm.UseVisualStyleBackColor = false;
            this.btnMinimizeMainForm.Click += new System.EventHandler(this.btnMinimizeMainForm_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShutdown.BackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowClose;
            this.btnShutdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShutdown.FlatAppearance.BorderSize = 0;
            this.btnShutdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutdown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShutdown.Location = new System.Drawing.Point(135, 2);
            this.btnShutdown.Margin = new System.Windows.Forms.Padding(0);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(44, 54);
            this.btnShutdown.TabIndex = 447;
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // round_Menu1
            // 
            this.round_Menu1.AutoSize = false;
            this.round_Menu1.BackColor = System.Drawing.Color.Transparent;
            this.round_Menu1.Dock = System.Windows.Forms.DockStyle.None;
            this.round_Menu1.Font = new System.Drawing.Font("Tahoma", 22F);
            this.round_Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dzzdzToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.btnNavigationSettings,
            this.Connected_services});
            this.round_Menu1.Location = new System.Drawing.Point(-70, 7);
            this.round_Menu1.Name = "round_Menu1";
            this.round_Menu1.Padding = new System.Windows.Forms.Padding(0);
            this.round_Menu1.Size = new System.Drawing.Size(263, 58);
            this.round_Menu1.TabIndex = 551;
            this.round_Menu1.Text = "round_Menu1";
            this.round_Menu1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.round_Menu1_ItemClicked);
            // 
            // dzzdzToolStripMenuItem
            // 
            this.dzzdzToolStripMenuItem.Name = "dzzdzToolStripMenuItem";
            this.dzzdzToolStripMenuItem.Size = new System.Drawing.Size(72, 58);
            this.dzzdzToolStripMenuItem.Text = "     ";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.menustripLanguage,
            this.toolStripSeparator11,
            this.simulatorOnToolStripMenuItem,
            this.enterSimCoordsToolStripMenuItem,
            this.toolStripSeparator10,
            this.kioskModeToolStrip,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.resetALLToolStripMenuItem,
            this.hotKeysToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.miseÀJourToolStripMenuItem,
            this.helpMenuItem,
            this.nozzleAppToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.fileMenu;
            this.fileToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 58);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(379, 6);
            // 
            // menustripLanguage
            // 
            this.menustripLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageDanish,
            this.menuLanguageDeutsch,
            this.menuLanguageEnglish,
            this.menuLanguageSpanish,
            this.menuLanguageFrench,
            this.menuLanguageItalian,
            this.menuLanguageLatvian,
            this.menuLanguageLithuanian,
            this.menuLanguageHungarian,
            this.menuLanguageNorsk,
            this.menuLanguageDutch,
            this.menuLanguagePortugese,
            this.menuLanguagePolish,
            this.menuLanguageRussian,
            this.menuLanguageFinnish,
            this.menuLanguageSerbie,
            this.menuLanguageSlovak,
            this.menuLanguageUkranian,
            this.menuLanguageChinese,
            this.menuLanguageTurkish,
            this.menuLanguageTest});
            this.menustripLanguage.Name = "menustripLanguage";
            this.menustripLanguage.Size = new System.Drawing.Size(382, 50);
            this.menustripLanguage.Text = "Language";
            // 
            // menuLanguageDanish
            // 
            this.menuLanguageDanish.Name = "menuLanguageDanish";
            this.menuLanguageDanish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageDanish.Text = "Dansk (Denmark)";
            this.menuLanguageDanish.Click += new System.EventHandler(this.menuLanguageDanish_Click);
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            this.menuLanguageDeutsch.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageDeutsch.Text = "Deutsch (Germany)";
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            this.menuLanguageEnglish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageEnglish.Text = "English (Canada)";
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
            // 
            // menuLanguageSpanish
            // 
            this.menuLanguageSpanish.CheckOnClick = true;
            this.menuLanguageSpanish.Name = "menuLanguageSpanish";
            this.menuLanguageSpanish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageSpanish.Text = "Español (Spanish)";
            this.menuLanguageSpanish.Click += new System.EventHandler(this.menuLanguageSpanish_Click);
            // 
            // menuLanguageFrench
            // 
            this.menuLanguageFrench.CheckOnClick = true;
            this.menuLanguageFrench.Name = "menuLanguageFrench";
            this.menuLanguageFrench.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageFrench.Text = "Français (France)";
            this.menuLanguageFrench.Click += new System.EventHandler(this.menuLanguageFrench_Click);
            // 
            // menuLanguageItalian
            // 
            this.menuLanguageItalian.Name = "menuLanguageItalian";
            this.menuLanguageItalian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageItalian.Text = "Italiano (Italy)";
            this.menuLanguageItalian.Click += new System.EventHandler(this.menuLanguageItalian_Click);
            // 
            // menuLanguageLatvian
            // 
            this.menuLanguageLatvian.Name = "menuLanguageLatvian";
            this.menuLanguageLatvian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageLatvian.Text = "Latviski (Latvia)";
            this.menuLanguageLatvian.Click += new System.EventHandler(this.menuLanguageLatvian_Click);
            // 
            // menuLanguageLithuanian
            // 
            this.menuLanguageLithuanian.Name = "menuLanguageLithuanian";
            this.menuLanguageLithuanian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageLithuanian.Text = "Lietuvių (Lithuania)";
            this.menuLanguageLithuanian.Click += new System.EventHandler(this.menuLanguageLithuanian_Click);
            // 
            // menuLanguageHungarian
            // 
            this.menuLanguageHungarian.Name = "menuLanguageHungarian";
            this.menuLanguageHungarian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageHungarian.Text = "Magyar (Hungary)";
            this.menuLanguageHungarian.Click += new System.EventHandler(this.menuLanguageHungarian_Click);
            // 
            // menuLanguageNorsk
            // 
            this.menuLanguageNorsk.Name = "menuLanguageNorsk";
            this.menuLanguageNorsk.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageNorsk.Text = "Norsk (Norway)";
            this.menuLanguageNorsk.Click += new System.EventHandler(this.menuLanguageNorsk_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            this.menuLanguageDutch.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageDutch.Text = "Nederlands (Holland)";
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguagePortugese
            // 
            this.menuLanguagePortugese.Name = "menuLanguagePortugese";
            this.menuLanguagePortugese.Size = new System.Drawing.Size(485, 50);
            this.menuLanguagePortugese.Text = "Português (Portuguese)";
            this.menuLanguagePortugese.Click += new System.EventHandler(this.menuLanguagesPortugese_Click);
            // 
            // menuLanguagePolish
            // 
            this.menuLanguagePolish.Name = "menuLanguagePolish";
            this.menuLanguagePolish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguagePolish.Text = "Polski (Poland)";
            this.menuLanguagePolish.Click += new System.EventHandler(this.menuLanguagesPolski_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            this.menuLanguageRussian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageRussian.Text = "русский (Russia)";
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageFinnish
            // 
            this.menuLanguageFinnish.Name = "menuLanguageFinnish";
            this.menuLanguageFinnish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageFinnish.Text = "Suomalainen (Finland)";
            this.menuLanguageFinnish.Click += new System.EventHandler(this.menuLanguageFinnish_Click);
            // 
            // menuLanguageSerbie
            // 
            this.menuLanguageSerbie.Name = "menuLanguageSerbie";
            this.menuLanguageSerbie.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageSerbie.Text = "Serbia (Servië)";
            this.menuLanguageSerbie.Click += new System.EventHandler(this.menuLanguageSerbie_Click);
            // 
            // menuLanguageSlovak
            // 
            this.menuLanguageSlovak.Name = "menuLanguageSlovak";
            this.menuLanguageSlovak.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageSlovak.Text = "Slovenčina (Slovakia)";
            this.menuLanguageSlovak.Click += new System.EventHandler(this.menuLanguageSlovak_Click);
            // 
            // menuLanguageUkranian
            // 
            this.menuLanguageUkranian.Name = "menuLanguageUkranian";
            this.menuLanguageUkranian.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageUkranian.Text = "Yкраїнська (Ukraine)";
            this.menuLanguageUkranian.Click += new System.EventHandler(this.menuLanguageUkranian_Click);
            // 
            // menuLanguageChinese
            // 
            this.menuLanguageChinese.Name = "menuLanguageChinese";
            this.menuLanguageChinese.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageChinese.Text = "中国人 (Chinese)";
            this.menuLanguageChinese.Click += new System.EventHandler(this.menuLanguageChinese_Click);
            // 
            // menuLanguageTurkish
            // 
            this.menuLanguageTurkish.Name = "menuLanguageTurkish";
            this.menuLanguageTurkish.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageTurkish.Text = "Türkçe (Turkey)";
            this.menuLanguageTurkish.Click += new System.EventHandler(this.menuLanguageTurkish_Click);
            // 
            // menuLanguageTest
            // 
            this.menuLanguageTest.Name = "menuLanguageTest";
            this.menuLanguageTest.Size = new System.Drawing.Size(485, 50);
            this.menuLanguageTest.Text = "Test";
            this.menuLanguageTest.Click += new System.EventHandler(this.menuLanguageTest_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(379, 6);
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            this.simulatorOnToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.simulatorOnToolStripMenuItem.Text = "Simulator On";
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // enterSimCoordsToolStripMenuItem
            // 
            this.enterSimCoordsToolStripMenuItem.Name = "enterSimCoordsToolStripMenuItem";
            this.enterSimCoordsToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.enterSimCoordsToolStripMenuItem.Text = "Enter Sim Coords";
            this.enterSimCoordsToolStripMenuItem.Click += new System.EventHandler(this.enterSimCoordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(379, 6);
            // 
            // kioskModeToolStrip
            // 
            this.kioskModeToolStrip.Name = "kioskModeToolStrip";
            this.kioskModeToolStrip.Size = new System.Drawing.Size(382, 50);
            this.kioskModeToolStrip.Text = "Kiosk Mode";
            this.kioskModeToolStrip.Click += new System.EventHandler(this.kioskModeToolStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(379, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(379, 6);
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetEverythingToolStripMenuItem});
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            this.resetALLToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.resetALLToolStripMenuItem.Text = "Reset All";
            // 
            // resetEverythingToolStripMenuItem
            // 
            this.resetEverythingToolStripMenuItem.Name = "resetEverythingToolStripMenuItem";
            this.resetEverythingToolStripMenuItem.Size = new System.Drawing.Size(372, 50);
            this.resetEverythingToolStripMenuItem.Text = "Reset To Default";
            this.resetEverythingToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click);
            // 
            // hotKeysToolStripMenuItem
            // 
            this.hotKeysToolStripMenuItem.Name = "hotKeysToolStripMenuItem";
            this.hotKeysToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.hotKeysToolStripMenuItem.Text = "HotKeys";
            this.hotKeysToolStripMenuItem.Click += new System.EventHandler(this.hotKeysToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // miseÀJourToolStripMenuItem
            // 
            this.miseÀJourToolStripMenuItem.Name = "miseÀJourToolStripMenuItem";
            this.miseÀJourToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.miseÀJourToolStripMenuItem.Text = "Mise à jour";
            this.miseÀJourToolStripMenuItem.Click += new System.EventHandler(this.miseÀJourToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(382, 50);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // nozzleAppToolStripMenuItem
            // 
            this.nozzleAppToolStripMenuItem.Name = "nozzleAppToolStripMenuItem";
            this.nozzleAppToolStripMenuItem.Size = new System.Drawing.Size(382, 50);
            this.nozzleAppToolStripMenuItem.Text = "Nozzle App";
            this.nozzleAppToolStripMenuItem.Visible = false;
            // 
            // btnNavigationSettings
            // 
            this.btnNavigationSettings.AutoSize = false;
            this.btnNavigationSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavigationSettings.Image = global::AgOpenGPS.Properties.Resources.NavigationSettings;
            this.btnNavigationSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNavigationSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavigationSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavigationSettings.Name = "btnNavigationSettings";
            this.btnNavigationSettings.ShowDropDownArrow = false;
            this.btnNavigationSettings.Size = new System.Drawing.Size(66, 66);
            this.btnNavigationSettings.Text = "toolStripDropDownButton4";
            this.btnNavigationSettings.Click += new System.EventHandler(this.btnNavigationSettings_Click);
            // 
            // Connected_services
            // 
            this.Connected_services.AutoSize = false;
            this.Connected_services.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Connected_services.Image = global::AgOpenGPS.Properties.Resources.connexions;
            this.Connected_services.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Connected_services.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Connected_services.Margin = new System.Windows.Forms.Padding(0);
            this.Connected_services.Name = "Connected_services";
            this.Connected_services.ShowDropDownArrow = false;
            this.Connected_services.Size = new System.Drawing.Size(66, 66);
            this.Connected_services.Text = "toolStripDropDownButton4";
            this.Connected_services.Click += new System.EventHandler(this.Connected_services_Click);
            // 
            // round_table6
            // 
            this.round_table6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round_table6.ColumnCount = 2;
            this.round_table6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table6.Controls.Add(this.btnFlag, 0, 0);
            this.round_table6.Location = new System.Drawing.Point(920, 521);
            this.round_table6.Name = "round_table6";
            this.round_table6.RowCount = 1;
            this.round_table6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table6.Size = new System.Drawing.Size(157, 65);
            this.round_table6.TabIndex = 557;
            // 
            // btnFlag
            // 
            this.btnFlag.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFlag.BackColor = System.Drawing.Color.Transparent;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlag.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnFlag.FlatAppearance.BorderSize = 0;
            this.btnFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlag.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlag.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.btnFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlag.Location = new System.Drawing.Point(8, 4);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(67, 56);
            this.btnFlag.TabIndex = 121;
            this.btnFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // round_table4
            // 
            this.round_table4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round_table4.ColumnCount = 3;
            this.round_table4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.55245F));
            this.round_table4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.44755F));
            this.round_table4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.round_table4.Controls.Add(this.btnABDraw, 0, 0);
            this.round_table4.Controls.Add(this.btnNudge, 1, 0);
            this.round_table4.Location = new System.Drawing.Point(852, 310);
            this.round_table4.Name = "round_table4";
            this.round_table4.RowCount = 1;
            this.round_table4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table4.Size = new System.Drawing.Size(181, 65);
            this.round_table4.TabIndex = 556;
            // 
            // btnABDraw
            // 
            this.btnABDraw.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnABDraw.BackColor = System.Drawing.Color.Transparent;
            this.btnABDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnABDraw.Enabled = false;
            this.btnABDraw.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnABDraw.FlatAppearance.BorderSize = 0;
            this.btnABDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABDraw.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnABDraw.Image = global::AgOpenGPS.Properties.Resources.ABDraw;
            this.btnABDraw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABDraw.Location = new System.Drawing.Point(8, 3);
            this.btnABDraw.Name = "btnABDraw";
            this.btnABDraw.Size = new System.Drawing.Size(57, 59);
            this.btnABDraw.TabIndex = 250;
            this.btnABDraw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnABDraw.UseVisualStyleBackColor = false;
            this.btnABDraw.Click += new System.EventHandler(this.btnABDraw_Click);
            // 
            // btnNudge
            // 
            this.btnNudge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNudge.AutoSize = true;
            this.btnNudge.BackColor = System.Drawing.Color.Transparent;
            this.btnNudge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNudge.ContextMenuStrip = this.contextMenuStrip_btnNudge;
            this.btnNudge.FlatAppearance.BorderSize = 0;
            this.btnNudge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNudge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNudge.Image = global::AgOpenGPS.Properties.Resources.ABSnapNudgeMenu;
            this.btnNudge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNudge.Location = new System.Drawing.Point(71, 3);
            this.btnNudge.Name = "btnNudge";
            this.btnNudge.Size = new System.Drawing.Size(69, 59);
            this.btnNudge.TabIndex = 489;
            this.btnNudge.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNudge.UseVisualStyleBackColor = false;
            this.btnNudge.Click += new System.EventHandler(this.btnNudge_Click);
            // 
            // round_table3
            // 
            this.round_table3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round_table3.ColumnCount = 3;
            this.round_table3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.7027F));
            this.round_table3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.2973F));
            this.round_table3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.round_table3.Controls.Add(this.btnHeadlandOnOff, 0, 0);
            this.round_table3.Controls.Add(this.btnContour, 1, 0);
            this.round_table3.Location = new System.Drawing.Point(852, 380);
            this.round_table3.Name = "round_table3";
            this.round_table3.RowCount = 1;
            this.round_table3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table3.Size = new System.Drawing.Size(189, 65);
            this.round_table3.TabIndex = 555;
            // 
            // btnHeadlandOnOff
            // 
            this.btnHeadlandOnOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHeadlandOnOff.BackColor = System.Drawing.Color.Transparent;
            this.btnHeadlandOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHeadlandOnOff.ContextMenuStrip = this.contextMenuStrip_headlane;
            this.btnHeadlandOnOff.FlatAppearance.BorderSize = 0;
            this.btnHeadlandOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeadlandOnOff.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlandOnOff.Image = global::AgOpenGPS.Properties.Resources.HeadlandOff;
            this.btnHeadlandOnOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHeadlandOnOff.Location = new System.Drawing.Point(7, 4);
            this.btnHeadlandOnOff.Name = "btnHeadlandOnOff";
            this.btnHeadlandOnOff.Size = new System.Drawing.Size(64, 56);
            this.btnHeadlandOnOff.TabIndex = 447;
            this.btnHeadlandOnOff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHeadlandOnOff.UseVisualStyleBackColor = false;
            this.btnHeadlandOnOff.Click += new System.EventHandler(this.btnHeadlandOnOff_Click);
            // 
            // btnContour
            // 
            this.btnContour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnContour.BackColor = System.Drawing.Color.Transparent;
            this.btnContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContour.ContextMenuStrip = this.contextMenuStrip_contour;
            this.btnContour.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnContour.FlatAppearance.BorderSize = 0;
            this.btnContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContour.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            this.btnContour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContour.Location = new System.Drawing.Point(81, 3);
            this.btnContour.Name = "btnContour";
            this.btnContour.Size = new System.Drawing.Size(64, 59);
            this.btnContour.TabIndex = 105;
            this.btnContour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // round_table2
            // 
            this.round_table2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round_table2.ColumnCount = 2;
            this.round_table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table2.Controls.Add(this.btnTramDisplayMode, 0, 0);
            this.round_table2.Location = new System.Drawing.Point(920, 450);
            this.round_table2.Name = "round_table2";
            this.round_table2.RowCount = 1;
            this.round_table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.round_table2.Size = new System.Drawing.Size(170, 65);
            this.round_table2.TabIndex = 554;
            // 
            // btnTramDisplayMode
            // 
            this.btnTramDisplayMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTramDisplayMode.BackColor = System.Drawing.Color.Transparent;
            this.btnTramDisplayMode.ContextMenuStrip = this.contextMenuStrip_tram;
            this.btnTramDisplayMode.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTramDisplayMode.FlatAppearance.BorderSize = 0;
            this.btnTramDisplayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTramDisplayMode.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTramDisplayMode.Image = global::AgOpenGPS.Properties.Resources.TramOff;
            this.btnTramDisplayMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTramDisplayMode.Location = new System.Drawing.Point(6, 4);
            this.btnTramDisplayMode.Name = "btnTramDisplayMode";
            this.btnTramDisplayMode.Size = new System.Drawing.Size(73, 56);
            this.btnTramDisplayMode.TabIndex = 480;
            this.btnTramDisplayMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTramDisplayMode.UseVisualStyleBackColor = false;
            this.btnTramDisplayMode.Click += new System.EventHandler(this.btnTramDisplayMode_Click);
            // 
            // round_table1
            // 
            this.round_table1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round_table1.ColumnCount = 4;
            this.round_table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.62016F));
            this.round_table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.96899F));
            this.round_table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.96899F));
            this.round_table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.round_table1.Controls.Add(this.btnBuildTracks, 0, 0);
            this.round_table1.Controls.Add(this.btnAutoTrack, 1, 0);
            this.round_table1.Controls.Add(this.btnCycleLines, 2, 0);
            this.round_table1.Location = new System.Drawing.Point(783, 240);
            this.round_table1.Name = "round_table1";
            this.round_table1.RowCount = 1;
            this.round_table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table1.Size = new System.Drawing.Size(258, 65);
            this.round_table1.TabIndex = 553;
            // 
            // btnBuildTracks
            // 
            this.btnBuildTracks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuildTracks.BackColor = System.Drawing.Color.Transparent;
            this.btnBuildTracks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuildTracks.ContextMenuStrip = this.contextMenuStrip_btnBuildTracks;
            this.btnBuildTracks.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBuildTracks.FlatAppearance.BorderSize = 0;
            this.btnBuildTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuildTracks.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnBuildTracks.Image = global::AgOpenGPS.Properties.Resources.ABTracks;
            this.btnBuildTracks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuildTracks.Location = new System.Drawing.Point(3, 3);
            this.btnBuildTracks.Name = "btnBuildTracks";
            this.btnBuildTracks.Size = new System.Drawing.Size(73, 59);
            this.btnBuildTracks.TabIndex = 539;
            this.btnBuildTracks.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuildTracks.UseVisualStyleBackColor = false;
            this.btnBuildTracks.Click += new System.EventHandler(this.btnBuildTracks_Click);
            // 
            // btnAutoTrack
            // 
            this.btnAutoTrack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoTrack.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAutoTrack.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAutoTrack.FlatAppearance.BorderSize = 0;
            this.btnAutoTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoTrack.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoTrack.Image = global::AgOpenGPS.Properties.Resources.AutoTrackOff;
            this.btnAutoTrack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoTrack.Location = new System.Drawing.Point(82, 3);
            this.btnAutoTrack.Name = "btnAutoTrack";
            this.btnAutoTrack.Size = new System.Drawing.Size(61, 59);
            this.btnAutoTrack.TabIndex = 543;
            this.btnAutoTrack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutoTrack.UseVisualStyleBackColor = false;
            this.btnAutoTrack.Click += new System.EventHandler(this.btnAutoTrack_Click);
            // 
            // btnCycleLines
            // 
            this.btnCycleLines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCycleLines.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLines.BackgroundImage = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnCycleLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLines.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLines.FlatAppearance.BorderSize = 0;
            this.btnCycleLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLines.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLines.Location = new System.Drawing.Point(149, 3);
            this.btnCycleLines.Name = "btnCycleLines";
            this.btnCycleLines.Size = new System.Drawing.Size(61, 59);
            this.btnCycleLines.TabIndex = 251;
            this.btnCycleLines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLines.UseVisualStyleBackColor = false;
            this.btnCycleLines.Click += new System.EventHandler(this.btnCycleLines_Click);
            // 
            // round_table5
            // 
            this.round_table5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.round_table5.ColumnCount = 3;
            this.round_table5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.round_table5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.round_table5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.round_table5.Controls.Add(this.btnSectionMasterAuto, 2, 0);
            this.round_table5.Controls.Add(this.btnSectionMasterManual, 0, 0);
            this.round_table5.Controls.Add(this.btnChangeMappingColor, 1, 0);
            this.round_table5.Location = new System.Drawing.Point(417, 649);
            this.round_table5.Name = "round_table5";
            this.round_table5.RowCount = 1;
            this.round_table5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table5.Size = new System.Drawing.Size(225, 65);
            this.round_table5.TabIndex = 552;
            // 
            // btnSectionMasterAuto
            // 
            this.btnSectionMasterAuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSectionMasterAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionMasterAuto.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterAuto.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionMasterAuto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSectionMasterAuto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.btnSectionMasterAuto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionMasterAuto.Location = new System.Drawing.Point(153, 0);
            this.btnSectionMasterAuto.Margin = new System.Windows.Forms.Padding(0);
            this.btnSectionMasterAuto.Name = "btnSectionMasterAuto";
            this.btnSectionMasterAuto.Size = new System.Drawing.Size(64, 64);
            this.btnSectionMasterAuto.TabIndex = 152;
            this.btnSectionMasterAuto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSectionMasterAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSectionMasterAuto.UseVisualStyleBackColor = false;
            this.btnSectionMasterAuto.Click += new System.EventHandler(this.btnSectionMasterAuto_Click);
            // 
            // btnSectionMasterManual
            // 
            this.btnSectionMasterManual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSectionMasterManual.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionMasterManual.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterManual.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionMasterManual.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSectionMasterManual.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
            this.btnSectionMasterManual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionMasterManual.Location = new System.Drawing.Point(7, 3);
            this.btnSectionMasterManual.Name = "btnSectionMasterManual";
            this.btnSectionMasterManual.Size = new System.Drawing.Size(64, 59);
            this.btnSectionMasterManual.TabIndex = 98;
            this.btnSectionMasterManual.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSectionMasterManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSectionMasterManual.UseVisualStyleBackColor = false;
            this.btnSectionMasterManual.Click += new System.EventHandler(this.btnSectionMasterManual_Click);
            // 
            // btnChangeMappingColor
            // 
            this.btnChangeMappingColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeMappingColor.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeMappingColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangeMappingColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChangeMappingColor.FlatAppearance.BorderSize = 0;
            this.btnChangeMappingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeMappingColor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeMappingColor.ForeColor = System.Drawing.Color.Black;
            this.btnChangeMappingColor.Image = global::AgOpenGPS.Properties.Resources.SectionMapping;
            this.btnChangeMappingColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeMappingColor.Location = new System.Drawing.Point(78, 4);
            this.btnChangeMappingColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeMappingColor.Name = "btnChangeMappingColor";
            this.btnChangeMappingColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChangeMappingColor.Size = new System.Drawing.Size(67, 56);
            this.btnChangeMappingColor.TabIndex = 476;
            this.btnChangeMappingColor.Text = "5.8.4";
            this.btnChangeMappingColor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChangeMappingColor.UseVisualStyleBackColor = false;
            this.btnChangeMappingColor.Click += new System.EventHandler(this.btnChangeMappingColor_Click);
            // 
            // round_StatusStrip2
            // 
            this.round_StatusStrip2.AllowMerge = false;
            this.round_StatusStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.round_StatusStrip2.AutoSize = false;
            this.round_StatusStrip2.BackColor = System.Drawing.Color.Transparent;
            this.round_StatusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.round_StatusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.round_StatusStrip2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_StatusStrip2.ImageScalingSize = new System.Drawing.Size(56, 56);
            this.round_StatusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.distanceToolBtn,
            this.toolStripDropDownButton4,
            this.toolStripDropDownButton1,
            this.btnStartAgIO,
            this.btnAutoSteerConfig});
            this.round_StatusStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.round_StatusStrip2.Location = new System.Drawing.Point(-50, 654);
            this.round_StatusStrip2.Name = "round_StatusStrip2";
            this.round_StatusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.round_StatusStrip2.Size = new System.Drawing.Size(388, 63);
            this.round_StatusStrip2.SizingGrip = false;
            this.round_StatusStrip2.Stretch = false;
            this.round_StatusStrip2.TabIndex = 550;
            this.round_StatusStrip2.Text = "UDP";
            this.round_StatusStrip2.Click += new System.EventHandler(this.distancetoolbutton);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(48, 58);
            this.toolStripStatusLabel4.Text = "     ";
            // 
            // distanceToolBtn
            // 
            this.distanceToolBtn.AutoSize = false;
            this.distanceToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.distanceToolBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.distanceToolBtn.Name = "distanceToolBtn";
            this.distanceToolBtn.ShowDropDownArrow = false;
            this.distanceToolBtn.Size = new System.Drawing.Size(54, 61);
            this.distanceToolBtn.Text = "2345m";
            this.distanceToolBtn.Click += new System.EventHandler(this.toolStripDropDownButtonDistance_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.AutoSize = false;
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wizardsMenu,
            this.steerChartStripMenu,
            this.eventViewerToolStripMenuItem,
            this.guidelinesToolStripMenuItem,
            this.deleteContourPathsToolStripMenuItem,
            this.offsetFixToolStrip,
            this.SmoothABtoolStripMenu,
            this.webcamToolStrip});
            this.toolStripDropDownButton4.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton4.Image = global::AgOpenGPS.Properties.Resources.SpecialFunctions;
            this.toolStripDropDownButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.ShowDropDownArrow = false;
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(66, 70);
            this.toolStripDropDownButton4.Text = "toolStripDropDownButton3";
            // 
            // wizardsMenu
            // 
            this.wizardsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steerWizardMenuItem});
            this.wizardsMenu.Image = global::AgOpenGPS.Properties.Resources.WizardWand;
            this.wizardsMenu.Name = "wizardsMenu";
            this.wizardsMenu.Size = new System.Drawing.Size(450, 70);
            this.wizardsMenu.Text = "Wizards";
            // 
            // steerWizardMenuItem
            // 
            this.steerWizardMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.steerWizardMenuItem.Name = "steerWizardMenuItem";
            this.steerWizardMenuItem.Size = new System.Drawing.Size(301, 44);
            this.steerWizardMenuItem.Text = "Steer Wizard";
            this.steerWizardMenuItem.Click += new System.EventHandler(this.steerWizardMenuItem_Click);
            // 
            // steerChartStripMenu
            // 
            this.steerChartStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steerChartToolStripMenuItem,
            this.headingChartToolStripMenuItem,
            this.xTEChartToolStripMenuItem,
            this.rollCheckToolStripMenuItem});
            this.steerChartStripMenu.Image = global::AgOpenGPS.Properties.Resources.Chart;
            this.steerChartStripMenu.Name = "steerChartStripMenu";
            this.steerChartStripMenu.Size = new System.Drawing.Size(450, 70);
            this.steerChartStripMenu.Text = "Charts";
            // 
            // steerChartToolStripMenuItem
            // 
            this.steerChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.steerChartToolStripMenuItem.Name = "steerChartToolStripMenuItem";
            this.steerChartToolStripMenuItem.Size = new System.Drawing.Size(322, 44);
            this.steerChartToolStripMenuItem.Text = "Steer Chart";
            this.steerChartToolStripMenuItem.Click += new System.EventHandler(this.toolStripAutoSteerChart_Click);
            // 
            // headingChartToolStripMenuItem
            // 
            this.headingChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.ConS_SourcesHeading;
            this.headingChartToolStripMenuItem.Name = "headingChartToolStripMenuItem";
            this.headingChartToolStripMenuItem.Size = new System.Drawing.Size(322, 44);
            this.headingChartToolStripMenuItem.Text = "Heading Chart";
            this.headingChartToolStripMenuItem.Click += new System.EventHandler(this.headingChartToolStripMenuItem_Click);
            // 
            // xTEChartToolStripMenuItem
            // 
            this.xTEChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.xTEChartToolStripMenuItem.Name = "xTEChartToolStripMenuItem";
            this.xTEChartToolStripMenuItem.Size = new System.Drawing.Size(322, 44);
            this.xTEChartToolStripMenuItem.Text = "XTE Chart";
            this.xTEChartToolStripMenuItem.Click += new System.EventHandler(this.xTEChartToolStripMenuItem_Click);
            // 
            // rollCheckToolStripMenuItem
            // 
            this.rollCheckToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.ConS_SourcesRoll;
            this.rollCheckToolStripMenuItem.Name = "rollCheckToolStripMenuItem";
            this.rollCheckToolStripMenuItem.Size = new System.Drawing.Size(322, 44);
            this.rollCheckToolStripMenuItem.Text = "Roll Check";
            this.rollCheckToolStripMenuItem.Click += new System.EventHandler(this.correctionToolStrip_Click);
            // 
            // eventViewerToolStripMenuItem
            // 
            this.eventViewerToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.ABTracks;
            this.eventViewerToolStripMenuItem.Name = "eventViewerToolStripMenuItem";
            this.eventViewerToolStripMenuItem.Size = new System.Drawing.Size(450, 70);
            this.eventViewerToolStripMenuItem.Text = "Event Viewer";
            this.eventViewerToolStripMenuItem.Click += new System.EventHandler(this.eventViewerToolStripMenuItem_Click);
            // 
            // guidelinesToolStripMenuItem
            // 
            this.guidelinesToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.ConD_ExtraGuides;
            this.guidelinesToolStripMenuItem.Name = "guidelinesToolStripMenuItem";
            this.guidelinesToolStripMenuItem.Size = new System.Drawing.Size(450, 70);
            this.guidelinesToolStripMenuItem.Text = "Extra Guides";
            this.guidelinesToolStripMenuItem.Click += new System.EventHandler(this.guidelinesToolStripMenuItem_Click);
            // 
            // deleteContourPathsToolStripMenuItem
            // 
            this.deleteContourPathsToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.TrashContourRef;
            this.deleteContourPathsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteContourPathsToolStripMenuItem.Name = "deleteContourPathsToolStripMenuItem";
            this.deleteContourPathsToolStripMenuItem.Size = new System.Drawing.Size(450, 70);
            this.deleteContourPathsToolStripMenuItem.Text = "Hide Contour Paths";
            this.deleteContourPathsToolStripMenuItem.Click += new System.EventHandler(this.deleteContourPathsToolStripMenuItem_Click);
            // 
            // offsetFixToolStrip
            // 
            this.offsetFixToolStrip.Image = global::AgOpenGPS.Properties.Resources.YouTurnReverse;
            this.offsetFixToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.offsetFixToolStrip.Name = "offsetFixToolStrip";
            this.offsetFixToolStrip.Size = new System.Drawing.Size(450, 70);
            this.offsetFixToolStrip.Text = "Offset Fix";
            this.offsetFixToolStrip.Click += new System.EventHandler(this.offsetFixToolStrip_Click);
            // 
            // SmoothABtoolStripMenu
            // 
            this.SmoothABtoolStripMenu.Image = global::AgOpenGPS.Properties.Resources.ABSmooth;
            this.SmoothABtoolStripMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SmoothABtoolStripMenu.Name = "SmoothABtoolStripMenu";
            this.SmoothABtoolStripMenu.Size = new System.Drawing.Size(450, 70);
            this.SmoothABtoolStripMenu.Text = "Smooth AB Curve";
            this.SmoothABtoolStripMenu.Click += new System.EventHandler(this.SmoothABtoolStripMenu_Click);
            // 
            // webcamToolStrip
            // 
            this.webcamToolStrip.Image = global::AgOpenGPS.Properties.Resources.Webcam;
            this.webcamToolStrip.Name = "webcamToolStrip";
            this.webcamToolStrip.Size = new System.Drawing.Size(450, 70);
            this.webcamToolStrip.Text = "WebCam";
            this.webcamToolStrip.Click += new System.EventHandler(this.webcamToolStrip_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConfig,
            this.toolStripSteerSettings,
            this.toolStripAllSettings,
            this.toolStripWorkingDirectories,
            this.toolStripGPSData,
            this.toolStripColors,
            this.toolStripSectionColors,
            this.toolStripHotkeys});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.Image = global::AgOpenGPS.Properties.Resources.Settings48;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(66, 80);
            this.toolStripDropDownButton1.Text = "All";
            // 
            // toolStripConfig
            // 
            this.toolStripConfig.Image = global::AgOpenGPS.Properties.Resources.Settings48;
            this.toolStripConfig.Name = "toolStripConfig";
            this.toolStripConfig.Size = new System.Drawing.Size(419, 44);
            this.toolStripConfig.Text = "Configuration";
            this.toolStripConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // toolStripSteerSettings
            // 
            this.toolStripSteerSettings.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.toolStripSteerSettings.Name = "toolStripSteerSettings";
            this.toolStripSteerSettings.Size = new System.Drawing.Size(419, 44);
            this.toolStripSteerSettings.Text = "Auto Steer";
            this.toolStripSteerSettings.Click += new System.EventHandler(this.btnAutoSteerConfig_Click);
            // 
            // toolStripAllSettings
            // 
            this.toolStripAllSettings.Image = global::AgOpenGPS.Properties.Resources.ScreenShot;
            this.toolStripAllSettings.Name = "toolStripAllSettings";
            this.toolStripAllSettings.Size = new System.Drawing.Size(419, 44);
            this.toolStripAllSettings.Text = "View All Settings";
            this.toolStripAllSettings.Click += new System.EventHandler(this.allSettingsMenuItem_Click);
            // 
            // toolStripWorkingDirectories
            // 
            this.toolStripWorkingDirectories.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.toolStripWorkingDirectories.Name = "toolStripWorkingDirectories";
            this.toolStripWorkingDirectories.Size = new System.Drawing.Size(419, 44);
            this.toolStripWorkingDirectories.Text = "Directories";
            this.toolStripWorkingDirectories.Click += new System.EventHandler(this.setWorkingDirectoryToolStripMenuItem_Click);
            // 
            // toolStripGPSData
            // 
            this.toolStripGPSData.Image = global::AgOpenGPS.Properties.Resources.GPSQuality;
            this.toolStripGPSData.Name = "toolStripGPSData";
            this.toolStripGPSData.Size = new System.Drawing.Size(419, 44);
            this.toolStripGPSData.Text = "GPS Data";
            this.toolStripGPSData.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // toolStripColors
            // 
            this.toolStripColors.Image = global::AgOpenGPS.Properties.Resources.ColourPick;
            this.toolStripColors.Name = "toolStripColors";
            this.toolStripColors.Size = new System.Drawing.Size(419, 44);
            this.toolStripColors.Text = "Colors";
            this.toolStripColors.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // toolStripSectionColors
            // 
            this.toolStripSectionColors.Image = global::AgOpenGPS.Properties.Resources.SectionMapping;
            this.toolStripSectionColors.Name = "toolStripSectionColors";
            this.toolStripSectionColors.Size = new System.Drawing.Size(419, 44);
            this.toolStripSectionColors.Text = "Multi-Section Colors";
            this.toolStripSectionColors.Click += new System.EventHandler(this.colorsSectionToolStripMenuItem_Click);
            // 
            // toolStripHotkeys
            // 
            this.toolStripHotkeys.Image = global::AgOpenGPS.Properties.Resources.ConD_KeyBoard;
            this.toolStripHotkeys.Name = "toolStripHotkeys";
            this.toolStripHotkeys.Size = new System.Drawing.Size(419, 44);
            this.toolStripHotkeys.Text = "HotKeys";
            this.toolStripHotkeys.Click += new System.EventHandler(this.hotKeysToolStripMenuItem_Click);
            // 
            // btnStartAgIO
            // 
            this.btnStartAgIO.AutoSize = false;
            this.btnStartAgIO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartAgIO.Image = global::AgOpenGPS.Properties.Resources.AgIO;
            this.btnStartAgIO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartAgIO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartAgIO.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnStartAgIO.Name = "btnStartAgIO";
            this.btnStartAgIO.ShowDropDownArrow = false;
            this.btnStartAgIO.Size = new System.Drawing.Size(66, 65);
            this.btnStartAgIO.Text = "toolStripDropDownButton4";
            this.btnStartAgIO.Click += new System.EventHandler(this.btnStartAgIO_Click);
            // 
            // btnAutoSteerConfig
            // 
            this.btnAutoSteerConfig.AutoSize = false;
            this.btnAutoSteerConfig.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSteerConfig.Image = global::AgOpenGPS.Properties.Resources.AutoSteerConf;
            this.btnAutoSteerConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAutoSteerConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoSteerConfig.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnAutoSteerConfig.Name = "btnAutoSteerConfig";
            this.btnAutoSteerConfig.ShowDropDownArrow = false;
            this.btnAutoSteerConfig.Size = new System.Drawing.Size(66, 65);
            this.btnAutoSteerConfig.Text = "-38.8.";
            this.btnAutoSteerConfig.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnAutoSteerConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnAutoSteerConfig.Click += new System.EventHandler(this.btnAutoSteerConfig_Click);
            // 
            // round_StatusStrip1
            // 
            this.round_StatusStrip1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.round_StatusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.round_StatusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.round_StatusStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.btnJobMenu,
            this.toolStripStatusLabel2});
            this.round_StatusStrip1.Location = new System.Drawing.Point(-88, 240);
            this.round_StatusStrip1.Name = "round_StatusStrip1";
            this.round_StatusStrip1.Size = new System.Drawing.Size(349, 68);
            this.round_StatusStrip1.TabIndex = 549;
            this.round_StatusStrip1.Text = "round_StatusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 63);
            this.toolStripStatusLabel1.Text = "                          ";
            // 
            // btnJobMenu
            // 
            this.btnJobMenu.AutoSize = false;
            this.btnJobMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJobMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJobMenu.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btnJobMenu.Image = global::AgOpenGPS.Properties.Resources.JobActive;
            this.btnJobMenu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJobMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnJobMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJobMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnJobMenu.Name = "btnJobMenu";
            this.btnJobMenu.ShowDropDownArrow = false;
            this.btnJobMenu.Size = new System.Drawing.Size(66, 68);
            this.btnJobMenu.Click += new System.EventHandler(this.btnJobMenu_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAppliedToolStripMenuItem,
            this.boundariesToolStripMenuItem,
            this.boundaryToolToolStripMenu,
            this.headlandBuildToolStripMenuItem,
            this.flagByLatLonToolStripMenuItem,
            this.recordedPathStripMenu,
            this.headlandToolStripMenuItem,
            this.tramsMultiMenuField,
            this.tramLinesMenuField});
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.ForestGreen;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(181, 68);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // deleteAppliedToolStripMenuItem
            // 
            this.deleteAppliedToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAppliedToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.TrashApplied;
            this.deleteAppliedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteAppliedToolStripMenuItem.Name = "deleteAppliedToolStripMenuItem";
            this.deleteAppliedToolStripMenuItem.Size = new System.Drawing.Size(451, 70);
            this.deleteAppliedToolStripMenuItem.Text = "Delete Applied";
            this.deleteAppliedToolStripMenuItem.Click += new System.EventHandler(this.toolStripAreYouSure_Click);
            // 
            // boundariesToolStripMenuItem
            // 
            this.boundariesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boundariesToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.boundariesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.boundariesToolStripMenuItem.Name = "boundariesToolStripMenuItem";
            this.boundariesToolStripMenuItem.Size = new System.Drawing.Size(451, 70);
            this.boundariesToolStripMenuItem.Text = "Boundary";
            this.boundariesToolStripMenuItem.Click += new System.EventHandler(this.boundariesToolStripMenuItem_Click);
            // 
            // boundaryToolToolStripMenu
            // 
            this.boundaryToolToolStripMenu.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold);
            this.boundaryToolToolStripMenu.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.boundaryToolToolStripMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.boundaryToolToolStripMenu.Name = "boundaryToolToolStripMenu";
            this.boundaryToolToolStripMenu.Size = new System.Drawing.Size(451, 70);
            this.boundaryToolToolStripMenu.Text = "Boundary Tool";
            this.boundaryToolToolStripMenu.Click += new System.EventHandler(this.boundaryToolToolStripMenu_Click);
            // 
            // headlandBuildToolStripMenuItem
            // 
            this.headlandBuildToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlandBuildToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Headache;
            this.headlandBuildToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.headlandBuildToolStripMenuItem.Name = "headlandBuildToolStripMenuItem";
            this.headlandBuildToolStripMenuItem.Size = new System.Drawing.Size(451, 70);
            this.headlandBuildToolStripMenuItem.Text = "Headland (Build)";
            this.headlandBuildToolStripMenuItem.Click += new System.EventHandler(this.headlandBuildToolStripMenuItem_Click);
            // 
            // flagByLatLonToolStripMenuItem
            // 
            this.flagByLatLonToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagByLatLonToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.flagByLatLonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.flagByLatLonToolStripMenuItem.Name = "flagByLatLonToolStripMenuItem";
            this.flagByLatLonToolStripMenuItem.Size = new System.Drawing.Size(451, 70);
            this.flagByLatLonToolStripMenuItem.Text = "Flag By Lat Lon";
            this.flagByLatLonToolStripMenuItem.Click += new System.EventHandler(this.flagByLatLonToolStripMenuItem_Click);
            // 
            // recordedPathStripMenu
            // 
            this.recordedPathStripMenu.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordedPathStripMenu.Image = global::AgOpenGPS.Properties.Resources.RecPath;
            this.recordedPathStripMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.recordedPathStripMenu.Name = "recordedPathStripMenu";
            this.recordedPathStripMenu.Size = new System.Drawing.Size(451, 70);
            this.recordedPathStripMenu.Text = "Recorded Path";
            this.recordedPathStripMenu.Click += new System.EventHandler(this.recordedPathStripMenu_Click);
            // 
            // headlandToolStripMenuItem
            // 
            this.headlandToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlandToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.HeadlandBuild;
            this.headlandToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.headlandToolStripMenuItem.Name = "headlandToolStripMenuItem";
            this.headlandToolStripMenuItem.Size = new System.Drawing.Size(451, 70);
            this.headlandToolStripMenuItem.Text = "Headland";
            this.headlandToolStripMenuItem.Click += new System.EventHandler(this.headlandToolStripMenuItem_Click);
            // 
            // tramsMultiMenuField
            // 
            this.tramsMultiMenuField.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tramsMultiMenuField.Image = global::AgOpenGPS.Properties.Resources.TramMulti;
            this.tramsMultiMenuField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tramsMultiMenuField.Name = "tramsMultiMenuField";
            this.tramsMultiMenuField.Size = new System.Drawing.Size(451, 70);
            this.tramsMultiMenuField.Text = "TramLines";
            this.tramsMultiMenuField.Click += new System.EventHandler(this.tramLinesMenuMulti_Click);
            // 
            // tramLinesMenuField
            // 
            this.tramLinesMenuField.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tramLinesMenuField.Image = global::AgOpenGPS.Properties.Resources.TramAll;
            this.tramLinesMenuField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tramLinesMenuField.Name = "tramLinesMenuField";
            this.tramLinesMenuField.Size = new System.Drawing.Size(451, 70);
            this.tramLinesMenuField.Text = "TramLines";
            this.tramLinesMenuField.Click += new System.EventHandler(this.tramLinesMenuField_Click);
            // 
            // round_table10
            // 
            this.round_table10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.round_table10.BackColor = System.Drawing.Color.Transparent;
            this.round_table10.Dock = System.Windows.Forms.DockStyle.None;
            this.round_table10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round_table10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.button2,
            this.label1});
            this.round_table10.Location = new System.Drawing.Point(-88, 310);
            this.round_table10.Name = "round_table10";
            this.round_table10.Size = new System.Drawing.Size(336, 65);
            this.round_table10.TabIndex = 548;
            this.round_table10.Text = "round_StatusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(85, 60);
            this.toolStripStatusLabel3.Text = "                          ";
            // 
            // button2
            // 
            this.button2.AutoSize = false;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button2.Font = new System.Drawing.Font("Tahoma", 18F);
            this.button2.Image = global::AgOpenGPS.Properties.Resources.ToolMenu;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.ShowDropDownArrow = false;
            this.button2.Size = new System.Drawing.Size(66, 65);
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 65);
            this.label1.Text = "toolStripStatusLabel2";
            // 
            // round_table9
            // 
            this.round_table9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.round_table9.ColumnCount = 4;
            this.round_table9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.round_table9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.round_table9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.84615F));
            this.round_table9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.15385F));
            this.round_table9.Controls.Add(this.btnAutoYouTurn, 1, 0);
            this.round_table9.Controls.Add(this.btnYouSkipEnable, 2, 0);
            this.round_table9.Controls.Add(this.cboxpRowWidth, 3, 0);
            this.round_table9.Location = new System.Drawing.Point(-90, 380);
            this.round_table9.Name = "round_table9";
            this.round_table9.RowCount = 1;
            this.round_table9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table9.Size = new System.Drawing.Size(283, 65);
            this.round_table9.TabIndex = 547;
            // 
            // btnAutoYouTurn
            // 
            this.btnAutoYouTurn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoYouTurn.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoYouTurn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoYouTurn.FlatAppearance.BorderSize = 0;
            this.btnAutoYouTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoYouTurn.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAutoYouTurn.Image = global::AgOpenGPS.Properties.Resources.YouTurnNo;
            this.btnAutoYouTurn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoYouTurn.Location = new System.Drawing.Point(89, 3);
            this.btnAutoYouTurn.Name = "btnAutoYouTurn";
            this.btnAutoYouTurn.Size = new System.Drawing.Size(64, 59);
            this.btnAutoYouTurn.TabIndex = 132;
            this.btnAutoYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnAutoYouTurn.Click += new System.EventHandler(this.btnAutoYouTurn_Click);
            // 
            // btnYouSkipEnable
            // 
            this.btnYouSkipEnable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnYouSkipEnable.BackColor = System.Drawing.Color.Transparent;
            this.btnYouSkipEnable.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnYouSkipEnable.FlatAppearance.BorderSize = 0;
            this.btnYouSkipEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYouSkipEnable.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouSkipEnable.Image = global::AgOpenGPS.Properties.Resources.YouSkipOff;
            this.btnYouSkipEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnYouSkipEnable.Location = new System.Drawing.Point(165, 4);
            this.btnYouSkipEnable.Name = "btnYouSkipEnable";
            this.btnYouSkipEnable.Size = new System.Drawing.Size(59, 56);
            this.btnYouSkipEnable.TabIndex = 490;
            this.btnYouSkipEnable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouSkipEnable.UseVisualStyleBackColor = false;
            this.btnYouSkipEnable.Click += new System.EventHandler(this.btnYouSkipEnable_Click);
            // 
            // cboxpRowWidth
            // 
            this.cboxpRowWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxpRowWidth.BackColor = System.Drawing.Color.Lavender;
            this.cboxpRowWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxpRowWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxpRowWidth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxpRowWidth.FormattingEnabled = true;
            this.cboxpRowWidth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboxpRowWidth.Location = new System.Drawing.Point(231, 14);
            this.cboxpRowWidth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxpRowWidth.Name = "cboxpRowWidth";
            this.cboxpRowWidth.Size = new System.Drawing.Size(48, 37);
            this.cboxpRowWidth.TabIndex = 247;
            this.cboxpRowWidth.Visible = false;
            this.cboxpRowWidth.SelectedIndexChanged += new System.EventHandler(this.cboxpRowWidth_SelectedIndexChanged);
            // 
            // round_table8
            // 
            this.round_table8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.round_table8.ColumnCount = 3;
            this.round_table8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.round_table8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.round_table8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.round_table8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.round_table8.Controls.Add(this.button1, 2, 0);
            this.round_table8.Controls.Add(this.btnHydLift, 1, 0);
            this.round_table8.Location = new System.Drawing.Point(-83, 521);
            this.round_table8.Name = "round_table8";
            this.round_table8.RowCount = 1;
            this.round_table8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table8.Size = new System.Drawing.Size(227, 65);
            this.round_table8.TabIndex = 546;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Image = global::AgOpenGPS.Properties.Resources.Ferti;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(158, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 55);
            this.button1.TabIndex = 565;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHydLift
            // 
            this.btnHydLift.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHydLift.BackColor = System.Drawing.Color.Transparent;
            this.btnHydLift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHydLift.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHydLift.FlatAppearance.BorderSize = 0;
            this.btnHydLift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHydLift.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnHydLift.Image = global::AgOpenGPS.Properties.Resources.HydraulicLiftOff;
            this.btnHydLift.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHydLift.Location = new System.Drawing.Point(83, 4);
            this.btnHydLift.Name = "btnHydLift";
            this.btnHydLift.Size = new System.Drawing.Size(69, 56);
            this.btnHydLift.TabIndex = 453;
            this.btnHydLift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHydLift.UseVisualStyleBackColor = false;
            this.btnHydLift.Click += new System.EventHandler(this.btnHydLift_Click);
            // 
            // round_table7
            // 
            this.round_table7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.round_table7.ColumnCount = 3;
            this.round_table7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.round_table7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.round_table7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.round_table7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.round_table7.Controls.Add(this.btnAutoSteer, 1, 0);
            this.round_table7.Controls.Add(this.btnResetToolHeading, 2, 0);
            this.round_table7.Location = new System.Drawing.Point(-83, 450);
            this.round_table7.Name = "round_table7";
            this.round_table7.RowCount = 1;
            this.round_table7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.round_table7.Size = new System.Drawing.Size(227, 65);
            this.round_table7.TabIndex = 544;
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoSteer.FlatAppearance.BorderSize = 0;
            this.btnAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAutoSteer.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.btnAutoSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoSteer.Location = new System.Drawing.Point(85, 0);
            this.btnAutoSteer.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.Size = new System.Drawing.Size(64, 64);
            this.btnAutoSteer.TabIndex = 128;
            this.btnAutoSteer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnResetToolHeading
            // 
            this.btnResetToolHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetToolHeading.BackColor = System.Drawing.Color.Transparent;
            this.btnResetToolHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetToolHeading.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnResetToolHeading.FlatAppearance.BorderSize = 0;
            this.btnResetToolHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetToolHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetToolHeading.ForeColor = System.Drawing.Color.Black;
            this.btnResetToolHeading.Image = global::AgOpenGPS.Properties.Resources.ResetTool;
            this.btnResetToolHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetToolHeading.Location = new System.Drawing.Point(156, 4);
            this.btnResetToolHeading.Margin = new System.Windows.Forms.Padding(0);
            this.btnResetToolHeading.Name = "btnResetToolHeading";
            this.btnResetToolHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnResetToolHeading.Size = new System.Drawing.Size(73, 56);
            this.btnResetToolHeading.TabIndex = 491;
            this.btnResetToolHeading.UseVisualStyleBackColor = false;
            this.btnResetToolHeading.Click += new System.EventHandler(this.btnResetToolHeading_Click);
            // 
            // lblHardwareMessage
            // 
            this.lblHardwareMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHardwareMessage.BackColor = System.Drawing.Color.Bisque;
            this.lblHardwareMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHardwareMessage.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardwareMessage.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblHardwareMessage.Location = new System.Drawing.Point(2, 163);
            this.lblHardwareMessage.Name = "lblHardwareMessage";
            this.lblHardwareMessage.Size = new System.Drawing.Size(889, 46);
            this.lblHardwareMessage.TabIndex = 568;
            this.lblHardwareMessage.Text = "This message is very long and boring no one should read 01234";
            this.lblHardwareMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHardwareMessage.Visible = false;
            // 
            // cboxAutoSnapToPivot
            // 
            this.cboxAutoSnapToPivot.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboxAutoSnapToPivot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAutoSnapToPivot.BackColor = System.Drawing.Color.Transparent;
            this.cboxAutoSnapToPivot.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cboxAutoSnapToPivot.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxAutoSnapToPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAutoSnapToPivot.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxAutoSnapToPivot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxAutoSnapToPivot.Image = global::AgOpenGPS.Properties.Resources.AutoSteerSnapToPivot;
            this.cboxAutoSnapToPivot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxAutoSnapToPivot.Location = new System.Drawing.Point(508, 529);
            this.cboxAutoSnapToPivot.Name = "cboxAutoSnapToPivot";
            this.cboxAutoSnapToPivot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxAutoSnapToPivot.Size = new System.Drawing.Size(54, 68);
            this.cboxAutoSnapToPivot.TabIndex = 468;
            this.cboxAutoSnapToPivot.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.cboxAutoSnapToPivot.UseVisualStyleBackColor = false;
            this.cboxAutoSnapToPivot.Visible = false;
            this.cboxAutoSnapToPivot.CheckedChanged += new System.EventHandler(this.btnSnapToPivot_Click);
            this.cboxAutoSnapToPivot.Click += new System.EventHandler(this.cboxAutoSnapToPivot_Click);
            // 
            // SnapCenterMain
            // 
            this.SnapCenterMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SnapCenterMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.SnapCenterMain.BackgroundImage = global::AgOpenGPS.Properties.Resources.SnapToPivot;
            this.SnapCenterMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SnapCenterMain.ContextMenuStrip = this.contextMenuStrip_SnapCenterMain;
            this.SnapCenterMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SnapCenterMain.Location = new System.Drawing.Point(508, 599);
            this.SnapCenterMain.Name = "SnapCenterMain";
            this.SnapCenterMain.Size = new System.Drawing.Size(54, 44);
            this.SnapCenterMain.TabIndex = 563;
            this.SnapCenterMain.UseVisualStyleBackColor = false;
            this.SnapCenterMain.Click += new System.EventHandler(this.btnSnapToPivot_Click);
            // 
            // btnAdjRightMain
            // 
            this.btnAdjRightMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdjRightMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnAdjRightMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdjRightMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjRightMain.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnAdjRightMain.Location = new System.Drawing.Point(593, 599);
            this.btnAdjRightMain.Name = "btnAdjRightMain";
            this.btnAdjRightMain.Size = new System.Drawing.Size(54, 44);
            this.btnAdjRightMain.TabIndex = 562;
            this.btnAdjRightMain.UseVisualStyleBackColor = false;
            this.btnAdjRightMain.Visible = false;
            this.btnAdjRightMain.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // btnAdjLeftMain
            // 
            this.btnAdjLeftMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdjLeftMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnAdjLeftMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdjLeftMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjLeftMain.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnAdjLeftMain.Location = new System.Drawing.Point(423, 599);
            this.btnAdjLeftMain.Name = "btnAdjLeftMain";
            this.btnAdjLeftMain.Size = new System.Drawing.Size(54, 44);
            this.btnAdjLeftMain.TabIndex = 561;
            this.btnAdjLeftMain.UseVisualStyleBackColor = false;
            this.btnAdjLeftMain.Visible = false;
            this.btnAdjLeftMain.Click += new System.EventHandler(this.btnAdjLeft_Click);
            // 
            // FormGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.panelDrag);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboxAutoSnapToPivot);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.SnapCenterMain);
            this.Controls.Add(this.btnAdjRightMain);
            this.Controls.Add(this.btnAdjLeftMain);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.round_table12);
            this.Controls.Add(this.round_table11);
            this.Controls.Add(this.round_Menu1);
            this.Controls.Add(this.round_table6);
            this.Controls.Add(this.round_table4);
            this.Controls.Add(this.round_table3);
            this.Controls.Add(this.round_table2);
            this.Controls.Add(this.round_table1);
            this.Controls.Add(this.round_table5);
            this.Controls.Add(this.round_StatusStrip2);
            this.Controls.Add(this.round_StatusStrip1);
            this.Controls.Add(this.round_table10);
            this.Controls.Add(this.round_table9);
            this.Controls.Add(this.round_table8);
            this.Controls.Add(this.round_table7);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.flp1);
            this.Controls.Add(this.panelSim);
            this.Controls.Add(this.btnZone8);
            this.Controls.Add(this.btnZone7);
            this.Controls.Add(this.btnZone6);
            this.Controls.Add(this.btnZone5);
            this.Controls.Add(this.btnZone4);
            this.Controls.Add(this.btnZone3);
            this.Controls.Add(this.btnZone2);
            this.Controls.Add(this.btnZone1);
            this.Controls.Add(this.btnSection13Man);
            this.Controls.Add(this.btnSection14Man);
            this.Controls.Add(this.btnSection15Man);
            this.Controls.Add(this.btnSection16Man);
            this.Controls.Add(this.btnSection8Man);
            this.Controls.Add(this.btnSection7Man);
            this.Controls.Add(this.btnSection6Man);
            this.Controls.Add(this.btnSection5Man);
            this.Controls.Add(this.btnSection4Man);
            this.Controls.Add(this.btnSection3Man);
            this.Controls.Add(this.btnSection2Man);
            this.Controls.Add(this.btnSection1Man);
            this.Controls.Add(this.btnSection12Man);
            this.Controls.Add(this.btnSection11Man);
            this.Controls.Add(this.btnSection10Man);
            this.Controls.Add(this.btnSection9Man);
            this.Controls.Add(this.oglMain);
            this.Controls.Add(this.oglZoom);
            this.Controls.Add(this.oglBack);
            this.Controls.Add(this.lblGuidanceLine);
            this.Controls.Add(this.lblHardwareMessage);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "FormGPS";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "AgOpenGPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.ResizeEnd += new System.EventHandler(this.FormGPS_ResizeEnd);
            this.Move += new System.EventHandler(this.FormGPS_Move);
            this.contextMenuStripOpenGL.ResumeLayout(false);
            this.contextMenuStripFlag.ResumeLayout(false);
            this.panelDrag.ResumeLayout(false);
            this.panelSim.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.round_table12.ResumeLayout(false);
            this.round_table12.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.round_table11.ResumeLayout(false);
            this.round_Menu1.ResumeLayout(false);
            this.round_Menu1.PerformLayout();
            this.round_table6.ResumeLayout(false);
            this.round_table4.ResumeLayout(false);
            this.round_table4.PerformLayout();
            this.round_table3.ResumeLayout(false);
            this.round_table2.ResumeLayout(false);
            this.round_table1.ResumeLayout(false);
            this.round_table5.ResumeLayout(false);
            this.round_StatusStrip2.ResumeLayout(false);
            this.round_StatusStrip2.PerformLayout();
            this.round_StatusStrip1.ResumeLayout(false);
            this.round_StatusStrip1.PerformLayout();
            this.round_table10.ResumeLayout(false);
            this.round_table10.PerformLayout();
            this.round_table9.ResumeLayout(false);
            this.round_table8.ResumeLayout(false);
            this.round_table7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrWatchdog;
        private System.Windows.Forms.Button btnSection1Man;
        private System.Windows.Forms.Button btnSection2Man;
        private System.Windows.Forms.Button btnSection3Man;
        private System.Windows.Forms.Button btnSection4Man;
        private System.Windows.Forms.Button btnSection5Man;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFlag;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFlagRed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagGrn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagYel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpenGL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem googleEarthOpenGLContextMenu;
        private System.Windows.Forms.Button btnSection8Man;
        private System.Windows.Forms.Button btnSection7Man;
        private System.Windows.Forms.Button btnSection6Man;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnResetSteerAngle;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.Button btnSectionMasterAuto;
        private System.Windows.Forms.Button btnSection9Man;
        private System.Windows.Forms.Button btnSection10Man;
        private System.Windows.Forms.Button btnSection11Man;
        private System.Windows.Forms.Button btnSection12Man;
        public System.Windows.Forms.Button btnAutoYouTurn;
        public System.Windows.Forms.Button btnAutoSteer;
        private System.Windows.Forms.HScrollBar hsbarSteerAngle;
        private OpenTK.GLControl oglZoom;
        private OpenTK.GLControl oglMain;
        private OpenTK.GLControl oglBack;
        private System.Windows.Forms.ComboBox cboxpRowWidth;
        public System.Windows.Forms.Button btnContour;
        public System.Windows.Forms.Timer timerSim;
        public System.Windows.Forms.Button btnSectionMasterManual;
        public System.Windows.Forms.Button btnABDraw;
        public System.Windows.Forms.Button btnCycleLines;
        private System.Windows.Forms.TableLayoutPanel panelSim;
        public System.Windows.Forms.TableLayoutPanel panelDrag;
        private System.Windows.Forms.Button btnHeadlandOnOff;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnSection16Man;
        private System.Windows.Forms.Button btnSection15Man;
        private System.Windows.Forms.Button btnSection14Man;
        private System.Windows.Forms.Button btnSection13Man;
        private System.Windows.Forms.Button btnSimSetSpeedToZero;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagForm;
        public System.Windows.Forms.Button btnDayNightMode;
        public System.Windows.Forms.Button btnPickPath;
        public System.Windows.Forms.Button btnPathRecordStop;
        public System.Windows.Forms.Button btnPathGoStop;
        private System.Windows.Forms.TableLayoutPanel panelNavigation;
        public System.Windows.Forms.Button btn2D;
        public System.Windows.Forms.Button btn3D;
        public System.Windows.Forms.Button btnN2D;
        public System.Windows.Forms.Button btnChangeMappingColor;
        private System.Windows.Forms.Button btnMinimizeMainForm;
        private System.Windows.Forms.Button btnMaximizeMainForm;
        public System.Windows.Forms.Button btnTramDisplayMode;
        public System.Windows.Forms.Button btnYouSkipEnable;
        private System.Windows.Forms.Button btnNudge;
        public System.Windows.Forms.Button btnResumePath;
        public System.Windows.Forms.Button btnBrightnessDn;
        public System.Windows.Forms.Button btnBrightnessUp;
        private System.Windows.Forms.Button btnZone1;
        private System.Windows.Forms.Button btnZone2;
        private System.Windows.Forms.Button btnZone3;
        private System.Windows.Forms.Button btnZone4;
        private System.Windows.Forms.Button btnZone5;
        private System.Windows.Forms.Button btnZone6;
        private System.Windows.Forms.Button btnZone7;
        private System.Windows.Forms.Button btnZone8;
        private ProXoft.WinForms.RepeatButton btnSimSpeedUp;
        private ProXoft.WinForms.RepeatButton btnSpeedDn;
        public System.Windows.Forms.Button btnSwapABRecordedPath;
        private System.Windows.Forms.Button btnSimReverseDirection;
        private System.Windows.Forms.CheckBox cboxAutoSnapToPivot;
        public System.Windows.Forms.Button btnBuildTracks;
        private System.Windows.Forms.Label lblGuidanceLine;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        public System.Windows.Forms.Button btnAutoTrack;
        public System.Windows.Forms.Button btnTiltDn;
        public System.Windows.Forms.Button btnTiltUp;
        private System.Windows.Forms.Label lblRed;
        private Round_StatusStrip round_table10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripDropDownButton button2;
        private System.Windows.Forms.ToolStripStatusLabel label1;
        private Round_table round_table9;
        private Round_table round_table8;
        private Round_table round_table7;
        public System.Windows.Forms.Button btnResetToolHeading;
        private Round_StatusStrip round_StatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton btnJobMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem boundaryToolToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteAppliedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headlandBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagByLatLonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordedPathStripMenu;
        private Round_StatusStrip round_StatusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripDropDownButton btnAutoSteerConfig;
        private System.Windows.Forms.ToolStripDropDownButton distanceToolBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem wizardsMenu;
        private System.Windows.Forms.ToolStripMenuItem steerWizardMenuItem;
        public System.Windows.Forms.ToolStripMenuItem steerChartStripMenu;
        private System.Windows.Forms.ToolStripMenuItem rollCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContourPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetFixToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SmoothABtoolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem webcamToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnStartAgIO;
        private Round_Menu round_Menu1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton btnNavigationSettings;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripMenuItem menustripLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDanish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDeutsch;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSpanish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFrench;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageItalian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLatvian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLithuanian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageHungarian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDutch;
        private System.Windows.Forms.ToolStripMenuItem menuLanguagePolish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageRussian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFinnish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSlovak;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageUkranian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTurkish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem enterSimCoordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetEverythingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miseÀJourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dzzdzToolStripMenuItem;
        private Round_table round_table5;
        private Round_table round_table6;
        private Round_table round_table4;
        private Round_table round_table3;
        private Round_table round_table2;
        private Round_table round_table1;
        private Round_table round_table11;
        private Round_table round_table12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbludpWatchCounts;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label BatLevel;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblHz;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Round_panel panel_top;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblTotalAppliedArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblWorkRemaining;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Button SnapCenterMain;
        private System.Windows.Forms.Button btnAdjRightMain;
        private System.Windows.Forms.Button btnAdjLeftMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tram;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_headlane;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_btnNudge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_contour;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_lblhz;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_btnBuildTracks;
        private System.Windows.Forms.ToolStripMenuItem headlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramLinesMenuField;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_SnapCenterMain;
        public System.Windows.Forms.Button btnGrid;
        private System.Windows.Forms.ToolStripMenuItem eventViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guidelinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nozzleAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripSteerSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripWorkingDirectories;
        private System.Windows.Forms.ToolStripMenuItem toolStripGPSData;
        private System.Windows.Forms.ToolStripMenuItem toolStripColors;
        private System.Windows.Forms.ToolStripMenuItem toolStripSectionColors;
        private System.Windows.Forms.ToolStripMenuItem toolStripHotkeys;
        private System.Windows.Forms.Button btnChargeStatus;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem menuLanguagePortugese;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageChinese;
        private System.Windows.Forms.ToolStripMenuItem kioskModeToolStrip;
        private ToolStripMenuItem menuLanguageNorsk;
        private ToolStripMenuItem menuLanguageSerbie;
        public System.Windows.Forms.Button btnHydLift;
        private System.Windows.Forms.Label lblHardwareMessage;
        private System.Windows.Forms.ToolStripMenuItem toolStripAllSettings;
        private ToolStripMenuItem tramsMultiMenuField;
        private ToolStripDropDownButton Connected_services;
    }
}