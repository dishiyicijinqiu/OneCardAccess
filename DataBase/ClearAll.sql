
delete from T_DlyNdx 
delete from T_PFBNBak
delete from T_PSNBak
delete from T_PDlyBak

delete from T_DlyNdx 
delete from T_PDly
delete from T_PDlyA 
delete from T_PInOutDetails
delete from T_PFBNInOutDetails
delete from T_PSNInOutDetails
delete from T_PBNInvent				
delete from T_PInvent		
delete from T_PFBNInvent	
delete from T_PSNInvent		

update T_AType set Total=0 where ATypeId=1101
update T_AType set Total=0 where ATypeId=4153