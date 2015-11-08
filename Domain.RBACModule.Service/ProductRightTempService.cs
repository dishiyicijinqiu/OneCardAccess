using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class ProductRightTempService
    {
        public static ProductRightTempEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new ProductRightTempEntity();
            result.RoleId = (string)row["RoleId"];
            result.ProductId = (int)row["ProductId"];
            result.Flag = (string)row["RoleId"];
            return result;
        }
        public static ProductRightTempEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ProductRightTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = ProductRightTempService.DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static ProductInfoRightStatusTempEntity DataRowToInfoEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new ProductInfoRightStatusTempEntity();
            var entity = ProductRightTempService.DataRowToEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.ProductNo = (string)row["ProductNo"];
            result.ProductName = (string)row["ProductName"];
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
        public static ProductInfoRightStatusTempEntity[] DataTableToInfoEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ProductInfoRightStatusTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = ProductRightTempService.DataRowToInfoEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
