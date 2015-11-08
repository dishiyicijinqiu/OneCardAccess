using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.Linq;

namespace FengSharp.OneCardAccess.Domain.HRModule.Service
{
    public class DeptService : ServiceBase, IDeptService
    {
        const string modestring = "dept";

        public DeptCMCateEntity[] GetDeptTree(int pid)
        {
            var dt = base.GetTree(modestring + "cm", pid);
            return DataTableToCMCateEntitys(dt);
        }

        public int CreateDept(DeptEntity entity)
        {
            int entityid = 0;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_CreateDept");
                base.Database.AddOutParameter(cmd, "DeptId", DbType.Int32, 4);
                base.Database.AddInParameter(cmd, "DeptNo", DbType.String, entity.DeptNo);
                base.Database.AddInParameter(cmd, "DeptName", DbType.String, entity.DeptName);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
                base.Database.AddInParameter(cmd, "PId", DbType.Int32, entity.PId);
                base.Database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
                base.Database.ExecuteNonQuery(cmd, tran);
                entityid = (int)base.Database.GetParameterValue(cmd, "DeptId");
            });
            return entityid;
        }

        public void UpdateDept(DeptEntity entity)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_UpdateDept");
                base.Database.AddInParameter(cmd, "DeptId", DbType.Int32, entity.DeptId);
                base.Database.AddInParameter(cmd, "DeptNo", DbType.String, entity.DeptNo);
                base.Database.AddInParameter(cmd, "DeptName", DbType.String, entity.DeptName);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
                base.Database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void DeleteDepts(int[] deptIds)
        {
            base.UseTran((tran) =>
            {
                deptIds.ToList().ForEach((deptid) =>
                {
                    base.DeleteEntity(modestring, deptid, tran);
                });
            });
        }

        public DeptEntity GetDeptById(int DeptId)
        {
            var row = this.FindById(modestring, DeptId);
            return DeptService.DataRowToEntity(row);
        }

        #region 实体转换
        private static DeptCMCateEntity[] DataTableToCMCateEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DeptCMCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DeptService.DataRowToCMCateEntity(dt.Rows[i]);
            }
            return results;
        }

        private static DeptCMCateEntity DataRowToCMCateEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new DeptCMCateEntity();
            var entity = DeptService.DataRowToCMEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.HasCate = result.Level_Num > 0;
            return result;
        }

        private static DeptCMEntity[] DataTableToCMEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DeptCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DeptService.DataRowToCMEntity(dt.Rows[i]);
            }
            return results;
        }

        private static DeptCMEntity DataRowToCMEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new DeptCMEntity();
            var entity = DeptService.DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }

        private static DeptEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DeptEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        private static DeptEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new DeptEntity()
            {
                DeptId = (int)(row["DeptId"]),
                DeptNo = (string)(row["DeptNo"]),
                DeptName = (string)(row["DeptName"]),
                Remark = (string)(row["Remark"]),
                PId = (int)(row["PId"]),
                Level_Path = (string)(row["Level_Path"]),
                Level_Num = (int)(row["Level_Num"]),
                Level_Total = (int)(row["Level_Total"]),
                Level_Deep = (int)(row["Level_Deep"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
                Deleted = (bool)(row["Deleted"]),

            };
            return result;
        }
        #endregion
    }
}
