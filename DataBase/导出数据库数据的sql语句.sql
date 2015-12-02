use OneCardAccessDB

DECLARE @tablename varchar(200)
declare GeneDataBaseSql_cursor cursor for
select TABLE_NAME from INFORMATION_SCHEMA.TABLES 
--where TABLE_NAME='T_Employee'
OPEN GeneDataBaseSql_cursor
FETCH NEXT FROM GeneDataBaseSql_cursor INTO @tablename
WHILE @@FETCH_STATUS = 0 
BEGIN

EXECUTE [dbo].[UspOutputData]  @tablename


FETCH NEXT FROM GeneDataBaseSql_cursor INTO @tablename
END
CLOSE GeneDataBaseSql_cursor
DEALLOCATE GeneDataBaseSql_cursor