--CREATE PROCEDURE P_CreateProduct
CREATE PROCEDURE P_CreateProduct
(
	@ProductId int output,
	@ProductNo varchar(50),
	@ProductName varchar(100),
	@ProductName1 varchar(100),
	@Spec varchar(100),
	@Spec1 varchar(100),
	@ProductType smallint,
	@ProductImage varchar(200),
	@Unit varchar(5),
	@Material varchar(10),
	@Code varchar(20),
	@GoodCode varchar(50),
	@CheckCodeOne varchar(10),
	@CheckCodeMany varchar(50),
	@PackQty int,
	@CertType smallint,
	@RegisterId varchar(36),
	@MinStore int,
	@MaxStore int,
	@Cycle numeric(9),
	@DrawingId int,
	@IsRemind bit,
	@QtyMode smallint,
	@preprice1 numeric(9),
	@preprice2 numeric(9),
	@preprice3 numeric(9),
	@preprice4 numeric(9),
	@recprice numeric(9),
	@Remark1 varchar(500),
	@Remark2 varchar(500),
	@Remark3 varchar(500),
	@Remark4 varchar(500),
	@Remark5 varchar(500),
	@Remark6 varchar(500),
	@Remark7 varchar(500),
	@Remark8 varchar(500),
	@ShowNo varchar(50),
	@ShowProductName varchar(100),
	@ShowSpec varchar(100),
	@ShowLOrR varchar(5),
	@ShowPos varchar(50),
	@IsShow bit,
	@IsNew bit,
	@NewRemark varchar(500),
	@PId int,
	@CreateId varchar(36)
)
AS
declare @errmsg varchar(max)
select @ProductId=0
select 1 from T_Product where ProductNo=@ProductNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_Product where ProductId=@PId
set @Level_Deep = @Level_Deep+1;
--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;
--获取树路径
insert into T_Product (
   ProductNo,--产品编号
   ProductName,--产品名称
   ProductName1,--产品名称(英文)
   Spec,--规格型号
   Spec1,--规格型号(英文)
   ProductType,--产品类型（成品，零部件）
   ProductImage,--产品大图
   Unit,--计量单位
   Material,--材料标识
   Code,--产品代码
   GoodCode,--货位号
   CheckCodeOne,--校验码（单）
   CheckCodeMany,--校验码（多）
   PackQty,--包装数量
   CertType,--证件类型（a证，b证）
   RegisterId,--产品注册证Id
   MinStore,--最小库存
   MaxStore,--最大库存
   Cycle,--生产周期（小时）
   DrawingId,--图纸Id
   IsRemind,--库存报警标识
   QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   preprice1,--预设价格1
   preprice2,--预设价格2
   preprice3,--预设价格3
   preprice4,--零售价
   recprice,--最近价格
   Remark1,--备注1
   Remark2,--备注2
   Remark3,--备注3
   Remark4,--备注4
   Remark5,--备注5
   Remark6,--备注6
   Remark7,--备注7
   Remark8,--备注8
   ShowNo,--显示编号
   ShowProductName,--显示产品名称
   ShowSpec,--显示规格型号
   ShowLOrR,--显示左右
   ShowPos,--显示适应部位
   IsShow,--是否销售（所有show开头均为销售选项）
   IsNew,--是否为新品
   NewRemark,--新品发布说明
   PId,--树性父结构代码
   Level_Path,--树性结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep,--树的深度
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted--删除标志
)
values(
   @ProductNo,--产品编号
   @ProductName,--产品名称
   @ProductName1,--产品名称(英文)
   @Spec,--规格型号
   @Spec1,--规格型号(英文)
   @ProductType,--产品类型（成品，零部件）
   @ProductImage,--产品大图
   @Unit,--计量单位
   @Material,--材料标识
   @Code,--产品代码
   @GoodCode,--货位号
   @CheckCodeOne,--校验码（单）
   @CheckCodeMany,--校验码（多）
   @PackQty,--包装数量
   @CertType,--证件类型（a证，b证）
   @RegisterId,--产品注册证Id
   @MinStore,--最小库存
   @MaxStore,--最大库存
   @Cycle,--生产周期（小时）
   @DrawingId,--图纸Id
   @IsRemind,--库存报警标识
   @QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   @preprice1,--预设价格1
   @preprice2,--预设价格2
   @preprice3,--预设价格3
   @preprice4,--零售价
   @recprice,--最近价格
   @Remark1,--备注1
   @Remark2,--备注2
   @Remark3,--备注3
   @Remark4,--备注4
   @Remark5,--备注5
   @Remark6,--备注6
   @Remark7,--备注7
   @Remark8,--备注8
   @ShowNo,--显示编号
   @ShowProductName,--显示产品名称
   @ShowSpec,--显示规格型号
   @ShowLOrR,--显示左右
   @ShowPos,--显示适应部位
   @IsShow,--是否销售（所有show开头均为销售选项）
   @IsNew,--是否为新品
   @NewRemark,--新品发布说明
   @PId,--树性父结构代码
   @Level_Path,--树性结构路径
   0,--儿子数量
   0,--子孙数量
   @Level_Deep,--树的深度
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0--删除标志
);
set @ProductId = @@IDENTITY;--获取插入的实体id

if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_Product set Level_Total=Level_Total+1 where ProductId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_Product set Level_Num=Level_Num+1 where  ProductId=@PId
	--更新父级节点的子孙数量
end

if(@Level_Path='') set @Level_Path=cast(@ProductId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@ProductId as varchar(20))
update T_Product set Level_Path=@Level_Path where ProductId=@ProductId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
