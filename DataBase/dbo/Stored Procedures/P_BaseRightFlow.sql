CREATE PROCEDURE [dbo].[P_BaseRightFlow]
--CREATE PROCEDURE [dbo].[P_BaseRightFlow]
(
	@OP varchar(20),
	@cMode varchar(50),
	@RoleId varchar(36),
	@EntityId int,
	@PId int,
	@Flag varchar(36),
	@NewFlag varchar(36),
	@Check bit
)
AS 
declare @errmsg varchar(max),@Level_Path varchar(1000),@IsAdmin bit 
select @IsAdmin=0
if exists(select 1 from T_Role where RoleId=@RoleId and IsSuper=1)
select @IsAdmin=1 
if @OP='getright'
begin
	if @cMode='rolestock'
	begin
		if @NewFlag is not null and @NewFlag<>''
		begin
		delete from T_StockRightTemp where Flag=@Flag
		end
		if @IsAdmin=1
		begin
			select StockId,@RoleId RoleId,StockNo,StockName,cast(1 as bit) Status from  T_Stock
			where Deleted=0
		end
		else
		begin
			if @NewFlag is not null and @NewFlag<>''
			begin
				delete from T_StockRightTemp where Flag=@NewFlag and RoleId=@RoleId

				insert into T_StockRightTemp (RoleId,StockId,Flag) 
				select @RoleId,s.StockId,@NewFlag from 
				T_Stock s join T_StockRight sr 
				on s.StockId=sr.StockId and sr.RoleId=@RoleId
				where s.Deleted=0

				select s.StockId,@RoleId RoleId,s.StockNo,s.StockName,cast((case when srt.RoleId is null then 0 else 1 end) as bit) Status 
				from dbo.T_Stock s left join dbo.T_StockRightTemp srt
				on s.StockId=srt.StockId and srt.RoleId=@RoleId and srt.Flag=@NewFlag
				where s.Deleted=0 
			end
			else
			begin

				--delete from T_StockRightTemp where Flag=@Flag and RoleId=@RoleId

				--insert into T_StockRightTemp (RoleId,StockId,Flag) 
				--select @RoleId,s.StockId,@Flag from 
				--T_Stock s join T_StockRight sr 
				--on s.StockId=sr.StockId and sr.RoleId=@RoleId
				--where s.Deleted=0

				select s.StockId,@RoleId RoleId,s.StockNo,s.StockName,cast((case when srt.RoleId is null then 0 else 1 end) as bit) Status 
				from dbo.T_Stock s left join dbo.T_StockRightTemp srt
				on s.StockId=srt.StockId and srt.RoleId=@RoleId and srt.Flag=@Flag
				where s.Deleted=0 
			end
		end
	end
	else if @cMode='roleproduct'
	begin
		if @NewFlag is not null and @NewFlag<>''
		begin
		delete from T_ProductRightTemp where Flag=@Flag
		end
		if @IsAdmin=1
		begin 
			select ProductId,@RoleId RoleId,ProductNo,ProductName,Spec,cast(1 as bit) Status,PId,Level_Path,Level_Num,Level_Total,Level_Deep from  T_Product
			where Deleted=0 and PId=@PId
		end
		else
		begin

			if @NewFlag is not null and @NewFlag<>''
			begin

				delete from T_ProductRightTemp where Flag=@NewFlag and RoleId=@RoleId and ProductId in(
					select ProductId from T_Product where PId=0
				)

				insert into T_ProductRightTemp (RoleId,ProductId,Flag) 
				select @RoleId,p.ProductId,@NewFlag from 
				T_Product p join T_ProductRight pr 
				on p.ProductId=pr.ProductId and pr.RoleId=@RoleId
				where p.Deleted=0 and p.PId=0

				select p.ProductId,@RoleId RoleId,p.ProductNo,p.ProductName,p.Spec,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_Product p left join dbo.T_ProductRightTemp prt
				on p.ProductId=prt.ProductId and prt.RoleId=@RoleId and prt.Flag=@NewFlag
				where p.Deleted=0 and PId=@PId
			end
			else
			begin

				--delete from T_ProductRightTemp where Flag=@Flag and RoleId=@RoleId and ProductId in(
				--	select ProductId from T_Product where PId=@PId
				--)

				--insert into T_ProductRightTemp (RoleId,ProductId,Flag) 
				--select @RoleId,p.ProductId,@Flag from 
				--T_Product p join T_ProductRight pr 
				--on p.ProductId=pr.ProductId and pr.RoleId=@RoleId
				--where p.Deleted=0 and p.PId=@PId

				select p.ProductId,@RoleId RoleId,p.ProductNo,p.ProductName,p.Spec,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_Product p left join dbo.T_ProductRightTemp prt
				on p.ProductId=prt.ProductId and prt.RoleId=@RoleId and prt.Flag=@Flag
				where p.Deleted=0 and PId=@PId
			end
		end
	end
	else if @cMode='rolecompany'
	begin
		if @NewFlag is not null and @NewFlag<>''
		begin
		delete from T_CompanyRightTemp where Flag=@Flag
		end
		if @IsAdmin=1
		begin 
			select CompanyId,@RoleId RoleId,CompanyNo,CompanyName,cast(1 as bit) Status,PId,Level_Path,Level_Num,Level_Total,Level_Deep from  T_Company
			where Deleted=0 and PId=@PId
		end
		else
		begin
			if @NewFlag is not null and @NewFlag<>''
			begin
				delete from T_CompanyRightTemp where Flag=@NewFlag and RoleId=@RoleId and CompanyId in(
					select CompanyId from T_Company where PId=0
				)

				insert into T_CompanyRightTemp (RoleId,CompanyId,Flag) 
				select @RoleId,p.CompanyId,@NewFlag from 
				T_Company p join T_CompanyRight pr 
				on p.CompanyId=pr.CompanyId and pr.RoleId=@RoleId
				where p.Deleted=0 and p.PId=0

				select p.CompanyId,@RoleId RoleId,p.CompanyNo,p.CompanyName,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_Company p left join dbo.T_CompanyRightTemp prt
				on p.CompanyId=prt.CompanyId and prt.RoleId=@RoleId and prt.Flag=@NewFlag
				where p.Deleted=0 and PId=@PId
			end
			else
			begin

				--delete from T_CompanyRightTemp where Flag=@Flag and RoleId=@RoleId and CompanyId in(
				--	select CompanyId from T_Company where PId=@PId
				--)

				--insert into T_CompanyRightTemp (RoleId,CompanyId,Flag) 
				--select @RoleId,p.CompanyId,@Flag from 
				--T_Company p join T_CompanyRight pr 
				--on p.CompanyId=pr.CompanyId and pr.RoleId=@RoleId
				--where p.Deleted=0 and p.PId=@PId and p.CompanyId not in (
				--	select CompanyId from T_CompanyRightTemp where Flag=@Flag and RoleId=@RoleId
				--)

				select p.CompanyId,@RoleId RoleId,p.CompanyNo,p.CompanyName,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_Company p left join dbo.T_CompanyRightTemp prt
				on p.CompanyId=prt.CompanyId and prt.RoleId=@RoleId and prt.Flag=@Flag
				where p.Deleted=0 and PId=@PId
			end
		end
	end
	else if @cMode='rolerawmate'
	begin
		if @NewFlag is not null and @NewFlag<>''
		begin
		delete from T_RawMateRightTemp where Flag=@Flag
		end
		if @IsAdmin=1
		begin 
			select RawMateId,@RoleId RoleId,RawMateNo,RawMateName,Spec,cast(1 as bit) Status,PId,Level_Path,Level_Num,Level_Total,Level_Deep from  T_RawMate
			where Deleted=0 and PId=@PId
		end
		else
		begin

			if @NewFlag is not null and @NewFlag<>''
			begin

				delete from T_RawMateRightTemp where Flag=@NewFlag and RoleId=@RoleId and RawMateId in(
					select RawMateId from T_RawMate where PId=0
				)

				insert into T_RawMateRightTemp (RoleId,RawMateId,Flag) 
				select @RoleId,p.RawMateId,@NewFlag from 
				T_RawMate p join T_RawMateRight pr 
				on p.RawMateId=pr.RawMateId and pr.RoleId=@RoleId
				where p.Deleted=0 and p.PId=0

				select p.RawMateId,@RoleId RoleId,p.RawMateNo,p.RawMateName,p.Spec,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_RawMate p left join dbo.T_RawMateRightTemp prt
				on p.RawMateId=prt.RawMateId and prt.RoleId=@RoleId and prt.Flag=@NewFlag
				where p.Deleted=0 and PId=@PId
			end
			else
			begin

				--delete from T_RawMateRightTemp where Flag=@Flag and RoleId=@RoleId and RawMateId in(
				--	select RawMateId from T_RawMate where PId=@PId
				--)

				--insert into T_RawMateRightTemp (RoleId,RawMateId,Flag) 
				--select @RoleId,p.RawMateId,@Flag from 
				--T_RawMate p join T_RawMateRight pr 
				--on p.RawMateId=pr.RawMateId and pr.RoleId=@RoleId
				--where p.Deleted=0 and p.PId=@PId

				select p.RawMateId,@RoleId RoleId,p.RawMateNo,p.RawMateName,p.Spec,cast((case when prt.RoleId is null then 0 else 1 end) as bit) Status,
				p.PId,p.Level_Path,p.Level_Num,p.Level_Total,p.Level_Deep
				from dbo.T_RawMate p left join dbo.T_RawMateRightTemp prt
				on p.RawMateId=prt.RawMateId and prt.RoleId=@RoleId and prt.Flag=@Flag
				where p.Deleted=0 and PId=@PId
			end
		end
	end
	else
	begin
		select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
	end
