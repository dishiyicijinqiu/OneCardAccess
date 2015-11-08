using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyTypeSelectForm : BaseForm, ISingleDlyTypeSelect
    {
        public DlyTypeSelectForm(bool isCateCanSelect = false)
        {
            InitializeComponent();
            this.dlyTypeSelectUserControl1.IsMulSelect = false;
            this.dlyTypeSelectUserControl1.OKClick -= dlyTypeSelectUserControl1_OKClick;
            this.dlyTypeSelectUserControl1.CancelClick -= dlyTypeSelectUserControl1_CancelClick;
            this.dlyTypeSelectUserControl1.OKClick += dlyTypeSelectUserControl1_OKClick;
            this.dlyTypeSelectUserControl1.CancelClick += dlyTypeSelectUserControl1_CancelClick;
            this.dlyTypeSelectUserControl1.IsCateCanSelect = isCateCanSelect;
            this.dlyTypeSelectUserControl1.BeforeBind += dlyTypeSelectUserControl1_BeforeBind;
        }


        private void DlyTypeSelectForm_Load(object sender, EventArgs e)
        {

        }



        public event VEventHandler<CEventArgs<DlyTypeCateEntity[]>> BeforeBind;

        void dlyTypeSelectUserControl1_CancelClick(EventArgs e)
        {
            IsSelect = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void dlyTypeSelectUserControl1_OKClick(EventArgs e)
        {
            IsSelect = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        void dlyTypeSelectUserControl1_BeforeBind(CEventArgs<DlyTypeCateEntity[]> e)
        {
            if (BeforeBind != null)
                BeforeBind(e);
        }

        public bool IsSelect { get; private set; }

        public DlyTypeCateEntity GetResult()
        {
            var diaresult = this.ShowDialog();
            if (diaresult != System.Windows.Forms.DialogResult.OK)
                return null;
            return this.dlyTypeSelectUserControl1.EntityResult;
        }
    }
}
