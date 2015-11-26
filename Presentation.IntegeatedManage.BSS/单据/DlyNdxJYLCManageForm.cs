using DevExpress.XtraGrid.Views.Base;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
using System.Collections.Generic;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyNdxJYLCManageForm : DlyNdxJYLCManageForm_Design
    {
        public DlyNdxJYLCManageForm()
        {
            InitializeComponent();
        }

        private void DlyNdxJYLCManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlyNdxJYLCManageFormFacade(this);
                this.Facade.Bind();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }


        internal void Bind(DlyNdxFullNameEntity[] entitys)
        {
            bindingSource1.DataSource = new List<DlyNdxFullNameEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Facade.Bind();
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
                    throw new BusinessException(Properties.Resources.DlyNotExists);
                DlySPRKYGZForm form = new DlySPRKYGZForm(entity.DlyNdxId);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class DlyNdxJYLCManageForm_Design : TreeLevelForm<DlyNdxJYLCManageFormFacade>
    {

    }
    public class DlyNdxJYLCManageFormFacade : ActualBase<DlyNdxJYLCManageForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public DlyNdxJYLCManageFormFacade(DlyNdxJYLCManageForm actual)
            : base(actual)
        { }

        internal void Bind()
        {
            var entitys = _DlyNdxService.GetJYLCList();
            this.Actual.Bind(entitys);
        }
    }
}
