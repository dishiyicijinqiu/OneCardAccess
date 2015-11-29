using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductFBNInputUserControl : ProductFBNInputUserControl_Design
    {
        public ProductFBNInputUserControl()
        {
            InitializeComponent();
        }

        private void ProductFBNInputUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.DesignMode)
                    return;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    return;
                CreateFacade();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var data = bindingSource1.DataSource as List<FBNInputEntity>;
            data.Clear();
            bindingSource1.ResetBindings(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as FBNInputEntity
                    ).ToList();
                if (entitys.Count <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                this.bindingSource1.RemoveEntityIfDataSourceIsList<FBNInputEntity>(entitys);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public FBNInputEntity[] EntityResults
        {
            get
            {
                return (bindingSource1.DataSource as List<FBNInputEntity>).ToArray();
            }
        }

        private void CreateFacade()
        {
            if (this.Facade == null)
                this.Facade = new ProductFBNInputUserControlFacade(this);
        }

        public void BindData(FBNInputEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<FBNInputEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }

        internal void ResetValue()
        {
            this.txtFBN.EditValue = string.Empty;
            this.txtQty.EditValue = 1;
            this.txtFBN.Focus();
        }

        private void txtQty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    var data = this.bindingSource1.DataSource as List<FBNInputEntity>;
                    string strfbn = this.txtFBN.Text;
                    string strbn;
                    if (!this.Facade.VerifyFBN(strfbn, out strbn))
                    {
                        MessageBoxEx.Info("批号录入不符合规则");
                        this.txtFBN.Focus();
                        return;
                    }
                    if (data.Count > 0)
                    {
                        if (strbn != data[0].BN)
                        {
                            MessageBoxEx.Info("检测到不同的批号");
                            return;
                        }
                    }
                    var firstsamedata = data.FirstOrDefault(t => t.FullBN == strfbn);
                    if (firstsamedata == null)
                    {
                        data.Add(new FBNInputEntity()
                        {
                            BN = strbn,
                            FullBN = strfbn,
                            Remark = string.Empty,
                            Qty = Convert.ToInt32(this.txtQty.EditValue),
                            SortNo = data.Count
                        });
                        bindingSource1.ResetBindings(false);
                        this.gridView1.MoveLast();
                    }
                    else
                    {
                        var rowhandle = this.gridView1.GetRowHandle(data.IndexOf(firstsamedata));
                        firstsamedata.Qty = firstsamedata.Qty + Convert.ToInt32(this.txtQty.EditValue);
                        this.gridView1.RefreshRow(rowhandle);
                        this.gridView1.FocusedRowHandle = rowhandle;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class ProductFBNInputUserControl_Design : Base_UserControl<ProductFBNInputUserControlFacade>
    {

    }
    public class ProductFBNInputUserControlFacade : ActualBase<ProductFBNInputUserControl>
    {
        public ProductFBNInputUserControlFacade(ProductFBNInputUserControl actual)
            : base(actual) { }
        internal bool VerifyFBN(string strfbn, out string strbn)
        {
            strbn = string.Empty;
            if (string.IsNullOrWhiteSpace(strfbn))
                return false;
            var firstrule = PFBNSNRule.PFBNRuleEntitys.FirstOrDefault(t => t.TotalLen == strfbn.Length);
            if (firstrule == null)
                return false;
            strbn = strfbn.Substring(firstrule.BNStartPos - 1, (firstrule.BNEndPos - firstrule.BNStartPos + 1));
            return true;
        }
    }

}
