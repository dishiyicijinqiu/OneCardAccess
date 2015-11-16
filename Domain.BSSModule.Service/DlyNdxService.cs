using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Services;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class DlyNdxService : ServiceBase, IDlyNdxService
    {
        public string GetNewDlyNo(int DlyTypeId)
        {
            var nowtime = DateTime.Now;
            int nowmonth = nowtime.Year * 12 + nowtime.Month;
            DbCommand cmd = Database.GetStoredProcCommand("P_GetNewDlyNo");
            Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
            Database.AddInParameter(cmd, "NowMonth", DbType.Int32, nowmonth);
            Database.AddOutParameter(cmd, "DlyFormat", DbType.String, 66);
            Database.AddOutParameter(cmd, "MaxNo", DbType.Int32, 4);
            base.UseTran((tran) =>
            {
                Database.ExecuteNonQuery(cmd, tran);
            });
            string strDlyFormat = Database.GetParameterValue(cmd, "DlyFormat").ToString();
            int maxno = Convert.ToInt32(Database.GetParameterValue(cmd, "MaxNo"));
            return string.Format(nowtime.ToString(strDlyFormat), maxno);
        }

        public string GetDlyDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public DlyNdxFullNameEntity[] GetCGList()
        {
            var dt = base.GetSQList("dlycg", string.Empty);
            return DlyNdxService.DataTableToDlyNdxFullNameEntity(dt);
        }

        public string SaveSPRKBak(SPRKDlyCGNdxEntity entity)
        {
            string dlyNdxId = string.Empty;
            base.UseTran((tran) =>
            {
                //删除之前的数据
                if (!string.IsNullOrWhiteSpace(entity.DlyNdxId))
                {
                    DbCommand cmdDlyNdxDelete = GetDeleteDlyNdxCommand(Database, entity, "p");
                    Database.ExecuteNonQuery(cmdDlyNdxDelete, tran);
                }

                //创建单据索引
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

                    //创建批号备份
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

                    //创建序列号备份
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
                }

                //创建优惠备份
                if (entity.Prefer != 0)
                {
                    DbCommand cmdCreatePreferBak = GetCreatePreferBakCommand(Database, entity, entity.Prefer);
                    Database.ExecuteNonQuery(cmdCreatePreferBak, tran);
                }
            });
            return dlyNdxId;
        }

        #region 实体转DbCommand

        public static DbCommand GetCreatePreferBakCommand(Database database, DlyNdxEntity entity, decimal prefer)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreatePDlyABak");
            database.AddOutParameter(cmd, "PDlyABakId", DbType.String, 36);
            #region 参数赋值
            database.AddInParameter(cmd, "DlyNdxId", DbType.String, entity.DlyNdxId);
            database.AddInParameter(cmd, "ATypeId", DbType.Int32, FengSharp.OneCardAccess.Application.Config.DlyConfig.SPYHATypeId);
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "JSRId", DbType.String, entity.JSRId);
            database.AddInParameter(cmd, "StockId", DbType.Int32, entity.StockId1);
            database.AddInParameter(cmd, "Total", DbType.Decimal, prefer);
            database.AddInParameter(cmd, "DlyDate", DbType.String, entity.DlyDate);
            database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, entity.DlyTypeId);
            database.AddInParameter(cmd, "Remark", DbType.String, string.Empty);
            #endregion
            return cmd;
        }
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
        #endregion

        #region 实体转换
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
            var entity = DataRowToEntity(dataRow);
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
        public static DlyNdxEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyNdxEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }
        public static DlyNdxEntity DataRowToEntity(DataRow row)
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
    }
}
