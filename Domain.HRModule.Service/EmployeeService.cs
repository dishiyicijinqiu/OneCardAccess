using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace FengSharp.OneCardAccess.Domain.HRModule.Service
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        const string modestring = "employee";
        public static EmployeeCMDeptEntity[] DataTableToEntitys2(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new EmployeeCMDeptEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = EmployeeService.DataRowToEntity2(dt.Rows[i]);
            }
            return results;
        }
        public static EmployeeCMDeptEntity DataRowToEntity2(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new EmployeeCMDeptEntity();
            var entity = DataRowToEntity1(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.DeptNo = dataRow["DeptNo"].ToString();
            result.DeptName = dataRow["DeptName"].ToString();
            return result;
        }
        public static EmployeeCMEntity DataRowToEntity1(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new EmployeeCMEntity();
            var entity = EmployeeService.DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = dataRow["CreateName"].ToString();
            result.LastModifyName = dataRow["LastModifyName"].ToString();
            return result;
        }
        public static EmployeeEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new EmployeeEntity()
            {
                EmpId = (string)(row["EmpId"]),
                EmpNo = (string)(row["EmpNo"]),
                EmpName = (string)(row["EmpName"]),
                DeptId = (int)(row["DeptId"]),
                Sex = (string)(row["Sex"]),
                Nation = (string)(row["Nation"]),
                Birthday = (string)(row["Birthday"]),
                Address = (string)(row["Address"]),
                TelPhone = (string)(row["TelPhone"]),
                Mobile = (string)(row["Mobile"]),
                Origin = (string)(row["Origin"]),
                Title = (string)(row["Title"]),
                Duty = (string)(row["Duty"]),
                Post = (string)(row["Post"]),
                EmpStatus = (short)(row["EmpStatus"]),
                WedStatus = (string)(row["WedStatus"]),
                AttCardNo = (string)(row["AttCardNo"]),
                GenCardNo = (string)(row["GenCardNo"]),
                IdCardNo = (string)(row["IdCardNo"]),
                Photo = (string)(row["Photo"]),
                Specialty = (string)(row["Specialty"]),
                Diploma = (string)(row["Diploma"]),
                GraduateSchool = (string)(row["GraduateSchool"]),
                PoliticalStatus = (string)(row["PoliticalStatus"]),
                JoinDate = (string)(row["JoinDate"]),
                TrialStartDate = (string)(row["TrialStartDate"]),
                TrialEndDate = (string)(row["TrialEndDate"]),
                PositiveDate = (string)(row["PositiveDate"]),
                ContractStartDate = (string)(row["ContractStartDate"]),
                ContractEndDate = (string)(row["ContractEndDate"]),
                HolidaySMS = (bool)(row["HolidaySMS"]),
                BirthdaySMS = (bool)(row["BirthdaySMS"]),
                Att = (bool)(row["Att"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
                Remark = (string)(row["Remark"]),
                Remark1 = (string)(row["Remark1"]),
                Remark2 = (string)(row["Remark2"]),

            };
            return result;
        }
        public static DbCommand GetCreateEmployeeCommand(Database database, EmployeeEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateEmployee");
            #region 参数赋值
            database.AddOutParameter(cmd, "EmpId", DbType.String, 36);
            database.AddInParameter(cmd, "EmpNo", DbType.String, entity.EmpNo);
            database.AddInParameter(cmd, "EmpName", DbType.String, entity.EmpName);
            database.AddInParameter(cmd, "DeptId", DbType.Int32, entity.DeptId);
            database.AddInParameter(cmd, "Sex", DbType.String, entity.Sex);
            database.AddInParameter(cmd, "Nation", DbType.String, entity.Nation);
            database.AddInParameter(cmd, "Birthday", DbType.String, entity.Birthday);
            database.AddInParameter(cmd, "Address", DbType.String, entity.Address);
            database.AddInParameter(cmd, "TelPhone", DbType.String, entity.TelPhone);
            database.AddInParameter(cmd, "Mobile", DbType.String, entity.Mobile);
            database.AddInParameter(cmd, "Origin", DbType.String, entity.Origin);
            database.AddInParameter(cmd, "Title", DbType.String, entity.Title);
            database.AddInParameter(cmd, "Duty", DbType.String, entity.Duty);
            database.AddInParameter(cmd, "Post", DbType.String, entity.Post);
            database.AddInParameter(cmd, "EmpStatus", DbType.Int16, entity.EmpStatus);
            database.AddInParameter(cmd, "WedStatus", DbType.String, entity.WedStatus);
            database.AddInParameter(cmd, "AttCardNo", DbType.String, entity.AttCardNo);
            database.AddInParameter(cmd, "GenCardNo", DbType.String, entity.GenCardNo);
            database.AddInParameter(cmd, "IdCardNo", DbType.String, entity.IdCardNo);
            database.AddInParameter(cmd, "Photo", DbType.String, entity.Photo);
            database.AddInParameter(cmd, "Specialty", DbType.String, entity.Specialty);
            database.AddInParameter(cmd, "Diploma", DbType.String, entity.Diploma);
            database.AddInParameter(cmd, "GraduateSchool", DbType.String, entity.GraduateSchool);
            database.AddInParameter(cmd, "PoliticalStatus", DbType.String, entity.PoliticalStatus);
            database.AddInParameter(cmd, "JoinDate", DbType.String, entity.JoinDate);
            database.AddInParameter(cmd, "TrialStartDate", DbType.String, entity.TrialStartDate);
            database.AddInParameter(cmd, "TrialEndDate", DbType.String, entity.TrialEndDate);
            database.AddInParameter(cmd, "PositiveDate", DbType.String, entity.PositiveDate);
            database.AddInParameter(cmd, "ContractStartDate", DbType.String, entity.ContractStartDate);
            database.AddInParameter(cmd, "ContractEndDate", DbType.String, entity.ContractEndDate);
            database.AddInParameter(cmd, "HolidaySMS", DbType.Boolean, entity.HolidaySMS);
            database.AddInParameter(cmd, "BirthdaySMS", DbType.Boolean, entity.BirthdaySMS);
            database.AddInParameter(cmd, "Att", DbType.Boolean, entity.Att);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            #endregion
            return cmd;
        }
        public static DbCommand GetUpdateEmployeeCommand(Database database, EmployeeEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateEmployee");
            #region 参数赋值
            database.AddInParameter(cmd, "EmpId", DbType.String, entity.EmpId);
            database.AddInParameter(cmd, "EmpNo", DbType.String, entity.EmpNo);
            database.AddInParameter(cmd, "EmpName", DbType.String, entity.EmpName);
            database.AddInParameter(cmd, "DeptId", DbType.Int32, entity.DeptId);
            database.AddInParameter(cmd, "Sex", DbType.String, entity.Sex);
            database.AddInParameter(cmd, "Nation", DbType.String, entity.Nation);
            database.AddInParameter(cmd, "Birthday", DbType.String, entity.Birthday);
            database.AddInParameter(cmd, "Address", DbType.String, entity.Address);
            database.AddInParameter(cmd, "TelPhone", DbType.String, entity.TelPhone);
            database.AddInParameter(cmd, "Mobile", DbType.String, entity.Mobile);
            database.AddInParameter(cmd, "Origin", DbType.String, entity.Origin);
            database.AddInParameter(cmd, "Title", DbType.String, entity.Title);
            database.AddInParameter(cmd, "Duty", DbType.String, entity.Duty);
            database.AddInParameter(cmd, "Post", DbType.String, entity.Post);
            database.AddInParameter(cmd, "EmpStatus", DbType.Int16, entity.EmpStatus);
            database.AddInParameter(cmd, "WedStatus", DbType.String, entity.WedStatus);
            database.AddInParameter(cmd, "AttCardNo", DbType.String, entity.AttCardNo);
            database.AddInParameter(cmd, "GenCardNo", DbType.String, entity.GenCardNo);
            database.AddInParameter(cmd, "IdCardNo", DbType.String, entity.IdCardNo);
            database.AddInParameter(cmd, "Photo", DbType.String, entity.Photo);
            database.AddInParameter(cmd, "Specialty", DbType.String, entity.Specialty);
            database.AddInParameter(cmd, "Diploma", DbType.String, entity.Diploma);
            database.AddInParameter(cmd, "GraduateSchool", DbType.String, entity.GraduateSchool);
            database.AddInParameter(cmd, "PoliticalStatus", DbType.String, entity.PoliticalStatus);
            database.AddInParameter(cmd, "JoinDate", DbType.String, entity.JoinDate);
            database.AddInParameter(cmd, "TrialStartDate", DbType.String, entity.TrialStartDate);
            database.AddInParameter(cmd, "TrialEndDate", DbType.String, entity.TrialEndDate);
            database.AddInParameter(cmd, "PositiveDate", DbType.String, entity.PositiveDate);
            database.AddInParameter(cmd, "ContractStartDate", DbType.String, entity.ContractStartDate);
            database.AddInParameter(cmd, "ContractEndDate", DbType.String, entity.ContractEndDate);
            database.AddInParameter(cmd, "HolidaySMS", DbType.Boolean, entity.HolidaySMS);
            database.AddInParameter(cmd, "BirthdaySMS", DbType.Boolean, entity.BirthdaySMS);
            database.AddInParameter(cmd, "Att", DbType.Boolean, entity.Att);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "Remark1", DbType.String, entity.Remark1);
            database.AddInParameter(cmd, "Remark2", DbType.String, entity.Remark2);
            #endregion
            return cmd;
        }
        public static DbCommand GetCreateAttachmentCommand(Database database, EmployeeAttachmentEntityNewLogic attach)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateEmployeeAttachment");
            database.AddOutParameter(cmd, "Id", DbType.String, 36);
            database.AddInParameter(cmd, "EmpId", DbType.String, attach.EmpId);
            database.AddInParameter(cmd, "SaveName", DbType.String, attach.SaveName);
            database.AddInParameter(cmd, "ShowName", DbType.String, attach.ShowName);
            return cmd;
        }
        public EmployeeAttachmentEntity[] GetEmployeeAttachmentEntitys(string empid)
        {
            var dt = this.GetRelationData("employeeattach", empid);
            return EmployeeAttachmentService.DataTableToBindEntitys(dt);
        }
        public EmployeeEntity FindEmployeeById(string empid)
        {
            var row = this.FindById(modestring, empid);
            return DataRowToEntity(row);
        }
        public EmployeeCMDeptEntity[] GetAllCMDeptEmployee()
        {
            var dt = this.GetList(modestring + "cmdept");
            return EmployeeService.DataTableToEntitys2(dt);
        }
        public void DeleteDeployees(string[] empids)
        {
            base.UseTran((tran) =>
            {
                empids.ToList().ForEach((EntityId) =>
                {
                    base.DeleteEntity(modestring, EntityId, tran);
                });
            });
        }
        public string CreateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogics)
        {
            string empid = string.Empty;
            base.UseTran((tran) =>
            {
                var cmd = GetCreateEmployeeCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                empid = base.Database.GetParameterValue(cmd, "EmpId").ToString();
                base.DeleteRelationData("employeeattachment", empid, tran);
                employeeAttachmentEntityNewLogics.ToList().ForEach((attach) =>
                {
                    var cmd1 = GetCreateAttachmentCommand(this.Database, attach);
                    base.Database.ExecuteNonQuery(cmd1, tran);
                    var attachId = base.Database.GetParameterValue(cmd1, "Id").ToString();
                });
            });
            return empid;
        }
        public void UpdateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogics)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateEmployeeCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                base.DeleteRelationData("employeeattachment", entity.EmpId, tran);
                employeeAttachmentEntityNewLogics.ToList().ForEach((attach) =>
                {
                    var cmd1 = GetCreateAttachmentCommand(this.Database, attach);
                    base.Database.ExecuteNonQuery(cmd1, tran);
                    var attachId = base.Database.GetParameterValue(cmd1, "Id").ToString();
                });
            });
        }
    }
}
