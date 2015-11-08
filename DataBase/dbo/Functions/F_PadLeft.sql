create function F_PadLeft(@num varchar(16),@paddingChar char(1),@totalWidth int)

returns varchar(16) as

begin

declare @curStr varchar(16)

select @curStr = isnull(replicate(@paddingChar,@totalWidth - len(isnull(@num ,0))), '') + @num

return @curStr

end
