@rem This is post build step that sets locally the data context driver and the samples

@echo off

if not "%1" == "" cd %1

set DRIVER_DIR=c:\ProgramData\LINQPad\Drivers\DataContext\4.0\TxLinqPadDriver (3d3a4b0768c9178e)
if not exist "%DRIVER_DIR%" md "%DRIVER_DIR%"

set TYPE_DIR=%DRIVER_DIR%\EventTypes
if not exist "%TYPE_DIR%" md "%TYPE_DIR%"

set BIN_DIR=%ProgramFiles(x86)%\Microsoft SDKs\LINQ to Traces\v1.0\Binaries\.NETFramework\v4.0"
if not exist "%DRIVER_DIR%" md "%DRIVER_DIR%"

 
call :copy_dll System.Reactive.Tx
call :copy_dll Microsoft.Etw
call :copy_dll Microsoft.Etw.TypeGeneration
call :copy_exe EtwEventTypeGen
call :copy_dll TxLinqPadDriver

echo Reactive Binaries
copy ..\References\System.Reactive.Interfaces.dll "%DRIVER_DIR%"\
copy ..\References\System.Reactive.Core.dll "%DRIVER_DIR%"\
copy ..\References\System.Reactive.Linq.dll "%DRIVER_DIR%"\
copy ..\References\System.Reactive.PlatformServices.dll "%DRIVER_DIR%"\

echo XEvent
copy ..\References\XEvent\* "%BIN_DIR%"\
copy Microsoft.XEvent\bin\Debug\Microsoft.XEvent.* "%BIN_DIR%"\

echo header.xml
copy TxLinqPadDriver\header.xml "%DRIVER_DIR%"\

goto end

:copy_dll
echo %1.dll
copy %1\bin\debug\%1.dll "%DRIVER_DIR%"\
copy %1\bin\debug\%1.pdb "%DRIVER_DIR%"\
copy %1\bin\debug\%1.dll "%BIN_DIR%"\
copy %1\bin\debug\%1.pdb "%BIN_DIR%"\
exit /b 0

:copy_exe
echo %1.exe
copy %1\bin\debug\%1.exe "%DRIVER_DIR%"\
copy %1\bin\debug\%1.pdb "%DRIVER_DIR%"\
copy %1\bin\debug\%1.exe "%BIN_DIR%"\
copy %1\bin\debug\%1.pdb "%BIN_DIR%"\
exit /b 0

:end
exit /b 0