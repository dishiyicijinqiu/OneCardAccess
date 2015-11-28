
declare @DlyNdxId varchar(36)
select @DlyNdxId='7F26EB63-4055-48C4-9D90-CB1BDAEED736'

select * from [dbo].[T_DlyNdx] where DlyNdxId=@DlyNdxId
select * from [dbo].[T_PDly] where DlyNdxId=@DlyNdxId
select * from [dbo].[T_PDlyA] where DlyNdxId=@DlyNdxId
select * from [dbo].[T_PInOutDetails] where DlyNdxId=@DlyNdxId
select * from [dbo].[T_PFBNInOutDetails] where DlyNdxId=@DlyNdxId
select * from [dbo].[T_PSNInOutDetails] where DlyNdxId=@DlyNdxId
select *  from T_PBNInvent				
select *  from [dbo].[T_PInvent]		
select *  from [dbo].[T_PFBNInvent]	
select *  from [dbo].[T_PSNInvent]	
select * from T_AType	

delete from [dbo].[T_DlyNdx] where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PDly] where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PDlyA] where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PInOutDetails] where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PFBNInOutDetails] where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PSNInOutDetails] where DlyNdxId=@DlyNdxId
delete from T_PBNInvent				where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PInvent]		where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PFBNInvent]	where DlyNdxId=@DlyNdxId
delete from [dbo].[T_PSNInvent]		where DlyNdxId=@DlyNdxId

update T_AType set Total=0 where ATypeId=1101
