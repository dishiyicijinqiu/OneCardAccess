CREATE PROCEDURE P_CreateRawMate
--ALTER PROCEDURE P_CreateRawMate
(
@RawMateId int output,--主键Id
@RawMateNo varchar(50),--原材料编号
@RawMateName varchar(100),--原材料名称
@Spec varchar(50),--规格型号
@MinStore numeric(9),--最小库存
@MaxStore numeric(9),--最大库存
@Unit varchar(20),--计量单位
@IsRemind bit,--库存报警标识
@QtyMode smallint,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
@preprice1 numeric(9),--预设价格1
@preprice2 numeric(9),--预设价格2
@preprice3 numeric(9),--预设价格3
@recprice numeric(9),--最近价格
@Remark1 varchar(500),--备注1
@Remark2 varchar(500),--备注2
@Remark3 varchar(500),--备注3
@Remark4 varchar(500),--备注4
@PId int,--父Id
@CreateId varchar(36)--创建人Id
)
AS
declare @errmsg varchar(max)
select @RawMateId=0
select 1 from T_RawMate where RawMateNo=@RawMateNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_RawMate where RawMateId=@PId
set @Level_Deep = @Level_Deep+1;

--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;

insert into T_RawMate (
   RawMateNo,--原材料编号
   RawMateName,--原材料名称
   Spec,--规格型号
   MinStore,--最小库存
   MaxStore,--最大库存
   Unit,--计量单位
   IsRemind,--库存报警标识
   QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   preprice1,--预设价格1
   preprice2,--预设价格2
   preprice3,--预设价格3
   recprice,--最近价格
   Remark1,--备注1
   Remark2,--备注2
   Remark3,--备注3
   Remark4,--备注4
   Deleted,--删除标识
   PId,--父Id
   Level_Path,--树形结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep,--树的深度
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate--最后更改日期
) values (
   @RawMateNo,--原材料编号
   @RawMateName,--原材料名称
   @Spec,--规格型号
   @MinStore,--最小库存
   @MaxStore,--最大库存
   @Unit,--计量单位
   @IsRemind,--库存报警标识
   @QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   @preprice1,--预设价格1
   @preprice2,--预设价格2
   @preprice3,--预设价格3
   @recprice,--最近价格
   @Remark1,--备注1
   @Remark2,--备注2
   @Remark3,--备注3
   @Remark4,--备注4
   0,--删除标识
   @PId,--父Id
   @Level_Path,--树形结构路径
   0,--儿子数量
   0,--子孙数量
   @Level_Deep,--树的深度
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate()--最后更改日期
)
set @RawMateId = @@IDENTITY;--获取插入的实体id
if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_RawMate set Level_Total=Level_Total+1 where RawMateId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_RawMate set Level_Num=Level_Num+1 where RawMateId=@PId
	--更新父级节点的子孙数量
end
if(@Level_Path='') set @Level_Path=cast(@RawMateId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@RawMateId as varchar(20))
update T_RawMate set Level_Path=@Level_Path where RawMateId=@RawMateId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
