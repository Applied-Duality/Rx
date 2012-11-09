@echo off
echo Extracting the Tx samples into c:\TxSamples
echo this will wipe clean the above directory, so please don't keep your work there
Pause

set TARGET_DIR=c:\TxSamples

if exist "%TARGET_DIR%" rd /s/q "%TARGET_DIR%"
md "%TARGET_DIR%"

call :extract Introduction
call :extract LinqPad

start c:\TxSamples


goto :end

:extract

ZipIt -Read %1.zip "%TARGET_DIR%"\%1

:end