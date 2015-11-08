--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_AddRoleAction')
--	BEGIN
--		DROP  Procedure  P_AddRoleAction
--	END
--GO
CREATE PROCEDURE P_AddRoleAction
(
	@RoleId VARCHAR(36),
	@ActionNo VARCHAR(50)
)
AS
insert into T_RoleAction(RoleId,ActionNo) values(@RoleId,@ActionNo);
