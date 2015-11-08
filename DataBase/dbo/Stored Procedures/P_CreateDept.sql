--CREATE PROCEDURE P_CreateDept
CREATE PROCEDURE P_CreateDept
(
	@DeptId int output,
	@DeptNo VARCHAR(50),
	@DeptName VARCHAR(50),
	@Remark VARCHAR(200),
	@PId int,
	@CreateId VARCHAR(36)
)
AS
declare @errmsg varchar(max)
select @DeptId=0
select 1 from T_Dept where DeptNo=@DeptNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_Dept where DeptId=@PId
set @Level_Deep = @Level_Deep+1;
--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;
--获取树路径
insert into T_Dept (
			DeptNo,--部门编号
			DeptName,--部门名称
			Remark,--备注
			PId,--父级Id
			Level_Path,--属性结构代码
			Level_Num,--儿子数量
			Level_Total,--子孙数量
			Level_Deep,--树深度
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate,--最后更改日期
			Deleted--删除标识
) values (
			@DeptNo,--部门编号
			@DeptName,--部门名称
			@Remark,--备注
			@PId,--父级Id
			@Level_Path,--属性结构代码
			0,--儿子数量
			0,--子孙数量
			@Level_Deep,
			@CreateId,--创建人Id
			getdate(),--创建日期
			@CreateId,--最后更改人Id
			getdate(),--最后更改日期
			0
);
set @DeptId = @@IDENTITY;--获取插入的实体id

if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_Dept set Level_Total=Level_Total+1 where DeptId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_Dept set Level_Num=Level_Num+1 where DeptId=@PId
	--更新父级节点的子孙数量
end

if(@Level_Path='') set @Level_Path=cast(@DeptId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@DeptId as varchar(20))
update T_Dept set Level_Path=@Level_Path where DeptId=@DeptId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
