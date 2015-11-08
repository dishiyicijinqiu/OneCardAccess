using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class RoleMenuService
    {
        public static RoleMenuEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RoleMenuEntity();
            result.RoleId = Convert.ToString(row["RoleId"]);
            result.MenuNo = Convert.ToString(row["MenuNo"]);
            return result;
        }
        public static RoleMenuEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RoleMenuEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = RoleMenuService.DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
