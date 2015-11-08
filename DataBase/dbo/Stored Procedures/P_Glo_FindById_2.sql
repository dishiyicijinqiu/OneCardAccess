CREATE PROCEDURE P_Glo_FindById;2
--CREATE PROCEDURE P_Glo_FindById;2
(
	@cMode VARCHAR(50),
	@EntityId int
)
AS 
begin
if @cMode = 'dept' --部门
select		DeptId,--Id
			DeptNo,--部门编号
			DeptName,--部门名称
			Remark,--备注
			PId,--父级Id
			Level_Path,--属性结构路径
			Level_Num,--儿子数量
			Level_Total,--子孙数量,
			Level_Deep,--树深度
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate,--最后更改日期
			Deleted
from T_Dept
where DeptId=@EntityId
else if @cMode = 'product'
select
   ProductId,--Id
   ProductNo,--产品编号
   ProductName,--商品名称
   ProductName1,--商品名称(英文)
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
from T_Product
where ProductId=@EntityId
else if @cMode = 'company' --往来单位
select
   CompanyId,--主键Id
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
from T_Company
where CompanyId=@EntityId
else if @cMode = 'rawmate' --原材料信息
select
   RawMateId,--主键Id
   RawMateNo,--原材料编号
   RawMateName,--原材料名称
   Spec,--规格型号
   MinStore,--最小库存
   MaxStore,--最大库存
   Unit,--计量单位
   IsRemind,--库存报警标识
   QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   preprice1,--预设价格1
   preprice2,--预设价格2
   preprice3,--预设价格3
   recprice,--最近价格
   Remark1,--备注1
   Remark2,--备注2
   Remark3,--备注3
   Remark4,--备注4
   Deleted,--删除标识
   PId,--父Id
   Level_Path,--树形结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep,--树的深度
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate--最后更改日期
from T_RawMate 
where RawMateId=@EntityId
else if @cMode = 'stock' --仓库表
select
   StockId,--主键Id
   StockNo,--仓库编号
   StockName,--仓库名称
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后修改人Id
   LastModifyDate,--最后修改日期
   Deleted,--删除标识
   Remark--备注
from T_Stock 
where StockId=@EntityId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
end
