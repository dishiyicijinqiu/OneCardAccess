--CREATE PROCEDURE P_AuthenticateUser
CREATE PROCEDURE P_AuthenticateUser
	@UserNo varchar(50),
	@UserPassWord varchar(50)
AS
	SELECT UserId from T_User where UserNo=@UserNo and UserPassWord=@UserPassWord and IsLock=0 and Deleted=0
