@echo off

setlocal EnableDelayedExpansion
set plugins_len=5
set plugins[0].name=..\FengSharp.OneCardAccess.Client.PCManage.Host\publishbuild.bat
set plugins[0].dir=..\FengSharp.OneCardAccess.Client.PCManage.Host
set plugins[1].name=..\FengSharp.OneCardAccess.Client.PCManage.MainStruct\publishbuild.bat
set plugins[1].dir=..\FengSharp.OneCardAccess.Client.PCManage.MainStruct
set plugins[2].name=..\FengSharp.OneCardAccess.Client.PCManage.Common\publishbuild.bat
set plugins[2].dir=..\FengSharp.OneCardAccess.Client.PCManage.Common
set plugins[3].name=..\FengSharp.OneCardAccess.Client.PCManage.Basic\publishbuild.bat
set plugins[3].dir=..\FengSharp.OneCardAccess.Client.PCManage.Basic
set plugins[4].name=..\FengSharp.OneCardAccess.Client.PCManage.SystemSet\publishbuild.bat
set plugins[4].dir=..\FengSharp.OneCardAccess.Client.PCManage.SystemSet
for /l %%j in (0,1,!plugins_len!) do (
	set bpathindex=%%j
	set bpath=!.!plugins[!bpathindex!].name!!
	set bdir=!.!plugins[!bpathindex!].dir!!
	call :Runbuild !bpath! !bdir!
)

set files_len=17
set /a flen=files_len-1
set files[0].name=FengSharp.OneCardAccess.DBUtility.dll
set files[1].name=FengSharp.OneCardAccess.Common.dll
set files[2].name=FengSharp.Tool.dll
set files[3].name=FengSharp.WinForm.Dev.dll
set files[4].name=Microsoft.Practices.EnterpriseLibrary.Caching.dll
set files[5].name=Microsoft.Practices.EnterpriseLibrary.Common.dll
set files[6].name=Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.dll
set files[7].name=Microsoft.Practices.EnterpriseLibrary.Logging.dll
set files[8].name=Microsoft.Practices.EnterpriseLibrary.PolicyInjection.CallHandlers.dll
set files[9].name=Microsoft.Practices.EnterpriseLibrary.PolicyInjection.dll
set files[10].name=Microsoft.Practices.EnterpriseLibrary.Security.dll
set files[11].name=Microsoft.Practices.EnterpriseLibrary.Validation.dll
set files[12].name=Microsoft.Practices.ObjectBuilder2.dll
set files[13].name=Microsoft.Practices.Unity.Configuration.dll
set files[14].name=Microsoft.Practices.Unity.dll
set files[15].name=Microsoft.Practices.Unity.Interception.dll
set files[16].name=Newtonsoft.Json.dll
set common_path=D:\Work\Project\Company\OneCardAccess\Publish\PCManage\lib
md %common_path%
set work_path=D:\Work\Project\Company\OneCardAccess\Publish\PCManage
cd %work_path%
for /r %%s in (*.dll) do (
	set mypath=%%s
	if "!mypath:%common_path%=!"=="%%s" (
		for /l %%j in (0,1,!flen!) do (
			set c=%%j
			set currentfilename=!.!files[!c!].name!!
			call :RemoveIfSameFileName !mypath! !currentfilename!
		)
	)
)
pause
exit

:Runbuild
set bpath=!%1!
set bdir=!%2!
call !bpath! !bdir!
goto :eof

:RemoveIfSameFileName
set currentpath=!%1!
set currentfilename=!%2!
if not "!currentpath:%currentfilename%=!"=="!currentpath!" (
	move !mypath! !common_path!\!%2!
)
goto :eof