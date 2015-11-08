--CREATE PROCEDURE P_CreateCompany
CREATE PROCEDURE P_CreateCompany
(
	@CompanyId int output,
	@CompanyNo varchar(50),
	@CompanyName varchar(150),
	@Address varchar(200),
	@Tel varchar(50),
	@Fax varchar(50),
	@PostCode varchar(50),
	@EMail varchar(100),
	@Person varchar(50),
	@BankAndAcount varchar(50),
	@TaxNumber varchar(50),
	@ARTotal numeric(9),
	@APTotal numeric(9),
	@Remark varchar(200),
	@Password varchar(100),
	@CreateId varchar(36),
	@PId int
)
AS
declare @errmsg varchar(max)
select @CompanyId=0
select 1 from T_Company where CompanyNo=@CompanyNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_Company where CompanyId=@PId
set @Level_Deep = @Level_Deep+1;
--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;
--获取树路径
insert into T_Company (
   CompanyNo,--单位编号
   CompanyName,--单位名称
   Address,--单位地址
   Tel,--电话
   Fax,--传真
   PostCode,--邮政编码
   EMail,--电子邮件
   Person,--联系人
   BankAndAcount,--开户银行
   TaxNumber,--税号
   ARTotal,--应收
   APTotal,--应付
   Remark,--备注
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted,--删除标志
   Password,--登陆密码
   Enable,--是否启用
   PId,--父Id
   Level_Path,--树形结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep--树的深度
)
values(
   @CompanyNo,--单位编号
   @CompanyName,--单位名称
   @Address,--单位地址
   @Tel,--电话
   @Fax,--传真
   @PostCode,--邮政编码
   @EMail,--电子邮件
   @Person,--联系人
   @BankAndAcount,--开户银行
   @TaxNumber,--税号
   @ARTotal,--应收
   @APTotal,--应付
   @Remark,--备注
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0,--删除标志
   @Password,--登陆密码
   1,--是否启用
   @PId,--父Id
   @Level_Path,--树形结构路径
   0,--儿子数量
   0,--子孙数量
   @Level_Deep--树的深度
);

set @CompanyId = @@IDENTITY;--获取插入的实体id

if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_Company set Level_Total=Level_Total+1 where CompanyId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_Company set Level_Num=Level_Num+1 where CompanyId=@PId
	--更新父级节点的子孙数量
end

if(@Level_Path='') set @Level_Path=cast(@CompanyId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@CompanyId as varchar(20))
update T_Company set Level_Path=@Level_Path where CompanyId=@CompanyId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
