@echo off
call msbuildpath.bat
"%MSBUILDDIR%msbuild.exe" heightmap2stl-gui.csproj /p:Configuration=Release