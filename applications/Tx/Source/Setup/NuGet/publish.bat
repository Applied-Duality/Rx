@echo off
echo Publish Tx NuGet packages
echo -------------------------
echo.

IF "%1"=="" GOTO :Cmdline

echo.
FOR /F %%i IN ('DIR /B *.nupkg') DO nuget.exe push %%i %1

GOTO :EOF

:Cmdline
echo Usage:  publish.bat ^<API key^>
echo.
echo You can get the API key at http://www.nuget.org/Contribute/MyAccount using
echo the rxteam account. For the password, contact mailto:rxdev.
