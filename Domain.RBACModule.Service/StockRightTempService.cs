using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class StockRightTempService
    {
        public static StockRightTempEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new StockRightTempEntity();
            result.RoleId = (string)row["RoleId"];
            result.StockId = (int)row["StockId"];
            result.Flag = (string)row["RoleId"];
            return result;
        }
        public static StockRightTempEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new StockRightTempEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = StockRightTempService.DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static StockInfoRightTempStatusEntity DataRowToInfoEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new StockInfoRightTempStatusEntity();
            var entity = StockRightTempService.DataRowToEntity(row);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.StockNo = (string)row["StockNo"];
            result.StockName = (string)row["StockName"];
            result.Status = (bool)row["Status"];
            return result;
        }
        public static StockInfoRightTempStatusEntity[] DataTableToInfoEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new StockInfoRightTempStatusEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = StockRightTempService.DataRowToInfoEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
