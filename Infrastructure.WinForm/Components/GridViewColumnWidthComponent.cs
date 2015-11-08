using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("根据ColumnWidth配置列宽")]
    [ProvideProperty("EnableColumnWidth", typeof(GridView))]
    public partial class GridViewColumnWidthComponent : Component, IExtenderProvider
    {
        Dictionary<GridView, GridViewColumnWidthPara> list;
        #region ctor
        public GridViewColumnWidthComponent()
        {
            InitializeComponent();
            list = new Dictionary<GridView, GridViewColumnWidthPara>();
        }

        public GridViewColumnWidthComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<GridView, GridViewColumnWidthPara>();
        }
        #endregion
        #region IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return extendee is GridView;
        }
        #endregion
        [Category("GridView列宽配置")]
        [Description("是否根据ColumnWidth配置列宽")]
        public bool GetEnableColumnWidth(GridView gv)
        {
            if (list.ContainsKey(gv))
            {
                return list[gv].EnableColumnWidth;
            }
            return true;
        }
        public void SetEnableColumnWidth(GridView gv, bool enablecolumnwidth)
        {
            if (!list.ContainsKey(gv))
            {
                var para = GetDefaultPara();
                list.Add(gv, para);
            }
            list[gv].EnableColumnWidth = enablecolumnwidth;
            this.DoProvideProperty(gv);
        }

        private void DoProvideProperty(GridView gv)
        {
            var para = list[gv];
            if (para == null)
            {
                return;
            }
            if (para.EnableColumnWidth)
            {
                gv.DataSourceChanged -= Gv_DataSourceChanged;
                gv.DataSourceChanged += Gv_DataSourceChanged;
            }
        }

        private void Gv_DataSourceChanged(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;
            object data = gv.DataSource;
            if (data == null)
                throw new Exception("数据源为空");
            if (data is BindingSource)
                data = (data as BindingSource).DataSource;
            Type objType = null;
            if (data is IList)
            {
                var method = data.GetType().GetMethod("get_Item", BindingFlags.Instance | BindingFlags.Public);
                if (method == null)
                {
                    method = data.GetType().GetMethod("Get", BindingFlags.Instance | BindingFlags.Public);
                }
                objType = method.ReturnType;
            }
            else
            {
                throw new Exception("数据源不是泛型集合");
            }
            object[] classattrs = objType.GetCustomAttributes(typeof(ColumnWidthAttribute), true);
            foreach (object obj in classattrs)
            {
                ColumnWidthAttribute attr = obj as ColumnWidthAttribute;
                if (attr != null)
                {
                    gv.OptionsView.ColumnAutoWidth = !attr.ForceColumnWidth;
                    break;
                }
            }
            Dictionary<string, ColumnWidthAttribute> dicColumnWidth = new Dictionary<string, ColumnWidthAttribute>();
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                object[] objAttrs = propInfo.GetCustomAttributes(typeof(ColumnWidthAttribute), true);
                if (objAttrs.Length > 0)
                {
                    ColumnWidthAttribute attr = objAttrs[0] as ColumnWidthAttribute;
                    if (attr != null)
                    {
                        dicColumnWidth.Add(propInfo.Name, attr);
                    }
                }
            }
            foreach (var item in dicColumnWidth)
            {
                gv.Columns[item.Key].Width = item.Value.Width;
            }
        }

        private GridViewColumnWidthPara GetDefaultPara()
        {
            return new GridViewColumnWidthPara()
            {
                EnableColumnWidth = true
            };
        }
    }
    public class GridViewColumnWidthPara
    {
        public bool EnableColumnWidth { get; set; }
    }
}
