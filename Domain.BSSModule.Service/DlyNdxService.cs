using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public partial class DlyNdxService : ServiceBase, IDlyNdxService
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

        public string GetDlyNdxIdByNdxNo(string NdxNo, short draft)
        {
            DbCommand cmd = Database.GetSqlStringCommand("select DlyNdxId from T_DlyNdx where DlyNo=@DlyNo and draft=@draft");
            Database.AddInParameter(cmd, "DlyNo", DbType.String, NdxNo);
            Database.AddInParameter(cmd, "draft", DbType.Int16, draft);
            var result = Database.ExecuteScalar(cmd);
            if (result == null)
                return null;
            return result.ToString();
        }

        public DlyNdxFullNameEntity[] GetCGList()
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            var dt = base.GetList("dlycg", userid);
            return DlyNdxService.DataTableToDlyNdxFullNameEntity(dt);
        }
        /// <summary>
        /// 保存商品入库单草稿
        /// </summary>
        public string SaveSPRKBak(SPRKDlyCGNdxEntity entity)
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
                }

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
            });
            return dlyNdxId;
        }
        /// <summary>
        /// 获取商品入库单草稿
        /// </summary>
        public SPRKDlyCGNdxEntity GetSPRKDlyCGNdxEntity(string dlyNdxId)
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            #region DlyNdxFullNameEntity
            var row = base.FindById("dlyndxfull", dlyNdxId, userid);
            DlyNdxFullNameEntity dlyndxfullnameentity = DlyNdxService.DataRowToDlyNdxFullNameEntity(row);
            if (dlyndxfullnameentity == null)
                return null;
            if (dlyndxfullnameentity.Draft != 0)
                return null;
            #endregion
            var result = new SPRKDlyCGNdxEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, dlyndxfullnameentity);

            var dtPDlyBakFullNameEntitys = base.GetRelationData("pdlybakfullname", dlyNdxId, userid);
            var listdlybaks = DataTableToPDlyBakFullNameEntitys(dtPDlyBakFullNameEntitys);
            //PDlyBakFullNameEntity
            #region PDlyBakFullNameEntitys
            result.PDlyBaks.AddRange(listdlybaks.Where(t => t.ATypeId == FengSharp.OneCardAccess.Application.Config.DlyConfig.KCSPATypeId));
            #endregion
            #region PFBNBaks,PSNBaks
            var dtPFBNBaks = base.GetRelationData("pfbnbak", dlyNdxId, userid);
            var listPFBNBaks = DataTableToPFBNBakEntitys(dtPFBNBaks);
            var dtPSNBaks = base.GetRelationData("psnbak", dlyNdxId, userid);
            var listPSNBaks = DataTableToPSNBakEntitys(dtPSNBaks);
            foreach (var dlybak in result.PDlyBaks)
            {
                dlybak.PFBNBaks.AddRange(listPFBNBaks.Where(t => t.PDlyBakId == dlybak.PDlyBakId));
                dlybak.PSNBaks.AddRange(listPSNBaks.Where(t => t.PDlyBakId == dlybak.PDlyBakId));
            }
            #endregion
            result.Qty = result.PDlyBaks.Sum(t => t.Qty);
            result.Total = result.PDlyBaks.Sum(t => t.Total);
            result.Prefer = listdlybaks.Where(t => t.ATypeId == FengSharp.OneCardAccess.Application.Config.DlyConfig.SPYHATypeId).Sum(t => t.Total);
            result.AfterPreferTotal = result.Total - result.Prefer;
            return result;
        }
    }
}