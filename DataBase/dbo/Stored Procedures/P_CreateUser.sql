--CREATE PROCEDURE P_CreateUser
CREATE PROCEDURE P_CreateUser
(
	@UserId varchar(36) output,
	@UserNo varchar(50),
	@UserName varchar(50),
	@UserPassWord varchar(50),
	@IsLock bit,
	@Remark varchar(100),
	@CreateId varchar(36)
)
AS
declare @errmsg varchar(max)
select 1 from T_User where UserNo=@UserNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @UserId = newid()
insert into T_User (
   UserId,--用户Id
   UserNo,--用户账号
   UserName,--用户名称
   UserPassWord,--用户密码
   IsLock,--是否锁定
   Deleted,--删除标识
   Remark,--备注
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   IsUserAuthority--是否启用用户权限
)
values(
   @UserId,--用户Id
   @UserNo,--用户账号
   @UserName,--用户名称
   @UserPassWord,--用户密码
   @IsLock,--是否锁定
   0,--删除标识
   @Remark,--备注
   @CreateId,--创建人
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0--是否启用用户权限
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
