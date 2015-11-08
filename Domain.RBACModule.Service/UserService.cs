using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class UserService : ServiceBase, IUserService
    {
        const string modestring = "user";
        public string CreateUser(UserEntity user)
        {
            string UserId = string.Empty;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_CreateUser");
                base.Database.AddOutParameter(cmd, "UserId", DbType.String, 36);
                base.Database.AddInParameter(cmd, "UserNo", DbType.String, user.UserNo);
                base.Database.AddInParameter(cmd, "UserName", DbType.String, user.UserName);
                base.Database.AddInParameter(cmd, "CreateId", DbType.String, user.CreateId);
                base.Database.AddInParameter(cmd, "UserPassWord", DbType.String, user.UserPassWord);
                base.Database.AddInParameter(cmd, "IsLock", DbType.String, user.IsLock);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, user.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
                UserId = base.Database.GetParameterValue(cmd, "UserId").ToString();
            });
            return UserId;
        }

        public void UpdateUser(UserEntity user)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_UpdateUser");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, user.UserId);
                base.Database.AddInParameter(cmd, "UserNo", DbType.String, user.UserNo);
                base.Database.AddInParameter(cmd, "UserName", DbType.String, user.UserName);
                base.Database.AddInParameter(cmd, "LastModifyId", DbType.String, user.LastModifyId);
                base.Database.AddInParameter(cmd, "IsLock", DbType.String, user.IsLock);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, user.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void DeleteUsers(string[] EntityIds)
        {
            base.UseTran((tran) =>
              {
                  EntityIds.ToList().ForEach((EntityId) =>
                  {
                      base.DeleteEntity(modestring, EntityId, tran);
                  });
              });
        }

        public UserEntity FindUserById(string UserId)
        {
            var row = this.FindById(modestring, UserId);
            return UserService.DataRowToEntity(row);
        }

        public UserEntity[] FindUsersByUserNo(string UserNo)
        {
            throw new System.NotImplementedException();
        }

        public UserEntity[] GetAllUser()
        {
            var dt = this.GetList(modestring);
            return UserService.DataTableToEntitys(dt);
        }

        public static UserEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new UserEntity();
            result.CreateDate = Convert.ToDateTime(row["CreateDate"]);
            result.CreateId = Convert.ToString(row["CreateId"]);
            result.IsLock = Convert.ToBoolean(row["IsLock"]);
            result.IsUserAuthority = Convert.ToBoolean(row["IsUserAuthority"]);
            result.LastModifyDate = Convert.ToDateTime(row["LastModifyDate"]);
            result.LastModifyId = Convert.ToString(row["LastModifyId"]);
            result.Remark = Convert.ToString(row["Remark"]);
            result.UserId = Convert.ToString(row["UserId"]);
            result.UserName = Convert.ToString(row["UserName"]);
            result.UserNo = Convert.ToString(row["UserNo"]);
            return result;
        }

        public static UserWithCreateAndModify DataRowToEntity1(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new UserWithCreateAndModify();
            var entity = DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }

        public static UserEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new UserEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static UserWithCreateAndModify[] DataTableToEntitys1(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new UserWithCreateAndModify[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity1(dt.Rows[i]);
            }
            return results;
        }

        public UserWithCreateAndModify[] GetAllUserWithCreateAndModify()
        {
            var dt = base.GetList(modestring + "cm");
            return UserService.DataTableToEntitys1(dt);
        }
    }
}