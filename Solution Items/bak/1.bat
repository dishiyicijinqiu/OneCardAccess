@rem go to target folder
@pushd "%~dp0"
echo %cd%
pause
@call 2\2.bat /q
if errorlevel 1 goto ERROR

goto :END
:ERROR
@exit errorLevel
:END
PING -n 2 localhsot


echo 当前盘符：%~d0
echo 当前盘符和路径：%~dp0
echo 当前盘符和路径的短文件名格式：%~sdp0
echo 当前批处理全路径：%~f0
echo 当前CMD默认目录：%cd%