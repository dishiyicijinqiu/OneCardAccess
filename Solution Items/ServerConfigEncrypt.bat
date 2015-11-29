@echo off
@pushd "%~dp0"
@rem ------------------------------------------------------加密------------------------------------------------------
@rem ---------------------------将加密配置节所需的DLL拷贝到Framework目录---------------------------
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.EnterpriseLibrary.Logging.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.Unity.Configuration.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.EnterpriseLibrary.Common.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.EnterpriseLibrary.Data.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.Unity.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.Unity.Interception.Configuration.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.Unity.Interception.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\Microsoft.Practices.EnterpriseLibrary.Caching.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\FengSharp.OneCardAccess.Infrastructure.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y
xcopy ..\Application.IntegeatedManageServer\bin\FengSharp.OneCardAccess.Infrastructure.Services.dll %WINDIR%\Microsoft.NET\Framework\v4.0.30319 /r/y

@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "loggingConfiguration" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "dataConfiguration" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "connectionStrings" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "appSettings" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "cachingConfiguration" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "unity" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/behaviors" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/extensions" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/serviceHostingEnvironment" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/bindings" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/services" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.serviceModel/behaviors" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.web/compilation" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis -pe "system.web/httpRuntime" -app "/" -prov "SZKLRsaProtectedConfigurationProvider"
@rem ------------------------------------------------------解密------------------------------------------------------
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "loggingConfiguration" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "dataConfiguration" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "connectionStrings" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "appSettings" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "cachingConfiguration" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "unity" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/behaviors" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/extensions" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/serviceHostingEnvironment" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/bindings" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/services" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.serviceModel/behaviors" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.web/compilation" -app "/"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -pd "system.web/httpRuntime" -app "/"
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