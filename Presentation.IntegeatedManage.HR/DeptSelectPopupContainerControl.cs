using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System.Linq;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public class DeptSelectPopupContainerControl : PopupContainerControl, IMultDeptSelect, ISingleDeptSelect
    {
        private bool isMulSelect = false;
        private bool isCateCanSelect = false;
        private DeptSelectUserControl selectUserControl1;
        public DeptSelectPopupContainerControl(bool isMulSelect = false, bool isCateCanSelect = false)
        {
            InitializeComponent();
            this.isMulSelect = isMulSelect;
            this.isCateCanSelect = isCateCanSelect;
            this.selectUserControl1.BeforeBind += selectUserControl1_BeforeBind;
        }

        protected override RepositoryItemPopupContainerEdit OwnerItem
        {
            get
            {
                return base.OwnerItem;
            }
            set
            {
                base.OwnerItem = value;
                if (this.PopupContainerProperties != null)
                {
                    this.PopupContainerProperties.QueryPopUp -= PopupContainerProperties_QueryPopUp;
                    this.PopupContainerProperties.QueryPopUp += PopupContainerProperties_QueryPopUp;
                }
            }
        }

        void selectUserControl1_BeforeBind(Infrastructure.Events.CEventArgs<DeptCMCateEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }

        void PopupContainerProperties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelect = false;
            this.selectUserControl1.IsMulSelect = isMulSelect;
        }

        private void InitializeComponent()
        {
            this.selectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.DeptSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // deptSelectUserControl1
            // 
            this.selectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.selectUserControl1.Name = "deptSelectUserControl1";
            this.selectUserControl1.Size = new System.Drawing.Size(200, 100);
            this.selectUserControl1.TabIndex = 0;
            this.selectUserControl1.OKClick += selectUserControl1_OKClick;
            this.selectUserControl1.CancelClick += selectUserControl1_CancelClick;
            // 
            // DeptSelectPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }


        void selectUserControl1_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            this.PopupContainerProperties.PopupControl.OwnerEdit.ClosePopup();
        }

        void selectUserControl1_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            this.PopupContainerProperties.PopupControl.OwnerEdit.ClosePopup();
        }

        public event VEventHandler<CEventArgs<DeptCMCateEntity[]>> BeforeBind;

        public bool IsSelect { get; private set; }
        public DeptCMCateEntity GetResult()
        {
            return this.selectUserControl1.EntityResult;
        }
        public DeptCMCateEntity[] GetResults()
        {
            return this.selectUserControl1.EntityResults;
        }
    }
}
