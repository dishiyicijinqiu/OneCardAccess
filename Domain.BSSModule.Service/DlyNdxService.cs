using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Data;
using System.Data.Common;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class DlyNdxService : ServiceBase, IDlyNdxService
    {
        public string GetNewDlyNo(int DlyTypeId)
        {
            var nowtime = DateTime.Now;
            int nowmonth = nowtime.Year * 12 + nowtime.Month;
            DbCommand cmd = Database.GetStoredProcCommand("P_GetNewDlyNo");
            Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
            Database.AddInParameter(cmd, "NowMonth", DbType.Int32, nowmonth);
            Database.AddOutParameter(cmd, "DlyFormat", DbType.String, 66);
            Database.AddOutParameter(cmd, "MaxNo", DbType.Int32, 4);
            base.UseTran((tran) =>
            {
                Database.ExecuteNonQuery(cmd, tran);
            });
            string strDlyFormat = Database.GetParameterValue(cmd, "DlyFormat").ToString();
            int maxno = Convert.ToInt32(Database.GetParameterValue(cmd, "MaxNo"));
            return string.Format(nowtime.ToString(strDlyFormat), maxno);
        }

        public string GetDlyDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
