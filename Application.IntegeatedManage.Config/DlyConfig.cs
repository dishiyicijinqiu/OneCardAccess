namespace FengSharp.OneCardAccess.Application.Config
{
    public class DlyConfig
    {
        #region 单据类型Id
        /// <summary>
        /// 商品入库单DlyTypeId
        /// </summary>
        public static readonly int SPRKDlyTypeId = 2;
        #endregion
        #region 资产类型Id
        /// <summary>
        /// 库存商品AtypeId
        /// </summary>
        public static readonly int KCSPATypeId = 1101;
        /// <summary>
        /// 商品现    金AtypeId
        /// </summary>
        public static readonly int SPXJATypeId = 1102;
        /// <summary>
        /// 商品银行AtypeId
        /// </summary>
        public static readonly int SPBANKATypeId = 1103;
        /// <summary>
        /// 商品应收款合计AtypeId
        /// </summary>
        public static readonly int SPYSKHJATypeId = 1104;
        /// <summary>
        /// 库存五金AtypeId
        /// </summary>
        public static readonly int KCWJATypeId = 1201;
        /// <summary>
        /// 五金现    金AtypeId
        /// </summary>
        public static readonly int WJXJATypeId = 1202;
        /// <summary>
        /// 五金银行AtypeId
        /// </summary>
        public static readonly int WJBANKATypeId = 1203;
        /// <summary>
        /// 五金应收款合计AtypeId
        /// </summary>
        public static readonly int WJYSKHJATypeId = 1204;
        /// <summary>
        /// 库存原材料AtypeId
        /// </summary>
        public static readonly int KCYCLATypeId = 1301;
        /// <summary>
        /// 原材料现    金AtypeId
        /// </summary>
        public static readonly int YCLXJATypeId = 1302;
        /// <summary>
        /// 原材料银行AtypeId
        /// </summary>
        public static readonly int YCLBANKATypeId = 1303;
        /// <summary>
        /// 原材料应收款合计AtypeId
        /// </summary>
        public static readonly int YCLYSKHJATypeId = 1304;
        /// <summary>
        /// 商品应付款合计AtypeId
        /// </summary>
        public static readonly int SPYFKHJATypeId = 2101;
        /// <summary>
        /// 五金应付款合计AtypeId
        /// </summary>
        public static readonly int WJYFKHJATypeId = 2201;
        /// <summary>
        /// 原材料应付款合计AtypeId
        /// </summary>
        public static readonly int YCLYFKHJATypeId = 2301;
        /// <summary>
        /// 商品销售收入AtypeId
        /// </summary>
        public static readonly int SPXSSRATypeId = 3101;
        /// <summary>
        /// 商品报溢收入AtypeId
        /// </summary>
        public static readonly int SPBYSRATypeId = 3103;
        /// <summary>
        /// 商品调帐收入AtypeId
        /// </summary>
        public static readonly int SPTZSRATypeId = 3152;
        /// <summary>
        /// 商品利息收入AtypeId
        /// </summary>
        public static readonly int SPLXSRATypeId = 3153;
        /// <summary>
        /// 商品其它AtypeId
        /// </summary>
        public static readonly int SPQTATypeId = 3154;
        /// <summary>
        /// 五金销售收入AtypeId
        /// </summary>
        public static readonly int WJXSSRATypeId = 3201;
        /// <summary>
        /// 五金报溢收入AtypeId
        /// </summary>
        public static readonly int WJBYSRATypeId = 3203;
        /// <summary>
        /// 五金调帐收入AtypeId
        /// </summary>
        public static readonly int WJTZSRATypeId = 3252;
        /// <summary>
        /// 五金利息收入AtypeId
        /// </summary>
        public static readonly int WJLXSRATypeId = 3253;
        /// <summary>
        /// 五金其它AtypeId
        /// </summary>
        public static readonly int WJQTATypeId = 3254;
        /// <summary>
        /// 原材料销售收入AtypeId
        /// </summary>
        public static readonly int YCLXSSRATypeId = 3301;
        /// <summary>
        /// 原材料报溢收入AtypeId
        /// </summary>
        public static readonly int YCLBYSRATypeId = 3303;
        /// <summary>
        /// 原材料调帐收入AtypeId
        /// </summary>
        public static readonly int YCLTZSRATypeId = 3352;
        /// <summary>
        /// 原材料利息收入AtypeId
        /// </summary>
        public static readonly int YCLLXSRATypeId = 3353;
        /// <summary>
        /// 原材料其它AtypeId
        /// </summary>
        public static readonly int YCLQTATypeId = 3354;
        /// <summary>
        /// 商品销售成本AtypeId
        /// </summary>
        public static readonly int SPXSCBATypeId = 4101;
        /// <summary>
        /// 商品报损AtypeId
        /// </summary>
        public static readonly int SPBSATypeId = 4103;
        /// <summary>
        /// 商品调账亏损AtypeId
        /// </summary>
        public static readonly int SPTZKSATypeId = 4152;
        /// <summary>
        /// 商品优惠AtypeId
        /// </summary>
        public static readonly int SPYHATypeId = 4153;
        /// <summary>
        /// 五金销售成本AtypeId
        /// </summary>
        public static readonly int WJXSCBATypeId = 4201;
        /// <summary>
        /// 五金报损AtypeId
        /// </summary>
        public static readonly int WJBSATypeId = 4203;
        /// <summary>
        /// 五金调账亏损AtypeId
        /// </summary>
        public static readonly int WJTZKSATypeId = 4252;
        /// <summary>
        /// 五金优惠AtypeId
        /// </summary>
        public static readonly int WJYHATypeId = 4253;
        /// <summary>
        /// 原材料销售成本AtypeId
        /// </summary>
        public static readonly int YCLXSCBATypeId = 4301;
        /// <summary>
        /// 原材料报损AtypeId
        /// </summary>
        public static readonly int YCLBSATypeId = 4303;
        /// <summary>
        /// 原材料调账亏损AtypeId
        /// </summary>
        public static readonly int YCLTZKSATypeId = 4352;
        /// <summary>
        /// 原材料优惠AtypeId
        /// </summary>
        public static readonly int YCLYHATypeId = 4353;
        /// <summary>
        /// 商品期初资本AtypeId
        /// </summary>
        public static readonly int SPQCZBATypeId = 5101;
        /// <summary>
        /// 五金期初资本AtypeId
        /// </summary>
        public static readonly int WJQCZBATypeId = 5201;
        /// <summary>
        /// 原材料期初资本AtypeId
        /// </summary>
        public static readonly int YCLQCZBATypeId = 5301;
        /// <summary>
        /// 商品利润AtypeId
        /// </summary>
        public static readonly int SPLRATypeId = 6101;
        /// <summary>
        /// 五金利润AtypeId
        /// </summary>
        public static readonly int WJLRATypeId = 6201;
        /// <summary>
        /// 原材料利润AtypeId
        /// </summary>
        public static readonly int YCLLRATypeId = 6301;
        #endregion
    }
}
