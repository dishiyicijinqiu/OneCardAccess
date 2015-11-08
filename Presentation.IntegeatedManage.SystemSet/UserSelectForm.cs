using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface;
using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class UserSelectForm : BaseForm, ISingleUserSelect, IMultiUserSelect
    {
        public UserSelectForm(bool isMulSelect = false)
        {
            InitializeComponent();
            this.userSelectUserControl1.IsMulSelect = isMulSelect;
            this.userSelectUserControl1.OKClick -= userSelectUserControl1_OKClick;
            this.userSelectUserControl1.CancelClick -= userSelectUserControl1_CancelClick;
            this.userSelectUserControl1.OKClick += userSelectUserControl1_OKClick;
            this.userSelectUserControl1.CancelClick += userSelectUserControl1_CancelClick;
            this.userSelectUserControl1.BeforeBind += userSelectUserControl1_BeforeBind;
        }

        public event VEventHandler<CEventArgs<UserEntity[]>> BeforeBind;

        void userSelectUserControl1_CancelClick(EventArgs e)
        {
            IsSelect = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void userSelectUserControl1_OKClick(EventArgs e)
        {
            IsSelect = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UserSelectForm_Load(object sender, EventArgs e)
        {
        }

        void userSelectUserControl1_BeforeBind(CEventArgs<UserEntity[]> e)
        {
            if (BeforeBind != null)
                BeforeBind(e);
        }
        public bool IsSelect { get; private set; }

        public UserEntity GetResult()
        {
            var diaresult = this.ShowDialog();
            if (diaresult != System.Windows.Forms.DialogResult.OK)
                return null;
            return this.userSelectUserControl1.EntityResult;
        }

        public UserEntity[] GetResults()
        {

            var diaresult = this.ShowDialog();
            if (diaresult != System.Windows.Forms.DialogResult.OK)
                return null;
            return this.userSelectUserControl1.EntityResults;
        }

    }
}
