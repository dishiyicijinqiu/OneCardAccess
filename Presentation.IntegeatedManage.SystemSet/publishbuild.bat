if not "%1"=="1" (
	cd %1%
)
set publishpath=..\publish\
set pluginspath=PCManage\plugins\SystemSet
set "fupath=%publishpath%%pluginspath%" 
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /p:Configuration=Release,Outdir=%fupath%,DebugSymbols=false,debuginfo='none',UseHostCompilerIfAvailable=false
PING -n 1 localhost
del %fupath%\*.pdb