
--主体数据库备份脚本
BACKUP DATABASE [JXTest] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\JXTest.bak' WITH NOFORMAT, NOINIT, 
 NAME = N'JXTest-完整 数据库 备份', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

--镜像还原数据库脚本
USE [master]
BACKUP LOG [JXTest] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\JXTest_LogBackup_2015-12-04_21-05-03.bak' WITH NOFORMAT, NOINIT,
  NAME = N'JXTest_LogBackup_2015-12-04_21-05-03', NOSKIP, NOREWIND, NOUNLOAD,  NORECOVERY ,  STATS = 5
RESTORE DATABASE [JXTest] FROM  DISK = N'C:\JXTest.bak' WITH  FILE = 1,  NORECOVERY,  NOUNLOAD,  REPLACE,  STATS = 5
RESTORE LOG [JXTest] FROM  DISK = N'C:\JXTest.bak' WITH  FILE = 2,  NORECOVERY,  NOUNLOAD,  STATS = 5

GO

--镜像数据库停止还原
use master
restore database JXTest with recovery
GO


