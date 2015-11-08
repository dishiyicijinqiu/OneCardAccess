CREATE TABLE [dbo].[T_Product] (
    [ProductId]       INT             IDENTITY (1, 1) NOT NULL,
    [ProductNo]       VARCHAR (50)    NOT NULL,
    [ProductName]     VARCHAR (100)   NOT NULL,
    [ProductName1]    VARCHAR (100)   NOT NULL,
    [Spec]            VARCHAR (100)   NOT NULL,
    [Spec1]           VARCHAR (100)   NOT NULL,
    [ProductType]     SMALLINT        CONSTRAINT [DF_T_Product_ProductType] DEFAULT ((0)) NOT NULL,
    [ProductImage]    VARCHAR (50)    NOT NULL,
    [Unit]            VARCHAR (5)     NOT NULL,
    [Material]        VARCHAR (10)    NOT NULL,
    [Code]            VARCHAR (20)    NOT NULL,
    [GoodCode]        VARCHAR (50)    NOT NULL,
    [CheckCodeOne]    VARCHAR (10)    NOT NULL,
    [CheckCodeMany]   VARCHAR (50)    NOT NULL,
    [PackQty]         INT             CONSTRAINT [DF_T_Product_PackQty] DEFAULT ((0)) NOT NULL,
    [CertType]        SMALLINT        CONSTRAINT [DF_T_Product_CertType] DEFAULT ((0)) NOT NULL,
    [RegisterId]      VARCHAR (36)    NOT NULL,
    [MinStore]        INT             CONSTRAINT [DF_T_Product_MinStore] DEFAULT ((0)) NOT NULL,
    [MaxStore]        INT             CONSTRAINT [DF_T_Product_MaxStore] DEFAULT ((0)) NOT NULL,
    [Cycle]           NUMERIC (18, 2) CONSTRAINT [DF_T_Product_Cycle] DEFAULT ((0)) NOT NULL,
    [DrawingId]       INT             CONSTRAINT [DF_T_Product_DrawingId] DEFAULT ((0)) NOT NULL,
    [IsRemind]        BIT             CONSTRAINT [DF_T_Product_IsRemind] DEFAULT ((0)) NOT NULL,
    [QtyMode]         SMALLINT        CONSTRAINT [DF_T_Product_QtyMode] DEFAULT ((1)) NOT NULL,
    [preprice1]       NUMERIC (18, 4) CONSTRAINT [DF_T_Product_preprice1] DEFAULT ((0)) NOT NULL,
    [preprice2]       NUMERIC (18, 4) CONSTRAINT [DF_T_Product_preprice2] DEFAULT ((0)) NOT NULL,
    [preprice3]       NUMERIC (18, 4) CONSTRAINT [DF_T_Product_preprice3] DEFAULT ((0)) NOT NULL,
    [preprice4]       NUMERIC (18, 4) CONSTRAINT [DF_T_Product_preprice31] DEFAULT ((0)) NOT NULL,
    [recprice]        NUMERIC (18, 4) CONSTRAINT [DF_T_Product_price] DEFAULT ((0)) NOT NULL,
    [Remark1]         VARCHAR (500)   NOT NULL,
    [Remark2]         VARCHAR (500)   NOT NULL,
    [Remark3]         VARCHAR (500)   NOT NULL,
    [Remark4]         VARCHAR (500)   NOT NULL,
    [Remark5]         VARCHAR (500)   NOT NULL,
    [Remark6]         VARCHAR (500)   NOT NULL,
    [Remark7]         VARCHAR (500)   NOT NULL,
    [Remark8]         VARCHAR (500)   NOT NULL,
    [ShowNo]          VARCHAR (50)    NOT NULL,
    [ShowProductName] VARCHAR (100)   NOT NULL,
    [ShowSpec]        VARCHAR (100)   NOT NULL,
    [ShowLOrR]        VARCHAR (5)     NOT NULL,
    [ShowPos]         VARCHAR (50)    NOT NULL,
    [IsShow]          BIT             CONSTRAINT [DF_T_Product_IsShow] DEFAULT ((0)) NOT NULL,
    [IsNew]           BIT             CONSTRAINT [DF_T_Product_IsNew] DEFAULT ((0)) NOT NULL,
    [NewRemark]       VARCHAR (500)   NOT NULL,
    [PId]             INT             NOT NULL,
    [Level_Path]      VARCHAR (1000)  NOT NULL,
    [Level_Num]       INT             NOT NULL,
    [Level_Total]     INT             NOT NULL,
    [Level_Deep]      INT             NOT NULL,
    [CreateId]        VARCHAR (36)    NOT NULL,
    [CreateDate]      DATETIME        NOT NULL,
    [LastModifyId]    VARCHAR (36)    NOT NULL,
    [LastModifyDate]  DATETIME        NOT NULL,
    [Deleted]         BIT             CONSTRAINT [DF_T_Product_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_T_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品信息', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'商品名称(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductName1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'规格型号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Spec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'规格型号(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Spec1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品类型（成品，零部件）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品大图', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ProductImage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'计量单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Unit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'材料标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Material';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品代码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'货位号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'GoodCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'校验码（单）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'CheckCodeOne';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'校验码（多）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'CheckCodeMany';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'包装数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'PackQty';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'证件类型（a证，b证）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'CertType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品注册证Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'RegisterId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最小库存', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'MinStore';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最大库存', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'MaxStore';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'生产周期（小时）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Cycle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'图纸Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'DrawingId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'库存报警标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'IsRemind';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'数量模式（0，通用模式，1严格管理序列号，2严格管理批号）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'QtyMode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'preprice1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'preprice2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'preprice3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'零售价', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'preprice4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最近价格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'recprice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark5';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark6';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注7', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark7';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Remark8';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ShowNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示产品名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ShowProductName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示规格型号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ShowSpec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示左右', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ShowLOrR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示适应部位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'ShowPos';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否销售（所有show开头均为销售选项）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'IsShow';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否为新品', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'IsNew';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'新品发布说明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'NewRemark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树性父结构代码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'PId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树性结构路径', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Level_Path';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'儿子数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Level_Num';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'子孙数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Level_Total';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树的深度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Level_Deep';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product', @level2type = N'COLUMN', @level2name = N'Deleted';

