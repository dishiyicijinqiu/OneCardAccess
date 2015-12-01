@rem %1% 操作方法build生成解决方案
@rem %2% 当%1%为build的时代表：项目文件
@rem %3% 当%1%为build的时代表：输出路径

if "%1"=="build" goto BUILD
if "%1"=="movecommondlltotemp" goto MOVECOMMONDLLTOTEMP
if "%1"=="delunusefile" goto DELUNUSEFILE
if "%1"=="movecommondllfromtemp" goto MOVECOMMONDLLFROMTEMP

@goto :exit

:BUILD
set dllpath=%2%
@rem echo %2%
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe %dllpath% /p:Configuration=Release /p:DebugSymbols=false /p:DebugType=None /p:Outdir=%3%
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" %dllpath% /p:Configuration=Release /p:DebugSymbols=false /p:DebugType=None /p:Outdir=%3%
@goto :exit

:MOVECOMMONDLLTOTEMP
xcopy ..\Publish\IntegratedManageClient\Plugins\BSS\%2% ..\Publish\IntegratedManageClientLibDLL /r/y/q
xcopy ..\Publish\IntegratedManageClient\Plugins\CRM\%2% ..\Publish\IntegratedManageClientLibDLL /r/y/q
xcopy ..\Publish\IntegratedManageClient\Plugins\HR\%2% ..\Publish\IntegratedManageClientLibDLL /r/y/q
xcopy ..\Publish\IntegratedManageClient\Plugins\SystemSet\%2% ..\Publish\IntegratedManageClientLibDLL /r/y/q
xcopy ..\Publish\IntegratedManageClient\%2% ..\Publish\IntegratedManageClientLibDLL /r/y/q
@goto :exit

:DELUNUSEFILE
del /a /f /q /s ..\Publish\IntegratedManageClient\%2%
@goto :exit

:MOVECOMMONDLLFROMTEMP
xcopy ..\Publish\IntegratedManageClientLibDLL\*.* ..\Publish\IntegratedManageClient\Lib\ /e/y/q
@goto :exit

:exit




@rem "C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" %1% Outdir=%3%;/p:Configuration=Release;DebugSymbols=false;debuginfo='none';UseHostCompilerIfAvailable=false;TargetFrameworkVersion=v4.0
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe %1% Outdir=%fupath%
@rem /p:Configuration=Release,Outdir=%fupath%,DebugSymbols=false,debuginfo='none',UseHostCompilerIfAvailable=false
@rem MSBuild MyApp.sln /t:Rebuild /p:Configuration=Release 重新生成release模式
@rem MSBuild MyApp.csproj /t:Clean 清除解决方案
@rem					  /p:Configuration=Debug;TargetFrameworkVersion=v3.5调试模式Framework版本V3.5
@rem del %fupath%\*.pdb