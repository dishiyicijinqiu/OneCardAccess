/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2015-11-05 11:51:42                          */
/*==============================================================*/


if exists (select 1
          from sysobjects
          where  id = object_id('dbo.F_GetError')
          and type in ('IF', 'FN', 'TF'))
   drop function dbo.F_GetError
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.F_PadLeft')
          and type in ('IF', 'FN', 'TF'))
   drop function dbo.F_PadLeft
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_AddRoleAction')
          and type in ('P','PC'))
   drop procedure dbo.P_AddRoleAction
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_AddRoleMenu')
          and type in ('P','PC'))
   drop procedure dbo.P_AddRoleMenu
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_AuthenticateUser')
          and type in ('P','PC'))
   drop procedure dbo.P_AuthenticateUser
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_BaseRightFlow')
          and type in ('P','PC'))
   drop procedure dbo.P_BaseRightFlow
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateAction')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateAction
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateCompany')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateCompany
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateDept')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateDept
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateEmployee')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateEmployee
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateEmployeeAttachment')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateEmployeeAttachment
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateMenu')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateMenu
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateProduct')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateProduct
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateRawMate')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateRawMate
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateRegister')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateRegister
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateRegisterAttachment')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateRegisterAttachment
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateRole')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateRole
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateStock')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateStock
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_CreateUser')
          and type in ('P','PC'))
   drop procedure dbo.P_CreateUser
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_GetDicDataByDicTypes')
          and type in ('P','PC'))
   drop procedure dbo.P_GetDicDataByDicTypes
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_GetRelationData')
          and type in ('P','PC'))
   drop procedure dbo.P_GetRelationData
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_Delete')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_Delete
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_DeleteRelationData')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_DeleteRelationData
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_FindById')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_FindById
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_FindByNo')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_FindByNo
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_GetChildList')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_GetChildList
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_GetList')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_GetList
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_Glo_GetTree')
          and type in ('P','PC'))
   drop procedure dbo.P_Glo_GetTree
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_IsSuper')
          and type in ('P','PC'))
   drop procedure dbo.P_IsSuper
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_RoleUserFlow')
          and type in ('P','PC'))
   drop procedure dbo.P_RoleUserFlow
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateAction')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateAction
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateCompany')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateCompany
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateDept')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateDept
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateEmployee')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateEmployee
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateMenu')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateMenu
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateProduct')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateProduct
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateRawMate')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateRawMate
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateRegister')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateRegister
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateRole')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateRole
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateStock')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateStock
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UpdateUser')
          and type in ('P','PC'))
   drop procedure dbo.P_UpdateUser
go

if exists (select 1
          from sysobjects
          where  id = object_id('dbo.P_UserAuth')
          and type in ('P','PC'))
   drop procedure dbo.P_UserAuth
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_AType')
            and   type = 'U')
   drop table dbo.T_AType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Action')
            and   type = 'U')
   drop table dbo.T_Action
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Company')
            and   type = 'U')
   drop table dbo.T_Company
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_CompanyRight')
            and   type = 'U')
   drop table dbo.T_CompanyRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_CompanyRightTemp')
            and   type = 'U')
   drop table dbo.T_CompanyRightTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Dept')
            and   type = 'U')
   drop table dbo.T_Dept
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_DicData')
            and   type = 'U')
   drop table dbo.T_DicData
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_DlyADetails')
            and   type = 'U')
   drop table T_DlyADetails
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_DlyGather')
            and   type = 'U')
   drop table T_DlyGather
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_DlyNdx')
            and   type = 'U')
   drop table dbo.T_DlyNdx
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Employee')
            and   type = 'U')
   drop table dbo.T_Employee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_EmployeeAttachment')
            and   type = 'U')
   drop table dbo.T_EmployeeAttachment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Menu')
            and   type = 'U')
   drop table dbo.T_Menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_NecessaryRight')
            and   type = 'U')
   drop table dbo.T_NecessaryRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_NecessaryRightTemp')
            and   type = 'U')
   drop table dbo.T_NecessaryRightTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Product')
            and   type = 'U')
   drop table dbo.T_Product
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductBNInvent')
            and   type = 'U')
   drop table dbo.T_ProductBNInvent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductDlyBak')
            and   type = 'U')
   drop table dbo.T_ProductDlyBak
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductDlyFBNBak')
            and   type = 'U')
   drop table dbo.T_ProductDlyFBNBak
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductDlySNBak')
            and   type = 'U')
   drop table dbo.T_ProductDlySNBak
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductFBNInOutDetails')
            and   type = 'U')
   drop table dbo.T_ProductFBNInOutDetails
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductFBNInvent')
            and   type = 'U')
   drop table dbo.T_ProductFBNInvent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductInOutDetails')
            and   type = 'U')
   drop table dbo.T_ProductInOutDetails
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductInvent')
            and   type = 'U')
   drop table dbo.T_ProductInvent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductRight')
            and   type = 'U')
   drop table dbo.T_ProductRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductRightTemp')
            and   type = 'U')
   drop table dbo.T_ProductRightTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductSNInOutDetails')
            and   type = 'U')
   drop table dbo.T_ProductSNInOutDetails
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductSNInvent')
            and   type = 'U')
   drop table dbo.T_ProductSNInvent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_ProductSaleDly')
            and   type = 'U')
   drop table dbo.T_ProductSaleDly
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Product_Drawings')
            and   type = 'U')
   drop table dbo.T_Product_Drawings
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Product_Register')
            and   type = 'U')
   drop table dbo.T_Product_Register
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Product_TechStep')
            and   type = 'U')
   drop table dbo.T_Product_TechStep
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RawMate')
            and   type = 'U')
   drop table dbo.T_RawMate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RawMateRight')
            and   type = 'U')
   drop table dbo.T_RawMateRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RawMateRightTemp')
            and   type = 'U')
   drop table dbo.T_RawMateRightTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Register')
            and   type = 'U')
   drop table dbo.T_Register
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RegisterAttachment')
            and   type = 'U')
   drop table dbo.T_RegisterAttachment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Role')
            and   type = 'U')
   drop table dbo.T_Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RoleAction')
            and   type = 'U')
   drop table dbo.T_RoleAction
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_RoleMenu')
            and   type = 'U')
   drop table dbo.T_RoleMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_Stock')
            and   type = 'U')
   drop table dbo.T_Stock
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_StockRight')
            and   type = 'U')
   drop table dbo.T_StockRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_StockRightTemp')
            and   type = 'U')
   drop table dbo.T_StockRightTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_User')
            and   type = 'U')
   drop table dbo.T_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_UserAction')
            and   type = 'U')
   drop table dbo.T_UserAction
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.T_UserEmployee')
            and   name  = 'IX_T_UserEmployee_UserId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.T_UserEmployee.IX_T_UserEmployee_UserId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.T_UserEmployee')
            and   name  = 'IX_T_UserEmployee_EmpId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.T_UserEmployee.IX_T_UserEmployee_EmpId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_UserEmployee')
            and   type = 'U')
   drop table dbo.T_UserEmployee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_UserInRole')
            and   type = 'U')
   drop table dbo.T_UserInRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_UserLog')
            and   type = 'U')
   drop table dbo.T_UserLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.T_UserMenu')
            and   type = 'U')
   drop table dbo.T_UserMenu
go

execute sp_revokedbaccess dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
execute sp_grantdbaccess dbo
go

