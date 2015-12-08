using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("显示行号")]
    [ProvideProperty("KeyDeleteRows", typeof(GridView))]
    [ProvideProperty("KeyString", typeof(GridView))]
    public partial class GridView_KeyDeletedRow : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<GridView, GridViewKeyDeleteRows> StyleList = null;
        #endregion
        public GridView_KeyDeletedRow()
        {
            InitializeComponent();
            StyleList = new Dictionary<GridView, GridViewKeyDeleteRows>();
        }

        public GridView_KeyDeletedRow(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            StyleList = new Dictionary<GridView, GridViewKeyDeleteRows>();
        }
        #region 行号格式化字符串
        [Category("扩展")]
        [Description("键盘按键"), DefaultValue("Delete")]
        public string GetKeyString(GridView gv)
        {
            if (StyleList.ContainsKey(gv))
            {
                return StyleList[gv].KeyString;
            }
            return "{0}";
        }
        public void SetKeyString(GridView gv, string keyString)
        {
            if (!StyleList.ContainsKey(gv))
            {
                StyleList.Add(gv, new GridViewKeyDeleteRows()
                {
                    KeyString = keyString
                });
            }
            else
            {
                StyleList[gv].KeyString = keyString;
            }
        }
        #endregion   
        #region 是否启用键盘删除选中行
        [Category("扩展")]
        [Description("是否启用键盘删除选中行"), DefaultValue(false)]
        public bool GetKeyDeleteRows(GridView dgv)
        {
            if (StyleList.ContainsKey(dgv))
            {
                return StyleList[dgv].EnableKeyDeleteRows;
            }
            return true;
        }
        public void SetKeyDeleteRows(GridView dgv, bool enableKeyDeleteRows)
        {
            if (!StyleList.ContainsKey(dgv))
            {
                StyleList.Add(dgv, new GridViewKeyDeleteRows()
                {
                    EnableKeyDeleteRows = enableKeyDeleteRows
                });
            }
            else
            {
                StyleList[dgv].EnableKeyDeleteRows = enableKeyDeleteRows;
            }
            dgv.KeyDown -= Dgv_KeyDown;
            if (enableKeyDeleteRows)
            {
                dgv.KeyDown += Dgv_KeyDown;
            }
        }

        private void Dgv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                var gv = sender as GridView;
                if (StyleList.ContainsKey(gv))
                {
                    if (string.Compare(e.KeyCode.ToString(), StyleList[gv].KeyString, false) == 0)
                    {
                        if (gv.GetSelectedRows().Length <= 0)
                        {
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                            return;
                        }
                        var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                        if (diaResult != System.Windows.Forms.DialogResult.Yes)
                            return;
                        gv.DeleteSelectedRows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        #endregion

        public bool CanExtend(object extendee)
        {
            return (extendee is GridView);
        }
    }
    internal class GridViewKeyDeleteRows
    {
        private bool enableKeyDeleteRows = true;
        /// <summary>
        /// 是否启用按键删除行
        /// </summary> 
        [DefaultValue(true)]
        public bool EnableKeyDeleteRows
        {
            get
            {
                return enableKeyDeleteRows;
            }
            set
            {
                enableKeyDeleteRows = value;
            }
        }

        private string keyString = "Delete";
        [DefaultValue("Delete")]
        public string KeyString
        {
            get
            {
                return keyString;
            }
            set
            {
                keyString = value;
            }
        }
    }
}
