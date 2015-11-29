D:
set dllpath=D:\Work\Project\MyProject\OneCardAccess\Presentation.IntegeatedManage.BSS\Presentation.IntegeatedManage.BSS.csproj
@rem \Presentation.IntegeatedManage.BSS.csproj
set outpath=D:\Work\Project\MyProject\OneCardAccess\Publish\IntegratedManageClient\Plugins
cd %dllpath%
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" %dllpath% /p:Configuration=Release,Outdir=%outpath%
@rem C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe %dllpath% /p:Configuration=Release,Outdir=%outpath%
@ping localhost -n 3 >nul
@rem pauseÔİÍ£
pause