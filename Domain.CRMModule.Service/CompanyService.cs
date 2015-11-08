using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FengSharp.OneCardAccess.Domain.CRMModule.Service
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        const string modestring = "company";
        public CompanyEntity GetCompanyById(int companyid)
        {
            var row = this.FindById(modestring, companyid);
            return CompanyService.DataRowToEntity(row);
        }

        public int CreateCompany(CompanyEntity entity)
        {
            int entityid = 0;
            base.UseTran((tran) =>
            {
                var cmd = GetCreateCompanyCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
                entityid = (int)base.Database.GetParameterValue(cmd, "CompanyId");
            });
            return entityid;
        }

        public void UpdateCompany(CompanyEntity entity)
        {
            base.UseTran((tran) =>
            {
                var cmd = GetUpdateProductCommand(this.Database, entity);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void DeleteCompanys(int[] companyids)
        {
            base.UseTran((tran) =>
            {
                companyids.ToList().ForEach((companyid) =>
                {
                    base.DeleteEntity(modestring, companyid, tran);
                });
            });
        }

        public CompanyCMCateEntity[] GetCompanyCMCateTree(int pid)
        {
            var dt = base.GetTree(modestring + "cm", pid);
            return CompanyService.DataTableToEntitys2(dt);
        }

        public static DbCommand GetCreateCompanyCommand(Database database, CompanyEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_CreateCompany");
            #region 参数赋值
            database.AddOutParameter(cmd, "CompanyId", DbType.Int32, 4);
            database.AddInParameter(cmd, "CompanyNo", DbType.String, entity.CompanyNo);
            database.AddInParameter(cmd, "CompanyName", DbType.String, entity.CompanyName);
            database.AddInParameter(cmd, "Address", DbType.String, entity.Address);
            database.AddInParameter(cmd, "Tel", DbType.String, entity.Tel);
            database.AddInParameter(cmd, "Fax", DbType.String, entity.Fax);
            database.AddInParameter(cmd, "PostCode", DbType.String, entity.PostCode);
            database.AddInParameter(cmd, "EMail", DbType.String, entity.EMail);
            database.AddInParameter(cmd, "Person", DbType.String, entity.Person);
            database.AddInParameter(cmd, "BankAndAcount", DbType.String, entity.BankAndAcount);
            database.AddInParameter(cmd, "TaxNumber", DbType.String, entity.TaxNumber);
            database.AddInParameter(cmd, "ARTotal", DbType.Decimal, entity.ARTotal);
            database.AddInParameter(cmd, "APTotal", DbType.Decimal, entity.APTotal);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "Password", DbType.String, entity.Password);
            database.AddInParameter(cmd, "PId", DbType.Int32, entity.PId);
            database.AddInParameter(cmd, "CreateId", DbType.String, entity.CreateId);
            #endregion
            return cmd;
        }

        public static DbCommand GetUpdateProductCommand(Database database, CompanyEntity entity)
        {
            DbCommand cmd = database.GetStoredProcCommand("P_UpdateCompany");
            #region 参数赋值
            database.AddInParameter(cmd, "CompanyId", DbType.Int32, entity.CompanyId);
            database.AddInParameter(cmd, "CompanyNo", DbType.String, entity.CompanyNo);
            database.AddInParameter(cmd, "CompanyName", DbType.String, entity.CompanyName);
            database.AddInParameter(cmd, "Address", DbType.String, entity.Address);
            database.AddInParameter(cmd, "Tel", DbType.String, entity.Tel);
            database.AddInParameter(cmd, "Fax", DbType.String, entity.Fax);
            database.AddInParameter(cmd, "PostCode", DbType.String, entity.PostCode);
            database.AddInParameter(cmd, "EMail", DbType.String, entity.EMail);
            database.AddInParameter(cmd, "Person", DbType.String, entity.Person);
            database.AddInParameter(cmd, "BankAndAcount", DbType.String, entity.BankAndAcount);
            database.AddInParameter(cmd, "TaxNumber", DbType.String, entity.TaxNumber);
            database.AddInParameter(cmd, "ARTotal", DbType.Decimal, entity.ARTotal);
            database.AddInParameter(cmd, "APTotal", DbType.Decimal, entity.APTotal);
            database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
            database.AddInParameter(cmd, "Password", DbType.String, entity.Password);
            database.AddInParameter(cmd, "Enable", DbType.Boolean, entity.Enable);
            database.AddInParameter(cmd, "LastModifyId", DbType.String, entity.LastModifyId);
            #endregion
            return cmd;
        }
        #region 实体转换

        private static CompanyCMCateEntity[] DataTableToEntitys2(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new CompanyCMCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = CompanyService.DataRowToEntity2(dt.Rows[i]);
            }
            return results;
        }
        private static CompanyCMCateEntity DataRowToEntity2(DataRow row)
        {
            if (row == null)
                return null;
            var result = new CompanyCMCateEntity();
            var entity = DataRowToEntity1(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.HasCate = result.Level_Num > 0;
            return result;
        }
        private static CompanyCMEntity[] DataTableToEntitys1(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new CompanyCMEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = CompanyService.DataRowToEntity1(dt.Rows[i]);
            }
            return results;
        }
        private static CompanyEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new CompanyEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = CompanyService.DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }
        private static CompanyCMEntity DataRowToEntity1(DataRow row)
        {
            if (row == null)
                return null;
            var result = new CompanyCMEntity();
            var entity = DataRowToEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = row["CreateName"].ToString();
            result.LastModifyName = row["LastModifyName"].ToString();
            return result;
        }
        private static CompanyEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new CompanyEntity()
            {
                CompanyId = (int)(row["CompanyId"]),
                CompanyNo = (string)(row["CompanyNo"]),
                CompanyName = (string)(row["CompanyName"]),
                Address = (string)(row["Address"]),
                Tel = (string)(row["Tel"]),
                Fax = (string)(row["Fax"]),
                PostCode = (string)(row["PostCode"]),
                EMail = (string)(row["EMail"]),
                Person = (string)(row["Person"]),
                BankAndAcount = (string)(row["BankAndAcount"]),
                TaxNumber = (string)(row["TaxNumber"]),
                ARTotal = (decimal)(row["ARTotal"]),
                APTotal = (decimal)(row["APTotal"]),
                Remark = (string)(row["Remark"]),
                CreateId = (string)(row["CreateId"]),
                CreateDate = (DateTime)(row["CreateDate"]),
                LastModifyId = (string)(row["LastModifyId"]),
                LastModifyDate = (DateTime)(row["LastModifyDate"]),
                Password = (string)(row["Password"]),
                Enable = (bool)(row["Enable"]),
                PId = (int)(row["PId"]),
                Level_Path = (string)(row["Level_Path"]),
                Level_Num = (int)(row["Level_Num"]),
                Level_Total = (int)(row["Level_Total"]),
                Level_Deep = (int)(row["Level_Deep"]),
            };
            return result;
        }
        #endregion
    }
}
