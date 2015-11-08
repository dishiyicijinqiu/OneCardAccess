--Create PROCEDURE P_UpdateCompany
CREATE PROCEDURE P_UpdateCompany
(
	@CompanyId int,
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
	@LastModifyId varchar(36),
	@Password varchar(100),
	@Enable bit
)
AS
declare @errmsg varchar(max)
select 1 from T_Company where CompanyNo=@CompanyNo and CompanyId<>@CompanyId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Company set 
	CompanyNo=@CompanyNo,
	CompanyName=@CompanyName,
	Address=@Address,
	Tel=@Tel,
	Fax=@Fax,
	PostCode=@PostCode,
	EMail=@EMail,
	Person=@Person,
	BankAndAcount=@BankAndAcount,
	TaxNumber=@TaxNumber,
	ARTotal=@ARTotal,
	APTotal=@APTotal,
	Remark=@Remark,
	LastModifyId=@LastModifyId,
	LastModifyDate=getdate(),
	Password=@Password,
	Enable=@Enable
where CompanyId=@CompanyId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
