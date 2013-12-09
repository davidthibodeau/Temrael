@echo off
if exist runuo.exe del runuo.exe
if exist runuo.exe goto locked
cd Server
SET PATH=%WINDIR%\Microsoft.NET\Framework\v2.0.50727
csc.exe /out:.\RunUO.exe /recurse:*.cs /win32icon:runuo.ico /optimize /unsafe /warn:4
move runuo.exe ..
cd ..
if not exist runuo.exe goto failed
runuo.exe
exit

:failed
echo "Compile failed!"
pause
exit
:locked
echo "Please stop the running RunUO.EXE and try again!"
pause
exit