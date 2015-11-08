using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    public partial class MenuLoadForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MenuLoadForm()
        {
            InitializeComponent();
        }
        private void MenuLoadForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                MenuHelper.LoadMenu(this.ribbon);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.Close();
            }
        }


        private void MenuLoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBoxEx.YesNoInfo("是否生成菜单") == System.Windows.Forms.DialogResult.Yes)
            {
                SaveFileDialog dia = new SaveFileDialog();
                dia.Filter = "xml文件|*.xml";
                if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ribbon.SaveLayoutToXml(dia.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.popupMenu.ShowPopup(Control.MousePosition);
        }
    }
}
