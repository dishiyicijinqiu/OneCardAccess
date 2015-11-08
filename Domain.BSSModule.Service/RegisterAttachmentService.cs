using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.Data;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class RegisterAttachmentService
    {
        public static RegisterAttachmentEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new RegisterAttachmentEntity();
            result.RegisterId = (string)row["RegisterId"];
            result.Id = (string)row["Id"];
            result.SaveName = (string)row["SaveName"];
            result.ShowName = (string)row["ShowName"];
            return result;
        }
        public static RegisterAttachmentEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new RegisterAttachmentEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
    }
}
