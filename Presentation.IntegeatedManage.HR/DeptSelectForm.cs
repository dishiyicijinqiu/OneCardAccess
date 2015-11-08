using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class DeptSelectForm : BaseForm, IMultDeptSelect, ISingleDeptSelect
    {
        public DeptSelectForm(bool isMulSelect = false, bool isCateCanSelect = false)
        {
            InitializeComponent();
            this.deptSelectUserControl1.IsMulSelect = isMulSelect;
            this.deptSelectUserControl1.IsCateCanSelect = isCateCanSelect;
            this.deptSelectUserControl1.OKClick -= deptSelectUserControl1_OKClick;
            this.deptSelectUserControl1.CancelClick -= deptSelectUserControl1_CancelClick;
            this.deptSelectUserControl1.OKClick += deptSelectUserControl1_OKClick;
            this.deptSelectUserControl1.CancelClick += deptSelectUserControl1_CancelClick;

            this.deptSelectUserControl1.BeforeBind += deptSelectUserControl1_BeforeBind;
        }

        public event VEventHandler<CEventArgs<DeptCMCateEntity[]>> BeforeBind;

        void deptSelectUserControl1_CancelClick(EventArgs e)
        {
            IsSelect = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void deptSelectUserControl1_OKClick(EventArgs e)
        {
            IsSelect = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void DeptSelectForm_Load(object sender, EventArgs e)
        {
        }

        void deptSelectUserControl1_BeforeBind(CEventArgs<DeptCMCateEntity[]> e)
        {
            if (BeforeBind != null)
                BeforeBind(e);
        }


        public bool IsSelect { get; private set; }

        public DeptCMCateEntity GetResult()
        {
            var diaresult = this.ShowDialog();
            if (diaresult != System.Windows.Forms.DialogResult.OK)
                return null;
            return this.deptSelectUserControl1.EntityResult;
        }


        public DeptCMCateEntity[] GetResults()
        {
            var diaresult = this.ShowDialog();
            if (diaresult != System.Windows.Forms.DialogResult.OK)
                return null;
            return this.deptSelectUserControl1.EntityResults;
        }
    }
}