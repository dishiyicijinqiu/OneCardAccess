using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services.Interface;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace FengSharp.OneCardAccess.Infrastructure.Services
{
    public class DicDataService : ServiceBase, IDicDataService
    {
        public DicDataEntity[] GetDataByDicTypes(string[] dictypes)
        {
            if (dictypes == null)
                throw new BusinessException("字典类型不可为空");
            for (int i = 0; i < dictypes.Length; i++)
            {
                string item = dictypes[i];
                if (string.IsNullOrEmpty(item))
                    throw new BusinessException("字典类型不可为空");
                if (IsSafeSqlString(item))
                    throw new BusinessException("字典类型有非法字符串");
                dictypes[i] = string.Format("'{0}'", item);
            }
            string para = string.Join(",", dictypes);
            DbCommand cmd = Database.GetStoredProcCommand("P_GetDicDataByDicTypes");
            Database.AddInParameter(cmd, "DicTypes", DbType.String, para);
            var dt = Database.ExecuteDataTable(cmd);
            return DataTableToEntitys(dt);
        }
        public static bool IsSafeSqlString(string str)
        {
            return Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        public static DicDataEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DicDataEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static DicDataEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new DicDataEntity()
            {
                DicType = (string)row["DicType"],
                DicValue = (string)row["DicValue"]
            };
            return result;
        }
    }
}
