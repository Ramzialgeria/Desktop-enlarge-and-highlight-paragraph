; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DPara"
#define MyAppVersion "1.0"
#define MyAppExeName "DPara.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F76555C3-AD63-4389-9066-69ECFBBFC5AA}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=H:\Ramzi projects
OutputBaseFilename=DPara_setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Imaging.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Imaging.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Math.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Math.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Video.DirectShow.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Video.DirectShow.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Video.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.Video.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\AForge.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\DPara.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\myco.ini"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Ramzi projects\Desktop enlarge and highlight paragraph\Desktop enlarge and highlight paragraph\bin\x86\DPara\mycursor.cur"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