/*==============================================================*/
/* Table: T_AType                                               */
/*==============================================================*/
create table dbo.T_AType (
   ATypeId              int                  not null,
   ATypeNo              varchar(26)          collate Chinese_PRC_CI_AS not null,
   ATypeName            varchar(66)          collate Chinese_PRC_CI_AS not null,
   Total                numeric(18,4)        not null,
   Remark               varchar(256)         collate Chinese_PRC_CI_AS not null,
   Level_Path           varchar(1000)        collate Chinese_PRC_CI_AS not null,
   Level_Num            int                  not null,
   Level_Total          int                  not null,
   Level_Deep           int                  not null,
   PId                  int                  not null,
   constraint PK__T_AType__38845C1C primary key (ATypeId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '资产科目表',
   'user', 'dbo', 'table', 'T_AType'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', 'dbo', 'table', 'T_AType', 'column', 'ATypeId'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目编号',
   'user', 'dbo', 'table', 'T_AType', 'column', 'ATypeNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目名称',
   'user', 'dbo', 'table', 'T_AType', 'column', 'ATypeName'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '树形结构路径',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Level_Path'
go

execute sp_addextendedproperty 'MS_Description', 
   '儿子数量',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Level_Num'
go

execute sp_addextendedproperty 'MS_Description', 
   '子孙数量',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Level_Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '树的深度',
   'user', 'dbo', 'table', 'T_AType', 'column', 'Level_Deep'
go

execute sp_addextendedproperty 'MS_Description', 
   '父Id',
   'user', 'dbo', 'table', 'T_AType', 'column', 'PId'
go

/*==============================================================*/
/* Table: T_Action                                              */
/*==============================================================*/
create table dbo.T_Action (
   ActionNo             varchar(100)         collate Chinese_PRC_CI_AS not null,
   ActionName           varchar(100)         collate Chinese_PRC_CI_AS not null,
   ParentActionNo       varchar(100)         collate Chinese_PRC_CI_AS not null,
   "Order"              int                  not null,
   ActionType           varchar(20)          collate Chinese_PRC_CI_AS not null,
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   constraint PK__T_Action__3A4CA8FD primary key (ActionNo)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '功能表',
   'user', 'dbo', 'table', 'T_Action'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能编号',
   'user', 'dbo', 'table', 'T_Action', 'column', 'ActionNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能名称',
   'user', 'dbo', 'table', 'T_Action', 'column', 'ActionName'
go

execute sp_addextendedproperty 'MS_Description', 
   '父级编号',
   'user', 'dbo', 'table', 'T_Action', 'column', 'ParentActionNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '序号',
   'user', 'dbo', 'table', 'T_Action', 'column', 'Order'
go

execute sp_addextendedproperty 'MS_Description', 
   '类型',
   'user', 'dbo', 'table', 'T_Action', 'column', 'ActionType'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Action', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_Company                                             */
/*==============================================================*/
create table dbo.T_Company (
   CompanyId            int                  identity(1, 1),
   CompanyNo            varchar(50)          collate Chinese_PRC_CI_AS not null,
   CompanyName          varchar(150)         collate Chinese_PRC_CI_AS not null,
   Address              varchar(200)         collate Chinese_PRC_CI_AS not null,
   Tel                  varchar(50)          collate Chinese_PRC_CI_AS not null,
   Fax                  varchar(50)          collate Chinese_PRC_CI_AS not null,
   PostCode             varchar(50)          collate Chinese_PRC_CI_AS not null,
   EMail                varchar(100)         collate Chinese_PRC_CI_AS not null,
   Person               varchar(50)          collate Chinese_PRC_CI_AS not null,
   BankAndAcount        varchar(50)          collate Chinese_PRC_CI_AS not null,
   TaxNumber            varchar(50)          collate Chinese_PRC_CI_AS not null,
   ARTotal              numeric(18,4)        not null,
   APTotal              numeric(18,4)        not null,
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF__T_Company__Delet__658C0CBD default (0),
   Password             varchar(100)         collate Chinese_PRC_CI_AS not null,
   Enable               bit                  not null,
   PId                  int                  not null,
   Level_Path           varchar(1000)        collate Chinese_PRC_CI_AS not null,
   Level_Num            int                  not null,
   Level_Total          int                  not null,
   Level_Deep           int                  not null,
   constraint PK_T_Company primary key (CompanyId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位',
   'user', 'dbo', 'table', 'T_Company'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_Company', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单位编号',
   'user', 'dbo', 'table', 'T_Company', 'column', 'CompanyNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '单位名称',
   'user', 'dbo', 'table', 'T_Company', 'column', 'CompanyName'
go

execute sp_addextendedproperty 'MS_Description', 
   '单位地址',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Address'
go

execute sp_addextendedproperty 'MS_Description', 
   '电话',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Tel'
go

execute sp_addextendedproperty 'MS_Description', 
   '传真',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Fax'
go

execute sp_addextendedproperty 'MS_Description', 
   '邮政编码',
   'user', 'dbo', 'table', 'T_Company', 'column', 'PostCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '电子邮件',
   'user', 'dbo', 'table', 'T_Company', 'column', 'EMail'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Person'
go

execute sp_addextendedproperty 'MS_Description', 
   '开户银行',
   'user', 'dbo', 'table', 'T_Company', 'column', 'BankAndAcount'
go

execute sp_addextendedproperty 'MS_Description', 
   '税号',
   'user', 'dbo', 'table', 'T_Company', 'column', 'TaxNumber'
go

execute sp_addextendedproperty 'MS_Description', 
   '应收',
   'user', 'dbo', 'table', 'T_Company', 'column', 'ARTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '应付',
   'user', 'dbo', 'table', 'T_Company', 'column', 'APTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Company', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Company', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Company', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Company', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标志',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Deleted'
go

execute sp_addextendedproperty 'MS_Description', 
   '登陆密码',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Password'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Enable'
go

execute sp_addextendedproperty 'MS_Description', 
   '父Id',
   'user', 'dbo', 'table', 'T_Company', 'column', 'PId'
go

execute sp_addextendedproperty 'MS_Description', 
   '树形结构路径',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Level_Path'
go

execute sp_addextendedproperty 'MS_Description', 
   '儿子数量',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Level_Num'
go

execute sp_addextendedproperty 'MS_Description', 
   '子孙数量',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Level_Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '树的深度',
   'user', 'dbo', 'table', 'T_Company', 'column', 'Level_Deep'
go

/*==============================================================*/
/* Table: T_CompanyRight                                        */
/*==============================================================*/
create table dbo.T_CompanyRight (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   CompanyId            int                  not null,
   constraint PK_T_CompanyRight primary key (RoleId, CompanyId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位权限表',
   'user', 'dbo', 'table', 'T_CompanyRight'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_CompanyRight', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位主键Id',
   'user', 'dbo', 'table', 'T_CompanyRight', 'column', 'CompanyId'
go

/*==============================================================*/
/* Table: T_CompanyRightTemp                                    */
/*==============================================================*/
create table dbo.T_CompanyRightTemp (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   CompanyId            int                  not null,
   Flag                 varchar(36)          collate Chinese_PRC_CI_AS not null
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位权限临时数据',
   'user', 'dbo', 'table', 'T_CompanyRightTemp'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_CompanyRightTemp', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位主键Id',
   'user', 'dbo', 'table', 'T_CompanyRightTemp', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态标识',
   'user', 'dbo', 'table', 'T_CompanyRightTemp', 'column', 'Flag'
go

/*==============================================================*/
/* Table: T_Dept                                                */
/*==============================================================*/
create table dbo.T_Dept (
   DeptId               int                  identity(1, 1),
   DeptNo               varchar(50)          collate Chinese_PRC_CI_AS not null,
   DeptName             varchar(50)          collate Chinese_PRC_CI_AS not null,
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   PId                  int                  not null,
   Level_Path           varchar(1000)        collate Chinese_PRC_CI_AS not null,
   Level_Num            int                  not null,
   Level_Total          int                  not null,
   Level_Deep           int                  not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Dept_Deleted default (0),
   constraint PK__tmp_ms_xx_T_Dept__33D4B598 primary key (DeptId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '部门',
   'user', 'dbo', 'table', 'T_Dept'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门Id',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'DeptId'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门编号',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'DeptNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门名称',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'DeptName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '树性父结构代码',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'PId'
go

execute sp_addextendedproperty 'MS_Description', 
   '树形结构路径',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Level_Path'
go

execute sp_addextendedproperty 'MS_Description', 
   '儿子数量',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Level_Num'
go

execute sp_addextendedproperty 'MS_Description', 
   '子孙数量',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Level_Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '树的深度',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Level_Deep'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标志',
   'user', 'dbo', 'table', 'T_Dept', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_DicData                                             */
/*==============================================================*/
create table dbo.T_DicData (
   DicType              varchar(20)          collate Chinese_PRC_CI_AS not null,
   DicValue             varchar(100)         collate Chinese_PRC_CI_AS not null,
   constraint PK_T_DicData primary key (DicValue, DicType)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '字典表',
   'user', 'dbo', 'table', 'T_DicData'
go

execute sp_addextendedproperty 'MS_Description', 
   '字典类型',
   'user', 'dbo', 'table', 'T_DicData', 'column', 'DicType'
go

execute sp_addextendedproperty 'MS_Description', 
   '字典键',
   'user', 'dbo', 'table', 'T_DicData', 'column', 'DicValue'
go

/*==============================================================*/
/* Table: T_DlyADetails                                         */
/*==============================================================*/
create table T_DlyADetails (
   DlyADetailId         varchar(36)          not null,
   DlyNdxId             varchar(36)          not null,
   ATypeId              int                  not null,
   CompanyId            int                  not null,
   JSRId                int                  not null,
   StockId              int                  not null,
   Total                numeric(18,4)        null,
   DlyDate              varchar(10)          null,
   DlyType              smallint             null,
   Remark               varchar(10)          null,
   constraint PK_T_DLYADETAILS primary key (DlyADetailId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单据资产明细表',
   'user', @CurrentUser, 'table', 'T_DlyADetails'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'DlyADetailId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'DlyNdxId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'ATypeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'JSRId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'StockId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'Total'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'DlyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'DlyType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_DlyADetails', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_DlyGather                                           */
/*==============================================================*/
create table T_DlyGather (
   GatherId             varchar(36)          not null,
   CompanyId            int                  not null,
   DlyNdxId             varchar(36)          not null,
   GatherNdxId          varchar(36)          not null,
   Total                numeric(18, 4)       not null,
   GatherType           smallint             not null,
   constraint PK_T_DLYGATHER primary key (GatherId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '收付款明细表',
   'user', @CurrentUser, 'table', 'T_DlyGather'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'GatherId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'DlyNdxId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '收支单据Id（要收款，付款的单据索引Id）',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'GatherNdxId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'Total'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '收支类型',
   'user', @CurrentUser, 'table', 'T_DlyGather', 'column', 'GatherType'
go

/*==============================================================*/
/* Table: T_DlyNdx                                              */
/*==============================================================*/
create table dbo.T_DlyNdx (
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_DlyNdx__DlyNdx__35A7EF71 default newid(),
   DlyNo                varchar(30)          collate Chinese_PRC_CI_AS not null,
   DlyType              smallint             not null,
   DlyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   CompanyId            int                  not null,
   JSRId                int                  not null,
   StockId1             int                  not null,
   StockId2             int                  not null,
   Draft                smallint             not null,
   Summary              varchar(256)         collate Chinese_PRC_CI_AS not null,
   Comment              varchar(256)         collate Chinese_PRC_CI_AS not null,
   ZDRId                varchar(36)          collate Chinese_PRC_CI_AS not null,
   SHRId1               varchar(36)          collate Chinese_PRC_CI_AS not null,
   SHRId2               varchar(36)          collate Chinese_PRC_CI_AS not null,
   SHRId3               varchar(36)          collate Chinese_PRC_CI_AS not null,
   SHRId4               varchar(36)          collate Chinese_PRC_CI_AS not null,
   SHRId5               varchar(36)          collate Chinese_PRC_CI_AS not null,
   IsInvoce             nchar(10)            collate Chinese_PRC_CI_AS not null,
   Total                numeric(18,4)        not null,
   QGNo                 varchar(36)          collate Chinese_PRC_CI_AS not null,
   QGDate               varchar(10)          collate Chinese_PRC_CI_AS not null,
   QGR                  varchar(10)          collate Chinese_PRC_CI_AS not null,
   YDJNo                varchar(36)          collate Chinese_PRC_CI_AS not null,
   BuyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   Buyer                varchar(10)          collate Chinese_PRC_CI_AS not null,
   LXR                  varchar(10)          collate Chinese_PRC_CI_AS not null,
   LXFS                 varchar(20)          collate Chinese_PRC_CI_AS not null,
   constraint PK_T_DLYNDX primary key (DlyNdxId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表',
   'user', 'dbo', 'table', 'T_DlyNdx'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   'DlyNo',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'DlyNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'DlyType'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'DlyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'JSRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id1',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'StockId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id2',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'StockId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '(是否过账0为草稿，1为过账,2被红冲标记，3红冲标记,4临时单据)',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'Draft'
go

execute sp_addextendedproperty 'MS_Description', 
   '摘要',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'Summary'
go

execute sp_addextendedproperty 'MS_Description', 
   '附加说明',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'Comment'
go

execute sp_addextendedproperty 'MS_Description', 
   '制单人Id,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'ZDRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '一级审核人,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'SHRId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '二级审核人,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'SHRId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '三级审核人,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'SHRId3'
go

execute sp_addextendedproperty 'MS_Description', 
   '四级审核人,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'SHRId4'
go

execute sp_addextendedproperty 'MS_Description', 
   '五级审核人,系统用户Id',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'SHRId5'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否开票',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'IsInvoce'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '请购单号',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'QGNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '请购日期',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'QGDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '请购人',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'QGR'
go

execute sp_addextendedproperty 'MS_Description', 
   '原单据号',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'YDJNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '购买日期',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'BuyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '购买人',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'Buyer'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'LXR'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系方式',
   'user', 'dbo', 'table', 'T_DlyNdx', 'column', 'LXFS'
go

/*==============================================================*/
/* Table: T_Employee                                            */
/*==============================================================*/
create table dbo.T_Employee (
   EmpId                varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__tmp_ms_xx__EmpId__10566F31 default newid(),
   EmpNo                varchar(50)          collate Chinese_PRC_CI_AS not null,
   EmpName              varchar(50)          collate Chinese_PRC_CI_AS not null,
   DeptId               int                  not null,
   Sex                  varchar(5)           collate Chinese_PRC_CI_AS not null,
   Nation               varchar(20)          collate Chinese_PRC_CI_AS not null,
   Birthday             varchar(10)          collate Chinese_PRC_CI_AS not null,
   Address              varchar(500)         collate Chinese_PRC_CI_AS not null,
   TelPhone             varchar(20)          collate Chinese_PRC_CI_AS not null,
   Mobile               varchar(20)          collate Chinese_PRC_CI_AS not null,
   Origin               varchar(10)          collate Chinese_PRC_CI_AS not null,
   Title                varchar(50)          collate Chinese_PRC_CI_AS not null,
   Duty                 varchar(50)          collate Chinese_PRC_CI_AS not null,
   Post                 varchar(50)          collate Chinese_PRC_CI_AS not null,
   EmpStatus            smallint             not null,
   WedStatus            varchar(5)           collate Chinese_PRC_CI_AS not null,
   AttCardNo            varchar(20)          collate Chinese_PRC_CI_AS not null,
   GenCardNo            varchar(20)          collate Chinese_PRC_CI_AS not null,
   IdCardNo             varchar(30)          collate Chinese_PRC_CI_AS not null,
   Photo                varchar(50)          collate Chinese_PRC_CI_AS not null,
   Specialty            varchar(50)          collate Chinese_PRC_CI_AS not null,
   Diploma              varchar(10)          collate Chinese_PRC_CI_AS not null,
   GraduateSchool       varchar(100)         collate Chinese_PRC_CI_AS not null,
   PoliticalStatus      varchar(10)          collate Chinese_PRC_CI_AS not null,
   JoinDate             varchar(10)          collate Chinese_PRC_CI_AS not null,
   TrialStartDate       varchar(10)          collate Chinese_PRC_CI_AS not null,
   TrialEndDate         varchar(10)          collate Chinese_PRC_CI_AS not null,
   PositiveDate         varchar(10)          collate Chinese_PRC_CI_AS not null,
   ContractStartDate    varchar(10)          collate Chinese_PRC_CI_AS not null,
   ContractEndDate      varchar(10)          collate Chinese_PRC_CI_AS not null,
   HolidaySMS           bit                  not null,
   BirthdaySMS          bit                  not null,
   Att                  bit                  not null constraint DF__tmp_ms_xx_T__Att__114A936A default (1),
   Deleted              bit                  not null constraint DF__tmp_ms_xx__Delet__123EB7A3 default (0),
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null constraint DF__tmp_ms_xx__Creat__1332DBDC default getdate(),
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null constraint DF__tmp_ms_xx__LastM__14270015 default getdate(),
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   Remark1              varchar(200)         collate Chinese_PRC_CI_AS not null,
   Remark2              varchar(200)         collate Chinese_PRC_CI_AS not null,
   constraint PK__tmp_ms_xx_T_Empl__0F624AF8 primary key (EmpId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '员工表',
   'user', 'dbo', 'table', 'T_Employee'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工Id',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'EmpId'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工编号',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'EmpNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工姓名',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'EmpName'
go

execute sp_addextendedproperty 'MS_Description', 
   '部门Id',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'DeptId'
go

execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '民族',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Nation'
go

execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Birthday'
go

execute sp_addextendedproperty 'MS_Description', 
   '家庭住址',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Address'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'TelPhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '手机',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Mobile'
go

execute sp_addextendedproperty 'MS_Description', 
   '籍贯',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Origin'
go

execute sp_addextendedproperty 'MS_Description', 
   '职称',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Title'
go

execute sp_addextendedproperty 'MS_Description', 
   '职务',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Duty'
go

execute sp_addextendedproperty 'MS_Description', 
   '岗位',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Post'
go

execute sp_addextendedproperty 'MS_Description', 
   '职位状态（1，在职，2，试用，3，停职，4，离职）',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'EmpStatus'
go

execute sp_addextendedproperty 'MS_Description', 
   '婚姻状况',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'WedStatus'
go

execute sp_addextendedproperty 'MS_Description', 
   '考勤卡号',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'AttCardNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '通用卡号（生产刷卡，材料领用）',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'GenCardNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'IdCardNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '照片',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Photo'
go

execute sp_addextendedproperty 'MS_Description', 
   '专业',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Specialty'
go

execute sp_addextendedproperty 'MS_Description', 
   '最高学历',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Diploma'
go

execute sp_addextendedproperty 'MS_Description', 
   '毕业学校',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'GraduateSchool'
go

execute sp_addextendedproperty 'MS_Description', 
   '政治面貌',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'PoliticalStatus'
go

execute sp_addextendedproperty 'MS_Description', 
   '入职日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'JoinDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '试用期开始日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'TrialStartDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '试用期结束日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'TrialEndDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '转正日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'PositiveDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '合同开始日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'ContractStartDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '合同结束日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'ContractEndDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '节假日短信祝福',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'HolidaySMS'
go

execute sp_addextendedproperty 'MS_Description', 
   '生日短信祝福',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'BirthdaySMS'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否记考勤',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Att'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Deleted'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注1',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Remark1'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注2',
   'user', 'dbo', 'table', 'T_Employee', 'column', 'Remark2'
go

/*==============================================================*/
/* Table: T_EmployeeAttachment                                  */
/*==============================================================*/
create table dbo.T_EmployeeAttachment (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null,
   EmpId                varchar(36)          collate Chinese_PRC_CI_AS not null,
   ShowName             varchar(50)          collate Chinese_PRC_CI_AS not null,
   SaveName             varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_EmployeeAttach__09FE775D primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '员工附件表',
   'user', 'dbo', 'table', 'T_EmployeeAttachment'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_EmployeeAttachment', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工Id',
   'user', 'dbo', 'table', 'T_EmployeeAttachment', 'column', 'EmpId'
go

execute sp_addextendedproperty 'MS_Description', 
   '附件名称',
   'user', 'dbo', 'table', 'T_EmployeeAttachment', 'column', 'ShowName'
go

execute sp_addextendedproperty 'MS_Description', 
   '保存名称',
   'user', 'dbo', 'table', 'T_EmployeeAttachment', 'column', 'SaveName'
go

/*==============================================================*/
/* Table: T_Menu                                                */
/*==============================================================*/
create table dbo.T_Menu (
   MenuNo               varchar(100)         collate Chinese_PRC_CI_AS not null,
   PNo                  varchar(100)         collate Chinese_PRC_CI_AS not null,
   MenuName             varchar(100)         collate Chinese_PRC_CI_AS not null,
   "Order"              int                  not null constraint DF__T_Menu__Order__25518C17 default (-1),
   Glyph                varchar(200)         collate Chinese_PRC_CI_AS not null,
   OnClick              varchar(200)         collate Chinese_PRC_CI_AS not null,
   KeyTip               varchar(30)          collate Chinese_PRC_CI_AS not null,
   MenuControl          varchar(20)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_Menu__245D67DE primary key (MenuNo)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '系统菜单表',
   'user', 'dbo', 'table', 'T_Menu'
go

execute sp_addextendedproperty 'MS_Description', 
   '菜单编号',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'MenuNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '父级菜单编号',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'PNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '菜单名称',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'MenuName'
go

execute sp_addextendedproperty 'MS_Description', 
   '菜单序号',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'Order'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示图像',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'Glyph'
go

execute sp_addextendedproperty 'MS_Description', 
   '点击事件',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'OnClick'
go

execute sp_addextendedproperty 'MS_Description', 
   '提示',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'KeyTip'
go

execute sp_addextendedproperty 'MS_Description', 
   '菜单编程控件',
   'user', 'dbo', 'table', 'T_Menu', 'column', 'MenuControl'
go

/*==============================================================*/
/* Table: T_NecessaryRight                                      */
/*==============================================================*/
create table dbo.T_NecessaryRight (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   NecessaryId          int                  not null,
   constraint PK_T_NecessaryRight primary key (NecessaryId, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '必需品权限表',
   'user', 'dbo', 'table', 'T_NecessaryRight'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_NecessaryRight', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '必需品表Id',
   'user', 'dbo', 'table', 'T_NecessaryRight', 'column', 'NecessaryId'
go

/*==============================================================*/
/* Table: T_NecessaryRightTemp                                  */
/*==============================================================*/
create table dbo.T_NecessaryRightTemp (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   NecessaryId          int                  not null,
   Flag                 varchar(36)          collate Chinese_PRC_CI_AS not null
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '必需品权限临时数据',
   'user', 'dbo', 'table', 'T_NecessaryRightTemp'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_NecessaryRightTemp', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '必需品表Id',
   'user', 'dbo', 'table', 'T_NecessaryRightTemp', 'column', 'NecessaryId'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态标识',
   'user', 'dbo', 'table', 'T_NecessaryRightTemp', 'column', 'Flag'
go

/*==============================================================*/
/* Table: T_Product                                             */
/*==============================================================*/
create table dbo.T_Product (
   ProductId            int                  identity(1, 1),
   ProductNo            varchar(50)          collate Chinese_PRC_CI_AS not null,
   ProductName          varchar(100)         collate Chinese_PRC_CI_AS not null,
   ProductName1         varchar(100)         collate Chinese_PRC_CI_AS not null,
   Spec                 varchar(100)         collate Chinese_PRC_CI_AS not null,
   Spec1                varchar(100)         collate Chinese_PRC_CI_AS not null,
   ProductType          smallint             not null constraint DF_T_Product_ProductType default (0),
   ProductImage         varchar(50)          collate Chinese_PRC_CI_AS not null,
   Unit                 varchar(5)           collate Chinese_PRC_CI_AS not null,
   Material             varchar(10)          collate Chinese_PRC_CI_AS not null,
   Code                 varchar(20)          collate Chinese_PRC_CI_AS not null,
   GoodCode             varchar(50)          collate Chinese_PRC_CI_AS not null,
   CheckCodeOne         varchar(10)          collate Chinese_PRC_CI_AS not null,
   CheckCodeMany        varchar(50)          collate Chinese_PRC_CI_AS not null,
   PackQty              int                  not null constraint DF_T_Product_PackQty default (0),
   CertType             smallint             not null constraint DF_T_Product_CertType default (0),
   RegisterId           varchar(36)          collate Chinese_PRC_CI_AS not null,
   MinStore             int                  not null constraint DF_T_Product_MinStore default (0),
   MaxStore             int                  not null constraint DF_T_Product_MaxStore default (0),
   Cycle                numeric(18,2)        not null constraint DF_T_Product_Cycle default (0),
   DrawingId            int                  not null constraint DF_T_Product_DrawingId default (0),
   IsRemind             bit                  not null constraint DF_T_Product_IsRemind default (0),
   QtyMode              smallint             not null constraint DF_T_Product_QtyMode default (1),
   preprice1            numeric(18,4)        not null constraint DF_T_Product_preprice1 default (0),
   preprice2            numeric(18,4)        not null constraint DF_T_Product_preprice2 default (0),
   preprice3            numeric(18,4)        not null constraint DF_T_Product_preprice3 default (0),
   preprice4            numeric(18,4)        not null constraint DF_T_Product_preprice31 default (0),
   recprice             numeric(18,4)        not null constraint DF_T_Product_price default (0),
   Remark1              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark2              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark3              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark4              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark5              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark6              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark7              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark8              varchar(500)         collate Chinese_PRC_CI_AS not null,
   ShowNo               varchar(50)          collate Chinese_PRC_CI_AS not null,
   ShowProductName      varchar(100)         collate Chinese_PRC_CI_AS not null,
   ShowSpec             varchar(100)         collate Chinese_PRC_CI_AS not null,
   ShowLOrR             varchar(5)           collate Chinese_PRC_CI_AS not null,
   ShowPos              varchar(50)          collate Chinese_PRC_CI_AS not null,
   IsShow               bit                  not null constraint DF_T_Product_IsShow default (0),
   IsNew                bit                  not null constraint DF_T_Product_IsNew default (0),
   NewRemark            varchar(500)         collate Chinese_PRC_CI_AS not null,
   PId                  int                  not null,
   Level_Path           varchar(1000)        collate Chinese_PRC_CI_AS not null,
   Level_Num            int                  not null,
   Level_Total          int                  not null,
   Level_Deep           int                  not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Product_Deleted default (0),
   constraint PK_T_Product primary key (ProductId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '产品信息',
   'user', 'dbo', 'table', 'T_Product'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品编号',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品名称',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductName'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品名称(英文)',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductName1'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格型号',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Spec'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格型号(英文)',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Spec1'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品类型（成品，零部件）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductType'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品大图',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ProductImage'
go

execute sp_addextendedproperty 'MS_Description', 
   '计量单位',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Unit'
go

execute sp_addextendedproperty 'MS_Description', 
   '材料标识',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Material'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品代码',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Code'
go

execute sp_addextendedproperty 'MS_Description', 
   '货位号',
   'user', 'dbo', 'table', 'T_Product', 'column', 'GoodCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '校验码（单）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'CheckCodeOne'
go

execute sp_addextendedproperty 'MS_Description', 
   '校验码（多）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'CheckCodeMany'
go

execute sp_addextendedproperty 'MS_Description', 
   '包装数量',
   'user', 'dbo', 'table', 'T_Product', 'column', 'PackQty'
go

execute sp_addextendedproperty 'MS_Description', 
   '证件类型（a证，b证）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'CertType'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品注册证Id',
   'user', 'dbo', 'table', 'T_Product', 'column', 'RegisterId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最小库存',
   'user', 'dbo', 'table', 'T_Product', 'column', 'MinStore'
go

execute sp_addextendedproperty 'MS_Description', 
   '最大库存',
   'user', 'dbo', 'table', 'T_Product', 'column', 'MaxStore'
go

execute sp_addextendedproperty 'MS_Description', 
   '生产周期（小时）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Cycle'
go

execute sp_addextendedproperty 'MS_Description', 
   '图纸Id',
   'user', 'dbo', 'table', 'T_Product', 'column', 'DrawingId'
go

execute sp_addextendedproperty 'MS_Description', 
   '库存报警标识',
   'user', 'dbo', 'table', 'T_Product', 'column', 'IsRemind'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量模式（0，通用模式，1严格管理序列号，2严格管理批号）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'QtyMode'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格1',
   'user', 'dbo', 'table', 'T_Product', 'column', 'preprice1'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格2',
   'user', 'dbo', 'table', 'T_Product', 'column', 'preprice2'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格3',
   'user', 'dbo', 'table', 'T_Product', 'column', 'preprice3'
go

execute sp_addextendedproperty 'MS_Description', 
   '零售价',
   'user', 'dbo', 'table', 'T_Product', 'column', 'preprice4'
go

execute sp_addextendedproperty 'MS_Description', 
   '最近价格',
   'user', 'dbo', 'table', 'T_Product', 'column', 'recprice'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注1',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark1'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注2',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark2'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注3',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark3'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注4',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark4'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注5',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark5'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注6',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark6'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注7',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark7'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注8',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Remark8'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示编号',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ShowNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示产品名称',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ShowProductName'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示规格型号',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ShowSpec'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示左右',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ShowLOrR'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示适应部位',
   'user', 'dbo', 'table', 'T_Product', 'column', 'ShowPos'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否销售（所有show开头均为销售选项）',
   'user', 'dbo', 'table', 'T_Product', 'column', 'IsShow'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否为新品',
   'user', 'dbo', 'table', 'T_Product', 'column', 'IsNew'
go

execute sp_addextendedproperty 'MS_Description', 
   '新品发布说明',
   'user', 'dbo', 'table', 'T_Product', 'column', 'NewRemark'
go

execute sp_addextendedproperty 'MS_Description', 
   '树性父结构代码',
   'user', 'dbo', 'table', 'T_Product', 'column', 'PId'
go

execute sp_addextendedproperty 'MS_Description', 
   '树性结构路径',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Level_Path'
go

execute sp_addextendedproperty 'MS_Description', 
   '儿子数量',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Level_Num'
go

execute sp_addextendedproperty 'MS_Description', 
   '子孙数量',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Level_Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '树的深度',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Level_Deep'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Product', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Product', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Product', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Product', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标志',
   'user', 'dbo', 'table', 'T_Product', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_ProductBNInvent                                     */
/*==============================================================*/
create table dbo.T_ProductBNInvent (
   PBNInventId          varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PBNIn__3B60C8C7 default newid(),
   PInventId            varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   Qty                  numeric(18,4)        not null,
   Price                numeric(18,4)        not null,
   Total                numeric(18,4)        not null,
   constraint PK__T_ProductBNInven__3A6CA48E primary key (PBNInventId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品批号库存表',
   'user', 'dbo', 'table', 'T_ProductBNInvent'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品批号库存Id',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'PBNInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品库存Id',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'PInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '单价',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'Price'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_ProductBNInvent', 'column', 'Total'
go

/*==============================================================*/
/* Table: T_ProductDlyBak                                       */
/*==============================================================*/
create table dbo.T_ProductDlyBak (
   PDlyBakId            varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PDlyB__3E3D3572 default newid(),
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   ATypeId              int                  not null,
   CompanyId            int                  not null,
   DlyType              smallint             not null,
   DlyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   JSRId                int                  not null,
   StockId1             int                  not null,
   StockId2             int                  not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   CostPrice            float                not null,
   CostTotal            numeric(18,4)        not null,
   Price                float                not null,
   Total                numeric(18,4)        not null,
   DisCount             numeric(3,2)         not null,
   DisPrice             float                not null,
   DisTotal             numeric(18,4)        not null,
   TaxRate              numeric(18,4)        not null,
   Tax                  numeric(18,4)        not null,
   TaxPrice             float                not null,
   TaxTotal             numeric(18,4)        not null,
   RetailPrice          float                not null,
   InvoceTotal          numeric(18,4)        not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   C_OrderNdxId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   C_ProductOrderId     varchar(36)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductDlyBak__3D491139 primary key (PDlyBakId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据草稿',
   'user', 'dbo', 'table', 'T_ProductDlyBak'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'PDlyBakId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'ATypeId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DlyType'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DlyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'JSRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id1',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'StockId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id2',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'StockId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '成本单价',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'CostPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '成本金额',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'CostTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '单价',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'Price'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '折扣(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DisCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '折后单价 单价*折扣(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DisPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '折后金额 金额*折扣(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'DisTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '税率(%?)(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'TaxRate'
go

execute sp_addextendedproperty 'MS_Description', 
   '税额  折后金额*税率(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'Tax'
go

execute sp_addextendedproperty 'MS_Description', 
   '含税单价 折后单价+(折后单价*税率)(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'TaxPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '含税金额 折后金额+税额(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'TaxTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '零售价格(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'RetailPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '开票金额(--)',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'InvoceTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'C_OrderNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品订单Id',
   'user', 'dbo', 'table', 'T_ProductDlyBak', 'column', 'C_ProductOrderId'
go

/*==============================================================*/
/* Table: T_ProductDlyFBNBak                                    */
/*==============================================================*/
create table dbo.T_ProductDlyFBNBak (
   PDlyFBNBakId         varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PDlyF__4119A21D default newid(),
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   ATypeId              int                  not null,
   PDlyBakId            varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   CompanyId            int                  not null,
   StockId1             int                  not null,
   StockId2             int                  not null,
   JSRId                int                  not null,
   FullBN               varchar(30)          collate Chinese_PRC_CI_AS not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   DlyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   C_OrderNdxId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   C_ProductOrderId     varchar(36)          collate Chinese_PRC_CI_AS not null,
   DlyType              smallint             not null,
   constraint PK__T_ProductDlyFBNB__40257DE4 primary key (PDlyFBNBakId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据草稿批号备份',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'PDlyFBNBakId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'ATypeId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据草稿Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'PDlyBakId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id1',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'StockId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id2',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'StockId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'JSRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '完整批号',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'FullBN'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'DlyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'C_OrderNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品订单Id',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'C_ProductOrderId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', 'dbo', 'table', 'T_ProductDlyFBNBak', 'column', 'DlyType'
go

/*==============================================================*/
/* Table: T_ProductDlySNBak                                     */
/*==============================================================*/
create table dbo.T_ProductDlySNBak (
   PDlySNBakId          varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PDlyS__43F60EC8 default newid(),
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   ATypeId              int                  not null,
   PDlyBakId            varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   CompanyId            int                  not null,
   StockId1             int                  not null,
   StockId2             int                  not null,
   JSRId                int                  not null,
   SN                   varchar(30)          collate Chinese_PRC_CI_AS not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   DlyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   C_OrderNdxId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   C_ProductOrderId     varchar(36)          collate Chinese_PRC_CI_AS not null,
   DlyType              smallint             not null,
   constraint PK__T_ProductDlySNBa__4301EA8F primary key (PDlySNBakId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据草稿序列号备份',
   'user', 'dbo', 'table', 'T_ProductDlySNBak'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'PDlySNBakId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'ATypeId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据草稿Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'PDlyBakId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id1',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'StockId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id2',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'StockId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'JSRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '序列号',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'SN'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'DlyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单索引表Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'C_OrderNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品订单Id',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'C_ProductOrderId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', 'dbo', 'table', 'T_ProductDlySNBak', 'column', 'DlyType'
go

/*==============================================================*/
/* Table: T_ProductFBNInOutDetails                              */
/*==============================================================*/
create table dbo.T_ProductFBNInOutDetails (
   PFBNInOutDetailId    varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PFBNI__46D27B73 default newid(),
   PInOutDetailId       varchar(36)          collate Chinese_PRC_CI_AS not null,
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   PDlyId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   InOutDate            varchar(10)          collate Chinese_PRC_CI_AS not null,
   FullBN               varchar(30)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductFBNInOu__45DE573A primary key (PFBNInOutDetailId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品完整批号出入库明细表',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'PFBNInOutDetailId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品出入库明细表Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'PInOutDetailId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据表Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'PDlyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '出入库日期',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'InOutDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '完整批号',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'FullBN'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductFBNInOutDetails', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_ProductFBNInvent                                    */
/*==============================================================*/
create table dbo.T_ProductFBNInvent (
   PFBNInventId         varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PFBNI__49AEE81E default newid(),
   PBNInventId          varchar(36)          collate Chinese_PRC_CI_AS not null,
   PInventId            varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   FBN                  varchar(10)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   constraint PK__T_ProductFBNInve__48BAC3E5 primary key (PFBNInventId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品完整批号库存表',
   'user', 'dbo', 'table', 'T_ProductFBNInvent'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品完整批号库存Id',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'PFBNInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品批号库存Id',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'PBNInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品库存Id',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'PInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '完整批号',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'FBN'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductFBNInvent', 'column', 'Qty'
go

/*==============================================================*/
/* Table: T_ProductInOutDetails                                 */
/*==============================================================*/
create table dbo.T_ProductInOutDetails (
   PInOutDetailId       varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PInOu__4C8B54C9 default newid(),
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   PDlyId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   InOutDate            varchar(10)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   Price                float                not null,
   Total                numeric(18,4)        not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductInOutDe__4B973090 primary key (PInOutDetailId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品出入库明细表',
   'user', 'dbo', 'table', 'T_ProductInOutDetails'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'PInOutDetailId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据表Id',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'PDlyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '出入库日期',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'InOutDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '单价',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'Price'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductInOutDetails', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_ProductInvent                                       */
/*==============================================================*/
create table dbo.T_ProductInvent (
   PInventId            varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PInve__4F67C174 default newid(),
   ProductId            int                  not null,
   StockId              int                  not null,
   Qty                  numeric(18,4)        not null,
   Price                numeric(18,4)        not null,
   Total                numeric(18,4)        not null,
   constraint PK__T_ProductInvent__4E739D3B primary key (PInventId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品库存表',
   'user', 'dbo', 'table', 'T_ProductInvent'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品库存Id',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'PInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '单价',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'Price'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_ProductInvent', 'column', 'Total'
go

/*==============================================================*/
/* Table: T_ProductRight                                        */
/*==============================================================*/
create table dbo.T_ProductRight (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   constraint PK__T_ProductRight__6F1576F7 primary key (ProductId, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '产品权限表',
   'user', 'dbo', 'table', 'T_ProductRight'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_ProductRight', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品Id',
   'user', 'dbo', 'table', 'T_ProductRight', 'column', 'ProductId'
go

/*==============================================================*/
/* Table: T_ProductRightTemp                                    */
/*==============================================================*/
create table dbo.T_ProductRightTemp (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   Flag                 varchar(36)          collate Chinese_PRC_CI_AS not null
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_ProductRightTemp',
   'user', 'dbo', 'table', 'T_ProductRightTemp'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_ProductRightTemp', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品Id',
   'user', 'dbo', 'table', 'T_ProductRightTemp', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态标识',
   'user', 'dbo', 'table', 'T_ProductRightTemp', 'column', 'Flag'
go

/*==============================================================*/
/* Table: T_ProductSNInOutDetails                               */
/*==============================================================*/
create table dbo.T_ProductSNInOutDetails (
   PSNInOutDetailId     varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PSNIn__55209ACA default newid(),
   PInOutDetailId       varchar(36)          collate Chinese_PRC_CI_AS not null,
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   PDlyId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   InOutDate            varchar(10)          collate Chinese_PRC_CI_AS not null,
   SN                   varchar(30)          collate Chinese_PRC_CI_AS not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductSNInOut__542C7691 primary key (PSNInOutDetailId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品序列号出入库明细表',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'PSNInOutDetailId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品出入库明细表Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'PInOutDetailId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品单据表Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'PDlyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '出入库日期',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'InOutDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '序列号',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'SN'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductSNInOutDetails', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_ProductSNInvent                                     */
/*==============================================================*/
create table dbo.T_ProductSNInvent (
   PSNInventId          varchar(36)          collate Chinese_PRC_CI_AS not null,
   PBNInventId          varchar(36)          collate Chinese_PRC_CI_AS not null,
   PInventId            varchar(36)          collate Chinese_PRC_CI_AS not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   SN                   varchar(30)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductSNInven__5708E33C primary key (PSNInventId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '商品序列号库存表',
   'user', 'dbo', 'table', 'T_ProductSNInvent'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品序列号库存Id',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'PSNInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品批号库存Id',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'PBNInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品库存Id',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'PInventId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '序列号',
   'user', 'dbo', 'table', 'T_ProductSNInvent', 'column', 'SN'
go

/*==============================================================*/
/* Table: T_ProductSaleDly                                      */
/*==============================================================*/
create table dbo.T_ProductSaleDly (
   PSaleDlyId           varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product__PSale__52442E1F default newid(),
   DlyNdxId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   ATypeId              int                  not null,
   CompanyId            int                  not null,
   DlyType              smallint             not null,
   DlyDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   JSRId                int                  not null,
   StockId1             int                  not null,
   StockId2             int                  not null,
   ProductId            int                  not null,
   BN                   varchar(10)          collate Chinese_PRC_CI_AS not null,
   Qty                  numeric(18,4)        not null,
   CostPrice            float                not null,
   CostTotal            numeric(18,4)        not null,
   Price                float                not null,
   Total                numeric(18,4)        not null,
   DisCount             numeric(3,2)         not null,
   DisPrice             float                not null,
   DisTotal             numeric(18,4)        not null,
   TaxRate              numeric(18,4)        not null,
   Tax                  numeric(18,4)        not null,
   TaxPrice             float                not null,
   TaxTotal             numeric(18,4)        not null,
   RetailPrice          float                not null,
   InvoceTotal          numeric(18,4)        not null,
   Remark               varchar(50)          collate Chinese_PRC_CI_AS not null,
   C_OrderNdxId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   C_ProductOrderId     varchar(36)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_ProductSaleDly__515009E6 primary key (PSaleDlyId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_ProductSaleDly',
   'user', 'dbo', 'table', 'T_ProductSaleDly'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'PSaleDlyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据索引表Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DlyNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '科目表Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'ATypeId'
go

execute sp_addextendedproperty 'MS_Description', 
   '往来单位Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'CompanyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据类型',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DlyType'
go

execute sp_addextendedproperty 'MS_Description', 
   '单据日期',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DlyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '经手人Id，员工Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'JSRId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id1',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'StockId1'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id2',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'StockId2'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '批号',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'BN'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '成本单价',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'CostPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '成本金额',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'CostTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '单价',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'Price'
go

execute sp_addextendedproperty 'MS_Description', 
   '金额',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '折扣(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DisCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '折后单价 单价*折扣(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DisPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '折后金额 金额*折扣(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'DisTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '税率(%?)(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'TaxRate'
go

execute sp_addextendedproperty 'MS_Description', 
   '税额  折后金额*税率(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'Tax'
go

execute sp_addextendedproperty 'MS_Description', 
   '含税单价 折后单价+(折后单价*税率)(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'TaxPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '含税金额 折后金额+税额(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'TaxTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '零售价格(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'RetailPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '开票金额(--)',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'InvoceTotal'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单索引表Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'C_OrderNdxId'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品订单Id',
   'user', 'dbo', 'table', 'T_ProductSaleDly', 'column', 'C_ProductOrderId'
go

/*==============================================================*/
/* Table: T_Product_Drawings                                    */
/*==============================================================*/
create table dbo.T_Product_Drawings (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product_Dr__Id__16644E42 default newid(),
   ProductId            int                  not null,
   DrawingId            int                  not null,
   CreateUserId         int                  not null,
   CreateDate           datetime             not null,
   LastModifyUserId     int                  not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Product_Drawings_Deleted default (0),
   constraint PK_Base_Product_Drawings primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_Product_Drawings',
   'user', 'dbo', 'table', 'T_Product_Drawings'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品Id',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '图纸Id',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'DrawingId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'CreateUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'LastModifyUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'Deleted',
   'user', 'dbo', 'table', 'T_Product_Drawings', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_Product_Register                                    */
/*==============================================================*/
create table dbo.T_Product_Register (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product_Re__Id__37C5420D default newid(),
   ProductId            int                  not null,
   RegisterId           varchar(36)          collate Chinese_PRC_CI_AS not null,
   Spec                 varchar(100)         collate Chinese_PRC_CI_AS not null,
   Spec1                varchar(100)         collate Chinese_PRC_CI_AS not null,
   CreateUserId         int                  not null,
   CreateDate           datetime             not null,
   LastModifyUserId     int                  not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Product_Register_Deleted default (0),
   constraint PK_T_Product_Register primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_Product_Register',
   'user', 'dbo', 'table', 'T_Product_Register'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品Id',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证Id',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'RegisterId'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格型号',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'Spec'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格型号(英文)',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'Spec1'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'CreateUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'LastModifyUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   'Deleted',
   'user', 'dbo', 'table', 'T_Product_Register', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_Product_TechStep                                    */
/*==============================================================*/
create table dbo.T_Product_TechStep (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Product_Te__Id__1E05700A default newid(),
   ProductId            int                  not null,
   DrawingId            int                  not null,
   TechId               int                  not null,
   TechStepId           int                  not null,
   Runtime              numeric(18,2)        null,
   AvgRunTime           numeric(18,2)        null,
   Wage                 numeric(18,2)        null,
   IsSelect             bit                  not null,
   IsContinue           bit                  not null,
   Remark               text                 collate Chinese_PRC_CI_AS null,
   CreateUserId         int                  not null,
   CreateDate           datetime             not null,
   LastModifyUserId     int                  not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Product_TechStep_Deleted default (0),
   constraint PK_Base_Product_TechStep primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_Product_TechStep',
   'user', 'dbo', 'table', 'T_Product_TechStep'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '产品Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'ProductId'
go

execute sp_addextendedproperty 'MS_Description', 
   '图纸Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'DrawingId'
go

execute sp_addextendedproperty 'MS_Description', 
   '工艺文件Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'TechId'
go

execute sp_addextendedproperty 'MS_Description', 
   '工艺步骤Id，顺序',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'TechStepId'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设时长',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'Runtime'
go

execute sp_addextendedproperty 'MS_Description', 
   '平均时长',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'AvgRunTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '工价',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'Wage'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否选择',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'IsSelect'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否连续',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'IsContinue'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'CreateUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'LastModifyUserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_Product_TechStep', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_RawMate                                             */
/*==============================================================*/
create table dbo.T_RawMate (
   RawMateId            int                  identity(1, 1),
   RawMateNo            varchar(50)          collate Chinese_PRC_CI_AS not null,
   RawMateName          varchar(100)         collate Chinese_PRC_CI_AS not null,
   Spec                 varchar(50)          collate Chinese_PRC_CI_AS not null,
   MinStore             numeric(18,2)        not null constraint DF_T_RawMate_MinStore default (0),
   MaxStore             numeric(18,2)        not null constraint DF_T_RawMate_MaxStore default (0),
   Unit                 varchar(20)          collate Chinese_PRC_CI_AS not null,
   IsRemind             bit                  not null constraint DF_T_RawMate_IsRemind default (0),
   QtyMode              smallint             not null constraint DF_T_RawMate_QtyMode default (0),
   preprice1            numeric(18,4)        not null constraint DF_T_RawMate_preprice1 default (0),
   preprice2            numeric(18,4)        not null constraint DF_T_RawMate_preprice2 default (0),
   preprice3            numeric(18,4)        not null constraint DF_T_RawMate_preprice3 default (0),
   recprice             numeric(18,4)        not null constraint DF_T_RawMate_price default (0),
   Remark1              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark2              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark3              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Remark4              varchar(500)         collate Chinese_PRC_CI_AS not null,
   Deleted              bit                  not null constraint DF_T_RawMate_Deleted default (0),
   PId                  int                  not null,
   Level_Path           varchar(1000)        collate Chinese_PRC_CI_AS not null,
   Level_Num            int                  not null,
   Level_Total          int                  not null,
   Level_Deep           int                  not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   constraint PK_T_RawMate primary key (RawMateId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料信息',
   'user', 'dbo', 'table', 'T_RawMate'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'RawMateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料编号',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'RawMateNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料名称',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'RawMateName'
go

execute sp_addextendedproperty 'MS_Description', 
   '规格型号',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Spec'
go

execute sp_addextendedproperty 'MS_Description', 
   '最小库存',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'MinStore'
go

execute sp_addextendedproperty 'MS_Description', 
   '最大库存',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'MaxStore'
go

execute sp_addextendedproperty 'MS_Description', 
   '计量单位',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Unit'
go

execute sp_addextendedproperty 'MS_Description', 
   '库存报警标识',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'IsRemind'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量模式（0，通用模式，1严格管理序列号，2严格管理批号）',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'QtyMode'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格1',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'preprice1'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格2',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'preprice2'
go

execute sp_addextendedproperty 'MS_Description', 
   '预设价格3',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'preprice3'
go

execute sp_addextendedproperty 'MS_Description', 
   '最近价格',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'recprice'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注1',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Remark1'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注2',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Remark2'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注3',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Remark3'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注4',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Remark4'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Deleted'
go

execute sp_addextendedproperty 'MS_Description', 
   '父Id',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'PId'
go

execute sp_addextendedproperty 'MS_Description', 
   '树形结构路径',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Level_Path'
go

execute sp_addextendedproperty 'MS_Description', 
   '儿子数量',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Level_Num'
go

execute sp_addextendedproperty 'MS_Description', 
   '子孙数量',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Level_Total'
go

execute sp_addextendedproperty 'MS_Description', 
   '树的深度',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'Level_Deep'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_RawMate', 'column', 'LastModifyDate'
go

/*==============================================================*/
/* Table: T_RawMateRight                                        */
/*==============================================================*/
create table dbo.T_RawMateRight (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   RawMateId            int                  not null,
   constraint PK__T_RawMateRight__71F1E3A2 primary key (RawMateId, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料权限表',
   'user', 'dbo', 'table', 'T_RawMateRight'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_RawMateRight', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料Id',
   'user', 'dbo', 'table', 'T_RawMateRight', 'column', 'RawMateId'
go

/*==============================================================*/
/* Table: T_RawMateRightTemp                                    */
/*==============================================================*/
create table dbo.T_RawMateRightTemp (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   RawMateId            int                  not null,
   Flag                 varchar(36)          collate Chinese_PRC_CI_AS not null
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料权限临时数据',
   'user', 'dbo', 'table', 'T_RawMateRightTemp'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_RawMateRightTemp', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '原材料Id',
   'user', 'dbo', 'table', 'T_RawMateRightTemp', 'column', 'RawMateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态标识',
   'user', 'dbo', 'table', 'T_RawMateRightTemp', 'column', 'Flag'
go

/*==============================================================*/
/* Table: T_Register                                            */
/*==============================================================*/
create table dbo.T_Register (
   RegisterId           varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_Registe__Regis__4F9CCB9E default newid(),
   RegisterNo           varchar(100)         collate Chinese_PRC_CI_AS not null,
   RegisterProductName  varchar(100)         collate Chinese_PRC_CI_AS not null,
   StandardCode         varchar(100)         collate Chinese_PRC_CI_AS not null,
   RegisterNo1          varchar(100)         collate Chinese_PRC_CI_AS not null,
   RegisterProductName1 varchar(100)         collate Chinese_PRC_CI_AS not null,
   StandardCode1        varchar(100)         collate Chinese_PRC_CI_AS not null,
   RegisterFile         varchar(50)          collate Chinese_PRC_CI_AS not null,
   StartDate            varchar(10)          collate Chinese_PRC_CI_AS not null,
   EndDate              varchar(10)          collate Chinese_PRC_CI_AS not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   Deleted              bit                  not null constraint DF_T_Register_Deleted default (0),
   constraint PK_Base_Register primary key (RegisterId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证信息',
   'user', 'dbo', 'table', 'T_Register'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterId'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证编号',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证名称',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterProductName'
go

execute sp_addextendedproperty 'MS_Description', 
   '标准号',
   'user', 'dbo', 'table', 'T_Register', 'column', 'StandardCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证编号(英文)',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterNo1'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证名称(英文)',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterProductName1'
go

execute sp_addextendedproperty 'MS_Description', 
   '标准号(英文)',
   'user', 'dbo', 'table', 'T_Register', 'column', 'StandardCode1'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证文件',
   'user', 'dbo', 'table', 'T_Register', 'column', 'RegisterFile'
go

execute sp_addextendedproperty 'MS_Description', 
   '启用日期',
   'user', 'dbo', 'table', 'T_Register', 'column', 'StartDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '停用日期',
   'user', 'dbo', 'table', 'T_Register', 'column', 'EndDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Register', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Register', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Register', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Register', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Register', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_Register', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_RegisterAttachment                                  */
/*==============================================================*/
create table dbo.T_RegisterAttachment (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null,
   RegisterId           varchar(36)          collate Chinese_PRC_CI_AS not null,
   ShowName             varchar(50)          collate Chinese_PRC_CI_AS not null,
   SaveName             varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_RegisterAttach__546180BB primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证附件表',
   'user', 'dbo', 'table', 'T_RegisterAttachment'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_RegisterAttachment', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册证Id',
   'user', 'dbo', 'table', 'T_RegisterAttachment', 'column', 'RegisterId'
go

execute sp_addextendedproperty 'MS_Description', 
   '附件名称',
   'user', 'dbo', 'table', 'T_RegisterAttachment', 'column', 'ShowName'
go

execute sp_addextendedproperty 'MS_Description', 
   '保存名称',
   'user', 'dbo', 'table', 'T_RegisterAttachment', 'column', 'SaveName'
go

/*==============================================================*/
/* Table: T_Role                                                */
/*==============================================================*/
create table dbo.T_Role (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF_T_Role_RoleId default newid(),
   RoleNo               varchar(50)          collate Chinese_PRC_CI_AS not null,
   RoleName             nvarchar(50)         collate Chinese_PRC_CI_AS not null,
   IsLock               bit                  not null,
   IsSuper              bit                  not null,
   Remark               varchar(100)         collate Chinese_PRC_CI_AS not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF_T_Role_Deleted default (0),
   constraint PK__tmp_ms_xx_T_Role__160F4887 primary key (RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '角色表',
   'user', 'dbo', 'table', 'T_Role'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_Role', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色编号',
   'user', 'dbo', 'table', 'T_Role', 'column', 'RoleNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', 'dbo', 'table', 'T_Role', 'column', 'RoleName'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否锁定',
   'user', 'dbo', 'table', 'T_Role', 'column', 'IsLock'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否是超级管理员角色',
   'user', 'dbo', 'table', 'T_Role', 'column', 'IsSuper'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Role', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Role', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Role', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_Role', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_Role', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标志',
   'user', 'dbo', 'table', 'T_Role', 'column', 'Deleted'
go

/*==============================================================*/
/* Table: T_RoleAction                                          */
/*==============================================================*/
create table dbo.T_RoleAction (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   ActionNo             varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_RoleAction__3E1D39E1 primary key (RoleId, ActionNo)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '角色功能表',
   'user', 'dbo', 'table', 'T_RoleAction'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_RoleAction', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '功能编号',
   'user', 'dbo', 'table', 'T_RoleAction', 'column', 'ActionNo'
go

/*==============================================================*/
/* Table: T_RoleMenu                                            */
/*==============================================================*/
create table dbo.T_RoleMenu (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   MenuNo               varchar(50)          collate Chinese_PRC_CI_AS not null,
   constraint PK__T_RoleMenu__2A164134 primary key (MenuNo, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '角色菜单表',
   'user', 'dbo', 'table', 'T_RoleMenu'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_RoleMenu', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '菜单编号',
   'user', 'dbo', 'table', 'T_RoleMenu', 'column', 'MenuNo'
go

/*==============================================================*/
/* Table: T_Stock                                               */
/*==============================================================*/
create table dbo.T_Stock (
   StockId              int                  identity(1, 1),
   StockNo              varchar(50)          collate Chinese_PRC_CI_AS not null,
   StockName            varchar(100)         collate Chinese_PRC_CI_AS not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null,
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   Deleted              bit                  not null constraint DF__T_Stock__Deleted__0BB1B5A5 default (0),
   Remark               varchar(200)         collate Chinese_PRC_CI_AS not null,
   constraint PK__T_Stock__0ABD916C primary key (StockId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库表',
   'user', 'dbo', 'table', 'T_Stock'
go

execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库编号',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'StockNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库名称',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'StockName'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后修改人Id',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后修改日期',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'Deleted'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_Stock', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_StockRight                                          */
/*==============================================================*/
create table dbo.T_StockRight (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   constraint PK__T_StockRight__74CE504D primary key (RoleId, StockId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库权限表',
   'user', 'dbo', 'table', 'T_StockRight'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_StockRight', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_StockRight', 'column', 'StockId'
go

/*==============================================================*/
/* Table: T_StockRightTemp                                      */
/*==============================================================*/
create table dbo.T_StockRightTemp (
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   StockId              int                  not null,
   Flag                 varchar(36)          collate Chinese_PRC_CI_AS not null
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库权限临时数据',
   'user', 'dbo', 'table', 'T_StockRightTemp'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_StockRightTemp', 'column', 'RoleId'
go

execute sp_addextendedproperty 'MS_Description', 
   '仓库Id',
   'user', 'dbo', 'table', 'T_StockRightTemp', 'column', 'StockId'
go

execute sp_addextendedproperty 'MS_Description', 
   '状态标识',
   'user', 'dbo', 'table', 'T_StockRightTemp', 'column', 'Flag'
go

/*==============================================================*/
/* Table: T_User                                                */
/*==============================================================*/
create table dbo.T_User (
   UserId               varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_User__UserId__1FCDBCEB default newid(),
   UserNo               varchar(50)          collate Chinese_PRC_CI_AS not null,
   UserName             nvarchar(50)         collate Chinese_PRC_CI_AS not null,
   UserPassWord         varchar(50)          collate Chinese_PRC_CI_AS not null,
   IsLock               bit                  not null constraint DF__T_User__IsLock__20C1E124 default (0),
   Deleted              bit                  not null constraint DF__T_User__Deleted__22AA2996 default (0),
   Remark               varchar(100)         collate Chinese_PRC_CI_AS not null,
   CreateId             varchar(36)          collate Chinese_PRC_CI_AS not null,
   CreateDate           datetime             not null constraint DF__T_User__CreateDa__24927208 default getdate(),
   LastModifyId         varchar(36)          collate Chinese_PRC_CI_AS not null,
   LastModifyDate       datetime             not null,
   IsUserAuthority      bit                  not null constraint DF__T_User__IsUserAu__25869641 default (0),
   constraint PK__T_User__1ED998B2 primary key (UserId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '用户表',
   'user', 'dbo', 'table', 'T_User'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'T_User', 'column', 'UserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户账号',
   'user', 'dbo', 'table', 'T_User', 'column', 'UserNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户名称',
   'user', 'dbo', 'table', 'T_User', 'column', 'UserName'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户密码',
   'user', 'dbo', 'table', 'T_User', 'column', 'UserPassWord'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否锁定',
   'user', 'dbo', 'table', 'T_User', 'column', 'IsLock'
go

execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', 'dbo', 'table', 'T_User', 'column', 'Deleted'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'T_User', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'T_User', 'column', 'CreateId'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'T_User', 'column', 'CreateDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改人Id',
   'user', 'dbo', 'table', 'T_User', 'column', 'LastModifyId'
go

execute sp_addextendedproperty 'MS_Description', 
   '最后更改日期',
   'user', 'dbo', 'table', 'T_User', 'column', 'LastModifyDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用用户权限',
   'user', 'dbo', 'table', 'T_User', 'column', 'IsUserAuthority'
go

/*==============================================================*/
/* Table: T_UserAction                                          */
/*==============================================================*/
create table dbo.T_UserAction (
   Id                   int                  not null,
   constraint PK__T_UserAction__440B1D61 primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_UserAction',
   'user', 'dbo', 'table', 'T_UserAction'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_UserAction', 'column', 'Id'
go

/*==============================================================*/
/* Table: T_UserEmployee                                        */
/*==============================================================*/
create table dbo.T_UserEmployee (
   UserId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   EmpId                varchar(36)          collate Chinese_PRC_CI_AS not null,
   constraint PK_T_UserEmployee primary key (UserId, EmpId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '用户员工关系表',
   'user', 'dbo', 'table', 'T_UserEmployee'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'T_UserEmployee', 'column', 'UserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '员工Id',
   'user', 'dbo', 'table', 'T_UserEmployee', 'column', 'EmpId'
go

/*==============================================================*/
/* Index: IX_T_UserEmployee_EmpId                               */
/*==============================================================*/
create unique index IX_T_UserEmployee_EmpId on dbo.T_UserEmployee (
EmpId ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_T_UserEmployee_UserId                              */
/*==============================================================*/
create unique index IX_T_UserEmployee_UserId on dbo.T_UserEmployee (
UserId ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: T_UserInRole                                          */
/*==============================================================*/
create table dbo.T_UserInRole (
   UserId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   RoleId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   constraint PK_T_UserInRole primary key (UserId, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '用户角色表',
   'user', 'dbo', 'table', 'T_UserInRole'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'T_UserInRole', 'column', 'UserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', 'dbo', 'table', 'T_UserInRole', 'column', 'RoleId'
go

/*==============================================================*/
/* Table: T_UserLog                                             */
/*==============================================================*/
create table dbo.T_UserLog (
   Id                   varchar(36)          collate Chinese_PRC_CI_AS not null constraint DF__T_UserLog__Id__0BC6C43E default newid(),
   UserId               varchar(36)          collate Chinese_PRC_CI_AS not null,
   Operation            varchar(50)          collate Chinese_PRC_CI_AS not null,
   LogDate              datetime             not null,
   constraint PK__T_UserLog__0AD2A005 primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '用户日志表',
   'user', 'dbo', 'table', 'T_UserLog'
go

execute sp_addextendedproperty 'MS_Description', 
   '日志表Id',
   'user', 'dbo', 'table', 'T_UserLog', 'column', 'Id'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'T_UserLog', 'column', 'UserId'
go

execute sp_addextendedproperty 'MS_Description', 
   '操作',
   'user', 'dbo', 'table', 'T_UserLog', 'column', 'Operation'
go

execute sp_addextendedproperty 'MS_Description', 
   '日志日期',
   'user', 'dbo', 'table', 'T_UserLog', 'column', 'LogDate'
go

/*==============================================================*/
/* Table: T_UserMenu                                            */
/*==============================================================*/
create table dbo.T_UserMenu (
   Id                   int                  not null,
   constraint PK__T_UserMenu__45F365D3 primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   'T_UserMenu',
   'user', 'dbo', 'table', 'T_UserMenu'
go

execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', 'dbo', 'table', 'T_UserMenu', 'column', 'Id'
go


create function dbo.F_GetError (@errormsg varchar(max),@code int)
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
go


create function dbo.F_PadLeft (@num varchar(16),@paddingChar char(1),@totalWidth int)
returns varchar(16) as

begin

declare @curStr varchar(16)

select @curStr = isnull(replicate(@paddingChar,@totalWidth - len(isnull(@num ,0))), '') + @num

return @curStr

end
go


create procedure dbo.P_AddRoleAction (
 	@RoleId VARCHAR(36),
 	@ActionNo VARCHAR(50)
 ) as
insert into T_RoleAction(RoleId,ActionNo) values(@RoleId,@ActionNo);
go


create procedure dbo.P_AddRoleMenu (
 	@RoleId VARCHAR(36),
 	@MenuNo VARCHAR(50)
 ) as
insert into T_RoleMenu(RoleId,MenuNo) values(@RoleId,@MenuNo);
go


create procedure dbo.P_AuthenticateUser @UserNo varchar(50),
 	@UserPassWord varchar(50) as
SELECT UserId from T_User where UserNo=@UserNo and UserPassWord=@UserPassWord and IsLock=0 and Deleted=0
go


create procedure dbo.P_BaseRightFlow (
 	@OP varchar(20),
 	@cMode varchar(50),
 	@RoleId varchar(36),
 	@EntityId int,
 	@PId int,
 	@Flag varchar(36),
 	@NewFlag varchar(36),
 	@Check bit
 ) as
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
go


create procedure dbo.P_CreateAction (
 	@ActionNo varchar(50),
 	@ActionName varchar(100),
 	@ParentActionNo varchar(50),
 	@Order int,
 	@Remark varchar(200),
 	@ActionType varchar(20)
 ) as
declare @errmsg varchar(max)
select 1 from T_Action where ActionNo=@ActionNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

insert into T_Action (
   ActionNo,--功能编号
   ActionName,--功能名称
   ParentActionNo,--父级编号
   [Order],--序号
   ActionType,--类型
   Remark--备注
)
values(
   @ActionNo,--功能编号
   @ActionName,--功能名称
   @ParentActionNo,--父级编号
   @Order,--序号
   @ActionType,--类型
   @Remark--备注
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateCompany (
 	@CompanyId int output,
 	@CompanyNo varchar(50),
 	@CompanyName varchar(150),
 	@Address varchar(200),
 	@Tel varchar(50),
 	@Fax varchar(50),
 	@PostCode varchar(50),
 	@EMail varchar(100),
 	@Person varchar(50),
 	@BankAndAcount varchar(50),
 	@TaxNumber varchar(50),
 	@ARTotal numeric(9),
 	@APTotal numeric(9),
 	@Remark varchar(200),
 	@Password varchar(100),
 	@CreateId varchar(36),
 	@PId int
 ) as
declare @errmsg varchar(max)
select @CompanyId=0
select 1 from T_Company where CompanyNo=@CompanyNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_Company where CompanyId=@PId
set @Level_Deep = @Level_Deep+1;
--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;
--获取树路径
insert into T_Company (
   CompanyNo,--单位编号
   CompanyName,--单位名称
   Address,--单位地址
   Tel,--电话
   Fax,--传真
   PostCode,--邮政编码
   EMail,--电子邮件
   Person,--联系人
   BankAndAcount,--开户银行
   TaxNumber,--税号
   ARTotal,--应收
   APTotal,--应付
   Remark,--备注
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted,--删除标志
   Password,--登陆密码
   Enable,--是否启用
   PId,--父Id
   Level_Path,--树形结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep--树的深度
)
values(
   @CompanyNo,--单位编号
   @CompanyName,--单位名称
   @Address,--单位地址
   @Tel,--电话
   @Fax,--传真
   @PostCode,--邮政编码
   @EMail,--电子邮件
   @Person,--联系人
   @BankAndAcount,--开户银行
   @TaxNumber,--税号
   @ARTotal,--应收
   @APTotal,--应付
   @Remark,--备注
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0,--删除标志
   @Password,--登陆密码
   1,--是否启用
   @PId,--父Id
   @Level_Path,--树形结构路径
   0,--儿子数量
   0,--子孙数量
   @Level_Deep--树的深度
);

set @CompanyId = @@IDENTITY;--获取插入的实体id

if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_Company set Level_Total=Level_Total+1 where CompanyId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_Company set Level_Num=Level_Num+1 where CompanyId=@PId
	--更新父级节点的子孙数量
end

if(@Level_Path='') set @Level_Path=cast(@CompanyId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@CompanyId as varchar(20))
update T_Company set Level_Path=@Level_Path where CompanyId=@CompanyId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateDept (
 	@DeptId int output,
 	@DeptNo VARCHAR(50),
 	@DeptName VARCHAR(50),
 	@Remark VARCHAR(200),
 	@PId int,
 	@CreateId VARCHAR(36)
 ) as
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
go


create procedure dbo.P_CreateEmployee (
 	@EmpId VARCHAR(36) output,
 	@EmpNo varchar(50),
 	@EmpName varchar(50),
 	@DeptId int,
 	@Sex varchar(5),
 	@Nation varchar(20),
 	@Birthday varchar(10),
 	@Address varchar(500),
 	@TelPhone varchar(20),
 	@Mobile varchar(20),
 	@Origin varchar(10),
 	@Title varchar(50),
 	@Duty varchar(50),
 	@Post varchar(50),
 	@EmpStatus smallint,
 	@WedStatus varchar(5),
 	@AttCardNo varchar(20),
 	@GenCardNo varchar(20),
 	@IdCardNo varchar(30),
 	@Photo varchar(50),
 	@Specialty varchar(50),
 	@Diploma varchar(10),
 	@GraduateSchool varchar(100),
 	@PoliticalStatus varchar(10),
 	@JoinDate varchar(10),
 	@TrialStartDate varchar(10),
 	@TrialEndDate varchar(10),
 	@PositiveDate varchar(10),
 	@ContractStartDate varchar(10),
 	@ContractEndDate varchar(10),
 	@HolidaySMS bit,
 	@BirthdaySMS bit,
 	@Att bit,
 	@CreateId varchar(36),
 	@Remark varchar(200),
 	@Remark1 varchar(200),
 	@Remark2 varchar(200)
 ) as
declare @errmsg varchar(max)
select 1 from T_Employee where EmpNo=@EmpNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @EmpId = newid();

insert into T_Employee (
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   DeptId,--部门Id
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Remark1,--备注1
   Remark2--备注2
)
values(
   @EmpId,--员工Id
   @EmpNo,--员工编号
   @EmpName,--员工姓名
   @DeptId,--部门Id
   @Sex,--性别
   @Nation,--民族
   @Birthday,--生日
   @Address,--家庭住址
   @TelPhone,--联系电话
   @Mobile,--手机
   @Origin,--籍贯
   @Title,--职称
   @Duty,--职务
   @Post,--岗位
   @EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   @WedStatus,--婚姻状况
   @AttCardNo,--考勤卡号
   @GenCardNo,--通用卡号（生产刷卡，材料领用）
   @IdCardNo,--身份证号
   @Photo,--照片
   @Specialty,--专业
   @Diploma,--最高学历
   @GraduateSchool,--毕业学校
   @PoliticalStatus,--政治面貌
   @JoinDate,--入职日期
   @TrialStartDate,--试用期开始日期
   @TrialEndDate,--试用期结束日期
   @PositiveDate,--转正日期
   @ContractStartDate,--合同开始日期
   @ContractEndDate,--合同结束日期
   @HolidaySMS,--节假日短信祝福
   @BirthdaySMS,--生日短信祝福
   @Att,--是否记考勤
   @CreateId,--创建人
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   @Remark,--备注
   @Remark1,--备注1
   @Remark2--备注2
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateEmployeeAttachment (
 	@Id VARCHAR(36) output,
 	@EmpId varchar(36),
 	@SaveName varchar(50),
 	@ShowName varchar(50)
 ) as
declare @errmsg varchar(max)
set @Id = newid();

insert into T_EmployeeAttachment(
   Id,--主键Id
   EmpId,--员工Id
   SaveName,--保存名称
   ShowName--显示名称
)
values(
   @Id,--主键Id
   @EmpId,--员工Id
   @SaveName,--保存名称
   @ShowName--显示名称
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateMenu (
 	@MenuNo varchar(100),
 	@PNo varchar(100),
 	@MenuName varchar(100),
 	@Order int,
 	@Glyph varchar(200),
 	@OnClick varchar(200),
 	@KeyTip varchar(30),
 	@MenuControl varchar(20)
 ) as
declare @errmsg varchar(max)
select 1 from T_Menu where MenuNo=@MenuNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

insert into T_Menu (
   MenuNo,--菜单编号
   PNo,--父级菜单编号
   MenuName,--菜单名称
   [Order],--菜单序号
   Glyph,--显示图像
   OnClick,--点击事件
   KeyTip,--提示
   MenuControl--菜单编程控件
)
values(
   @MenuNo,--菜单编号
   @PNo,--父级菜单编号
   @MenuName,--菜单名称
   @Order,--菜单序号
   @Glyph,--显示图像
   @OnClick,--点击事件
   @KeyTip,--提示
   @MenuControl--菜单编程控件
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateProduct (
 	@ProductId int output,
 	@ProductNo varchar(50),
 	@ProductName varchar(100),
 	@ProductName1 varchar(100),
 	@Spec varchar(100),
 	@Spec1 varchar(100),
 	@ProductType smallint,
 	@ProductImage varchar(200),
 	@Unit varchar(5),
 	@Material varchar(10),
 	@Code varchar(20),
 	@GoodCode varchar(50),
 	@CheckCodeOne varchar(10),
 	@CheckCodeMany varchar(50),
 	@PackQty int,
 	@CertType smallint,
 	@RegisterId varchar(36),
 	@MinStore int,
 	@MaxStore int,
 	@Cycle numeric(9),
 	@DrawingId int,
 	@IsRemind bit,
 	@QtyMode smallint,
 	@preprice1 numeric(9),
 	@preprice2 numeric(9),
 	@preprice3 numeric(9),
 	@preprice4 numeric(9),
 	@recprice numeric(9),
 	@Remark1 varchar(500),
 	@Remark2 varchar(500),
 	@Remark3 varchar(500),
 	@Remark4 varchar(500),
 	@Remark5 varchar(500),
 	@Remark6 varchar(500),
 	@Remark7 varchar(500),
 	@Remark8 varchar(500),
 	@ShowNo varchar(50),
 	@ShowProductName varchar(100),
 	@ShowSpec varchar(100),
 	@ShowLOrR varchar(5),
 	@ShowPos varchar(50),
 	@IsShow bit,
 	@IsNew bit,
 	@NewRemark varchar(500),
 	@PId int,
 	@CreateId varchar(36)
 ) as
declare @errmsg varchar(max)
select @ProductId=0
select 1 from T_Product where ProductNo=@ProductNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

declare @Level_Path varchar(1000),@Level_Deep int;
set @Level_Deep = 0;
select @Level_Path=Level_Path,@Level_Deep=Level_Deep from T_Product where ProductId=@PId
set @Level_Deep = @Level_Deep+1;
--获取树路径
if(@Level_Path is null)	set @Level_Path='';
else set @Level_Path=@Level_Path;
--获取树路径
insert into T_Product (
   ProductNo,--产品编号
   ProductName,--产品名称
   ProductName1,--产品名称(英文)
   Spec,--规格型号
   Spec1,--规格型号(英文)
   ProductType,--产品类型（成品，零部件）
   ProductImage,--产品大图
   Unit,--计量单位
   Material,--材料标识
   Code,--产品代码
   GoodCode,--货位号
   CheckCodeOne,--校验码（单）
   CheckCodeMany,--校验码（多）
   PackQty,--包装数量
   CertType,--证件类型（a证，b证）
   RegisterId,--产品注册证Id
   MinStore,--最小库存
   MaxStore,--最大库存
   Cycle,--生产周期（小时）
   DrawingId,--图纸Id
   IsRemind,--库存报警标识
   QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   preprice1,--预设价格1
   preprice2,--预设价格2
   preprice3,--预设价格3
   preprice4,--零售价
   recprice,--最近价格
   Remark1,--备注1
   Remark2,--备注2
   Remark3,--备注3
   Remark4,--备注4
   Remark5,--备注5
   Remark6,--备注6
   Remark7,--备注7
   Remark8,--备注8
   ShowNo,--显示编号
   ShowProductName,--显示产品名称
   ShowSpec,--显示规格型号
   ShowLOrR,--显示左右
   ShowPos,--显示适应部位
   IsShow,--是否销售（所有show开头均为销售选项）
   IsNew,--是否为新品
   NewRemark,--新品发布说明
   PId,--树性父结构代码
   Level_Path,--树性结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep,--树的深度
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted--删除标志
)
values(
   @ProductNo,--产品编号
   @ProductName,--产品名称
   @ProductName1,--产品名称(英文)
   @Spec,--规格型号
   @Spec1,--规格型号(英文)
   @ProductType,--产品类型（成品，零部件）
   @ProductImage,--产品大图
   @Unit,--计量单位
   @Material,--材料标识
   @Code,--产品代码
   @GoodCode,--货位号
   @CheckCodeOne,--校验码（单）
   @CheckCodeMany,--校验码（多）
   @PackQty,--包装数量
   @CertType,--证件类型（a证，b证）
   @RegisterId,--产品注册证Id
   @MinStore,--最小库存
   @MaxStore,--最大库存
   @Cycle,--生产周期（小时）
   @DrawingId,--图纸Id
   @IsRemind,--库存报警标识
   @QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   @preprice1,--预设价格1
   @preprice2,--预设价格2
   @preprice3,--预设价格3
   @preprice4,--零售价
   @recprice,--最近价格
   @Remark1,--备注1
   @Remark2,--备注2
   @Remark3,--备注3
   @Remark4,--备注4
   @Remark5,--备注5
   @Remark6,--备注6
   @Remark7,--备注7
   @Remark8,--备注8
   @ShowNo,--显示编号
   @ShowProductName,--显示产品名称
   @ShowSpec,--显示规格型号
   @ShowLOrR,--显示左右
   @ShowPos,--显示适应部位
   @IsShow,--是否销售（所有show开头均为销售选项）
   @IsNew,--是否为新品
   @NewRemark,--新品发布说明
   @PId,--树性父结构代码
   @Level_Path,--树性结构路径
   0,--儿子数量
   0,--子孙数量
   @Level_Deep,--树的深度
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0--删除标志
);
set @ProductId = @@IDENTITY;--获取插入的实体id

if(@Level_Deep>1)
begin
	--更新父级节点的儿子数量
	declare @sql varchar(max);
	set @sql = 'update T_Product set Level_Total=Level_Total+1 where ProductId in ('+@Level_Path+');'
	exec(@sql);
	--更新父级节点的儿子数量
	--更新父级节点的子孙数量
	update T_Product set Level_Num=Level_Num+1 where  ProductId=@PId
	--更新父级节点的子孙数量
end

if(@Level_Path='') set @Level_Path=cast(@ProductId as varchar(20))
else set @Level_Path=@Level_Path+','+cast(@ProductId as varchar(20))
update T_Product set Level_Path=@Level_Path where ProductId=@ProductId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateRawMate (
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
 ) as
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
go


create procedure dbo.P_CreateRegister (
 	@RegisterId varchar(36) output,
 	@RegisterNo varchar(100),
 	@RegisterProductName varchar(100),
 	@StandardCode varchar(100),
 	@RegisterNo1 varchar(100),
 	@RegisterProductName1 varchar(100),
 	@StandardCode1 varchar(100),
 	@RegisterFile varchar(50),
 	@StartDate varchar(10),
 	@EndDate varchar(10),
 	@CreateId varchar(36),
 	@Remark varchar(200)
 ) as
declare @errmsg varchar(max)
select 1 from T_Register where RegisterNo=@RegisterNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
select @RegisterId = newid();
insert into T_Register (
	RegisterId,--主键Id
	RegisterNo,--注册证编号
	RegisterProductName,--注册证名称
	StandardCode,--标准号
	RegisterNo1,--注册证编号(英文)
	RegisterProductName1,--注册证名称(英文)
	StandardCode1,--标准号(英文)
	RegisterFile,--注册证文件
	StartDate,--启用日期
	EndDate,--停用日期
	CreateId,--创建人Id
	CreateDate,--创建日期
	LastModifyId,--最后更改人Id
	LastModifyDate,--最后更改日期
	Remark,--备注
	Deleted--删除标识
)
values(
	@RegisterId,--主键Id
	@RegisterNo,--注册证编号
	@RegisterProductName,--注册证名称
	@StandardCode,--标准号
	@RegisterNo1,--注册证编号(英文)
	@RegisterProductName1,--注册证名称(英文)
	@StandardCode1,--标准号(英文)
	@RegisterFile,--注册证文件
	@StartDate,--启用日期
	@EndDate,--停用日期
	@CreateId,--创建人Id
	getdate(),--创建日期
	@CreateId,--最后更改人Id
	getdate(),--最后更改日期
	@Remark,--备注
	0--删除标识
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateRegisterAttachment (
 	@Id VARCHAR(36) output,
 	@RegisterId varchar(36),
 	@SaveName varchar(50),
 	@ShowName varchar(50)
 ) as
declare @errmsg varchar(max)
set @Id = newid();

insert into T_RegisterAttachment(
   Id,--主键Id
   RegisterId,--员工Id
   SaveName,--保存名称
   ShowName--显示名称
)
values(
   @Id,--主键Id
   @RegisterId,--注册证Id
   @SaveName,--保存名称
   @ShowName--显示名称
);

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateRole (
 	@RoleId VARCHAR(36) output,
 	@RoleNo VARCHAR(50),
 	@RoleName VARCHAR(50),
 	@CreateId VARCHAR(36),
 	@IsLock bit,
 	@Remark varchar(100)
 ) as
declare @errmsg varchar(max)
select 1 from T_Role where RoleNo=@RoleNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @RoleId = newid()
insert into T_Role(RoleId,RoleNo,RoleName,IsLock,IsSuper,Deleted,Remark,CreateId,CreateDate,LastModifyId,LastModifyDate)
values (@RoleId,@RoleNo,@RoleName,@IsLock,0,0,@Remark,@CreateId,getdate(),@CreateId,getdate())
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateStock (
 @StockId int output,--主键Id
 @StockNo varchar(50),--仓库编号
 @StockName varchar(100),--仓库名称
 @CreateId varchar(36),--创建人Id
 @Remark varchar(200)--备注
 ) as
declare @errmsg varchar(max)
select @StockId=0
select 1 from T_Stock where StockNo=@StockNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号



insert into T_Stock (
   StockNo,--仓库编号
   StockName,--仓库名称
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后修改人Id
   LastModifyDate,--最后修改日期
   Deleted,--删除标识
   Remark--备注
) values (
   @StockNo,--仓库编号
   @StockName,--仓库名称
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后修改人Id
   getdate(),--最后修改日期
   0,--删除标识
   @Remark--备注
)
select @StockId = @@IDENTITY;
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_CreateUser (
 	@UserId varchar(36) output,
 	@UserNo varchar(50),
 	@UserName varchar(50),
 	@UserPassWord varchar(50),
 	@IsLock bit,
 	@Remark varchar(100),
 	@CreateId varchar(36)
 ) as
declare @errmsg varchar(max)
select 1 from T_User where UserNo=@UserNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @UserId = newid()
insert into T_User (
   UserId,--用户Id
   UserNo,--用户账号
   UserName,--用户名称
   UserPassWord,--用户密码
   IsLock,--是否锁定
   Deleted,--删除标识
   Remark,--备注
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   IsUserAuthority--是否启用用户权限
)
values(
   @UserId,--用户Id
   @UserNo,--用户账号
   @UserName,--用户名称
   @UserPassWord,--用户密码
   @IsLock,--是否锁定
   0,--删除标识
   @Remark,--备注
   @CreateId,--创建人
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   0--是否启用用户权限
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
go


create procedure dbo.P_GetDicDataByDicTypes (
 	@DicTypes VARCHAR(max)
 ) as
exec ('select * from T_DicData where DicType in ('+@DicTypes+')')
go


create procedure dbo.P_GetRelationData ;1
 (
 	@cMode VARCHAR(50),
 	@EntityId VARCHAR(36)
 ) as
if(@cMode='roleaction')
select		 RoleId
			,ActionNo
from T_RoleAction
where RoleId=@EntityId
else if(@cMode='rolemenu')
select		 RoleId
			,MenuNo
from T_RoleMenu
where RoleId=@EntityId
else if(@cMode='usermenu')
begin
if(exists(select 1 from T_Role
where IsSuper=1 and RoleId in 
(select RoleId from T_UserInRole ur join T_User u on ur.UserId=u.UserId and u.Deleted=0 and u.IsLock=0 and ur.UserId=@EntityId)))
select MenuNo from T_Menu
else
select MenuNo from T_RoleMenu where RoleId in (
select ur.RoleId from T_UserInRole ur join T_User u on ur.UserId=u.UserId and u.Deleted=0 and u.IsLock=0
join T_Role r on ur.RoleId = r.RoleId where u.UserId = @EntityId
)
end
else if(@cMode='roleuser')
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserId in (select UserId from T_UserInRole where RoleId=@EntityId) and Deleted=0 and IsLock=0
order by UserNo
else if(@cMode='employeeattach')
select * from T_EmployeeAttachment where EmpId=@EntityId order by ShowName;
else if(@cMode='registerattach')
select * from T_RegisterAttachment where RegisterId=@EntityId order by ShowName;
else
begin
	declare @errmsg varchar(max)
	if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1) end--查询方法未实现
end
go


create procedure dbo.P_Glo_Delete ;1
 (
 	@cMode VARCHAR(50),
 	@EntityId VARCHAR(100)
 ) as
declare @errmsg varchar(max)
if @cMode = 'menu'
begin
	delete from T_Menu where MenuNo=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'action'
begin
	delete from T_Action where ActionNo=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'employee' --员工信息
begin
	--begin检查引用：
	--end检查引用：
	update T_Employee set Deleted=1 where EmpId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'role' --角色信息
begin
	select top 1 1 from T_Role where RoleId=@EntityId and IsSuper=1 --检查是否是超级角色
	if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可删除',0) RAISERROR(@errmsg,11,1) end --超级角色不可删除
	--begin检查引用：
	--检查用户是否引用
		select 1 from T_Role r join T_UserInRole ur
		on r.RoleId=ur.RoleId and r.RoleId=@EntityId and r.Deleted=0
		join T_User u on ur.UserId=u.UserId and u.Deleted=0
		if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end--正在使用
	--end检查引用：
	update T_Role set Deleted=1 where RoleId=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'user' --用户信息
begin
	--begin检查引用：
	--end检查引用：
	update T_User set Deleted=1 where UserId=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
	--检查是否为最后一个超级用户
	select 1 from T_Role r 
		join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
		join T_User u on u.UserId = ur.UserId and u.Deleted=0 and u.UserId = @EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) RAISERROR(@errmsg,11,1) end--最后一个超级用户不可删除
	--检查是否为最后一个超级用户
end
else if @cMode = 'register'
begin
	update T_Register set Deleted=1 where RegisterId=@EntityId
	--begin检查引用：
	--end检查引用：
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end--CREATE PROCEDURE P_Glo_Delete;2
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
go


create procedure dbo.P_Glo_DeleteRelationData ;1
 (
 	@cMode VARCHAR(50),
 	@EntityId VARCHAR(100)
 ) as
if @cMode = 'employeeattachment' --员工附件
begin
	delete from T_EmployeeAttachment where EmpId=@EntityId
end
else if @cMode = 'registerattach' --员工附件
begin
	delete from T_RegisterAttachment where RegisterId=@EntityId
end
else if(@cMode='roleaction')
delete from T_RoleAction where RoleId=@EntityId;
else if(@cMode='rolemenu')
delete from T_RoleMenu where RoleId=@EntityId
else if(@cMode='roleuser')
delete from T_UserInRole
where UserId in (select UserId from T_UserInRole where RoleId=@EntityId)
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
go


create procedure dbo.P_Glo_FindById ;1
 (
 	@cMode VARCHAR(50),
 	@EntityId VARCHAR(36)
 ) as
begin
if @cMode = 'employee' --员工信息
select
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   DeptId,--部门Id
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Remark1,--备注1
   Remark2--备注2
from T_Employee 
where EmpId=@EntityId
else if @cMode = 'role' --角色
select		 RoleId
			,RoleNo
			,RoleName
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsSuper
from T_Role
where RoleId=@EntityId
else if @cMode = 'user'
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserId=@EntityId
else if @cMode = 'register'
select
   RegisterId,--主键Id
   RegisterNo,--注册证编号
   RegisterProductName,--注册证名称
   StandardCode,--标准号
   RegisterNo1,--注册证编号(英文)
   RegisterProductName1,--注册证名称(英文)
   StandardCode1,--标准号(英文)
   RegisterFile,--注册证文件
   StartDate,--启用日期
   EndDate,--停用日期
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Deleted--删除标识
from T_Register
where RegisterId=@EntityId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
endCREATE PROCEDURE P_Glo_FindById;2
--CREATE PROCEDURE P_Glo_FindById;2
(
	@cMode VARCHAR(50),
	@EntityId int
)
AS 
begin
if @cMode = 'dept' --部门
select		DeptId,--Id
			DeptNo,--部门编号
			DeptName,--部门名称
			Remark,--备注
			PId,--父级Id
			Level_Path,--属性结构路径
			Level_Num,--儿子数量
			Level_Total,--子孙数量,
			Level_Deep,--树深度
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate,--最后更改日期
			Deleted
from T_Dept
where DeptId=@EntityId
else if @cMode = 'product'
select
   ProductId,--Id
   ProductNo,--产品编号
   ProductName,--商品名称
   ProductName1,--商品名称(英文)
   Spec,--规格型号
   Spec1,--规格型号(英文)
   ProductType,--产品类型（成品，零部件）
   ProductImage,--产品大图
   Unit,--计量单位
   Material,--材料标识
   Code,--产品代码
   GoodCode,--货位号
   CheckCodeOne,--校验码（单）
   CheckCodeMany,--校验码（多）
   PackQty,--包装数量
   CertType,--证件类型（a证，b证）
   RegisterId,--产品注册证Id
   MinStore,--最小库存
   MaxStore,--最大库存
   Cycle,--生产周期（小时）
   DrawingId,--图纸Id
   IsRemind,--库存报警标识
   QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   preprice1,--预设价格1
   preprice2,--预设价格2
   preprice3,--预设价格3
   preprice4,--零售价
   recprice,--最近价格
   Remark1,--备注1
   Remark2,--备注2
   Remark3,--备注3
   Remark4,--备注4
   Remark5,--备注5
   Remark6,--备注6
   Remark7,--备注7
   Remark8,--备注8
   ShowNo,--显示编号
   ShowProductName,--显示产品名称
   ShowSpec,--显示规格型号
   ShowLOrR,--显示左右
   ShowPos,--显示适应部位
   IsShow,--是否销售（所有show开头均为销售选项）
   IsNew,--是否为新品
   NewRemark,--新品发布说明
   PId,--树性父结构代码
   Level_Path,--树性结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep,--树的深度
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted--删除标志
from T_Product
where ProductId=@EntityId
else if @cMode = 'company' --往来单位
select
   CompanyId,--主键Id
   CompanyNo,--单位编号
   CompanyName,--单位名称
   Address,--单位地址
   Tel,--电话
   Fax,--传真
   PostCode,--邮政编码
   EMail,--电子邮件
   Person,--联系人
   BankAndAcount,--开户银行
   TaxNumber,--税号
   ARTotal,--应收
   APTotal,--应付
   Remark,--备注
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Deleted,--删除标志
   Password,--登陆密码
   Enable,--是否启用
   PId,--父Id
   Level_Path,--树形结构路径
   Level_Num,--儿子数量
   Level_Total,--子孙数量
   Level_Deep--树的深度
from T_Company
where CompanyId=@EntityId
else if @cMode = 'rawmate' --原材料信息
select
   RawMateId,--主键Id
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
from T_RawMate 
where RawMateId=@EntityId
else if @cMode = 'stock' --仓库表
select
   StockId,--主键Id
   StockNo,--仓库编号
   StockName,--仓库名称
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后修改人Id
   LastModifyDate,--最后修改日期
   Deleted,--删除标识
   Remark--备注
from T_Stock 
where StockId=@EntityId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
end
go


create procedure dbo.P_Glo_FindByNo (
 	@cMode VARCHAR(50),
 	@EntityNo VARCHAR(50)
 ) as
if @cMode = 'dept' --部门
select		DeptId,--Id
			DeptNo,--部门编号
			DeptName,--部门名称
			Remark,--备注
			PId,--父级Id
			Level_Path,--属性结构路径
			Level_Num,--儿子数量
			Level_Total,--子孙数量,
			Level_Deep,--树深度
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate--最后更改日期
from T_Dept
where DeptNo=@EntityNo and Deleted=0
else if @cMode = 'employee' --部门
select
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   DeptId,--部门Id
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Remark1,--备注1
   Remark2--备注2
from T_Employee 
where EmpNo=@EntityNo and Deleted=0
else if @cMode = 'role' --角色
select		 RoleId
			,RoleNo
			,RoleName
			,IsLock
			,IsSuper
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
from T_Role
where RoleNo=@EntityNo and Deleted=0
else if @cMode = 'user'
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserNo=@EntityNo and Deleted=0
else if @cMode = 'action' -- 功能表
select *
from T_Action
where ActionNo=@EntityNo
else if @cMode = 'menu' -- 菜单表
select *
from T_Menu
where MenuNo=@EntityNo
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
go


create procedure dbo.P_Glo_GetChildList ;1
 --CREATE PROCEDURE P_Glo_GetChildList;1
 (
 	@cMode VARCHAR(50),
 	@PId varchar(100)
 ) as
begin
if @cMode = 'menu' --部门
select		*
from T_Menu
where PNo=@PId

else if @cMode = 'action' --部门
select		*
from T_Action
where ParentActionNo=@PId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
end
go


create procedure dbo.P_Glo_GetList (
 	@cMode VARCHAR(50)
 ) as
if @cMode = 'employee' --员工信息
select
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   DeptId,--部门Id
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,
   Remark1,
   Remark2
from T_Employee
where Deleted = 0
order by EmpNo
else if @cMode = 'employeecmdept'
select
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   e.DeptId,--部门Id
   d.DeptNo,
   d.DeptName,
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   e.CreateId,--创建人
   e.CreateDate,--创建日期
   e.LastModifyId,--最后更改人Id
   e.LastModifyDate,--最后更改日期
   e.Remark,
   e.Remark1,
   e.Remark2,
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Employee e left join T_User u1 on  e.CreateId=u1.UserId left join T_User u2 on e.CreateId=u2.UserId left join T_Dept d on e.DeptId=d.DeptId
where e.Deleted = 0
order by EmpNo
else if @cMode = 'user'
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User where Deleted=0 order by UserNo
else if @cMode = 'usercm'
select		 u.UserId
			,u.UserNo
			,u.UserName
			,u.UserPassWord
			,u.IsLock
			,u.Remark
			,u.CreateId
			,u.CreateDate
			,u.LastModifyId
			,u.LastModifyDate
			,u.IsUserAuthority
			,u1.UserName CreateName
			,u2.UserName LastModifyName
from T_User u left join T_User u1 on  u.CreateId=u1.UserId left join T_User u2 on u.CreateId=u2.UserId where u.Deleted=0 order by UserNo
else if @cMode = 'role'
select		RoleId,--角色Id
			RoleNo,--角色编号
			RoleName,--角色名称
			Remark,--备注
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate,--最后更改日期
			IsLock,--是否锁定
			IsSuper
from T_Role where Deleted=0
order by RoleNo
else if @cMode = 'menu'
select * from T_Menu
else if @cMode = 'action'
select * from T_Action
else if @cMode = 'registercm'
select
   RegisterId,--主键Id
   RegisterNo,--注册证编号
   RegisterProductName,--注册证名称
   StandardCode,--标准号
   RegisterNo1,--注册证编号(英文)
   RegisterProductName1,--注册证名称(英文)
   StandardCode1,--标准号(英文)
   RegisterFile,--注册证文件
   StartDate,--启用日期
   EndDate,--停用日期
   r.CreateId,--创建人Id
   r.CreateDate,--创建日期
   r.LastModifyId,--最后更改人Id
   r.LastModifyDate,--最后更改日期
   r.Remark,--备注
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Register r left join T_User u1 on  r.CreateId=u1.UserId left join T_User u2 on r.CreateId=u2.UserId
where r.Deleted = 0
order by RegisterNo
else if @cMode = 'stockcm' --仓库表
select
   s.StockId,--主键Id
   s.StockNo,--仓库编号
   s.StockName,--仓库名称
   s.CreateId,--创建人Id
   s.CreateDate,--创建日期
   s.LastModifyId,--最后修改人Id
   s.LastModifyDate,--最后修改日期
   s.Deleted,--删除标识
   s.Remark,--备注
   u1.UserName CreateName,--创建人
   u2.UserName LastModifyName--最后更改人
from T_Stock s 
left join T_User u1 on  s.CreateId=u1.UserId 
left join T_User u2 on s.CreateId=u2.UserId 
where s.Deleted = 0
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
go


create procedure dbo.P_Glo_GetTree (
 	@cMode VARCHAR(50),
 	@PId int
 ) as
if @cMode = 'deptcm' --部门
select		d.DeptId,--Id
			d.DeptNo,--部门编号
			d.DeptName,--部门名称
			d.Remark,--备注
			d.PId,--父级Id
			d.Level_Path,--树形路径
			d.Level_Num,--儿子数量
			d.Level_Total,--子孙数量,
			d.Level_Deep,--树深度
			d.CreateId,--创建人Id
			d.CreateDate,--创建日期
			d.LastModifyId,--最后更改人Id
			d.LastModifyDate,--最后更改日期
			d.Deleted,--是否删除
			u1.UserName CreateName,
			u2.UserName LastModifyName
from T_Dept d left join T_User u1 
on  d.CreateId=u1.UserId left join T_User u2 on d.CreateId=u2.UserId 
where d.PId=@PId and d.Deleted=0
order by DeptNo
else if @cMode = 'productrdcm' --产品信息
select
  p.ProductId,--Id
  p.ProductNo,--产品编号
  p.ProductName,--产品名称
  p.ProductName1,--产品名称(英文)
  p.Spec,--规格型号
  p.Spec1,--规格型号(英文)
  p.ProductType,--产品类型（成品，零部件）
  p.ProductImage,--产品大图
  p.Unit,--计量单位
  p.Material,--材料标识
  p.Code,--产品代码
  p.GoodCode,--货位号
  p.CheckCodeOne,--校验码（单）
  p.CheckCodeMany,--校验码（多）
  p.PackQty,--包装数量
  p.CertType,--证件类型（a证，b证）
  p.RegisterId,--产品注册证Id
  p.MinStore,--最小库存
  p.MaxStore,--最大库存
  p.Cycle,--生产周期（小时）
  p.DrawingId,--图纸Id
  p.IsRemind,--库存报警标识
  p.QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
  p.preprice1,--预设价格1
  p.preprice2,--预设价格2
  p.preprice3,--预设价格3
  p.preprice4,--零售价
  p.recprice,--最近价格
  p.Remark1,--备注1
  p.Remark2,--备注2
  p.Remark3,--备注3
  p.Remark4,--备注4
  p.Remark5,--备注5
  p.Remark6,--备注6
  p.Remark7,--备注7
  p.Remark8,--备注8
  p.ShowNo,--显示编号
  p.ShowProductName,--显示产品名称
  p.ShowSpec,--显示规格型号
  p.ShowLOrR,--显示左右
  p.ShowPos,--显示适应部位
  p.IsShow,--是否销售（所有show开头均为销售选项）
  p.IsNew,--是否为新品
  p.NewRemark,--新品发布说明
  p.PId,--父Id
  p.Level_Path,--树形路径
  p.Level_Num,--儿子数量
  p.Level_Total,--子孙数量
  p.Level_Deep,--树的深度
  p.CreateId,--创建人Id
  p.CreateDate,--创建日期
  p.LastModifyId,--最后更改人Id
  p.LastModifyDate,--最后更改日期
  u1.UserName CreateName,
  u2.UserName LastModifyName,
  r.RegisterNo RegisterNo,
  r.RegisterProductName RegisterProductName,
  r.StandardCode StandardCode,
  r.RegisterNo1 RegisterNo1,
  r.RegisterProductName1 RegisterProductName1,
  r.StandardCode1 StandardCode1,
   '' DrawingName
from T_Product p 
left join T_User u1 on  p.CreateId=u1.UserId 
left join T_User u2 on p.CreateId=u2.UserId 
left join T_Register r on p.RegisterId=r.RegisterId

where p.PId = @PId and p.Deleted = 0
order by ProductNo
else if @cMode = 'companycm' --往来单位
select
   c.CompanyId,--主键Id
   c.CompanyNo,--单位编号
   c.CompanyName,--单位名称
   c.Address,--单位地址
   c.Tel,--电话
   c.Fax,--传真
   c.PostCode,--邮政编码
   c.EMail,--电子邮件
   c.Person,--联系人
   c.BankAndAcount,--开户银行
   c.TaxNumber,--税号
   c.ARTotal,--应收
   c.APTotal,--应付
   c.Remark,--备注
   c.CreateId,--创建人Id
   c.CreateDate,--创建日期
   c.LastModifyId,--最后更改人Id
   c.LastModifyDate,--最后更改日期
   c.Deleted,--删除标志
   c.Password,--登陆密码
   c.Enable,--是否启用
   c.PId,--父Id
   c.Level_Path,--树形结构路径
   c.Level_Num,--儿子数量
   c.Level_Total,--子孙数量
   c.Level_Deep,--树的深度
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Company c 
left join T_User u1 on  c.CreateId=u1.UserId 
left join T_User u2 on c.CreateId=u2.UserId 
where c.PId = @PId and c.Deleted = 0
order by CompanyNo

else if @cMode = 'rawmatecm' --原材料信息
select
   r.RawMateId,--主键Id
   r.RawMateNo,--原材料编号
   r.RawMateName,--原材料名称
   r.Spec,--规格型号
   r.MinStore,--最小库存
   r.MaxStore,--最大库存
   r.Unit,--计量单位
   r.IsRemind,--库存报警标识
   r.QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
   r.preprice1,--预设价格1
   r.preprice2,--预设价格2
   r.preprice3,--预设价格3
   r.recprice,--最近价格
   r.Remark1,--备注1
   r.Remark2,--备注2
   r.Remark3,--备注3
   r.Remark4,--备注4
   r.Deleted,--删除标识
   r.PId,--父Id
   r.Level_Path,--树形结构路径
   r.Level_Num,--儿子数量
   r.Level_Total,--子孙数量
   r.Level_Deep,--树的深度
   r.CreateId,--创建人Id
   r.CreateDate,--创建日期
   r.LastModifyId,--最后更改人Id
   r.LastModifyDate,--最后更改日期
   u1.UserName CreateName,--创建人
   u2.UserName LastModifyName--最后更改人
from T_RawMate r 
left join T_User u1 on  r.CreateId=u1.UserId 
left join T_User u2 on r.CreateId=u2.UserId 
where r.PId = @PId and r.Deleted = 0
order by RawMateNo
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
go


create procedure dbo.P_IsSuper (
 	@UserId VARCHAR(36),
 	@IsSuper bit output
 ) as
select 1 from T_Role r 
join T_UserInRole ur on r.RoleId = ur.RoleId and r.IsSuper=1
join T_User u on ur.UserId = u.UserId and u.UserId=@UserId and u.Deleted=0 and u.IsLock=0
if(@@ROWCOUNT<=0) set @IsSuper = 0;
else set @IsSuper = 1;
go


create procedure dbo.P_RoleUserFlow (
 	@OP VARCHAR(20),
 	@UserId VARCHAR(36),
 	@RoleId VARCHAR(36),
 	@Lock bit
 ) as
declare @errmsg varchar(max)
if @OP='removeuserfromrole'
begin
	delete from T_UserInRole where UserId=@UserId and RoleId=@RoleId;
	select 1 from T_Role r 
	join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
	if(@@ROWCOUNT<=0)
	begin
		select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) 
		RAISERROR(@errmsg,11,1)
	end
end
else if @OP='addusertorole'
begin
	insert into T_UserInRole(UserId,RoleId) values(@UserId,@RoleId);
end
else if @OP='lockrole'
begin
	if(@Lock=0)
	begin
		select 1 from T_Role where RoleId=@RoleId and IsSuper=1
		if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可禁用',0) RAISERROR(@errmsg,11,1) end
	end
	update T_Role set IsLock=@Lock where RoleId=@RoleId
	if(@@ROWCOUNT<=0)--角色状态更改失败
	begin select @errmsg=dbo.F_GetError('角色状态更改失败',0) RAISERROR(@errmsg,11,1) end
end
else if @OP='lockuser'
begin
	update T_User set IsLock=@Lock where UserId=@UserId
	if(@@ROWCOUNT<=0)--用户状态更改失败
	begin select @errmsg=dbo.F_GetError('用户状态更改失败',0) RAISERROR(@errmsg,11,1) end
	--检查超级用户数量，若为0则回滚
	select 1 from T_Role r 
		join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
		join T_User u on u.UserId = ur.UserId and u.Deleted=0
	if(@@ROWCOUNT<=0) 
	begin select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) RAISERROR(@errmsg,11,1) end
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
go


create procedure dbo.P_UpdateAction (
 	@OldActionNo varchar(50),
 	@ActionNo varchar(50),
 	@ActionName varchar(100),
 	@ParentActionNo varchar(50),
 	@Order int,
 	@Remark varchar(200),
 	@ActionType varchar(20)
 ) as
declare @errmsg varchar(max)
select 1 from T_Action where ActionNo=@ActionNo and ActionNo<>@OldActionNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Action set 
ActionNo=@ActionNo,
ActionName=@ActionName,
ParentActionNo=@ParentActionNo,
[Order]=@Order,
ActionType=@ActionType,
Remark=@Remark
where ActionNo=@OldActionNo

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateCompany (
 	@CompanyId int,
 	@CompanyNo varchar(50),
 	@CompanyName varchar(150),
 	@Address varchar(200),
 	@Tel varchar(50),
 	@Fax varchar(50),
 	@PostCode varchar(50),
 	@EMail varchar(100),
 	@Person varchar(50),
 	@BankAndAcount varchar(50),
 	@TaxNumber varchar(50),
 	@ARTotal numeric(9),
 	@APTotal numeric(9),
 	@Remark varchar(200),
 	@LastModifyId varchar(36),
 	@Password varchar(100),
 	@Enable bit
 ) as
declare @errmsg varchar(max)
select 1 from T_Company where CompanyNo=@CompanyNo and CompanyId<>@CompanyId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Company set 
	CompanyNo=@CompanyNo,
	CompanyName=@CompanyName,
	Address=@Address,
	Tel=@Tel,
	Fax=@Fax,
	PostCode=@PostCode,
	EMail=@EMail,
	Person=@Person,
	BankAndAcount=@BankAndAcount,
	TaxNumber=@TaxNumber,
	ARTotal=@ARTotal,
	APTotal=@APTotal,
	Remark=@Remark,
	LastModifyId=@LastModifyId,
	LastModifyDate=getdate(),
	Password=@Password,
	Enable=@Enable
where CompanyId=@CompanyId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateDept (
 	@DeptId int,
 	@DeptNo VARCHAR(50),
 	@DeptName VARCHAR(50),
 	@Remark VARCHAR(200),
 	@LastModifyId VARCHAR(36)
 ) as
declare @errmsg varchar(max)
select 1 from T_Dept where DeptNo=@DeptNo and DeptId<>@DeptId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Dept 
set DeptNo=@DeptNo,
	DeptName=@DeptName,
	Remark=@Remark,
	LastModifyId=@LastModifyId,
	LastModifyDate=getdate()
	where DeptId=@DeptId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateEmployee (
 	@EmpId VARCHAR(36),
 	@EmpNo varchar(50),
 	@EmpName varchar(50),
 	@DeptId varchar(36),
 	@Sex varchar(5),
 	@Nation varchar(20),
 	@Birthday varchar(10),
 	@Address varchar(500),
 	@TelPhone varchar(20),
 	@Mobile varchar(20),
 	@Origin varchar(10),
 	@Title varchar(50),
 	@Duty varchar(50),
 	@Post varchar(50),
 	@EmpStatus smallint,
 	@WedStatus varchar(5),
 	@AttCardNo varchar(20),
 	@GenCardNo varchar(20),
 	@IdCardNo varchar(30),
 	@Photo varchar(50),
 	@Specialty varchar(50),
 	@Diploma varchar(10),
 	@GraduateSchool varchar(100),
 	@PoliticalStatus varchar(10),
 	@JoinDate varchar(10),
 	@TrialStartDate varchar(10),
 	@TrialEndDate varchar(10),
 	@PositiveDate varchar(10),
 	@ContractStartDate varchar(10),
 	@ContractEndDate varchar(10),
 	@HolidaySMS bit,
 	@BirthdaySMS bit,
 	@Att bit,
 	@LastModifyId varchar(36),
 	@Remark varchar(200),
 	@Remark1 varchar(200),
 	@Remark2 varchar(200)
 ) as
declare @errmsg varchar(max)
select 1 from T_Employee where EmpNo=@EmpNo and EmpId<>@EmpId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Employee set 
EmpNo=@EmpNo,
EmpName=@EmpName,
DeptId=@DeptId,
Sex=@Sex,
Nation=@Nation,
Birthday=@Birthday,
Address=@Address,
TelPhone=@TelPhone,
Mobile=@Mobile,
Origin=@Origin,
Title=@Title,
Duty=@Duty,
Post=@Post,
EmpStatus=@EmpStatus,
WedStatus=@WedStatus,
AttCardNo=@AttCardNo,
GenCardNo=@GenCardNo,
IdCardNo=@IdCardNo,
Photo=@Photo,
Specialty=@Specialty,
Diploma=@Diploma,
GraduateSchool=@GraduateSchool,
PoliticalStatus=@PoliticalStatus,
JoinDate=@JoinDate,
TrialStartDate=@TrialStartDate,
TrialEndDate=@TrialEndDate,
PositiveDate=@PositiveDate,
ContractStartDate=@ContractStartDate,
ContractEndDate=@ContractEndDate,
HolidaySMS=@HolidaySMS,
BirthdaySMS=@BirthdaySMS,
Att=@Att,
LastModifyId=@LastModifyId,
LastModifyDate=getdate(),
Remark=@Remark,
Remark1=@Remark1,
Remark2=@Remark2
where EmpId=@EmpId

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateMenu (
 	@OldMenuNo varchar(100),
 	@MenuNo varchar(100),
 	@PNo varchar(100),
 	@MenuName varchar(100),
 	@Order int,
 	@Glyph varchar(200),
 	@OnClick varchar(200),
 	@KeyTip varchar(30),
 	@MenuControl varchar(20)
 ) as
declare @errmsg varchar(max)
select 1 from T_Menu where MenuNo=@MenuNo and MenuNo<>@OldMenuNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Menu set 
MenuNo=@OldMenuNo,
PNo=@PNo,
MenuName=@MenuName,
[Order]=@Order,
Glyph=@Glyph,
OnClick=@OnClick,
KeyTip=@KeyTip,
MenuControl=@MenuControl
where MenuNo=@OldMenuNo

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateProduct (
 	@ProductId int,
 	@ProductNo varchar(50),
 	@ProductName varchar(100),
 	@ProductName1 varchar(100),
 	@Spec varchar(100),
 	@Spec1 varchar(100),
 	@ProductType smallint,
 	@ProductImage varchar(200),
 	@Unit varchar(5),
 	@Material varchar(10),
 	@Code varchar(20),
 	@GoodCode varchar(50),
 	@CheckCodeOne varchar(10),
 	@CheckCodeMany varchar(50),
 	@PackQty int,
 	@CertType smallint,
 	@RegisterId varchar(36),
 	@MinStore int,
 	@MaxStore int,
 	@Cycle numeric(9),
 	@DrawingId int,
 	@IsRemind bit,
 	@QtyMode smallint,
 	@preprice1 numeric(9),
 	@preprice2 numeric(9),
 	@preprice3 numeric(9),
 	@preprice4 numeric(9),
 	@recprice numeric(9),
 	@Remark1 varchar(500),
 	@Remark2 varchar(500),
 	@Remark3 varchar(500),
 	@Remark4 varchar(500),
 	@Remark5 varchar(500),
 	@Remark6 varchar(500),
 	@Remark7 varchar(500),
 	@Remark8 varchar(500),
 	@ShowNo varchar(50),
 	@ShowProductName varchar(100),
 	@ShowSpec varchar(100),
 	@ShowLOrR varchar(5),
 	@ShowPos varchar(50),
 	@IsShow bit,
 	@IsNew bit,
 	@NewRemark varchar(500),
 	@LastModifyId varchar(36)
 ) as
declare @errmsg varchar(max)
select 1 from T_Product where ProductNo=@ProductNo and ProductId<>@ProductId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Product 
set ProductNo=@ProductNo,
	ProductName=@ProductName,
	ProductName1=@ProductName1,
	Spec=@Spec,
	Spec1=@Spec1,
	ProductType=@ProductType,
	ProductImage=@ProductImage,
	Unit=@Unit,
	Material=@Material,
	Code=@Code,
	GoodCode=@GoodCode,
	CheckCodeOne=@CheckCodeOne,
	CheckCodeMany=@CheckCodeMany,
	PackQty=@PackQty,
	CertType=@CertType,
	RegisterId=@RegisterId,
	MinStore=@MinStore,
	MaxStore=@MaxStore,
	Cycle=@Cycle,
	DrawingId=@DrawingId,
	IsRemind=@IsRemind,
	QtyMode=@QtyMode,
	preprice1=@preprice1,
	preprice2=@preprice2,
	preprice3=@preprice3,
	preprice4=@preprice4,
	recprice=@recprice,
	Remark1=@Remark1,
	Remark2=@Remark2,
	Remark3=@Remark3,
	Remark4=@Remark4,
	Remark5=@Remark5,
	Remark6=@Remark6,
	Remark7=@Remark7,
	Remark8=@Remark8,
	ShowNo=@ShowNo,
	ShowProductName=@ShowProductName,
	ShowSpec=@ShowSpec,
	ShowLOrR=@ShowLOrR,
	ShowPos=@ShowPos,
	IsShow=@IsShow,
	IsNew=@IsNew,
	NewRemark=@NewRemark,
	LastModifyId=@LastModifyId,
	LastModifyDate=getdate()
	where ProductId=@ProductId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateRawMate (
 @RawMateId int,--主键Id
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
 @LastModifyId varchar(36)--最后更改人Id
 ) as
declare @errmsg varchar(max)
select 1 from T_RawMate where RawMateNo=@RawMateNo and RawMateId<>@RawMateId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_RawMate set 
RawMateNo=@RawMateNo,--原材料编号
RawMateName=@RawMateName,--原材料名称
Spec=@Spec,--规格型号
MinStore=@MinStore,--最小库存
MaxStore=@MaxStore,--最大库存
Unit=@Unit,--计量单位
IsRemind=@IsRemind,--库存报警标识
QtyMode=@QtyMode,--数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
preprice1=@preprice1,--预设价格1
preprice2=@preprice2,--预设价格2
preprice3=@preprice3,--预设价格3
recprice=@recprice,--最近价格
Remark1=@Remark1,--备注1
Remark2=@Remark2,--备注2
Remark3=@Remark3,--备注3
Remark4=@Remark4,--备注4
LastModifyId=@LastModifyId,--最后更改人Id
LastModifyDate=getdate()--最后更改日期
where RawMateId=@RawMateId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateRegister (
 	@RegisterId varchar(36),
 	@RegisterNo varchar(100),
 	@RegisterProductName varchar(100),
 	@StandardCode varchar(100),
 	@RegisterNo1 varchar(100),
 	@RegisterProductName1 varchar(100),
 	@StandardCode1 varchar(100),
 	@RegisterFile varchar(50),
 	@StartDate varchar(10),
 	@EndDate varchar(10),
 	@LastModifyId varchar(36),
 	@Remark varchar(200)
 ) as
declare @errmsg varchar(max)
select 1 from T_Register where RegisterNo=@RegisterNo and RegisterId<>@RegisterId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Register set 
RegisterNo=@RegisterNo,
RegisterProductName=@RegisterProductName,
StandardCode=@StandardCode,
RegisterNo1=@RegisterNo1,
RegisterProductName1=@RegisterProductName1,
StandardCode1=@StandardCode1,
RegisterFile=@RegisterFile,
StartDate=@StartDate,
EndDate=@EndDate,
LastModifyId=@LastModifyId,
LastModifyDate=getdate(),
Remark=@Remark
where RegisterId=@RegisterId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateRole (
 	@RoleId VARCHAR(36),
 	@RoleNo VARCHAR(50),
 	@RoleName VARCHAR(50),
 	@LastModifyId VARCHAR(36),
 	@IsLock bit,
 	@Remark varchar(100)
 ) as
declare @errmsg varchar(max)
select 1 from T_Role where RoleId=@RoleId and IsSuper=1
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可更改',0) RAISERROR(@errmsg,11,1) end--超级角色不可更改

select 1 from T_Role where RoleNo=@RoleNo and Roleid<>@RoleId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Role set 
RoleNo=@RoleNo,
RoleName=@RoleName,
LastModifyId=@LastModifyId,
LastModifyDate=getdate(),
IsLock=@IsLock,
Remark=@Remark
where RoleId=@RoleId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateStock (
 @StockId int,--主键Id
 @StockNo varchar(50),--仓库编号
 @StockName varchar(100),--仓库名称
 @LastModifyId varchar(36),--最后修改人Id
 @Remark varchar(200)--备注
 ) as
declare @errmsg varchar(max)
select 1 from T_Stock where StockNo=@StockNo and StockId<>@StockId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Stock set 
StockNo=@StockNo,--仓库编号
StockName=@StockName,--仓库名称
LastModifyId=@LastModifyId,--最后修改人Id
LastModifyDate=getdate(),--最后修改日期
Remark=@Remark--备注
where StockId=@StockId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
go


create procedure dbo.P_UpdateUser (
 	@UserId varchar(36),
 	@UserNo varchar(50),
 	@UserName varchar(50),
 	@IsLock bit,
 	@Remark varchar(100),
 	@LastModifyId varchar(36)
 ) as
declare @errmsg varchar(max)
select 1 from T_User where UserNo=@UserNo and UserId<>@UserId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_User set 
UserNo=@UserNo,
UserName=@UserName,
IsLock=@IsLock,
Remark=@Remark,
LastModifyId=@LastModifyId,
LastModifyDate=getdate()
where UserId=@UserId

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败


if(@IsLock=1)
begin
--检查未被禁用且未被删除的超级用户数量，若为0则回滚
select 1 from T_Role r 
	join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
	join T_User u on u.UserId = ur.UserId and u.Deleted=0 and u.IsLock=0
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('最后一个超级用户不可禁用',0) RAISERROR(@errmsg,11,1) end--最后一个超级用户不可禁用
--检查未被禁用且未被删除的超级用户数量，若为0则回滚
end
go


create procedure dbo.P_UserAuth (
 	@UserId VARCHAR(36),
 	@ActionNo VARCHAR(50),
 	@IsAuth bit output
 ) as
select top 1 1 from T_Action where ActionNo=@ActionNo
if(@@ROWCOUNT<=0) 
begin 
	set @IsAuth=0 
	return -101--没有找到对应的权限
end
--检查是否为超级角色
select top 1 1 from T_UserInRole ur join T_Role r on ur.RoleId= r.RoleId and r.IsSuper=1  and ur.UserId=@UserId
if(@@ROWCOUNT>0)
begin
	set @IsAuth=1
	return 0;
end
--检查是否为超级角色
select top 1 1 from T_RoleAction where ActionNo=@ActionNo and RoleId in (
	select ur.RoleId from T_UserInRole ur join T_Role r on ur.RoleId= r.RoleId and r.IsLock=0 and r.Deleted=0 and ur.UserId=@UserId
)
if(@@ROWCOUNT>0)
begin
	set @IsAuth=1
	return 0;
end
else
begin
	set @IsAuth=0
	return 0;
end
go

