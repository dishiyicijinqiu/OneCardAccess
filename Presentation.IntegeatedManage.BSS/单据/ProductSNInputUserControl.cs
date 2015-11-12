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
    public partial class ProductSNInputUserControl : ProductSNInputUserControl_Design
    {
        public ProductSNInputUserControl()
        {
            InitializeComponent();
        }

        private void ProductSNInputUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            CreateFacade();
        }

        private void CreateFacade()
        {
            if (this.Facade == null)
                this.Facade = new ProductSNInputUserControlFacade(this);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as SNInputEntity
                    ).ToList();
                if (entitys.Count <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                this.bindingSource1.RemoveEntityIfDataSourceIsList<SNInputEntity>(entitys);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var data = bindingSource1.DataSource as List<SNInputEntity>;
            data.Clear();
            bindingSource1.ResetBindings(false);
        }
        public SNInputEntity[] EntityResults
        {
            get
            {
                return (bindingSource1.DataSource as List<SNInputEntity>).ToArray();
            }
        }

        public void BindData(SNInputEntity[] entitys)
        {
            ResetValue();
            this.bindingSource1.DataSource = new List<SNInputEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }
        private void ResetValue()
        {
            this.txtStart.EditValue = string.Empty;
            this.txtEnd.EditValue = string.Empty;
        }

        private void txtEnd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    var data = this.bindingSource1.DataSource as List<FBNInputEntity>;
                    string strfbn = this.txtFBN.Text;
                    string strbn;
                    if (!this.VerifyFBN(strfbn, out strbn))
                    {
                        MessageBoxEx.Info("录入批号有误");
                        this.txtFBN.Focus();
                        return;
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
    public class ProductSNInputUserControl_Design : Base_UserControl<ProductSNInputUserControlFacade>
    {

    }
    public class ProductSNInputUserControlFacade : ActualBase<ProductSNInputUserControl>
    {
        public ProductSNInputUserControlFacade(ProductSNInputUserControl actual)
            : base(actual) { }

    }
}
