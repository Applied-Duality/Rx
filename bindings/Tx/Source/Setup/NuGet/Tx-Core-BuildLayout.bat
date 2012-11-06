@echo off

set TxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a\lib

mkdir "%OutputSetupFolder%\Net40"
copy "%BinariesLayoutFolder%\Release\System.Reactive.Tx.dll" "%OutputSetupFolder%\Net40\"
copy "%BinariesLayoutFolder%\Release\System.Reactive.Tx.xml" "%OutputSetupFolder%\Net40\"
