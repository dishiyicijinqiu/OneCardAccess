using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM
{
    public partial class CompanyManageForm : CompanyManageForm_Design
    {
        public CompanyManageForm()
        {
            InitializeComponent();
        }

        private void CompanyManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new CompanyManageFormFacade(this);
                this.Facade.BindData(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        #region TreeLevelForm
        public override void DeepIn(int pid)
        {
            this.Facade.BindData(pid);
            base.DeepIn(pid);
        }

        public override void DeepOut(int pid)
        {
            pid = this.Facade.BindFaterData(pid);
            base.DeepOut(pid);
        }
        #endregion

        #region Events
        internal void Bind(CompanyCMCateEntity[] entitys)
        {
            bindingSource.DataSource = new List<CompanyCMCateEntity>(entitys);
            this.gridControl1.DataSource = bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new CompanyEditForm(this.TreeLevel.PId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnCopyAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as CompanyCMCateEntity;
                var form = new CompanyEditForm(this.TreeLevel.PId, ViewType.CopyAdd, entity.CompanyId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as CompanyCMCateEntity;
                var form = new CompanyEditForm(this.TreeLevel.PId, ViewType.Edit, entity.CompanyId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as CompanyCMCateEntity
                    ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteCompanys(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource.RemoveEntityIfDataSourceIsList<CompanyCMCateEntity>(entitys.ToList());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnKind_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as CompanyCMCateEntity;
                var form = new CompanyEditForm(entity.CompanyId, ViewType.Kind, entity.CompanyId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeepOut(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        void form_AfterEdit(CEventArgs<ViewType, int, int> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = bindingSource.DataSource as List<CompanyCMCateEntity>;
                            list.Add(entity);
                            bindingSource.ResetBindings(false);
                            if (e.Para1 == ViewType.CopyAdd)
                                this.btnCopyAdd_Click(null, null);
                        }
                        break;
                    case ViewType.Edit:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                            FengSharp.Tool.Reflect.ClassValueCopier.Copy(row, entity);
                            this.gridView1.RefreshRow(this.gridView1.FocusedRowHandle);
                        }
                        break;
                    case ViewType.Kind:
                        this.DeepIn(e.Para3);
                        break;
                    case ViewType.AddChild:
                    default:
                    case ViewType.ReadOnly:
                        break;
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as CompanyCMCateEntity;
                if (entity.HasCate)
                {
                    this.DeepIn(entity.CompanyId);
                }
                else
                {
                    this.btnEdit_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        #endregion
    }

    public class CompanyManageForm_Design : TreeLevelForm<CompanyManageFormFacade>
    {
    }
    public class CompanyManageFormFacade : ActualBase<CompanyManageForm>
    {
        private ICompanyService _CompanyService = ServiceProxyFactory.Create<ICompanyService>();

        public CompanyManageFormFacade(CompanyManageForm actual)
            : base(actual) { }

        internal void BindData(int pid)
        {
            CompanyCMCateEntity[] entitys = this._CompanyService.GetCompanyCMCateTree(pid);
            if (entitys == null)
                entitys = new CompanyCMCateEntity[0];
            this.Actual.Bind(entitys);
        }

        internal int BindFaterData(int pid)
        {
            var pEntity = this._CompanyService.GetCompanyById(pid);
            if (pEntity != null)
            {
                this.BindData(pEntity.PId);
                return pEntity.PId;
            }
            return 0;
        }

        internal CompanyCMCateEntity FindEntity(int id)
        {
            var entity = this._CompanyService.GetCompanyById(id);
            if (entity == null)
                return null;
            var cmcateentity = new CompanyCMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cmcateentity, entity);
            cmcateentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.CreateId).UserName;
            cmcateentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.LastModifyId).UserName;
            cmcateentity.HasCate = cmcateentity.Level_Num > 0;
            return cmcateentity;
        }

        internal void DeleteCompanys(CompanyCMCateEntity[] entitys)
        {
            this._CompanyService.DeleteCompanys(entitys.Select(t => t.CompanyId).ToArray());
        }
    }
}