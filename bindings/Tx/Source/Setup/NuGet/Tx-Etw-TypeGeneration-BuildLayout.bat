@echo off

set TxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a\lib

mkdir "%OutputSetupFolder%\Net40"
copy "%BinariesLayoutFolder%\Release\Microsoft.Etw.TypeGeneration.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.Etw.TypeGeneration.xml" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\EtwEventTypeGen.exe" "%OutputSetupFolder%\Net40\"
