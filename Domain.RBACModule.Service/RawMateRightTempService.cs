using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class RawMateRightTempService
    {
        public static RawMateRightTempEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RawMateRightTempEntity();
            result.RoleId = (string)row["RoleId"];
            result.RawMateId = (int)row["RawMateId"];
            result.Flag = (string)row["RoleId"];
            return result;
        }
        public static RawMateRightTempEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RawMateRightTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = RawMateRightTempService.DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static RawMateInfoRightStatusTempEntity DataRowToInfoEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RawMateInfoRightStatusTempEntity();
            var entity = RawMateRightTempService.DataRowToEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.RawMateNo = (string)row["RawMateNo"];
            result.RawMateName = (string)row["RawMateName"];
            result.Spec = (string)row["Spec"];
            result.Status = (bool)row["Status"];
            result.PId = (int)row["PId"];
            result.Level_Path = (string)row["Level_Path"];
            result.Level_Num = (int)row["Level_Num"];
            result.Level_Total = (int)row["Level_Total"];
            result.Level_Deep = (int)row["Level_Deep"];
            result.HasCate = result.Level_Num > 0;
            return result;
        }
        public static RawMateInfoRightStatusTempEntity[] DataTableToInfoEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RawMateInfoRightStatusTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = RawMateRightTempService.DataRowToInfoEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
