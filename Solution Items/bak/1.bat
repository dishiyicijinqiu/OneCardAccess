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


echo ��ǰ�̷���%~d0
echo ��ǰ�̷���·����%~dp0
echo ��ǰ�̷���·���Ķ��ļ�����ʽ��%~sdp0
echo ��ǰ������ȫ·����%~f0
echo ��ǰCMDĬ��Ŀ¼��%cd%