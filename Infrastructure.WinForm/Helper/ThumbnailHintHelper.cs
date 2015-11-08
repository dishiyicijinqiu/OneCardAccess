using DevExpress.Utils;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm
{
    public class ThumbnailHintHelper
    {

        private XtraTabbedMdiManager _Manager;
        public ThumbnailHintHelper(XtraTabbedMdiManager manager)
        {
            _Manager = manager;
            manager.MouseMove += new MouseEventHandler(manager_MouseMove);
        }
        [DebuggerStepThrough]
        void manager_MouseMove(object sender, MouseEventArgs e)
        {
            BaseTabHitInfo hi = _Manager.CalcHitInfo(e.Location);
            if (hi.HitTest == XtraTabHitTest.PageHeader)
                ShowHint(hi.Page);
        }
        [DebuggerStepThrough]
        private void ShowHint(DevExpress.XtraTab.IXtraTabPage page)
        {
            ToolTipControlInfo toolTip = new ToolTipControlInfo();
            toolTip.ToolTipType = ToolTipType.SuperTip;
            toolTip.Interval = 500;
            toolTip.Object = page;
            SuperToolTip superTip = new SuperToolTip();
            toolTip.SuperTip = superTip;
            superTip.Items.AddTitle(page.Text);
            superTip.Items.AddSeparator();
            ToolTipItem item1 = new ToolTipItem();
            var child = (page as XtraMdiTabPage).MdiChild;
            item1.Image = ThumbnailHelper.FormToBitmap(child, new Size((int)(child.Size.Width * 0.6), (int)(child.Size.Height * 0.6)));
            superTip.Items.Add(item1);
            ToolTipController.DefaultController.ShowHint(toolTip);
        }
    }
}
