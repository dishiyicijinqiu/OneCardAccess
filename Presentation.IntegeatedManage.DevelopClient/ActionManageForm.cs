using DevExpress.XtraTreeList;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    public partial class ActionManageForm : ActionManageForm_Design
    {
        BindingSource bindingSource = new BindingSource();
        private string NewActionNo = string.Empty;
        string newmsg = "请先将新增的项进行保存";
        public ActionManageForm()
        {
            InitializeComponent();
        }

        private void ActionManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new ActionManageFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }

        public void Bind(ActionEntity[] bindentitys)
        {
            this.treeList1.BeginUnboundLoad();
            bindingSource.DataSource = new BindingList<ActionEntity>(new List<ActionEntity>(bindentitys));
            this.treeList1.DataSource = bindingSource;
            this.treeList1.EndUnboundLoad();
            this.treeList1.ExpandAll();
            this.treeList1.FocusedNodeChanged -= this.treeList1_FocusedNodeChanged;
            this.treeList1.FocusedNodeChanged += this.treeList1_FocusedNodeChanged;
            this.bindingSource1.DataSource = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode);
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (this.treeList1.FocusedNode == null)
                return;
            var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as ActionEntity;
            if (data == null)
                return;
            this.bindingSource1.DataSource = data;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as ActionEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    if (NewActionNo != data.ActionNo)
                    {
                        MessageBoxEx.Info(newmsg);
                        return;
                    }
                }

                this.bindingSource1.ResetBindings(false);
                this.Facade.SaveMenu(data);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                this.bindingSource.ResetBindings(false);
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    NewActionNo = string.Empty;
                }
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



        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList1.FocusedNode == null)
                    return;
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as ActionEntity;
                if (data == null)
                    return;
                if (MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm) != System.Windows.Forms.DialogResult.Yes)
                    return;
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    if (NewActionNo != data.ActionNo)
                    {
                        MessageBoxEx.Info(newmsg);
                        return;
                    }
                }
                this.Facade.Delete(data.ActionNo);
                this.bindingSource.Remove(data);
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    NewActionNo = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList1.FocusedNode == null)
                    return;
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as ActionEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    MessageBoxEx.Info(newmsg);
                    return;
                }
                ActionEntity newdata = this.Facade.GetAddChildItem(data);
                this.bindingSource.Position = this.bindingSource.Add(newdata);
                this.bindingSource.IndexOf(newdata);
                NewActionNo = newdata.ActionNo;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList1.FocusedNode == null)
                    return;
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as ActionEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewActionNo))
                {
                    MessageBoxEx.Info(newmsg);
                    return;
                }
                ActionEntity newdata = this.Facade.GetAddItem(data);
                this.bindingSource.Position = this.bindingSource.Add(newdata);
                this.bindingSource.IndexOf(newdata);
                NewActionNo = newdata.ActionNo;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }
    }
    public partial class ActionManageForm_Design : Base_Form<ActionManageFacade>
    {
    }

    public class ActionManageFacade : ActualBase<ActionManageForm>
    {
        private IActionService _Service = ServiceProxyFactory.Create<IActionService>("ActionService");
        public ActionManageFacade(ActionManageForm actual)
            : base(actual)
        { }

        public void BindData()
        {
            var entitys = this._Service.GetAllEntity();
            if (entitys == null)
                entitys = new ActionEntity[0];
            this.Actual.Bind(entitys);
        }

        public ActionEntity GetAddItem(ActionEntity data)
        {
            var result = new ActionEntity();
            result.ActionNo = _Service.GetNewChildNo(data.ParentActionNo);
            result.ParentActionNo = data.ParentActionNo;
            result.ActionType = "auth";
            result.ActionName = "新增项";
            return result;
        }

        public void Delete(string ActionNo)
        {
            var entity = this._Service.FindEntityByNo(ActionNo);
            if (entity != null)
                this._Service.DeleteEntity(ActionNo);
        }

        public ActionEntity GetAddChildItem(ActionEntity data)
        {
            var result = new ActionEntity();
            result.ActionNo = _Service.GetNewChildNo(data.ActionNo);
            result.ParentActionNo = data.ActionNo;
            result.ActionType = "auth";
            result.ActionName = "新增项";
            return result;
        }

        public void SaveMenu(ActionEntity data)
        {
            var entity = this._Service.FindEntityByNo(data.ActionNo);
            if (entity == null)
                this._Service.CreateEntity(data);
            else
                this._Service.UpdateEntity(data.ActionNo, data);
        }
    }

}