@echo off
@rem ------------------------------------------------------传入当前目录------------------------------------------------------
@pushd "%~dp0"
@rem @goto :Debug
@rem ------------------------------------------------------删除现有文件------------------------------------------------------
rd ..\Publish\IntegratedManageClient /s/q
@rem ------------------------------------------------------调用bat生成解决方案------------------------------------------------------
@call publishbuild.bat build ..\Presentation.IntegeatedManage.BSS\Presentation.IntegeatedManage.BSS.csproj ..\Publish\IntegratedManageClient\Plugins\BSS
@call publishbuild.bat build ..\Presentation.IntegeatedManage.CRM\Presentation.IntegeatedManage.CRM.csproj ..\Publish\IntegratedManageClient\Plugins\CRM
@call publishbuild.bat build ..\Presentation.IntegeatedManage.HR\Presentation.IntegeatedManage.HR.csproj ..\Publish\IntegratedManageClient\Plugins\HR
@call publishbuild.bat build ..\Presentation.IntegeatedManage.SystemSet\Presentation.IntegeatedManage.SystemSet.csproj ..\Publish\IntegratedManageClient\Plugins\SystemSet
@call publishbuild.bat build ..\Presentation.IntegeatedManage.MainStruct\Presentation.IntegeatedManage.MainStruct.csproj ..\Publish\IntegratedManageClient

@rem ------------------------------------------------------给配置文件配置节加密------------------------------------------------------
@rem ---------------------------将加密配置节所需的DLL拷贝到Framework目录---------------------------
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.Unity.Configuration.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.EnterpriseLibrary.Common.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.Unity.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.Unity.Interception.Configuration.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.Unity.Interception.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\Microsoft.Practices.EnterpriseLibrary.Caching.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Publish\IntegratedManageClient\FengSharp.OneCardAccess.Infrastructure.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
cd ..\
set pulishpath=%cd%\Publish\IntegratedManageClient
cd "Solution Items"
ren ..\Publish\IntegratedManageClient\OneCardAccessIntegeatedManageClient.exe.config web.config
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "appSettings" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "cachingConfiguration" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "unity" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/behaviors" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/extensions" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/bindings" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/client" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
ren ..\Publish\IntegratedManageClient\web.config OneCardAccessIntegeatedManageClient.exe.config
@rem ------------------------------------------------------删除Dev无用文件夹------------------------------------------------------
rd ..\Publish\IntegratedManageClient\de\ /s/q
rd ..\Publish\IntegratedManageClient\es\ /s/q
rd ..\Publish\IntegratedManageClient\ja\ /s/q
rd ..\Publish\IntegratedManageClient\ru\ /s/q
@rem ------------------------------------------------------将公用的DLL移动到临时目录------------------------------------------------------
@call publishbuild.bat movecommondlltotemp Microsoft.Practices*.dll
@call publishbuild.bat movecommondlltotemp GZipEncoder.dll
@call publishbuild.bat movecommondlltotemp FengSharp.Tool.dll
@call publishbuild.bat movecommondlltotemp FengSharp.WinForm.Dev.dll
@call publishbuild.bat movecommondlltotemp Newtonsoft.Json.dll
@call publishbuild.bat movecommondlltotemp DevExpress.*.dll
@rem ------------------------------------------------------删除无用的文件------------------------------------------------------
@call publishbuild.bat delunusefile GZipEncoder.dll
@call publishbuild.bat delunusefile FengSharp.Tool.dll
@call publishbuild.bat delunusefile FengSharp.WinForm.Dev.dll
@call publishbuild.bat delunusefile Newtonsoft.Json.dll
@call publishbuild.bat delunusefile Microsoft.Practices*.dll
@call publishbuild.bat delunusefile Microsoft.Practices*.xml
@call publishbuild.bat delunusefile DevExpress*.dll
@call publishbuild.bat delunusefile DevExpress*.xml
@rem @call publishbuild.bat delunusefile *.xml
@call publishbuild.bat delunusefile *.pdb
@call publishbuild.bat delunusefile *.Designer.dll
@rem ------------------------------------------------------将公用的DLL移动到Lib目录------------------------------------------------------
@call publishbuild.bat movecommondllfromtemp

@rem ------------------------------------------------------延时关闭------------------------------------------------------
@ping localhost -n 3 >nul
@rem pause暂停



@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 
@rem 