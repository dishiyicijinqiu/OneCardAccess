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
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    public partial class MenuManageForm : MenuManageForm_Design
    {
        BindingSource bindingSource = new BindingSource();
        private string NewMenuNo = string.Empty;
        string newmsg = "请先将新增的项进行保存";
        public MenuManageForm()
        {
            InitializeComponent();
        }

        private void MenuManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new MenuManageFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }

        public void Bind(MenuEntity[] bindentitys)
        {
            this.treeList1.BeginUnboundLoad();
            bindingSource.DataSource = new BindingList<MenuEntity>(new List<MenuEntity>(bindentitys));
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
            var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as MenuEntity;
            if (data == null)
                return;
            this.bindingSource1.DataSource = data;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as MenuEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    if (NewMenuNo != data.MenuNo)
                    {
                        MessageBoxEx.Info(newmsg);
                        return;
                    }
                }
                this.bindingSource1.ResetBindings(false);
                this.Facade.SaveMenu(data);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                this.bindingSource.ResetBindings(false);
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    NewMenuNo = string.Empty;
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
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as MenuEntity;
                if (data == null)
                    return;
                if (MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm) != System.Windows.Forms.DialogResult.Yes)
                    return;
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    if (NewMenuNo != data.MenuNo)
                    {
                        MessageBoxEx.Info(newmsg);
                        return;
                    }
                }
                this.Facade.Delete(data.MenuNo);
                this.bindingSource.Remove(data);
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    NewMenuNo = string.Empty;
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
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as MenuEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    MessageBoxEx.Info(newmsg);
                    return;
                }
                MenuEntity newdata = this.Facade.GetAddChildItem(data);
                this.bindingSource.Position = this.bindingSource.Add(newdata);
                this.bindingSource.IndexOf(newdata);
                NewMenuNo = newdata.MenuNo;
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
                var data = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as MenuEntity;
                if (data == null)
                    return;
                if (!string.IsNullOrWhiteSpace(NewMenuNo))
                {
                    MessageBoxEx.Info(newmsg);
                    return;
                }
                MenuEntity newdata = this.Facade.GetAddItem(data);
                this.bindingSource.Position = this.bindingSource.Add(newdata);
                this.bindingSource.IndexOf(newdata);
                NewMenuNo = newdata.MenuNo;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }
    }
    public partial class MenuManageForm_Design : Base_Form<MenuManageFacade>
    {
    }

    public class MenuManageFacade : ActualBase<MenuManageForm>
    {
        private IMenuService _Service = ServiceProxyFactory.Create<IMenuService>();
        public MenuManageFacade(MenuManageForm actual)
            : base(actual)
        { }

        public void BindData()
        {
            var entitys = this._Service.GetAllEntity();
            entitys = entitys.OrderBy(t => t.Order).ToArray();
            if (entitys == null)
                entitys = new MenuEntity[0];
            this.Actual.Bind(entitys);
        }

        public MenuEntity GetAddItem(MenuEntity data)
        {
            var result = new MenuEntity();
            result.MenuNo = _Service.GetNewChildNo(data.PNo);
            result.PNo = data.PNo;
            result.MenuControl = "BarItem";
            result.MenuName = "新增项";
            return result;
        }

        public void Delete(string MenuNo)
        {
            var entity = this._Service.FindEntityByNo(MenuNo);
            if (entity != null)
                this._Service.DeleteEntity(MenuNo);
        }

        public MenuEntity GetAddChildItem(MenuEntity data)
        {
            var result = new MenuEntity();
            result.MenuNo = _Service.GetNewChildNo(data.MenuNo);
            result.PNo = data.MenuNo;
            result.MenuControl = "BarItem";
            result.MenuName = "新增项";
            return result;
        }

        public void SaveMenu(MenuEntity data)
        {
            var entity = this._Service.FindEntityByNo(data.MenuNo);
            if (entity == null)
                this._Service.CreateEntity(data);
            else
                this._Service.UpdateEntity(data.MenuNo, data);
        }
    }
}
