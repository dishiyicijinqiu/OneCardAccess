
using DevExpress.XtraGrid.Views.Base;
using FengSharp.OneCardAccess.Application.Config;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class DlyFormat
    {
        public static void ColumnDisplayTextForDlyTypeId(CustomColumnDisplayTextEventArgs e)
        {
            int dlytypeid = (int)e.Value;
            switch (dlytypeid)
            {
                case DlyConfig.SPRKDlyTypeId:
                    e.DisplayText = "商品入库单";
                    break;
                default:
                    break;
            }
        }
    }
}
