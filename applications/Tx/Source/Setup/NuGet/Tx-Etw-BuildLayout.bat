@echo off

set TxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a\lib

mkdir "%OutputSetupFolder%\Net40"
copy "%BinariesLayoutFolder%\Release\Microsoft.Etw.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\Microsoft.Etw.xml" "%OutputSetupFolder%\Net40\"
