using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class ProductSNLookPopupContainerControl: PopupContainerControl, IProductSNLook
    {
        private ProductSNLookUserControl selectUserControl1;
        public ProductSNLookPopupContainerControl()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.selectUserControl1 = new ProductSNLookUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // selectUserControl1
            // 
            this.selectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.selectUserControl1.Name = "selectUserControl1";
            this.selectUserControl1.Size = new System.Drawing.Size(200, 100);
            this.selectUserControl1.TabIndex = 0;
            // 
            // ProductSNLookPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        public void BindData(PSNInOutDetailsEntity[] data)
        {
            this.selectUserControl1.BindData(data);
        }
    }
}
