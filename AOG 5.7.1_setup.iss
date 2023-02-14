; -- 64Bit.iss --
; Demonstrates installation of a program built for the x64 (a.k.a. AMD64)
; architecture.
; To successfully run this installation and the program it installs,
; you must have a "x64" edition of Windows.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=AgOpenGPS
AppVersion=5.7.1
AppPublisher=Urepom - Maxime EMPROU
;SignTool=Urepom - Maxime EMPROU 
AppPublisherURL=ttt
WizardStyle=modern
DefaultDirName={autopf}/AgOpenGPS
DefaultGroupName=AgOpenGPS
UninstallDisplayIcon={app}\MyProg.exe
Compression=lzma2
SolidCompression=yes
OutputDir=C:\Users\maxim\Documents\GitHub\AgOpenGPS_Urepom_Design
OutputBaseFilename=AgOpenGPS 5.7.1 Urepom_Setup
DisableDirPage=no
DisableProgramGroupPage=no
; "ArchitecturesAllowed=x64" specifies that Setup cannot run on
; anything but x64.
;ArchitecturesAllowed=x64
; "ArchitecturesInstallIn64BitMode=x64" requests that the install be
; done in "64-bit mode" on x64, meaning it should use the native
; 64-bit Program Files directory and the 64-bit view of the registry.
;ArchitecturesInstallIn64BitMode=x64
[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Files]
;Source: "C:\Users\maxim\Documents\GitHub\Full_custom\ProgramV4/AgOpenGPS.exe"; DestDir: "{app}"; DestName: "AgOpenGPS.exe";Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\maxim\Documents\GitHub\AgOpenGPS_Urepom_Design\AgOpenGPS_v5\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
;Source: "MyProg.chm"; DestDir: "{app}"
;Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme

[Icons]
Name: "{group}\AgOpenGPS"; Filename: "{app}\AgOpenGPS.exe"
Name: "{commondesktop}\AgOpenGPS"; Filename: "{app}\AgOpenGPS"; Tasks: desktopicon
