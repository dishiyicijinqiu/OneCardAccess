using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class ProductFBNSelectPopupContainerControl : PopupContainerControl, IProductFBNSelect
    {
        private ProductFBNSelectUserControl selectUserControl1;
        public ProductFBNSelectPopupContainerControl()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.selectUserControl1 = new ProductFBNSelectUserControl();
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
            // ProductFBNSelectPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        public string BN
        {
            get
            {
                var firstselectedrow = this.selectUserControl1.EntityResults.FirstOrDefault(t => t.Qty > 0);
                if (firstselectedrow == null)
                    return string.Empty;
                return firstselectedrow.BN;
            }
        }
        public void BindData(PFBNBakEntity[] entitys, int StockId, int ProductId, string BN)
        {
            this.selectUserControl1.BindData(entitys, StockId, ProductId, BN);
        }

        public PFBNBakEntity[] EntityResults
        {
            get { return this.selectUserControl1.EntityResults; }
        }

        public int Qty
        {
            get { return (int)this.selectUserControl1.EntityResults.Sum(t => t.Qty); }
        }
    }
}
