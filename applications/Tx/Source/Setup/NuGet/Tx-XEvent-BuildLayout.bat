@echo off

set TxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a\lib

mkdir "%OutputSetupFolder%\Net40"
copy "%BinariesLayoutFolder%\Release\Microsoft.XEvent.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.XEvent.xml" "%OutputSetupFolder%\Net40\"

copy "%BinariesLayoutFolder%\Release\Microsoft.SqlServer.XE.Core.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.SqlServer.XEvent.Configuration.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.SqlServer.XEvent.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.SqlServer.XEvent.Linq.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.SqlServer.XEvent.Targets.dll" "%OutputSetupFolder%\Net40\"

mkdir "%OutputSetupFolder%\Dependencies"
copy "%BinariesLayoutFolder%\Release\xe.dll" "%OutputSetupFolder%\Dependencies\"
