--CREATE PROCEDURE P_Glo_Delete;2
CREATE PROCEDURE P_Glo_Delete;2
(
	@cMode VARCHAR(50),
	@EntityId int
)
AS 
declare @errmsg varchar(max)
declare @Level_Path varchar(1000),@Level_Total int
if @cMode = 'dept' --部门
begin
	select @Level_Path=Level_Path,@Level_Total=Level_Total from T_Dept where DeptId=@EntityId
	if(@Level_Total>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end --正在使用，检查是否有子节点
	if(charindex(',',@Level_Path)>0)--检查是否有父节点，更新父节点的子孙数量
	begin
		exec('update T_Dept set Level_Total=Level_Total-1,Level_Num=Level_Num-1 where DeptId in ('+@Level_Path+')')
	end
	--begin检查引用：
	--检查员工是否引用
	select top 1 1 from T_Employee where Deleted=0 and DeptId=@EntityId
	if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end
	--end检查引用：
	update T_Dept set Deleted=1 where DeptId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'product' --产品信息
begin
	select @Level_Path=Level_Path,@Level_Total=Level_Total from T_Product where ProductId=@EntityId
	if(@Level_Total>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end --正在使用，检查是否有子节点
	if(charindex(',',@Level_Path)>0)--检查是否有父节点，更新父节点的子孙数量
	begin
		exec('update T_Product set Level_Total=Level_Total-1,Level_Num=Level_Num-1 where ProductId in ('+@Level_Path+')')
	end
	--begin检查引用：
	--end检查引用：
	update T_Product set Deleted=1 where ProductId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end

else if @cMode = 'company' --往来单位
begin
	select @Level_Path=Level_Path,@Level_Total=Level_Total from T_Company where CompanyId=@EntityId
	if(@Level_Total>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end --正在使用，检查是否有子节点
	if(charindex(',',@Level_Path)>0)--检查是否有父节点，更新父节点的子孙数量
	begin
		exec('update T_Company set Level_Total=Level_Total-1,Level_Num=Level_Num-1 where CompanyId in ('+@Level_Path+')')
	end
	--begin检查引用：
	--end检查引用：
	update T_Company set Deleted=1 where CompanyId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'rawmate' --往来单位
begin
	select @Level_Path=Level_Path,@Level_Total=Level_Total from T_RawMate where RawMateId=@EntityId
	if(@Level_Total>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end --正在使用，检查是否有子节点
	if(charindex(',',@Level_Path)>0)--检查是否有父节点，更新父节点的子孙数量
	begin
		exec('update T_RawMate set Level_Total=Level_Total-1,Level_Num=Level_Num-1 where RawMateId in ('+@Level_Path+')')
	end
	--begin检查引用：
	--end检查引用：
	update T_RawMate set Deleted=1 where RawMateId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'stock'
begin
	update T_Stock set Deleted=1 where StockId=@EntityId
	--begin检查引用：
	--end检查引用：
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end