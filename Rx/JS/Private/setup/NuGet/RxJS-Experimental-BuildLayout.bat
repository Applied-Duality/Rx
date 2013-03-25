@echo off

set RxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a

copy "%BinariesLayoutFolder%\rx.experimental.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.experimental.min.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.experimental-vsdoc.js" "%OutputSetupFolder%\"
