--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_AddRoleMenu')
--	BEGIN
--		DROP  Procedure  P_AddRoleMenu
--	END
--GO
CREATE PROCEDURE P_AddRoleMenu
(
	@RoleId VARCHAR(36),
	@MenuNo VARCHAR(50)
)
AS
insert into T_RoleMenu(RoleId,MenuNo) values(@RoleId,@MenuNo);
