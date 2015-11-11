using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public class EmployeeSelectPopupContainerControl : PopupContainerControl, ISingleEmployeeSelect
    {
        private EmployeeSelectUserControl employeeSelectUserControl;
        bool isMulSelect = false;
        public EmployeeSelectPopupContainerControl(bool isMulSelect)
        {
            InitializeComponent();
            employeeSelectUserControl.BeforeBind += employeeSelectUserControl_BeforeBind;
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
                    this.PopupContainerProperties.QueryPopUp -= Properties_QueryPopUp;
                    this.PopupContainerProperties.QueryPopUp += Properties_QueryPopUp;
                }
            }
        }
        void employeeSelectUserControl_BeforeBind(CEventArgs<EmployeeCMDeptEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }

        void Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelect = false;
            this.employeeSelectUserControl.IsMulSelect = isMulSelect;
        }
        private void InitializeComponent()
        {
            this.employeeSelectUserControl = new EmployeeSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // registerSelectUserControl1
            // 
            this.employeeSelectUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeSelectUserControl.Location = new System.Drawing.Point(0, 0);
            this.employeeSelectUserControl.Name = "employeeSelectUserControl";
            this.employeeSelectUserControl.Size = new System.Drawing.Size(200, 100);
            this.employeeSelectUserControl.TabIndex = 0;
            this.employeeSelectUserControl.OKClick += employeeSelectUserControl_OKClick;
            this.employeeSelectUserControl.CancelClick += employeeSelectUserControl_CancelClick;
            // 
            // DeptSelectPopupContainerControl
            // 
            this.Controls.Add(this.employeeSelectUserControl);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        void employeeSelectUserControl_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        void employeeSelectUserControl_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }
        public event VEventHandler<CEventArgs<EmployeeCMDeptEntity[]>> BeforeBind;

        public EmployeeCMDeptEntity GetResult()
        {
            return this.employeeSelectUserControl.EntityResult;
        }


        public bool IsSelect
        {
            get;
            private set;
        }
    }
}
