using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class RegisterManageForm : RegisterManageForm_Design
    {
        public RegisterManageForm()
        {
            InitializeComponent();
        }

        private void RegisterManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new RegisterManageFormFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.SetLoadError(this, true);
                MessageBoxEx.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new RegisterEditForm();
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as RegisterCMEntity;
                var form = new RegisterEditForm(ViewType.CopyAdd, entity.RegisterId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as RegisterCMEntity;
                var form = new RegisterEditForm(ViewType.Edit, entity.RegisterId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }


        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
            (
                t => this.gridView1.GetRow(t) as RegisterCMEntity
            ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteRegisters(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource1.RemoveEntityIfDataSourceIsList<RegisterCMEntity>(entitys.ToList());
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


        void form_AfterEdit(CEventArgs<ViewType, string> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = this.bindingSource1.DataSource as List<RegisterCMEntity>;
                            list.Add(entity);
                            bindingSource1.ResetBindings(false);
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
        internal void Bind(RegisterCMEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<RegisterCMEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || e.RowHandle < 0)
                    return;
                if (btnEdit.Enabled)
                    btnEdit_Click(btnEdit, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }
    }
    public class RegisterManageForm_Design : Base_Form<RegisterManageFormFacade>
    {
    }
    public class RegisterManageFormFacade : ActualBase<RegisterManageForm>
    {
        private IRegisterService _RegisterService = ServiceProxyFactory.Create<IRegisterService>();
        public RegisterManageFormFacade(RegisterManageForm actual)
            : base(actual) { }
        internal void BindData()
        {
            RegisterCMEntity[] entitys = this._RegisterService.GetRegisterCMList();
            if (entitys == null)
                entitys = new RegisterCMEntity[0];
            this.Actual.Bind(entitys);
        }
        internal void DeleteRegisters(RegisterCMEntity[] entitys)
        {
            this._RegisterService.DeleteRegisters(entitys.Select(t => t.RegisterId).ToArray());
        }
        internal RegisterCMEntity FindEntity(string entityid)
        {
            var entity = this._RegisterService.GetRegisterById(entityid);
            if (entity == null) return null;
            var result = new RegisterCMEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(result.CreateId).UserName;
            result.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(result.LastModifyId).UserName;
            var registerEntity = ServiceProxyFactory.Create<IRegisterService>().GetRegisterById(result.RegisterId);
            if (registerEntity != null)
            {
                result.RegisterNo = registerEntity.RegisterNo;
                result.RegisterNo1 = registerEntity.RegisterNo1;
                result.RegisterProductName = registerEntity.RegisterProductName;
                result.RegisterProductName1 = registerEntity.RegisterProductName1;
                result.StandardCode = registerEntity.StandardCode;
                result.StandardCode1 = registerEntity.StandardCode1;
            }
            return result;
        }
    }
}
