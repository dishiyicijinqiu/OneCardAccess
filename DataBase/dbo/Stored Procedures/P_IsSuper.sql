--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_IsSuper')
--	BEGIN
--		DROP  Procedure  P_IsSuper
--	END
--GO
--CREATE PROCEDURE P_IsSuper
CREATE PROCEDURE P_IsSuper
(
	@UserId VARCHAR(36),
	@IsSuper bit output
)
AS


select 1 from T_Role r 
join T_UserInRole ur on r.RoleId = ur.RoleId and r.IsSuper=1
join T_User u on ur.UserId = u.UserId and u.UserId=@UserId and u.Deleted=0 and u.IsLock=0
if(@@ROWCOUNT<=0) set @IsSuper = 0;
else set @IsSuper = 1;