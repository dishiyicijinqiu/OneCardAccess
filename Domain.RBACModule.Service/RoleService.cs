using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class RoleService : ServiceBase, IRoleService
    {
        const string modestring = "role";

        public RoleEntity FindRoleById(string RoleId)
        {
            var row = this.FindById(modestring, RoleId);
            return DataRowToBindEntity(row);
        }
        public string CreateRole(RoleEntity role)
        {
            string RoleId = string.Empty;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_CreateRole");
                base.Database.AddOutParameter(cmd, "RoleId", DbType.String, 36);
                base.Database.AddInParameter(cmd, "RoleNo", DbType.String, role.RoleNo);
                base.Database.AddInParameter(cmd, "RoleName", DbType.String, role.RoleName);
                base.Database.AddInParameter(cmd, "CreateId", DbType.String, role.CreateId);
                base.Database.AddInParameter(cmd, "IsLock", DbType.String, role.IsLock);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, role.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
                RoleId = base.Database.GetParameterValue(cmd, "RoleId").ToString();
            });
            return RoleId;
        }

        public void DeleteRole(string roleid)
        {
            base.UseTran((tran) =>
            {
                base.DeleteEntity(modestring, roleid, tran);
            });
        }

        public void UpdateRole(RoleEntity role)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_UpdateRole");
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, role.RoleId);
                base.Database.AddInParameter(cmd, "RoleNo", DbType.String, role.RoleNo);
                base.Database.AddInParameter(cmd, "RoleName", DbType.String, role.RoleName);
                base.Database.AddInParameter(cmd, "LastModifyId", DbType.String, role.LastModifyId);
                base.Database.AddInParameter(cmd, "IsLock", DbType.String, role.IsLock);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, role.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public RoleEntity[] GetAllRole()
        {
            var dt = this.GetList("role");
            return RoleService.DataTableToBindEntitys(dt);
        }

        public UserEntity[] GetRoleUsers(string RoleId)
        {
            DataTable dt = base.GetRelationData("roleuser", RoleId);
            return UserService.DataTableToEntitys(dt);
        }
        public static RoleEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RoleEntity()
            {
                CreateDate = (System.DateTime)(row["CreateDate"]),
                CreateId = Convert.ToString(row["CreateId"]),
                IsLock = Convert.ToBoolean(row["IsLock"]),
                LastModifyDate = Convert.ToDateTime(row["LastModifyDate"]),
                LastModifyId = Convert.ToString(row["LastModifyId"]),
                Remark = Convert.ToString(row["Remark"]),
                RoleId = Convert.ToString(row["RoleId"]),
                RoleNo = Convert.ToString(row["RoleNo"]),
                IsSuper = Convert.ToBoolean(row["IsSuper"]),
                RoleName = Convert.ToString(row["RoleName"]),
            };
            return result;
        }
        public static RoleEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RoleEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}