end
--else if @OP='gettempright'
--begin

--end
else if @OP='savetempright'
begin
	if @IsAdmin=1 begin select @errmsg=dbo.F_GetError('超级管理员不可更改',0) RAISERROR(@errmsg,11,1) end--方法未实现
	if @cMode = 'rolestock'
	begin
		delete from T_StockRightTemp  where Flag=@Flag and StockId=@EntityId
		 if @Check=1
		 insert into T_StockRightTemp (RoleId,StockId,Flag)
		 select @RoleId RoleId,@EntityId StockId,@Flag Flag
	end
	else if @cMode='roleproduct'
	begin
		select @Level_Path=Level_Path from T_Product where ProductId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_ProductRightTemp  where Flag=@Flag and ProductId in(
			select ProductId from T_Product 
			where Level_Path like @Level_Path+'%'
		 )

		 if @Check=1
		 insert into T_ProductRightTemp (RoleId,ProductId,Flag)
		 select @RoleId,ProductId,@Flag from T_Product
		 where ProductId in(
			select ProductId from T_Product 
			where Level_Path like @Level_Path+'%'
		 )
	end
	else if @cMode='rolecompany'
	begin
		select @Level_Path=Level_Path from T_Company where CompanyId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_CompanyRightTemp  where Flag=@Flag and CompanyId in(
			select CompanyId from T_Company 
			where Level_Path like @Level_Path+'%'
		 )

		 if @Check=1
		 insert into T_CompanyRightTemp (RoleId,CompanyId,Flag)
		 select @RoleId,CompanyId,@Flag from T_Company
		 where CompanyId in(
			select CompanyId from T_Company 
			where Level_Path like @Level_Path+'%'
		 )
	end
	else if @cMode='rolerawmate'
	begin
		select @Level_Path=Level_Path from T_RawMate where RawMateId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_RawMateRightTemp  where Flag=@Flag and RawMateId in(
			select RawMateId from T_RawMate 
			where Level_Path like @Level_Path+'%'
		 )

		 if @Check=1
		 insert into T_RawMateRightTemp (RoleId,RawMateId,Flag)
		 select @RoleId,RawMateId,@Flag from T_RawMate
		 where RawMateId in(
			select RawMateId from T_RawMate 
			where Level_Path like @Level_Path+'%'
		 )
	end
	else
	begin
		select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
	end
