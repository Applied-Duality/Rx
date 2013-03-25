@echo off

set RxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a

copy "%BinariesLayoutFolder%\rx.coincidence.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.coincidence.min.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.coincidence-vsdoc.js" "%OutputSetupFolder%\"
