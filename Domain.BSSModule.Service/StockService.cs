using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Services;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class StockService : ServiceBase, IStockService
    {
        const string modestring = "stock";
        public StockEntity GetStockById(int entityid)
        {
            var row = this.FindById(modestring, entityid);
            return StockService.DataRowToEntity(row);
        }

        public void DeleteStocks(int[] entityids)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    base.DeleteEntity(modestring, entityid, tran);
                });
            });
        }

        public StockCMEntity[] GetStockCMList()
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            var dt = base.GetList(modestring + "cm", userid);
            return StockService.DataTableToCMEntitys(dt);
        }

        public int CreateStock(StockEntity entity)
        {
            int entityid = 0;
            base.UseTran((tran) =>
            {
                var cmd = GetCreateStockCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                entityid = (int)base.Database.GetParameterValue(cmd, "StockId");
            });
            return entityid;
        }

        public void UpdateStock(StockEntity entity)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateEntityCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public static DbCommand GetCreateStockCommand(Database database, StockEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateStock");
            database.AddOutParameter(cmd, "StockId", DbType.Int32, 4);
            #region 参数赋值
            database.AddInParameter(cmd, "StockNo", DbType.String, entity.StockNo);
            database.AddInParameter(cmd, "StockName", DbType.String, entity.StockName);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            #endregion
            return cmd;
        }
        public static DbCommand GetUpdateEntityCommand(Database database, StockEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateStock");
            #region 参数赋值
            database.AddInParameter(cmd, "StockId", DbType.Int32, entity.StockId);
            database.AddInParameter(cmd, "StockNo", DbType.String, entity.StockNo);
            database.AddInParameter(cmd, "StockName", DbType.String, entity.StockName);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            #endregion
            return cmd;
        }
        #region 实体转换
        public static StockEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new StockEntity()
            {
                StockId = (int)(row["StockId"]),
                StockNo = (string)(row["StockNo"]),
                StockName = (string)(row["StockName"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
                Remark = (string)(row["Remark"]),

            };
            return result;
        }
        public static StockEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new StockEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }
        public static StockCMEntity DataRowToCMEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new StockCMEntity();
            var entity = DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }
        public static StockCMEntity[] DataTableToCMEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new StockCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToCMEntity(dt.Rows[i]);
            }
            return results;
        }
        #endregion
    }
}
