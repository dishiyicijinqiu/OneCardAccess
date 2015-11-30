@echo off
@pushd "%~dp0"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pi "SZKL" "keys.xml"
pause