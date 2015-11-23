declare @dlyndxid varchar(36)
select @dlyndxid = '10D9918F-D901-4E28-B71C-51790ABE6784'
select * from T_DlyNdx  where dlyndxid = @dlyndxid
select * from T_PDlyBak	where dlyndxid = @dlyndxid
select * from T_PFBNBak	where dlyndxid = @dlyndxid
select * from T_PSNBak	where dlyndxid = @dlyndxid


delete from T_DlyNdx where dlyndxid <> 'F762AFDA-8B2B-473A-BF46-9C606441BF53'

delete from T_DlyNdx where dlyndxid = @dlyndxid
delete from T_PFBNBak	where dlyndxid = @dlyndxid
delete from T_PSNBak	where dlyndxid = @dlyndxid
delete from T_PDlyBak	where dlyndxid = @dlyndxid