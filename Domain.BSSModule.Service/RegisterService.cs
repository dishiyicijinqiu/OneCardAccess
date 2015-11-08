using System.Linq;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class RegisterService : ServiceBase, IRegisterService
    {
        const string modestring = "register";
        #region 实体转换
        private static RegisterCMEntity[] DataTableToEntitys1(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RegisterCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity1(dt.Rows[i]);
            }
            return results;
        }

        private static RegisterCMEntity DataRowToEntity1(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new RegisterCMEntity();
            var entity = DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }

        private static RegisterEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RegisterEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        private static RegisterEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RegisterEntity()
            {
                RegisterId = (string)(row["RegisterId"]),
                RegisterNo = (string)(row["RegisterNo"]),
                RegisterProductName = (string)(row["RegisterProductName"]),
                StandardCode = (string)(row["StandardCode"]),
                RegisterNo1 = (string)(row["RegisterNo1"]),
                RegisterProductName1 = (string)(row["RegisterProductName1"]),
                StandardCode1 = (string)(row["StandardCode1"]),
                RegisterFile = (string)(row["RegisterFile"]),
                StartDate = (string)(row["StartDate"]),
                EndDate = (string)(row["EndDate"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
                Remark = (string)(row["Remark"]),
            };
            return result;
        }
        #endregion

        public RegisterEntity GetRegisterById(string registerid)
        {
            var row = base.FindById(modestring, registerid);
            return RegisterService.DataRowToEntity(row);
        }
        public RegisterCMEntity[] GetRegisterCMList()
        {
            var dt = this.GetList(modestring + "cm");
            return DataTableToEntitys1(dt);
        }
        public RegisterAttachmentEntity[] GetRegisterAttachmentEntitys(string registerid)
        {
            var dt = this.GetRelationData("registerattach", registerid);
            return RegisterAttachmentService.DataTableToBindEntitys(dt);
        }
        public void DeleteRegisters(string[] registerids)
        {
            base.UseTran((tran) =>
            {
                registerids.ToList().ForEach((registerid) =>
                {
                    base.DeleteEntity(modestring, registerid, tran);
                });
            });
        }

        public static DbCommand GetCreateRegisterCommand(Database database, RegisterEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateRegister");
            #region 参数赋值
            database.AddOutParameter(cmd, "RegisterId", DbType.String, 36);
            database.AddInParameter(cmd, "RegisterNo", DbType.String, entity.RegisterNo);
            database.AddInParameter(cmd, "RegisterProductName", DbType.String, entity.RegisterProductName);
            database.AddInParameter(cmd, "StandardCode", DbType.String, entity.StandardCode);
            database.AddInParameter(cmd, "RegisterNo1", DbType.String, entity.RegisterNo1);
            database.AddInParameter(cmd, "RegisterProductName1", DbType.String, entity.RegisterProductName1);
            database.AddInParameter(cmd, "StandardCode1", DbType.String, entity.StandardCode1);
            database.AddInParameter(cmd, "RegisterFile", DbType.String, entity.RegisterFile);
            database.AddInParameter(cmd, "StartDate", DbType.String, entity.StartDate);
            database.AddInParameter(cmd, "EndDate", DbType.String, entity.EndDate);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            #endregion
            return cmd;
        }
        public static DbCommand GetUpdateRegisterCommand(Database database, RegisterEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateRegister");
            #region 参数赋值
            database.AddInParameter(cmd, "RegisterId", DbType.String, entity.RegisterId);
            database.AddInParameter(cmd, "RegisterNo", DbType.String, entity.RegisterNo);
            database.AddInParameter(cmd, "RegisterProductName", DbType.String, entity.RegisterProductName);
            database.AddInParameter(cmd, "StandardCode", DbType.String, entity.StandardCode);
            database.AddInParameter(cmd, "RegisterNo1", DbType.String, entity.RegisterNo1);
            database.AddInParameter(cmd, "RegisterProductName1", DbType.String, entity.RegisterProductName1);
            database.AddInParameter(cmd, "StandardCode1", DbType.String, entity.StandardCode1);
            database.AddInParameter(cmd, "RegisterFile", DbType.String, entity.RegisterFile);
            database.AddInParameter(cmd, "StartDate", DbType.String, entity.StartDate);
            database.AddInParameter(cmd, "EndDate", DbType.String, entity.EndDate);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            #endregion
            return cmd;
        }
        public static DbCommand GetCreateAttachmentCommand(Database database, RegisterAttachmentEntityNewLogic attach)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateRegisterAttachment");
            database.AddOutParameter(cmd, "Id", DbType.String, 36);
            database.AddInParameter(cmd, "RegisterId", DbType.String, attach.RegisterId);
            database.AddInParameter(cmd, "SaveName", DbType.String, attach.SaveName);
            database.AddInParameter(cmd, "ShowName", DbType.String, attach.ShowName);
            return cmd;
        }

        public string CreateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic)
        {
            string registerId = string.Empty;
            #region 使用事务
            base.UseTran((tran) =>
            {
                DbCommand cmd = RegisterService.GetCreateRegisterCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                registerId = (string)base.Database.GetParameterValue(cmd, "RegisterId");

                base.DeleteRelationData("registerattach", registerId, tran);

                registerAttachmentEntityNewLogic.ToList().ForEach((item) =>
                {
                    item.RegisterId = registerId;
                    DbCommand cmd1 = GetCreateAttachmentCommand(this.Database, item);
                    base.Database.ExecuteNonQuery(cmd1, tran);
                    var attachId = base.Database.GetParameterValue(cmd1, "Id").ToString();
                });
            });
            #endregion
            return registerId;
        }
        public void UpdateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateRegisterCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);

                base.DeleteRelationData("registerattach", entity.RegisterId, tran);

                registerAttachmentEntityNewLogic.ToList().ForEach((item) =>
                {
                    #region CreateAttachment
                    DbCommand cmd1 = RegisterService.GetCreateAttachmentCommand(this.Database, item);
                    base.Database.ExecuteNonQuery(cmd1, tran);
                    var attachId = base.Database.GetParameterValue(cmd1, "Id").ToString();
                    #endregion
                });
            });
        }
    }
}