end
else if @OP='saveright'
begin
	if @IsAdmin=1 begin select @errmsg=dbo.F_GetError('超级管理员不可更改',0) RAISERROR(@errmsg,11,1) end--方法未实现
	if @cMode='rolestock'
	begin
		delete from T_StockRight where RoleId=@RoleId and StockId=@EntityId
		if @Check=1
		insert into T_StockRight(RoleId,StockId)
		select @RoleId RoleId,@EntityId StockId
	end
	else if @cMode='roleproduct'
	begin
		select @Level_Path=Level_Path from T_Product where ProductId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_ProductRight where RoleId=@RoleId and ProductId in(
			select ProductId from T_Product 
			where Level_Path like @Level_Path+'%'
		 )
		 if @Check=1
		 insert into T_ProductRight (RoleId,ProductId)
		 select @RoleId RoleId,ProductId from T_Product where Level_Path like @Level_Path+'%' and Deleted=0
	end
	else if @cMode='rolecompany'
	begin
		select @Level_Path=Level_Path from T_Company where CompanyId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_CompanyRight where RoleId=@RoleId and CompanyId in(
			select CompanyId from T_Company 
			where Level_Path like @Level_Path+'%'
		 )
		 if @Check=1
		 insert into T_CompanyRight (RoleId,CompanyId)
		 select @RoleId RoleId,CompanyId from T_Company where Level_Path like @Level_Path+'%' and Deleted=0
	end
	else if @cMode='rolerawmate'
	begin
		select @Level_Path=Level_Path from T_RawMate where RawMateId=@EntityId
		if @Level_Path is null begin select @errmsg=dbo.F_GetError('',7) RAISERROR(@errmsg,11,1) end--对象不存在 

		delete from T_RawMateRight where RoleId=@RoleId and RawMateId in(
			select RawMateId from T_RawMate 
			where Level_Path like @Level_Path+'%'
		 )
		 if @Check=1
		 insert into T_RawMateRight (RoleId,RawMateId)
		 select @RoleId RoleId,RawMateId from T_RawMate where Level_Path like @Level_Path+'%' and Deleted=0
	end
	else
	begin
		select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
	end
end
else if @OP='deltempright'
begin
	if @cMode='rolestock'
	begin
		delete from T_StockRightTemp  where Flag=@Flag
	end
	else if @cMode='roleproduct'
	begin
		delete from T_ProductRightTemp  where Flag=@Flag
	end
	else if @cMode='rolecompany'
	begin
		delete from T_CompanyRightTemp  where Flag=@Flag
	end
	else if @cMode='rolerawmate'
	begin
		delete from T_RawMateRightTemp  where Flag=@Flag
	end
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end