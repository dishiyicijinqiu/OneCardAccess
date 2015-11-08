using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class CompanyRightTempService
    {
        public static CompanyRightTempEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new CompanyRightTempEntity();
            result.RoleId = (string)row["RoleId"];
            result.CompanyId = (int)row["CompanyId"];
            result.Flag = (string)row["RoleId"];
            return result;
        }
        public static CompanyRightTempEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new CompanyRightTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = CompanyRightTempService.DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static CompanyInfoRightStatusTempEntity DataRowToInfoEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new CompanyInfoRightStatusTempEntity();
            var entity = CompanyRightTempService.DataRowToEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CompanyNo = (string)row["CompanyNo"];
            result.CompanyName = (string)row["CompanyName"];
            result.Status = (bool)row["Status"];
            result.PId = (int)row["PId"];
            result.Level_Path = (string)row["Level_Path"];
            result.Level_Num = (int)row["Level_Num"];
            result.Level_Total = (int)row["Level_Total"];
            result.Level_Deep = (int)row["Level_Deep"];
            result.HasCate = result.Level_Num > 0;
            return result;
        }
        public static CompanyInfoRightStatusTempEntity[] DataTableToInfoEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new CompanyInfoRightStatusTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = CompanyRightTempService.DataRowToInfoEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
