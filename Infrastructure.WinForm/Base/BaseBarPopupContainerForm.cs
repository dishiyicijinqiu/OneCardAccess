using DevExpress.XtraBars;
using DevExpress.XtraBars.Forms;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Base
{
    public class BaseBarPopupContainerForm : PopupContainerForm
    {
        public BaseBarPopupContainerForm(BarManager manager, Control containedControl)
            : base(manager, containedControl)
        {

        }
    }
}
