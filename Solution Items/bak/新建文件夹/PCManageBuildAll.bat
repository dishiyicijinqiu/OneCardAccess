@echo off
@rem ------传入当前目录------
@pushd "%~dp0"
@rem ------删除现有文件------
rd ..\Publish\IntegratedManageClient /s/q
@rem ------删除现有文件------
@rem ------调用bat生成解决方案------
@call publishbuild.bat build ..\Presentation.IntegeatedManage.BSS\Presentation.IntegeatedManage.BSS.csproj ..\Publish\IntegratedManageClient\Plugins\BSS
@call publishbuild.bat build ..\Presentation.IntegeatedManage.CRM\Presentation.IntegeatedManage.CRM.csproj ..\Publish\IntegratedManageClient\Plugins\CRM
@call publishbuild.bat build ..\Presentation.IntegeatedManage.HR\Presentation.IntegeatedManage.HR.csproj ..\Publish\IntegratedManageClient\Plugins\HR
@call publishbuild.bat build ..\Presentation.IntegeatedManage.SystemSet\Presentation.IntegeatedManage.SystemSet.csproj ..\Publish\IntegratedManageClient\Plugins\SystemSet
@call publishbuild.bat build ..\Presentation.IntegeatedManage.MainStruct\Presentation.IntegeatedManage.MainStruct.csproj ..\Publish\IntegratedManageClient
@rem ------将公用的DLL移动到临时目录------
@call publishbuild.bat movecommondlltotemp Microsoft.Practices*.dll
pause
@rem ------删除无用的文件------
@call publishbuild.bat delunusefile Microsoft.Practices*.dll
@call publishbuild.bat delunusefile *.xml
@call publishbuild.bat delunusefile *.pdb
@call publishbuild.bat delunusefile *.Designer.dll
pause
@rem ------将公用的DLL移动到Lib目录------
@call publishbuild.bat movecommondllfromtemp Microsoft.Practices*.dll
@rem ------删除含有Microsoft.Practices的dll和xml------
del /a /f /q /s ..\Publish\IntegratedManageClient\Microsoft.Practices*.dll /s
del /a /f /q /s ..\Publish\IntegratedManageClient\*.xml /s
del /a /f /q /s ..\Publish\IntegratedManageClient\*.pdb /s
del /a /f /q /s ..\Publish\IntegratedManageClient\*.Designer.dll /s
@rem del /a /f /q /s ..\Publish\IntegratedManageClient\*.xml /s
@rem rd ..\Publish\IntegratedManageClient\Microsoft.Practices*.dll /s
@rem rd ..\Publish\IntegratedManageClient\*.xml /s
@rem rd ..\Publish\IntegratedManageClient\*.pdb /s
@rem rd ..\Publish\IntegratedManageClientLibDLL\*.dll /s
@rem ------复制公共DLL-------------
@rem xcopy ..\Publish\IntegratedManageClientLibDLL\*.dll ..\Publish\IntegratedManageClient\Lib /y
@rem ------延时关闭------
@ping localhost -n 3 >nul
@rem pause暂停
pause


@rem setlocal EnableDelayedExpansion
@rem set plugins_len=5
@rem set plugins[0].name=..\FengSharp.OneCardAccess.Client.PCManage.Host\publishbuild.bat
@rem set plugins[0].dir=..\FengSharp.OneCardAccess.Client.PCManage.Host
@rem set plugins[1].name=..\FengSharp.OneCardAccess.Client.PCManage.MainStruct\publishbuild.bat
@rem set plugins[1].dir=..\FengSharp.OneCardAccess.Client.PCManage.MainStruct
@rem set plugins[2].name=..\FengSharp.OneCardAccess.Client.PCManage.Common\publishbuild.bat
@rem set plugins[2].dir=..\FengSharp.OneCardAccess.Client.PCManage.Common
@rem set plugins[3].name=..\FengSharp.OneCardAccess.Client.PCManage.Basic\publishbuild.bat
@rem set plugins[3].dir=..\FengSharp.OneCardAccess.Client.PCManage.Basic
@rem set plugins[4].name=..\FengSharp.OneCardAccess.Client.PCManage.SystemSet\publishbuild.bat
@rem set plugins[4].dir=..\FengSharp.OneCardAccess.Client.PCManage.SystemSet
@rem for /l %%j in (0,1,!plugins_len!) do (
@rem 	set bpathindex=%%j
@rem 	set bpath=!.!plugins[!bpathindex!].name!!
@rem 	set bdir=!.!plugins[!bpathindex!].dir!!
@rem 	call :Runbuild !bpath! !bdir!
@rem )
@rem 
@rem set files_len=17
@rem set /a flen=files_len-1
@rem set files[0].name=FengSharp.OneCardAccess.DBUtility.dll
@rem set files[1].name=FengSharp.OneCardAccess.Common.dll
@rem set files[2].name=FengSharp.Tool.dll
@rem set files[3].name=FengSharp.WinForm.Dev.dll
@rem set files[4].name=Microsoft.Practices.EnterpriseLibrary.Caching.dll
@rem set files[5].name=Microsoft.Practices.EnterpriseLibrary.Common.dll
@rem set files[6].name=Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.dll
@rem set files[7].name=Microsoft.Practices.EnterpriseLibrary.Logging.dll
@rem set files[8].name=Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.dll
@rem set files[9].name=Microsoft.Practices.EnterpriseLibrary.PolicyInjection.dll
@rem set files[10].name=Microsoft.Practices.EnterpriseLibrary.Security.dll
@rem set files[11].name=Microsoft.Practices.EnterpriseLibrary.Validation.dll
@rem set files[12].name=Microsoft.Practices.ObjectBuilder2.dll
@rem set files[13].name=Microsoft.Practices.Unity.Configuration.dll
@rem set files[14].name=Microsoft.Practices.Unity.dll
@rem set files[15].name=Microsoft.Practices.Unity.Interception.dll
@rem set files[16].name=Newtonsoft.Json.dll
@rem set common_path=D:\Work\Project\Company\OneCardAccess\Publish\PCManage\lib
@rem md %common_path%
@rem set work_path=D:\Work\Project\Company\OneCardAccess\Publish\PCManage
@rem cd %work_path%
@rem for /r %%s in (*.dll) do (
@rem 	set mypath=%%s
@rem 	if "!mypath:%common_path%=!"=="%%s" (
@rem 		for /l %%j in (0,1,!flen!) do (
@rem 			set c=%%j
@rem 			set currentfilename=!.!files[!c!].name!!
@rem 			call :RemoveIfSameFileName !mypath! !currentfilename!
@rem 		)
@rem 	)
@rem )
@rem pause
@rem exit
@rem 
@rem :Runbuild
@rem set bpath=!%1!
@rem set bdir=!%2!
@rem call !bpath! !bdir!
@rem goto :eof

@rem :RemoveIfSameFileName
@rem set currentpath=!%1!
@rem set currentfilename=!%2!
@rem if not "!currentpath:%currentfilename%=!"=="!currentpath!" (
@rem 	move !mypath! !common_path!\!%2!
@rem )
@rem goto :eof