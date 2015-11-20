namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCloseCurrent = new DevExpress.XtraBars.BarButtonItem();
            this.btnCloseOther = new DevExpress.XtraBars.BarButtonItem();
            this.btnCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.barItemUser = new DevExpress.XtraBars.BarButtonItem();
            this.barItemEmpty = new DevExpress.XtraBars.BarStaticItem();
            this.barTimeItem = new FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.BarTimeItem();
            this.barTimeInfo = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager = new FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.ExXtraTabbedMdiManager(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ButtonGroupsLayout = DevExpress.XtraBars.ButtonGroupsLayout.ThreeRows;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnCloseCurrent,
            this.btnCloseOther,
            this.btnCloseAll,
            this.barItemUser,
            this.barItemEmpty,
            this.barTimeItem,
            this.barTimeInfo});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1148, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnCloseCurrent
            // 
            this.btnCloseCurrent.Caption = "关闭当前(&C)";
            this.btnCloseCurrent.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCloseCurrent.Glyph")));
            this.btnCloseCurrent.Id = 4;
            this.btnCloseCurrent.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCloseCurrent.LargeGlyph")));
            this.btnCloseCurrent.Name = "btnCloseCurrent";
            this.btnCloseCurrent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseCurrent_ItemClick);
            // 
            // btnCloseOther
            // 
            this.btnCloseOther.Caption = "关闭其他(&O)";
            this.btnCloseOther.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCloseOther.Glyph")));
            this.btnCloseOther.Id = 5;
            this.btnCloseOther.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCloseOther.LargeGlyph")));
            this.btnCloseOther.Name = "btnCloseOther";
            this.btnCloseOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseOther_ItemClick);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Caption = "关闭所有(&A)";
            this.btnCloseAll.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCloseAll.Glyph")));
            this.btnCloseAll.Id = 6;
            this.btnCloseAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCloseAll.LargeGlyph")));
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseAll_ItemClick);
            // 
            // barItemUser
            // 
            this.barItemUser.Id = 9;
            this.barItemUser.Name = "barItemUser";
            // 
            // barItemEmpty
            // 
            this.barItemEmpty.Caption = "    当前账号：";
            this.barItemEmpty.Id = 10;
            this.barItemEmpty.Name = "barItemEmpty";
            this.barItemEmpty.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barTimeItem
            // 
            this.barTimeItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barTimeItem.Caption = "2015年11月20日 14:33:44";
            this.barTimeItem.Id = 11;
            this.barTimeItem.Name = "barTimeItem";
            this.barTimeItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barTimeInfo
            // 
            this.barTimeInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barTimeInfo.Caption = "当前时间：";
            this.barTimeInfo.Id = 12;
            this.barTimeInfo.Name = "barTimeInfo";
            this.barTimeInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barItemEmpty);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemUser);
            this.ribbonStatusBar.ItemLinks.Add(this.barTimeInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barTimeItem);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 631);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1148, 31);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabbedMdiManager.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.OnMouseUp;
            this.xtraTabbedMdiManager.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded;
            this.xtraTabbedMdiManager.MdiParent = this;
            this.xtraTabbedMdiManager.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabbedMdiManager.UseDefaultPageImageSize = false;
            this.xtraTabbedMdiManager.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xtraTabbedMdiManager_MouseUp);
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.btnCloseCurrent, true);
            this.popupMenu.ItemLinks.Add(this.btnCloseOther, true);
            this.popupMenu.ItemLinks.Add(this.btnCloseAll, true);
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // applicationMenu
            // 
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbon;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 662);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "一卡通系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.ExXtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnCloseCurrent;
        private DevExpress.XtraBars.BarButtonItem btnCloseOther;
        private DevExpress.XtraBars.BarButtonItem btnCloseAll;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.XtraBars.BarButtonItem barItemUser;
        private DevExpress.XtraBars.BarStaticItem barItemEmpty;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.BarTimeItem barTimeItem;
        private DevExpress.XtraBars.BarStaticItem barTimeInfo;
    }
}