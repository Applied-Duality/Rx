@echo off

set RxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a

copy "%BinariesLayoutFolder%\rx.aggregates.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.aggregates.min.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.aggregates-vsdoc.js" "%OutputSetupFolder%\"
