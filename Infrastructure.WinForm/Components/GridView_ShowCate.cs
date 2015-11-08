using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{

    [ToolboxItem(true)]
    [Description("显示行号")]
    [ProvideProperty("ShowCate", typeof(GridView))]
    [ProvideProperty("CateString", typeof(GridView))]
    [ProvideProperty("CateField", typeof(GridView))]
    [ProvideProperty("FormatString", typeof(GridView))]
    public partial class GridView_ShowCate : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<GridView, GridView_ShowCatePara> StyleList = null;
        #endregion
        public GridView_ShowCate()
        {
            InitializeComponent();
            StyleList = new Dictionary<GridView, GridView_ShowCatePara>();
        }

        public GridView_ShowCate(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            StyleList = new Dictionary<GridView, GridView_ShowCatePara>();
        }

        #region 格式化字符串
        [Category("扩展")]
        [Description("格式化字符串"), DefaultValue("{line}{cate}")]
        public string GetFormatString(GridView gv)
        {
            if (StyleList.ContainsKey(gv))
            {
                return StyleList[gv].FormatString;
            }
            return "{line}{cate}";
        }
        public void SetFormatString(GridView gv, string formatString)
        {
            if (!StyleList.ContainsKey(gv))
            {
                StyleList.Add(gv, new GridView_ShowCatePara()
                {
                    FormatString = formatString
                });
            }
            else
            {
                StyleList[gv].FormatString = formatString;
            }
        }
        #endregion

        #region 分类字符串
        [Category("扩展")]
        [Description("分类字符串"), DefaultValue("..")]
        public string GetCateString(GridView gv)
        {
            if (StyleList.ContainsKey(gv))
            {
                return StyleList[gv].CateString;
            }
            return "..";
        }
        public void SetCateString(GridView gv, string cateString)
        {
            if (!StyleList.ContainsKey(gv))
            {
                StyleList.Add(gv, new GridView_ShowCatePara()
                {
                    CateString = cateString
                });
            }
            else
            {
                StyleList[gv].CateString = cateString;
            }
        }
        #endregion

        #region 分类字段名称
        [Category("扩展")]
        [Description("分类字段名称"), DefaultValue("HasCate")]
        public string GetCateField(GridView gv)
        {
            if (StyleList.ContainsKey(gv))
            {
                return StyleList[gv].CateField;
            }
            return "HasCate";
        }
        public void SetCateField(GridView gv, string catefield)
        {
            if (!StyleList.ContainsKey(gv))
            {
                StyleList.Add(gv, new GridView_ShowCatePara()
                {
                    CateField = catefield
                });
            }
            else
            {
                StyleList[gv].CateField = catefield;
            }
        }
        #endregion

        #region 是否显示分类
        [Category("扩展")]
        [Description("是否显示分类"), DefaultValue(false)]
        public bool GetShowCate(GridView dgv)
        {
            if (StyleList.ContainsKey(dgv))
            {
                return StyleList[dgv].EnableShowCate;
            }
            return true;
        }
        public void SetShowCate(GridView dgv, bool enableshowcate)
        {
            if (!StyleList.ContainsKey(dgv))
            {
                StyleList.Add(dgv, new GridView_ShowCatePara()
                {
                    EnableShowCate = enableshowcate
                });
            }
            else
            {
                StyleList[dgv].EnableShowCate = enableshowcate;
            }
            dgv.CustomDrawRowIndicator -= gridView1_CustomDrawRowIndicator;
            if (enableshowcate)
                dgv.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (this.DesignMode)
                return;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                var gv = sender as GridView;
                var para = StyleList[gv];
                if (para.EnableShowCate)
                {
                    bool hasCate = (bool)gv.GetRowCellValue(e.RowHandle, para.CateField);
                    if (hasCate)
                        e.Info.DisplayText = string.Format(para.FormatString.Replace("{line}", "{0}").Replace("{cate}", "{1}"), e.RowHandle + 1, StyleList[gv].CateString);
                    else
                        e.Info.DisplayText = string.Format(para.FormatString.Replace("{line}", "{0}").Replace("{cate}", "{1}"), e.RowHandle + 1, string.Empty);
                }
            }
        }
        #endregion

        public bool CanExtend(object extendee)
        {
            return (extendee is GridView);
        }
    }
    internal class GridView_ShowCatePara
    {

        private string formatString = "{line}{cate}";
        public string FormatString
        {
            get
            {
                return formatString;
            }
            set
            {
                formatString = value;
            }
        }

        private string cateString = "..";
        public string CateString
        {
            get
            {
                return cateString;
            }
            set
            {
                cateString = value;
            }
        }

        private bool enableshowcate = true;
        public bool EnableShowCate
        {
            get
            {
                return enableshowcate;
            }
            set
            {
                enableshowcate = value;
            }
        }

        private string catefield = "HasCate";
        public string CateField
        {
            get
            {
                return catefield;
            }
            set
            {
                catefield = value;
            }
        }
    }
}
