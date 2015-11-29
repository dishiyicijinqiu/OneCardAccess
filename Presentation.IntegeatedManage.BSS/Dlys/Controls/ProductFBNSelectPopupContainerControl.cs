using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;

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
        public void BindData(PFBNBakEntity[] entitys, int StockId, int ProductId, string BN)
        {
            this.selectUserControl1.BindData(entitys, StockId, ProductId, BN);
        }
        public string BN
        {
            get
            {
                if (this.selectUserControl1.EntityResults.Length <= 0) return string.Empty;
                return this.selectUserControl1.EntityResults[0].BN;
            }
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
