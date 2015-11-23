using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;


namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public partial class DlyNdxService
    {
        #region 实体转DbCommand

        public static DbCommand GetCreatePSNBakCommand(Database database, PSNBakEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreatePSNBak");
            database.AddOutParameter(cmd, "PSNBakId", DbType.String, 36);
            #region 参数赋值
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, entity.DlyNdxId);
            database.AddInParameter(cmd, "ATypeId", DbType.Int32, entity.ATypeId);
            database.AddInParameter(cmd, "PDlyBakId", DbType.String, entity.PDlyBakId);
            database.AddInParameter(cmd, "ProductId", DbType.Int32, entity.ProductId);
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "StockId", DbType.Int32, entity.StockId);
            database.AddInParameter(cmd, "JSRId", DbType.String, entity.JSRId);
            database.AddInParameter(cmd, "BN", DbType.String, entity.BN);
            database.AddInParameter(cmd, "SN", DbType.String, entity.SN);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "DlyDate", DbType.String, entity.DlyDate);
            database.AddInParameter(cmd, "C_OrderNdxId", DbType.String, entity.C_OrderNdxId);
            database.AddInParameter(cmd, "C_ProductOrderId", DbType.String, entity.C_ProductOrderId);
            database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, entity.DlyTypeId);
            database.AddInParameter(cmd, "SortNo", DbType.Int32, entity.SortNo);
            #endregion
            return cmd;
        }
        public static DbCommand GetCreatePFBNBakCommand(Database database, PFBNBakEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreatePFBNBak");
            database.AddOutParameter(cmd, "PFBNBakId", DbType.String, 36);
            #region 参数赋值
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, entity.DlyNdxId);
            database.AddInParameter(cmd, "ATypeId", DbType.Int32, entity.ATypeId);
            database.AddInParameter(cmd, "PDlyBakId", DbType.String, entity.PDlyBakId);
            database.AddInParameter(cmd, "ProductId", DbType.Int32, entity.ProductId);
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "StockId", DbType.Int32, entity.StockId);
            database.AddInParameter(cmd, "JSRId", DbType.String, entity.JSRId);
            database.AddInParameter(cmd, "BN", DbType.String, entity.BN);
            database.AddInParameter(cmd, "FullBN", DbType.String, entity.FullBN);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "DlyDate", DbType.String, entity.DlyDate);
            database.AddInParameter(cmd, "Qty", DbType.Decimal, entity.Qty);
            database.AddInParameter(cmd, "C_OrderNdxId", DbType.String, entity.C_OrderNdxId);
            database.AddInParameter(cmd, "C_ProductOrderId", DbType.String, entity.C_ProductOrderId);
            database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, entity.DlyTypeId);
            database.AddInParameter(cmd, "SortNo", DbType.Int32, entity.SortNo);
            #endregion
            return cmd;
        }
        public static DbCommand GetCreatePDlyBakCommand(Database database, PDlyBakEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreatePDlyBak");
            database.AddOutParameter(cmd, "PDlyBakId", DbType.String, 36);
            #region 参数赋值
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, entity.DlyNdxId);
            database.AddInParameter(cmd, "ATypeId", DbType.Int32, entity.ATypeId);
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, entity.DlyTypeId);
            database.AddInParameter(cmd, "DlyDate", DbType.String, entity.DlyDate);
            database.AddInParameter(cmd, "JSRId", DbType.String, entity.JSRId);
            database.AddInParameter(cmd, "StockId1", DbType.Int32, entity.StockId1);
            database.AddInParameter(cmd, "StockId2", DbType.Int32, entity.StockId2);
            database.AddInParameter(cmd, "ProductId", DbType.Int32, entity.ProductId);
            database.AddInParameter(cmd, "BN", DbType.String, entity.BN);
            database.AddInParameter(cmd, "Qty", DbType.Decimal, entity.Qty);
            database.AddInParameter(cmd, "CostPrice", DbType.Double, entity.CostPrice);
            database.AddInParameter(cmd, "CostTotal", DbType.Decimal, entity.CostTotal);
            database.AddInParameter(cmd, "Price", DbType.Double, entity.Price);
            database.AddInParameter(cmd, "Total", DbType.Decimal, entity.Total);
            //database.AddInParameter(cmd, "DisCount", DbType.Decimal, entity.DisCount);
            //database.AddInParameter(cmd, "DisPrice", DbType.Double, entity.DisPrice);
            //database.AddInParameter(cmd, "DisTotal", DbType.Decimal, entity.DisTotal);
            //database.AddInParameter(cmd, "TaxRate", DbType.Decimal, entity.TaxRate);
            //database.AddInParameter(cmd, "Tax", DbType.Decimal, entity.Tax);
            //database.AddInParameter(cmd, "TaxPrice", DbType.Double, entity.TaxPrice);
            //database.AddInParameter(cmd, "TaxTotal", DbType.Decimal, entity.TaxTotal);
            //database.AddInParameter(cmd, "RetailPrice", DbType.Double, entity.RetailPrice);
            //database.AddInParameter(cmd, "InvoceTotal", DbType.Decimal, entity.InvoceTotal);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "C_OrderNdxId", DbType.String, entity.C_OrderNdxId);
            database.AddInParameter(cmd, "C_ProductOrderId", DbType.String, entity.C_ProductOrderId);
            database.AddInParameter(cmd, "SortNo", DbType.Int32, entity.SortNo);
            #endregion
            return cmd;
        }
        public static DbCommand GetDeleteDlyNdxCommand(Database database, DlyNdxEntity entity, string cMode)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_DeleteDlyNdx");
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, entity.DlyNdxId);
            database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            return cmd;
        }
        public static DbCommand GetCreateDlyNdxCommand(Database database, DlyNdxEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateDlyNdx");
            database.AddOutParameter(cmd, "DlyNdxId", DbType.String, 36);
            //database.AddParameter(cmd, "DlyNdxId", DbType.String, ParameterDirection.InputOutput, string.Empty, DataRowVersion.Default, entity.DlyNdxId);
            #region 参数赋值
            database.AddInParameter(cmd, "DlyNo", DbType.String, entity.DlyNo);
            database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, entity.DlyTypeId);
            database.AddInParameter(cmd, "DlyDate", DbType.String, entity.DlyDate);
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "JSRId", DbType.String, entity.JSRId);
            database.AddInParameter(cmd, "StockId1", DbType.Int32, entity.StockId1);
            database.AddInParameter(cmd, "StockId2", DbType.Int32, entity.StockId2);
            database.AddInParameter(cmd, "Draft", DbType.Int16, entity.Draft);
            database.AddInParameter(cmd, "Summary", DbType.String, entity.Summary);
            database.AddInParameter(cmd, "Comment", DbType.String, entity.Comment);
            database.AddInParameter(cmd, "ZDRId", DbType.String, entity.ZDRId);
            database.AddInParameter(cmd, "SHRId1", DbType.String, entity.SHRId1);
            database.AddInParameter(cmd, "SHRId2", DbType.String, entity.SHRId2);
            database.AddInParameter(cmd, "SHRId3", DbType.String, entity.SHRId3);
            database.AddInParameter(cmd, "SHRId4", DbType.String, entity.SHRId4);
            database.AddInParameter(cmd, "SHRId5", DbType.String, entity.SHRId5);
            //database.AddInParameter(cmd, "IsInvoce", DbType.Boolean, entity.IsInvoce);
            database.AddInParameter(cmd, "Total", DbType.Decimal, entity.Total);
            database.AddInParameter(cmd, "QGNo", DbType.String, entity.QGNo);
            database.AddInParameter(cmd, "QGDate", DbType.String, entity.QGDate);
            database.AddInParameter(cmd, "QGR", DbType.String, entity.QGR);
            database.AddInParameter(cmd, "YDJNo", DbType.String, entity.YDJNo);
            database.AddInParameter(cmd, "BuyDate", DbType.String, entity.BuyDate);
            database.AddInParameter(cmd, "Buyer", DbType.String, entity.Buyer);
            database.AddInParameter(cmd, "LXR", DbType.String, entity.LXR);
            database.AddInParameter(cmd, "LXFS", DbType.String, entity.LXFS);
            #endregion
            return cmd;
        }

        public static DbCommand GetZCreatePDlyCommand(Database database, string dlyNdxId, string userId)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_ZCreatePDly");
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, dlyNdxId);
            database.AddInParameter(cmd, "UserId", DbType.String, userId);
            database.AddOutParameter(cmd, "ProductIdError", DbType.Int32, 4);
            database.AddOutParameter(cmd, "CompanyIdError", DbType.Int32, 4);
            database.AddOutParameter(cmd, "StockId1Error", DbType.Int32, 4);
            database.AddOutParameter(cmd, "StockId2Error", DbType.Int32, 4);
            database.AddOutParameter(cmd, "ATypeIdError", DbType.Int32, 4);
            database.AddOutParameter(cmd, "BNError", DbType.String, 10);
            return cmd;
        }
        #endregion

        #region 实体转换
        #region PSNBakEntity
        public static PSNBakEntity[] DataTableToPSNBakEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new PSNBakEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyNdxService.DataRowToPSNBakEntity(dt.Rows[i]);
            }
            return results;
        }
        public static PSNBakEntity DataRowToPSNBakEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PSNBakEntity()
            {
                PSNBakId = (string)(row["PSNBakId"]),
                DlyNdxId = (string)(row["DlyNdxId"]),
                ATypeId = (int)(row["ATypeId"]),
                PDlyBakId = (string)(row["PDlyBakId"]),
                ProductId = (int)(row["ProductId"]),
                CompanyId = (int)(row["CompanyId"]),
                StockId = (int)(row["StockId"]),
                JSRId = (string)(row["JSRId"]),
                BN = (string)(row["BN"]),
                SN = (string)(row["SN"]),
                Remark = (string)(row["Remark"]),
                DlyDate = (string)(row["DlyDate"]),
                C_OrderNdxId = (string)(row["C_OrderNdxId"]),
                C_ProductOrderId = (string)(row["C_ProductOrderId"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                SortNo = (int)(row["SortNo"]),

            };
            return result;
        }
        #endregion
        #region PFBNBakEntity
        public static PFBNBakEntity[] DataTableToPFBNBakEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new PFBNBakEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyNdxService.DataRowToPFBNBakEntity(dt.Rows[i]);
            }
            return results;
        }
        public static PFBNBakEntity DataRowToPFBNBakEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PFBNBakEntity()
            {
                PFBNBakId = (string)(row["PFBNBakId"]),
                DlyNdxId = (string)(row["DlyNdxId"]),
                ATypeId = (int)(row["ATypeId"]),
                PDlyBakId = (string)(row["PDlyBakId"]),
                ProductId = (int)(row["ProductId"]),
                CompanyId = (int)(row["CompanyId"]),
                StockId = (int)(row["StockId"]),
                JSRId = (string)(row["JSRId"]),
                BN = (string)(row["BN"]),
                FullBN = (string)(row["FullBN"]),
                Remark = (string)(row["Remark"]),
                DlyDate = (string)(row["DlyDate"]),
                Qty = (decimal)(row["Qty"]),
                C_OrderNdxId = (string)(row["C_OrderNdxId"]),
                C_ProductOrderId = (string)(row["C_ProductOrderId"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                SortNo = (int)(row["SortNo"]),

            };
            return result;
        }
        #endregion
        #region PDlyAEntity
        public static PDlyAEntity[] DataTableToPDlyAEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new PDlyAEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyNdxService.DataRowToPDlyAEntity(dt.Rows[i]);
            }
            return results;
        }
        public static PDlyAEntity DataRowToPDlyAEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PDlyAEntity()
            {
                PDlyAId = (string)(row["PDlyAId"]),
                DlyNdxId = (string)(row["DlyNdxId"]),
                ATypeId = (int)(row["ATypeId"]),
                CompanyId = (int)(row["CompanyId"]),
                JSRId = (string)(row["JSRId"]),
                StockId = (int)(row["StockId"]),
                Total = (decimal)(row["Total"]),
                DlyDate = (string)(row["DlyDate"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                Remark = (string)(row["Remark"]),

            };
            return result;
        }
        #endregion
        #region PDlyBakFullNameEntity
        public static PDlyBakFullNameEntity[] DataTableToPDlyBakFullNameEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new PDlyBakFullNameEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyNdxService.DataRowToPDlyBakFullNameEntity(dt.Rows[i]);
            }
            return results;
        }
        public static PDlyBakFullNameEntity DataRowToPDlyBakFullNameEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PDlyBakFullNameEntity();
            var entity = DataRowToPDlyBakEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.ProductNo = row["ProductNo"].ToString();
            result.ProductName = row["ProductName"].ToString();
            result.Spec = row["Spec"].ToString();
            result.GoodCode = row["GoodCode"].ToString();
            result.Unit = row["Unit"].ToString();
            result.QtyMode = (short)row["QtyMode"];
            return result;
        }
        #endregion
        #region PDlyBakEntity
        public static PDlyBakEntity DataRowToPDlyBakEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PDlyBakEntity()
            {
                PDlyBakId = (string)(row["PDlyBakId"]),
                DlyNdxId = (string)(row["DlyNdxId"]),
                ATypeId = (int)(row["ATypeId"]),
                CompanyId = (int)(row["CompanyId"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                DlyDate = (string)(row["DlyDate"]),
                JSRId = (string)(row["JSRId"]),
                StockId1 = (int)(row["StockId1"]),
                StockId2 = (int)(row["StockId2"]),
                ProductId = (int)(row["ProductId"]),
                BN = (string)(row["BN"]),
                Qty = (decimal)(row["Qty"]),
                CostPrice = (double)(row["CostPrice"]),
                CostTotal = (decimal)(row["CostTotal"]),
                Price = (double)(row["Price"]),
                Total = (decimal)(row["Total"]),
                DisCount = (decimal)(row["DisCount"]),
                DisPrice = (double)(row["DisPrice"]),
                DisTotal = (decimal)(row["DisTotal"]),
                TaxRate = (decimal)(row["TaxRate"]),
                Tax = (decimal)(row["Tax"]),
                TaxPrice = (double)(row["TaxPrice"]),
                TaxTotal = (decimal)(row["TaxTotal"]),
                RetailPrice = (double)(row["RetailPrice"]),
                InvoceTotal = (decimal)(row["InvoceTotal"]),
                Remark = (string)(row["Remark"]),
                C_OrderNdxId = (string)(row["C_OrderNdxId"]),
                C_ProductOrderId = (string)(row["C_ProductOrderId"]),
                SortNo = (int)(row["SortNo"]),

            };
            return result;
        }
        #endregion
        #region DlyNdxFullNameEntity
        public static DlyNdxFullNameEntity[] DataTableToDlyNdxFullNameEntity(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyNdxFullNameEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyNdxService.DataRowToDlyNdxFullNameEntity(dt.Rows[i]);
            }
            return results;
        }
        public static DlyNdxFullNameEntity DataRowToDlyNdxFullNameEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new DlyNdxFullNameEntity();
            var entity = DataRowToDlyNdxEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CompanyNo = dataRow["CompanyNo"].ToString();
            result.CompanyName = dataRow["CompanyName"].ToString();
            result.JSRName = dataRow["JSRName"].ToString();
            result.StockNo1 = dataRow["StockNo1"].ToString();
            result.StockName1 = dataRow["StockName1"].ToString();
            result.StockNo2 = dataRow["StockNo2"].ToString();
            result.StockName2 = dataRow["StockName2"].ToString();
            result.ZDRName = dataRow["ZDRName"].ToString();
            result.SHRName1 = dataRow["SHRName1"].ToString();
            result.SHRName2 = dataRow["SHRName2"].ToString();
            result.SHRName3 = dataRow["SHRName3"].ToString();
            result.SHRName4 = dataRow["SHRName4"].ToString();
            result.SHRName5 = dataRow["SHRName5"].ToString();
            return result;
        }
        #endregion
        #region DlyNdxEntity
        public static DlyNdxEntity[] DataTableToDlyNdxEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyNdxEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToDlyNdxEntity(dt.Rows[i]);
            }
            return results;
        }
        public static DlyNdxEntity DataRowToDlyNdxEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new DlyNdxEntity()
            {
                DlyNdxId = (string)(row["DlyNdxId"]),
                DlyNo = (string)(row["DlyNo"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                DlyDate = (string)(row["DlyDate"]),
                CompanyId = (int)(row["CompanyId"]),
                JSRId = (string)(row["JSRId"]),
                StockId1 = (int)(row["StockId1"]),
                StockId2 = (int)(row["StockId2"]),
                Draft = (short)(row["Draft"]),
                Summary = (string)(row["Summary"]),
                Comment = (string)(row["Comment"]),
                ZDRId = (string)(row["ZDRId"]),
                SHRId1 = (string)(row["SHRId1"]),
                SHRId2 = (string)(row["SHRId2"]),
                SHRId3 = (string)(row["SHRId3"]),
                SHRId4 = (string)(row["SHRId4"]),
                SHRId5 = (string)(row["SHRId5"]),
                IsInvoce = (bool)(row["IsInvoce"]),
                Total = (decimal)(row["Total"]),
                QGNo = (string)(row["QGNo"]),
                QGDate = (string)(row["QGDate"]),
                QGR = (string)(row["QGR"]),
                YDJNo = (string)(row["YDJNo"]),
                BuyDate = (string)(row["BuyDate"]),
                Buyer = (string)(row["Buyer"]),
                LXR = (string)(row["LXR"]),
                LXFS = (string)(row["LXFS"]),
            };
            return result;
        }
        #endregion
        #endregion

        #region 公共方法
        public static void CheckZCreatePDlyError(Database database, DbCommand cmd)
        {
            int ProductIdError = (int)database.GetParameterValue(cmd, "ProductIdError");
            if (ProductIdError > 0)
                throw new BusinessException(ProductIdError.ToString());
            int CompanyIdError = (int)database.GetParameterValue(cmd, "CompanyIdError");
            if (CompanyIdError > 0)
                throw new BusinessException(CompanyIdError.ToString());
            int AtypeIdError = (int)database.GetParameterValue(cmd, "AtypeIdError");
            if (AtypeIdError > 0)
                throw new BusinessException(AtypeIdError.ToString());
            int StockIdError = (int)database.GetParameterValue(cmd, "StockIdError");
            if (StockIdError > 0)
                throw new BusinessException(StockIdError.ToString());
            string BNError = (string)database.GetParameterValue(cmd, "BNError");
            if (string.IsNullOrWhiteSpace(BNError))
                throw new BusinessException(BNError);
        }
        #endregion

        /// <summary>
        /// 商品入库单过账
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string SaveSPRKDly(SPRKDlyCGNdxEntity entity)
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            if (string.IsNullOrWhiteSpace(entity.LastSHRId))
            {
                entity.SHRId1 = userid;
            }
            else if (string.Compare(entity.LastSHRId, userid, false) != 0)
            {
                throw new BusinessException(FengSharp.OneCardAccess.Domain.BSSModule.Service.Properties.Resources.NotCurrentSHR);
            }
            string dlyNdxId = string.Empty;
            base.UseTran((tran) =>
            {
                #region 将单据保存为临时单据
                //创建单据索引
                entity.Draft = 4;
                DbCommand cmdDlyNdxCreate = GetCreateDlyNdxCommand(Database, entity);
                Database.ExecuteNonQuery(cmdDlyNdxCreate, tran);
                dlyNdxId = (string)base.Database.GetParameterValue(cmdDlyNdxCreate, "DlyNdxId");
                for (int i = 0; i < entity.PDlyBaks.Count; i++)
                {
                    //创建单据备份
                    var dlyBak = entity.PDlyBaks[i];
                    string dlyNdxBakId = string.Empty;
                    dlyBak.DlyNdxId = dlyNdxId;
                    dlyBak.ATypeId = FengSharp.OneCardAccess.Application.Config.DlyConfig.KCSPATypeId;
                    dlyBak.CompanyId = entity.CompanyId;
                    dlyBak.DlyTypeId = entity.DlyTypeId;
                    dlyBak.DlyDate = entity.DlyDate;
                    dlyBak.JSRId = entity.JSRId;
                    dlyBak.StockId1 = entity.StockId1;
                    dlyBak.SortNo = i;
                    DbCommand cmdCreateDlyBak = GetCreatePDlyBakCommand(Database, dlyBak);
                    Database.ExecuteNonQuery(cmdCreateDlyBak, tran);
                    dlyNdxBakId = (string)base.Database.GetParameterValue(cmdCreateDlyBak, "PDlyBakId");
                    #region 创建批号备份
                    for (int j = 0; j < dlyBak.PFBNBaks.Count; j++)
                    {
                        var FBNBak = dlyBak.PFBNBaks[j];
                        string fbnbakId = FBNBak.PFBNBakId;
                        FBNBak.DlyNdxId = dlyNdxId;
                        FBNBak.PDlyBakId = dlyNdxBakId;
                        FBNBak.ATypeId = dlyBak.ATypeId;
                        FBNBak.ProductId = dlyBak.ProductId;
                        FBNBak.StockId = dlyBak.StockId1;
                        FBNBak.BN = dlyBak.BN;
                        FBNBak.JSRId = dlyBak.JSRId;
                        FBNBak.DlyDate = dlyBak.DlyDate;
                        FBNBak.DlyTypeId = dlyBak.DlyTypeId;
                        FBNBak.SortNo = j;
                        DbCommand cmdCreatePFBNBak = GetCreatePFBNBakCommand(Database, FBNBak);
                        Database.ExecuteNonQuery(cmdCreatePFBNBak, tran);
                        fbnbakId = (string)base.Database.GetParameterValue(cmdCreatePFBNBak, "PFBNBakId");
                    }
                    #endregion
                    #region 创建序列号备份
                    for (int j = 0; j < dlyBak.PSNBaks.Count; j++)
                    {
                        var SNBak = dlyBak.PSNBaks[j];
                        string snbakId = SNBak.PSNBakId;
                        SNBak.DlyNdxId = dlyNdxId;
                        SNBak.PDlyBakId = dlyNdxBakId;
                        SNBak.ATypeId = dlyBak.ATypeId;
                        SNBak.ProductId = dlyBak.ProductId;
                        SNBak.StockId = dlyBak.StockId1;
                        SNBak.BN = dlyBak.BN;
                        SNBak.JSRId = dlyBak.JSRId;
                        SNBak.DlyDate = dlyBak.DlyDate;
                        SNBak.DlyTypeId = dlyBak.DlyTypeId;
                        SNBak.SortNo = j;

                        DbCommand cmdCreateSNBak = GetCreatePSNBakCommand(Database, SNBak);
                        Database.ExecuteNonQuery(cmdCreateSNBak, tran);
                        snbakId = (string)base.Database.GetParameterValue(cmdCreateSNBak, "PSNBakId");
                    }
                    #endregion
                    #region 创建优惠备份
                    if (entity.Prefer != 0)
                    {
                        var preferbak = new PDlyBakEntity();
                        string preferbakBakId = string.Empty;
                        preferbak.DlyNdxId = dlyNdxId;
                        preferbak.ATypeId = FengSharp.OneCardAccess.Application.Config.DlyConfig.KCSPATypeId;
                        preferbak.CompanyId = entity.CompanyId;
                        preferbak.DlyTypeId = entity.DlyTypeId;
                        preferbak.DlyDate = entity.DlyDate;
                        preferbak.JSRId = entity.JSRId;
                        preferbak.StockId1 = entity.StockId1;
                        preferbak.Total = entity.Prefer;
                        DbCommand cmdCreatePreferBak = GetCreatePDlyBakCommand(Database, preferbak);
                        Database.ExecuteNonQuery(cmdCreatePreferBak, tran);
                        preferbakBakId = (string)base.Database.GetParameterValue(cmdCreatePreferBak, "PDlyBakId");
                    }
                    #endregion
                }
                #endregion
                #region 过账
                DbCommand cmd = GetZCreatePDlyCommand(Database, dlyNdxId, userid);
                Database.ExecuteNonQuery(cmd, tran);
                CheckZCreatePDlyError(Database, cmd);
                #endregion
            });
            return dlyNdxId;
        }
    }
}
