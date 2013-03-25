@echo off

set RxRelease=%3

for %%a in (%1) do set BinariesLayoutFolder=%%~a
for %%a in (%2) do set OutputSetupFolder=%%~a

copy "%BinariesLayoutFolder%\rx.joinpatterns.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.joinpatterns.min.js" "%OutputSetupFolder%\"
copy "%BinariesLayoutFolder%\rx.joinpatterns-vsdoc.js" "%OutputSetupFolder%\"
