set bin="c:\Bin"

msbuild /p:Configuration=Release40
msbuild /p:Configuration=Debug40
msbuild /p:Configuration=Release45
msbuild /p:Configuration=Debug45

copy ..\tools\NuGet.exe %bin%\

pushd

cd %bin%\Debug
call :packAll

cd %bin%\Release
call :packAll

popd
goto end

:packAll
call :pack Tx.Core
call :pack Tx.Windows
call :pack Tx.Windows.TypeGeneration
call :pack Tx.SqlServer
call :pack Tx.All

exit /b 0

:pack %1
call Net40\%1.Layout.cmd
cd %1
copy ..\Net40\%1.nuspec
..\..\NuGet pack %1.nuspec
move *.nupkg ..\
cd ..
rd /s/q %1
exit /b 0

:end
popd
exit /b 0
