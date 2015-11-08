--returncode：
--	-1到-100通用错误代号
--		0:正确执行
--		-1:插入失败
--		-2:更新失败
--		-3:删除失败
--		-4:存在相同的编号
--		-5:对象被引用
--		-6:子节点引用
--	-101到-200自定义错误代号
--	-500:没有对应的删除方法
CREATE FUNCTION [dbo].[F_GetError](@errormsg varchar(max),@code int)
returns varchar(max) as
begin

if(@code=0)
return @errormsg

else if(@code=1)
return '编号重复'

else if(@code=2)
return '插入失败'

else if(@code=3)
return '更新失败'

else if(@code=4)
return '正在使用'

else if(@code=5)
return '方法未实现'

else if(@code=6)
return '删除失败'

else if(@code=7)
return '对象不存在'

else if(@code=8)
return '不正确的调用'

return '未知错误';
end
