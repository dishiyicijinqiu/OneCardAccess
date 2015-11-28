declare @dlyndxid varchar(36)
select @dlyndxid = '014397BC-FCAE-4500-93C3-7A8B93632DAC'
select * from T_DlyNdx  where DlyNdxId = @dlyndxid
select * from T_PDlyBak	where DlyNdxId = @dlyndxid
select * from T_PFBNBak	where DlyNdxId = @dlyndxid
select * from T_PSNBak	where DlyNdxId = @dlyndxid


delete from T_DlyNdx where DlyNdxId = @dlyndxid

delete from T_DlyNdx where DlyNdxId = @dlyndxid
delete from T_PFBNBak	where DlyNdxId = @dlyndxid
delete from T_PSNBak	where DlyNdxId = @dlyndxid
delete from T_PDlyBak	where DlyNdxId = @dlyndxid