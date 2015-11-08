CREATE PROCEDURE P_GetDicDataByDicTypes
--CREATE PROCEDURE P_GetDicDataByDicTypes
(
	@DicTypes VARCHAR(max)
)
AS 
--select * from T_DicData where DicType in (@DicTypes);
exec ('select * from T_DicData where DicType in ('+@DicTypes+')')