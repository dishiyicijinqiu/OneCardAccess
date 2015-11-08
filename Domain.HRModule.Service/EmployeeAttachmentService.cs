using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using System.Data;
namespace FengSharp.OneCardAccess.Domain.HRModule.Service
{
    public class EmployeeAttachmentService
    {
        public static EmployeeAttachmentEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new EmployeeAttachmentEntity();
            result.EmpId = (string)row["EmpId"];
            result.Id = (string)row["Id"];
            result.SaveName = (string)row["SaveName"];
            result.ShowName = (string)row["ShowName"];
            return result;
        }
        public static EmployeeAttachmentEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new EmployeeAttachmentEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
