using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class ProductService : ServiceBase, IProductService
    {
        const string modestring = "product";

        public ProductEntity GetProductById(int entityid)
        {
            var row = this.FindById(modestring, entityid);
            return ProductService.DataRowToEntity(row);
        }

        public int CreateProduct(ProductEntity entity)
        {
            int entityid = 0;
            base.UseTran((tran) =>
            {
                var cmd = GetCreateProductCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                entityid = (int)base.Database.GetParameterValue(cmd, "ProductId");
            });
            return entityid;
        }

        public void UpdateProduct(ProductEntity entity)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateProductCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void DeleteProducts(int[] entityids)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    base.DeleteEntity(modestring, entityid, tran);
                });
            });
        }
        public Product_Register_Draw_CMCateEntity[] GetProduct_Register_Draw_CMCateTree(int pid)
        {
            var dt = base.GetTree(modestring + "rdcm", pid);
            return ProductService.DataTableToRegisterDrawCMCateEntity(dt);
        }
        public static DbCommand GetCreateProductCommand(Database database, ProductEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateProduct");
            #region 参数赋值
            database.AddOutParameter(cmd, "ProductId", DbType.Int32, 4);
            database.AddInParameter(cmd, "ProductNo", DbType.String, entity.ProductNo);
            database.AddInParameter(cmd, "ProductName", DbType.String, entity.ProductName);
            database.AddInParameter(cmd, "ProductName1", DbType.String, entity.ProductName1);
            database.AddInParameter(cmd, "Spec", DbType.String, entity.Spec);
            database.AddInParameter(cmd, "Spec1", DbType.String, entity.Spec1);
            database.AddInParameter(cmd, "ProductType", DbType.Int16, entity.ProductType);
            database.AddInParameter(cmd, "ProductImage", DbType.String, entity.ProductImage);
            database.AddInParameter(cmd, "Unit", DbType.String, entity.Unit);
            database.AddInParameter(cmd, "Material", DbType.String, entity.Material);
            database.AddInParameter(cmd, "Code", DbType.String, entity.Code);
            database.AddInParameter(cmd, "GoodCode", DbType.String, entity.GoodCode);
            database.AddInParameter(cmd, "CheckCodeOne", DbType.String, entity.CheckCodeOne);
            database.AddInParameter(cmd, "CheckCodeMany", DbType.String, entity.CheckCodeMany);
            database.AddInParameter(cmd, "PackQty", DbType.Int32, entity.PackQty);
            database.AddInParameter(cmd, "CertType", DbType.Int16, entity.CertType);
            database.AddInParameter(cmd, "RegisterId", DbType.String, entity.RegisterId);
            database.AddInParameter(cmd, "MinStore", DbType.Int32, entity.MinStore);
            database.AddInParameter(cmd, "MaxStore", DbType.Int32, entity.MaxStore);
            database.AddInParameter(cmd, "Cycle", DbType.Decimal, entity.Cycle);
            database.AddInParameter(cmd, "DrawingId", DbType.Int32, entity.DrawingId);
            database.AddInParameter(cmd, "IsRemind", DbType.Boolean, entity.IsRemind);
            database.AddInParameter(cmd, "QtyMode", DbType.Int16, entity.QtyMode);
            database.AddInParameter(cmd, "preprice1", DbType.Decimal, entity.preprice1);
            database.AddInParameter(cmd, "preprice2", DbType.Decimal, entity.preprice2);
            database.AddInParameter(cmd, "preprice3", DbType.Decimal, entity.preprice3);
            database.AddInParameter(cmd, "preprice4", DbType.Decimal, entity.preprice4);
            database.AddInParameter(cmd, "recprice", DbType.Decimal, entity.recprice);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            database.AddInParameter(cmd, "Remark3", DbType.String, entity.Remark3);
            database.AddInParameter(cmd, "Remark4", DbType.String, entity.Remark4);
            database.AddInParameter(cmd, "Remark5", DbType.String, entity.Remark5);
            database.AddInParameter(cmd, "Remark6", DbType.String, entity.Remark6);
            database.AddInParameter(cmd, "Remark7", DbType.String, entity.Remark7);
            database.AddInParameter(cmd, "Remark8", DbType.String, entity.Remark8);
            database.AddInParameter(cmd, "ShowNo", DbType.String, entity.ShowNo);
            database.AddInParameter(cmd, "ShowProductName", DbType.String, entity.ShowProductName);
            database.AddInParameter(cmd, "ShowSpec", DbType.String, entity.ShowSpec);
            database.AddInParameter(cmd, "ShowLOrR", DbType.String, entity.ShowLOrR);
            database.AddInParameter(cmd, "ShowPos", DbType.String, entity.ShowPos);
            database.AddInParameter(cmd, "IsShow", DbType.Boolean, entity.IsShow);
            database.AddInParameter(cmd, "IsNew", DbType.Boolean, entity.IsNew);
            database.AddInParameter(cmd, "NewRemark", DbType.String, entity.NewRemark);
            database.AddInParameter(cmd, "PId", DbType.Int32, entity.PId);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            #endregion
            return cmd;
        }

        public static DbCommand GetUpdateProductCommand(Database database, ProductEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateProduct");
            #region 参数赋值
            database.AddInParameter(cmd, "ProductId", DbType.Int32, entity.ProductId);
            database.AddInParameter(cmd, "ProductNo", DbType.String, entity.ProductNo);
            database.AddInParameter(cmd, "ProductName", DbType.String, entity.ProductName);
            database.AddInParameter(cmd, "ProductName1", DbType.String, entity.ProductName1);
            database.AddInParameter(cmd, "Spec", DbType.String, entity.Spec);
            database.AddInParameter(cmd, "Spec1", DbType.String, entity.Spec1);
            database.AddInParameter(cmd, "ProductType", DbType.Int16, entity.ProductType);
            database.AddInParameter(cmd, "ProductImage", DbType.String, entity.ProductImage);
            database.AddInParameter(cmd, "Unit", DbType.String, entity.Unit);
            database.AddInParameter(cmd, "Material", DbType.String, entity.Material);
            database.AddInParameter(cmd, "Code", DbType.String, entity.Code);
            database.AddInParameter(cmd, "GoodCode", DbType.String, entity.GoodCode);
            database.AddInParameter(cmd, "CheckCodeOne", DbType.String, entity.CheckCodeOne);
            database.AddInParameter(cmd, "CheckCodeMany", DbType.String, entity.CheckCodeMany);
            database.AddInParameter(cmd, "PackQty", DbType.Int32, entity.PackQty);
            database.AddInParameter(cmd, "CertType", DbType.Int16, entity.CertType);
            database.AddInParameter(cmd, "RegisterId", DbType.String, entity.RegisterId);
            database.AddInParameter(cmd, "MinStore", DbType.Int32, entity.MinStore);
            database.AddInParameter(cmd, "MaxStore", DbType.Int32, entity.MaxStore);
            database.AddInParameter(cmd, "Cycle", DbType.Decimal, entity.Cycle);
            database.AddInParameter(cmd, "DrawingId", DbType.Int32, entity.DrawingId);
            database.AddInParameter(cmd, "IsRemind", DbType.Boolean, entity.IsRemind);
            database.AddInParameter(cmd, "QtyMode", DbType.Int16, entity.QtyMode);
            database.AddInParameter(cmd, "preprice1", DbType.Decimal, entity.preprice1);
            database.AddInParameter(cmd, "preprice2", DbType.Decimal, entity.preprice2);
            database.AddInParameter(cmd, "preprice3", DbType.Decimal, entity.preprice3);
            database.AddInParameter(cmd, "preprice4", DbType.Decimal, entity.preprice4);
            database.AddInParameter(cmd, "recprice", DbType.Decimal, entity.recprice);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            database.AddInParameter(cmd, "Remark3", DbType.String, entity.Remark3);
            database.AddInParameter(cmd, "Remark4", DbType.String, entity.Remark4);
            database.AddInParameter(cmd, "Remark5", DbType.String, entity.Remark5);
            database.AddInParameter(cmd, "Remark6", DbType.String, entity.Remark6);
            database.AddInParameter(cmd, "Remark7", DbType.String, entity.Remark7);
            database.AddInParameter(cmd, "Remark8", DbType.String, entity.Remark8);
            database.AddInParameter(cmd, "ShowNo", DbType.String, entity.ShowNo);
            database.AddInParameter(cmd, "ShowProductName", DbType.String, entity.ShowProductName);
            database.AddInParameter(cmd, "ShowSpec", DbType.String, entity.ShowSpec);
            database.AddInParameter(cmd, "ShowLOrR", DbType.String, entity.ShowLOrR);
            database.AddInParameter(cmd, "ShowPos", DbType.String, entity.ShowPos);
            database.AddInParameter(cmd, "IsShow", DbType.Boolean, entity.IsShow);
            database.AddInParameter(cmd, "IsNew", DbType.Boolean, entity.IsNew);
            database.AddInParameter(cmd, "NewRemark", DbType.String, entity.NewRemark);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            #endregion
            return cmd;
        }
        #region 实体转换

        public static Product_Register_Draw_CMCateEntity[] DataTableToRegisterDrawCMCateEntity(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new Product_Register_Draw_CMCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = ProductService.DataRowToRegisterDrawCMCateEntity(dt.Rows[i]);
            }
            return results;
        }

        public static Product_Register_Draw_CMCateEntity DataRowToRegisterDrawCMCateEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new Product_Register_Draw_CMCateEntity();
            var entity = DataRowToCMCateEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.RegisterNo = dataRow["RegisterNo"].ToString();
            result.RegisterNo1 = dataRow["RegisterNo1"].ToString();
            result.RegisterProductName = dataRow["RegisterProductName"].ToString();
            result.RegisterProductName1 = dataRow["RegisterProductName1"].ToString();
            result.StandardCode = dataRow["StandardCode"].ToString();
            result.StandardCode1 = dataRow["StandardCode1"].ToString();
            result.DrawingName = dataRow["DrawingName"].ToString();
            return result;
        }

        public static ProductCMCateEntity[] DataTableToCMCateEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ProductCMCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = ProductService.DataRowToCMCateEntity(dt.Rows[i]);
            }
            return results;
        }

        public static ProductCMCateEntity DataRowToCMCateEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new ProductCMCateEntity();
            var entity = DataRowToCMEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.HasCate = result.Level_Num > 0;
            return result;
        }

        public static ProductCMEntity[] DataTableToCMEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ProductCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToCMEntity(dt.Rows[i]);
            }
            return results;
        }

        public static ProductCMEntity DataRowToCMEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new ProductCMEntity();
            var entity = DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }

        public static ProductEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ProductEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static ProductEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new ProductEntity()
            {
                ProductId = (int)(row["ProductId"]),
                ProductNo = (string)(row["ProductNo"]),
                ProductName = (string)(row["ProductName"]),
                ProductName1 = (string)(row["ProductName1"]),
                Spec = (string)(row["Spec"]),
                Spec1 = (string)(row["Spec1"]),
                ProductType = (short)(row["ProductType"]),
                ProductImage = (string)(row["ProductImage"]),
                Unit = (string)(row["Unit"]),
                Material = (string)(row["Material"]),
                Code = (string)(row["Code"]),
                GoodCode = (string)(row["GoodCode"]),
                CheckCodeOne = (string)(row["CheckCodeOne"]),
                CheckCodeMany = (string)(row["CheckCodeMany"]),
                PackQty = (int)(row["PackQty"]),
                CertType = (short)(row["CertType"]),
                RegisterId = (string)(row["RegisterId"]),
                MinStore = (int)(row["MinStore"]),
                MaxStore = (int)(row["MaxStore"]),
                Cycle = (decimal)(row["Cycle"]),
                DrawingId = (int)(row["DrawingId"]),
                IsRemind = (bool)(row["IsRemind"]),
                QtyMode = (short)(row["QtyMode"]),
                preprice1 = (decimal)(row["preprice1"]),
                preprice2 = (decimal)(row["preprice2"]),
                preprice3 = (decimal)(row["preprice3"]),
                preprice4 = (decimal)(row["preprice4"]),
                recprice = (decimal)(row["recprice"]),
                Remark1 = (string)(row["Remark1"]),
                Remark2 = (string)(row["Remark2"]),
                Remark3 = (string)(row["Remark3"]),
                Remark4 = (string)(row["Remark4"]),
                Remark5 = (string)(row["Remark5"]),
                Remark6 = (string)(row["Remark6"]),
                Remark7 = (string)(row["Remark7"]),
                Remark8 = (string)(row["Remark8"]),
                ShowNo = (string)(row["ShowNo"]),
                ShowProductName = (string)(row["ShowProductName"]),
                ShowSpec = (string)(row["ShowSpec"]),
                ShowLOrR = (string)(row["ShowLOrR"]),
                ShowPos = (string)(row["ShowPos"]),
                IsShow = (bool)(row["IsShow"]),
                IsNew = (bool)(row["IsNew"]),
                NewRemark = (string)(row["NewRemark"]),
                PId = (int)(row["PId"]),
                Level_Path = (string)(row["Level_Path"]),
                Level_Num = (int)(row["Level_Num"]),
                Level_Total = (int)(row["Level_Total"]),
                Level_Deep = (int)(row["Level_Deep"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
            };
            return result;
        }
        #endregion
    }
}
