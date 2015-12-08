
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
                case DlyConfig.SPFGDlyTypeId:
                    e.DisplayText = "商品返工单";
                    break;
                case DlyConfig.SPXSDlyTypeId:
                    e.DisplayText = "商品销售单";
                    break;
                case DlyConfig.SPXSTHDlyTypeId:
                    e.DisplayText = "商品销售退货单";
                    break;
                default:
                    break;
            }
        }
    }
}
