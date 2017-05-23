@echo off
if exist heightmap2stl-gui.zip del heightmap2stl-gui.zip
powershell -NoProfile -ExecutionPolicy Bypass -Command "Compress-Archive -Path .\Bin\Release\heightmap2stl-gui.exe, .\Bin\Release\heightmap2stl-gui.exe.config -CompressionLevel Optimal -DestinationPath .\heightmap2stl-gui.zip"