Create PROCEDURE P_UpdateRawMate
--ALTER PROCEDURE P_UpdateRawMate
(
@RawMateId int,--主键Id
@RawMateNo varchar(50),--原材料编号
@RawMateName varchar(100),--原材料名称
@Spec varchar(50),--规格型号
@MinStore numeric(9),--最小库存
@MaxStore numeric(9),--最大库存
@Unit varchar(20),--计量单位
@IsRemind bit,--库存报警标识
@QtyMode smallint,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
@preprice1 numeric(9),--预设价格1
@preprice2 numeric(9),--预设价格2
@preprice3 numeric(9),--预设价格3
@recprice numeric(9),--最近价格
@Remark1 varchar(500),--备注1
@Remark2 varchar(500),--备注2
@Remark3 varchar(500),--备注3
@Remark4 varchar(500),--备注4
@LastModifyId varchar(36)--最后更改人Id
)
AS
declare @errmsg varchar(max)
select 1 from T_RawMate where RawMateNo=@RawMateNo and RawMateId<>@RawMateId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_RawMate set 
RawMateNo=@RawMateNo,--原材料编号
RawMateName=@RawMateName,--原材料名称
Spec=@Spec,--规格型号
MinStore=@MinStore,--最小库存
MaxStore=@MaxStore,--最大库存
Unit=@Unit,--计量单位
IsRemind=@IsRemind,--库存报警标识
QtyMode=@QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
preprice1=@preprice1,--预设价格1
preprice2=@preprice2,--预设价格2
preprice3=@preprice3,--预设价格3
recprice=@recprice,--最近价格
Remark1=@Remark1,--备注1
Remark2=@Remark2,--备注2
Remark3=@Remark3,--备注3
Remark4=@Remark4,--备注4
LastModifyId=@LastModifyId,--最后更改人Id
LastModifyDate=getdate()--最后更改日期
where RawMateId=@RawMateId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败