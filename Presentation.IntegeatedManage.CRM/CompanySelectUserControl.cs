using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM
{
    public partial class CompanySelectUserControl : CompanySelectUserControl_Design
    {
        public event VEventHandler<CEventArgs<CompanyCMCateEntity[]>> BeforeBind;
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        private bool isCateCanSelect = false;
        public CompanySelectUserControl()
        {
            InitializeComponent();
        }
        public bool IsMulSelect
        {
            get
            {
                return isMulSelect;
            }
            internal set
            {
                isMulSelect = value;
            }
        }
        public bool IsCateCanSelect
        {
            get
            {
                return isCateCanSelect;
            }
            internal set
            {
                isCateCanSelect = value;
            }
        }
        private void CompanySelectUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = null;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            this.Facade = new CompanySelectUserControlFacade(this);
            this.Facade.BindData(this.TreeLevel.PId);
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
        public override void TreeLevel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Level_Deep")
            {
                var btns = this.Controls.Find("btnCancel", true);
                if (btns.Length > 0)
                {
                    var btn = btns[0] as SimpleButton;
                    btn.Text = TreeLevel.Level_Deep > 0 ?
                        FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnReturn :
                        FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnCancel;
                }
                if (TreeLevel.Level_Deep < 0)
                {
                    if (CancelClick != null)
                    {
                        this.CancelClick(new EventArgs());
                    }
                }
            }
        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
                return;
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as CompanyCMCateEntity;
                if (EntityResult.HasCate && !this.isCateCanSelect)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.NotLastNodeCanSelect);
                    return;
                }
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => this.gridView1.GetRow(t) as CompanyCMCateEntity
                    ).Where(m => (this.isCateCanSelect || (!m.HasCate && !this.isCateCanSelect))).ToArray();
            }
            if (OKClick != null)
            {
                this.OKClick(new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
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
                    this.btnOK_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        internal void Bind(CompanyCMCateEntity[] entitys)
        {
            if (BeforeBind != null)
            {
                var args = new CEventArgs<CompanyCMCateEntity[]>(entitys);
                this.BeforeBind(args);
                entitys = args.Para1;
            }
            this.bindingSource1.DataSource = new List<CompanyCMCateEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        public CompanyCMCateEntity EntityResult { get; private set; }

        public CompanyCMCateEntity[] EntityResults { get; private set; }
    }

    public class CompanySelectUserControl_Design : TreeLevelUserControl<CompanySelectUserControlFacade>
    {
    }
    public class CompanySelectUserControlFacade : ActualBase<CompanySelectUserControl>
    {
        private ICompanyService _CompanyService = ServiceProxyFactory.Create<ICompanyService>();

        public CompanySelectUserControlFacade(CompanySelectUserControl actual)
            : base(actual)
        { }

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
            var cateentity = new CompanyCMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cateentity, entity);
            cateentity.HasCate = cateentity.Level_Num > 0;
            return cateentity;
        }
    }
}
