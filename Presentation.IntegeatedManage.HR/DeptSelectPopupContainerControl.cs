using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System.Linq;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public class DeptSelectPopupContainerControl : PopupContainerControl, IMultDeptSelect, ISingleDeptSelect
    {
        private bool isMulSelect = false;
        private bool isCateCanSelect = false;
        public DeptSelectPopupContainerControl(bool isMulSelect = false, bool isCateCanSelect = false)
        {
            InitializeComponent();
            this.isMulSelect = isMulSelect;
            this.isCateCanSelect = isCateCanSelect;
            this.deptSelectUserControl1.BeforeBind += deptSelectUserControl1_BeforeBind;
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

        void deptSelectUserControl1_BeforeBind(Infrastructure.Events.CEventArgs<DeptCMCateEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }

        void PopupContainerProperties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.deptSelectUserControl1.IsMulSelect = isMulSelect;
        }
        private DeptSelectUserControl deptSelectUserControl1;

        private void InitializeComponent()
        {
            this.deptSelectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.DeptSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // deptSelectUserControl1
            // 
            this.deptSelectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.deptSelectUserControl1.Name = "deptSelectUserControl1";
            this.deptSelectUserControl1.Size = new System.Drawing.Size(200, 100);
            this.deptSelectUserControl1.TabIndex = 0;
            this.deptSelectUserControl1.OKClick += deptSelectUserControl1_OKClick;
            this.deptSelectUserControl1.CancelClick += deptSelectUserControl1_CancelClick;
            // 
            // DeptSelectPopupContainerControl
            // 
            this.Controls.Add(this.deptSelectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }


        void deptSelectUserControl1_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        void deptSelectUserControl1_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        public event Infrastructure.Events.VEventHandler<Infrastructure.Events.CEventArgs<DeptCMCateEntity[]>> BeforeBind;

        public bool IsSelect { get; private set; }
        public DeptCMCateEntity GetResult()
        {
            return this.deptSelectUserControl1.EntityResult;
        }
        public DeptCMCateEntity[] GetResults()
        {
            return this.deptSelectUserControl1.EntityResults;
        }
    }
}
