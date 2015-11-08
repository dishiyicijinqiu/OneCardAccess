CREATE PROCEDURE P_Glo_GetTree
--CREATE PROCEDURE P_Glo_GetTree
(
	@cMode VARCHAR(50),
	@PId int
)
AS 
if @cMode = 'deptcm' --部门
select		d.DeptId,--Id
			d.DeptNo,--部门编号
			d.DeptName,--部门名称
			d.Remark,--备注
			d.PId,--父级Id
			d.Level_Path,--树形路径
			d.Level_Num,--儿子数量
			d.Level_Total,--子孙数量,
			d.Level_Deep,--树深度
			d.CreateId,--创建人Id
			d.CreateDate,--创建日期
			d.LastModifyId,--最后更改人Id
			d.LastModifyDate,--最后更改日期
			d.Deleted,--是否删除
			u1.UserName CreateName,
			u2.UserName LastModifyName
from T_Dept d left join T_User u1 
on  d.CreateId=u1.UserId left join T_User u2 on d.CreateId=u2.UserId 
where d.PId=@PId and d.Deleted=0
order by DeptNo
else if @cMode = 'productrdcm' --产品信息
select
  p.ProductId,--Id
  p.ProductNo,--产品编号
  p.ProductName,--产品名称
  p.ProductName1,--产品名称(英文)
  p.Spec,--规格型号
  p.Spec1,--规格型号(英文)
  p.ProductType,--产品类型（成品，零部件）
  p.ProductImage,--产品大图
  p.Unit,--计量单位
  p.Material,--材料标识
  p.Code,--产品代码
  p.GoodCode,--货位号
  p.CheckCodeOne,--校验码（单）
  p.CheckCodeMany,--校验码（多）
  p.PackQty,--包装数量
  p.CertType,--证件类型（a证，b证）
  p.RegisterId,--产品注册证Id
  p.MinStore,--最小库存
  p.MaxStore,--最大库存
  p.Cycle,--生产周期（小时）
  p.DrawingId,--图纸Id
  p.IsRemind,--库存报警标识
  p.QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
  p.preprice1,--预设价格1
  p.preprice2,--预设价格2
  p.preprice3,--预设价格3
  p.preprice4,--零售价
  p.recprice,--最近价格
  p.Remark1,--备注1
  p.Remark2,--备注2
  p.Remark3,--备注3
  p.Remark4,--备注4
  p.Remark5,--备注5
  p.Remark6,--备注6
  p.Remark7,--备注7
  p.Remark8,--备注8
  p.ShowNo,--显示编号
  p.ShowProductName,--显示产品名称
  p.ShowSpec,--显示规格型号
  p.ShowLOrR,--显示左右
  p.ShowPos,--显示适应部位
  p.IsShow,--是否销售（所有show开头均为销售选项）
  p.IsNew,--是否为新品
  p.NewRemark,--新品发布说明
  p.PId,--父Id
  p.Level_Path,--树形路径
  p.Level_Num,--儿子数量
  p.Level_Total,--子孙数量
  p.Level_Deep,--树的深度
  p.CreateId,--创建人Id
  p.CreateDate,--创建日期
  p.LastModifyId,--最后更改人Id
  p.LastModifyDate,--最后更改日期
  u1.UserName CreateName,
  u2.UserName LastModifyName,
  r.RegisterNo RegisterNo,
  r.RegisterProductName RegisterProductName,
  r.StandardCode StandardCode,
  r.RegisterNo1 RegisterNo1,
  r.RegisterProductName1 RegisterProductName1,
  r.StandardCode1 StandardCode1,
   '' DrawingName
from T_Product p 
left join T_User u1 on  p.CreateId=u1.UserId 
left join T_User u2 on p.CreateId=u2.UserId 
left join T_Register r on p.RegisterId=r.RegisterId

where p.PId = @PId and p.Deleted = 0
order by ProductNo
else if @cMode = 'companycm' --往来单位
select
   c.CompanyId,--主键Id
   c.CompanyNo,--单位编号
   c.CompanyName,--单位名称
   c.Address,--单位地址
   c.Tel,--电话
   c.Fax,--传真
   c.PostCode,--邮政编码
   c.EMail,--电子邮件
   c.Person,--联系人
   c.BankAndAcount,--开户银行
   c.TaxNumber,--税号
   c.ARTotal,--应收
   c.APTotal,--应付
   c.Remark,--备注
   c.CreateId,--创建人Id
   c.CreateDate,--创建日期
   c.LastModifyId,--最后更改人Id
   c.LastModifyDate,--最后更改日期
   c.Deleted,--删除标志
   c.Password,--登陆密码
   c.Enable,--是否启用
   c.PId,--父Id
   c.Level_Path,--树形结构路径
   c.Level_Num,--儿子数量
   c.Level_Total,--子孙数量
   c.Level_Deep,--树的深度
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Company c 
left join T_User u1 on  c.CreateId=u1.UserId 
left join T_User u2 on c.CreateId=u2.UserId 
where c.PId = @PId and c.Deleted = 0
order by CompanyNo

else if @cMode = 'rawmatecm' --原材料信息
select
   r.RawMateId,--主键Id
   r.RawMateNo,--原材料编号
   r.RawMateName,--原材料名称
   r.Spec,--规格型号
   r.MinStore,--最小库存
   r.MaxStore,--最大库存
   r.Unit,--计量单位
   r.IsRemind,--库存报警标识
   r.QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   r.preprice1,--预设价格1
   r.preprice2,--预设价格2
   r.preprice3,--预设价格3
   r.recprice,--最近价格
   r.Remark1,--备注1
   r.Remark2,--备注2
   r.Remark3,--备注3
   r.Remark4,--备注4
   r.Deleted,--删除标识
   r.PId,--父Id
   r.Level_Path,--树形结构路径
   r.Level_Num,--儿子数量
   r.Level_Total,--子孙数量
   r.Level_Deep,--树的深度
   r.CreateId,--创建人Id
   r.CreateDate,--创建日期
   r.LastModifyId,--最后更改人Id
   r.LastModifyDate,--最后更改日期
   u1.UserName CreateName,--创建人
   u2.UserName LastModifyName--最后更改人
from T_RawMate r 
left join T_User u1 on  r.CreateId=u1.UserId 
left join T_User u2 on r.CreateId=u2.UserId 
where r.PId = @PId and r.Deleted = 0
order by RawMateNo
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end