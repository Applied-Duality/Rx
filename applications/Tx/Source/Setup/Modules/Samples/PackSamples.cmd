call :pack_samples Introduction
call :pack_samples LINQPad

goto end

:pack_samples

set SOURCE_DIR=..\..\..\..\Samples\%1
set TARGET_DIR=%temp%\TxSamples\%1

if exist "%TARGET_DIR%" rd /s /q "%TARGET_DIR%"
md "%TARGET_DIR%"
xcopy /s /y "%SOURCE_DIR%"\* "%TARGET_DIR%"\

attrib -r -h /s "%TARGET_DIR%"\*

..\..\..\..\Tools\RemoveTfsBindings "%TARGET_DIR%"
..\..\..\..\Tools\ZipIt -Create %1.zip "%TARGET_DIR%"

rd /s /q "%TARGET_DIR%"


:end
exit /b 0
