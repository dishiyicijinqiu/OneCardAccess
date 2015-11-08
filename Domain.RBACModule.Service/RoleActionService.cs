using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class RoleActionService
    {
        public static RoleActionEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RoleActionEntity();
            result.RoleId = Convert.ToString(row["RoleId"]);
            result.ActionNo = Convert.ToString(row["ActionNo"]);
            return result;
        }
        public static RoleActionEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RoleActionEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = RoleActionService.DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
