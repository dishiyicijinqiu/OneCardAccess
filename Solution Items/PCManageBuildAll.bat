@echo off
@rem ------���뵱ǰĿ¼------
@pushd "%~dp0"
@goto :Debug
@rem ------ɾ�������ļ�------
rd ..\Publish\IntegratedManageClient /s/q
@rem ------ɾ�������ļ�------
@rem ------����bat���ɽ������------
@call publishbuild.bat build ..\Presentation.IntegeatedManage.BSS\Presentation.IntegeatedManage.BSS.csproj ..\Publish\IntegratedManageClient\Plugins\BSS
@call publishbuild.bat build ..\Presentation.IntegeatedManage.CRM\Presentation.IntegeatedManage.CRM.csproj ..\Publish\IntegratedManageClient\Plugins\CRM
@call publishbuild.bat build ..\Presentation.IntegeatedManage.HR\Presentation.IntegeatedManage.HR.csproj ..\Publish\IntegratedManageClient\Plugins\HR
@call publishbuild.bat build ..\Presentation.IntegeatedManage.SystemSet\Presentation.IntegeatedManage.SystemSet.csproj ..\Publish\IntegratedManageClient\Plugins\SystemSet
@call publishbuild.bat build ..\Presentation.IntegeatedManage.MainStruct\Presentation.IntegeatedManage.MainStruct.csproj ..\Publish\IntegratedManageClient

@rem ------�������ļ����ýڼ���------
:Debug
cd ..\
set pulishpath=%cd%\Publish\IntegratedManageClient
cd "Solution Items"
ren ..\Publish\IntegratedManageClient\OneCardAccessIntegeatedManageClient.exe.config web.config
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/extensions" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.serviceModel/bindings" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "appSettings" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "cachingConfiguration" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "unity" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "runtime" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.web" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pef "system.web/membership" "%pulishpath%" -prov "SZKLRsaProtectedConfigurationProvider"
ren ..\Publish\IntegratedManageClient\web.config OneCardAccessIntegeatedManageClient.exe.config
pause
pause
pause
pause
@rem ------�����õ�DLL�ƶ�����ʱĿ¼------
@call publishbuild.bat movecommondlltotemp Microsoft.Practices*.dll
@call publishbuild.bat movecommondlltotemp GZipEncoder.dll
@call publishbuild.bat movecommondlltotemp FengSharp.Tool.dll
@call publishbuild.bat movecommondlltotemp FengSharp.WinForm.Dev.dll
@call publishbuild.bat movecommondlltotemp Newtonsoft.Json.dll
@rem ------ɾ�����õ��ļ�------
@call publishbuild.bat delunusefile GZipEncoder.dll
@call publishbuild.bat delunusefile FengSharp.Tool.dll
@call publishbuild.bat delunusefile FengSharp.WinForm.Dev.dll
@call publishbuild.bat delunusefile Newtonsoft.Json.dll
@call publishbuild.bat delunusefile Microsoft.Practices*.dll
@call publishbuild.bat delunusefile *.xml
@call publishbuild.bat delunusefile *.pdb
@call publishbuild.bat delunusefile *.Designer.dll
@rem ------�����õ�DLL�ƶ���LibĿ¼------
@call publishbuild.bat movecommondllfromtemp

@rem ------��ʱ�ر�------
@ping localhost -n 3 >nul
pause
@rem pause��ͣ
