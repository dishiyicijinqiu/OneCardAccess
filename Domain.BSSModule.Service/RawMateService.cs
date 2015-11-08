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
    public class RawMateService : ServiceBase, IRawMateService
    {
        const string modestring = "rawmate";
        public RawMateCMCateEntity[] GetRawMateTree(int pid)
        {
            var dt = base.GetTree(modestring + "cm", pid);
            return RawMateService.DataTableToEntitys2(dt);
        }

        public RawMateEntity GetRawMateById(int entityid)
        {
            var row = this.FindById(modestring, entityid);
            return RawMateService.DataRowToEntity(row);
        }

        public int CreateRawMate(RawMateEntity entity)
        {
            int entityid = 0;
            base.UseTran((tran) =>
            {
                var cmd = GetCreateRawMateCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                entityid = (int)base.Database.GetParameterValue(cmd, "RawMateId");
            });
            return entityid;
        }

        public void UpdateRawMate(RawMateEntity entity)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateRawMateCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void DeleteRawMates(int[] entityids)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    base.DeleteEntity(modestring, entityid, tran);
                });
            });
        }

        public static DbCommand GetCreateRawMateCommand(Database database, RawMateEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateRawMate");
            database.AddOutParameter(cmd, "RawMateId", DbType.Int32, 4);
            #region 参数赋值
            database.AddInParameter(cmd, "RawMateNo", DbType.String, entity.RawMateNo);
            database.AddInParameter(cmd, "RawMateName", DbType.String, entity.RawMateName);
            database.AddInParameter(cmd, "Spec", DbType.String, entity.Spec);
            database.AddInParameter(cmd, "MinStore", DbType.Decimal, entity.MinStore);
            database.AddInParameter(cmd, "MaxStore", DbType.Decimal, entity.MaxStore);
            database.AddInParameter(cmd, "Unit", DbType.String, entity.Unit);
            database.AddInParameter(cmd, "IsRemind", DbType.Boolean, entity.IsRemind);
            database.AddInParameter(cmd, "QtyMode", DbType.Int16, entity.QtyMode);
            database.AddInParameter(cmd, "preprice1", DbType.Decimal, entity.preprice1);
            database.AddInParameter(cmd, "preprice2", DbType.Decimal, entity.preprice2);
            database.AddInParameter(cmd, "preprice3", DbType.Decimal, entity.preprice3);
            database.AddInParameter(cmd, "recprice", DbType.Decimal, entity.recprice);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            database.AddInParameter(cmd, "Remark3", DbType.String, entity.Remark3);
            database.AddInParameter(cmd, "Remark4", DbType.String, entity.Remark4);
            database.AddInParameter(cmd, "PId", DbType.Int32, entity.PId);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            #endregion
            return cmd;
        }

        public static DbCommand GetUpdateRawMateCommand(Database database, RawMateEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateRawMate");
            #region 参数赋值
            database.AddInParameter(cmd, "RawMateId", DbType.Int32, entity.RawMateId);
            database.AddInParameter(cmd, "RawMateNo", DbType.String, entity.RawMateNo);
            database.AddInParameter(cmd, "RawMateName", DbType.String, entity.RawMateName);
            database.AddInParameter(cmd, "Spec", DbType.String, entity.Spec);
            database.AddInParameter(cmd, "MinStore", DbType.Decimal, entity.MinStore);
            database.AddInParameter(cmd, "MaxStore", DbType.Decimal, entity.MaxStore);
            database.AddInParameter(cmd, "Unit", DbType.String, entity.Unit);
            database.AddInParameter(cmd, "IsRemind", DbType.Boolean, entity.IsRemind);
            database.AddInParameter(cmd, "QtyMode", DbType.Int16, entity.QtyMode);
            database.AddInParameter(cmd, "preprice1", DbType.Decimal, entity.preprice1);
            database.AddInParameter(cmd, "preprice2", DbType.Decimal, entity.preprice2);
            database.AddInParameter(cmd, "preprice3", DbType.Decimal, entity.preprice3);
            database.AddInParameter(cmd, "recprice", DbType.Decimal, entity.recprice);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            database.AddInParameter(cmd, "Remark3", DbType.String, entity.Remark3);
            database.AddInParameter(cmd, "Remark4", DbType.String, entity.Remark4);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            #endregion
            return cmd;
        }
        #region 实体转换

        public static RawMateCMCateEntity[] DataTableToEntitys2(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RawMateCMCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = RawMateService.DataRowToEntity2(dt.Rows[i]);
            }
            return results;
        }

        public static RawMateCMCateEntity DataRowToEntity2(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new RawMateCMCateEntity();
            var entity = DataRowToEntity1(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.HasCate = result.Level_Num > 0;
            return result;
        }

        public static RawMateCMEntity[] DataTableToEntitys1(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RawMateCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity1(dt.Rows[i]);
            }
            return results;
        }

        public static RawMateCMEntity DataRowToEntity1(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new RawMateCMEntity();
            var entity = DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }

        public static RawMateEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RawMateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static RawMateEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RawMateEntity()
            {
                RawMateId = (int)(row["RawMateId"]),
                RawMateNo = (string)(row["RawMateNo"]),
                RawMateName = (string)(row["RawMateName"]),
                Spec = (string)(row["Spec"]),
                MinStore = (decimal)(row["MinStore"]),
                MaxStore = (decimal)(row["MaxStore"]),
                Unit = (string)(row["Unit"]),
                IsRemind = (bool)(row["IsRemind"]),
                QtyMode = (short)(row["QtyMode"]),
                preprice1 = (decimal)(row["preprice1"]),
                preprice2 = (decimal)(row["preprice2"]),
                preprice3 = (decimal)(row["preprice3"]),
                recprice = (decimal)(row["recprice"]),
                Remark1 = (string)(row["Remark1"]),
                Remark2 = (string)(row["Remark2"]),
                Remark3 = (string)(row["Remark3"]),
                Remark4 = (string)(row["Remark4"]),
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
