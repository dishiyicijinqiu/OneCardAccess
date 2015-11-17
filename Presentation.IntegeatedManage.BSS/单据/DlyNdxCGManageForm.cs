using DevExpress.XtraGrid.Views.Base;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using System;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using System.Collections.Generic;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyNdxCGManageForm : DlyNdxCGManageForm_Design
    {
        public DlyNdxCGManageForm()
        {
            InitializeComponent();
        }

        private void DlyNdxCGManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlyNdxCGManageFormFacade(this);
                this.Facade.Bind();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == colDlyTypeId)
                {
                    DlyFormat.ColumnDisplayTextForDlyTypeId(e);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyNdxEntity;
                if (entity == null)
                    throw new BusinessException("单据不存在");
                DlySPRKForm form = new DlySPRKForm(entity.DlyNdxId);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        internal void Bind(DlyNdxFullNameEntity[] entitys)
        {
            bindingSource1.DataSource = new List<DlyNdxFullNameEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }
    }
    public class DlyNdxCGManageForm_Design : TreeLevelForm<DlyNdxCGManageFormFacade>
    {

    }
    public class DlyNdxCGManageFormFacade : ActualBase<DlyNdxCGManageForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public DlyNdxCGManageFormFacade(DlyNdxCGManageForm actual)
            : base(actual) { }

        internal void Bind()
        {
            var entitys = _DlyNdxService.GetCGList();
            this.Actual.Bind(entitys);
        }
    }
}