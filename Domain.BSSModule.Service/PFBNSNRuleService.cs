using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class PFBNSNRuleService : ServiceBase, IPFBNSNRuleService
    {
        const string modestring = "fbnsnrule";
        public PFBNSNRuleEntity[] GetPFBNSNRules()
        {
            var dt = this.GetList(modestring);
            return DataTableToEntitys(dt);
        }

        public static PFBNSNRuleEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new PFBNSNRuleEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static PFBNSNRuleEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new PFBNSNRuleEntity()
            {
                BNEndPos = (int)(row["BNEndPos"]),
                BNStartPos = (int)(row["BNStartPos"]),
                TotalLen = (int)(row["TotalLen"]),
                IsSNOrFBN = (bool)(row["IsSNOrFBN"]),
            };
            return result;
        }
    }
}
