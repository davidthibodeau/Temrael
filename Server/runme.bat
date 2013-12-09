cd Server
SET DOTNET=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727
SET PATH=%DOTNET%
csc.exe /win32icon:runuo.ico /r:Ultima.dll /debug /nowarn:0618 /nologo /out:..\RunUO.exe /unsafe /recurse:*.cs
cd ..
title RunUO
echo off
cls
RunUO.exe