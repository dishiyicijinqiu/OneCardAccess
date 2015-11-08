using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class MyLookUpEdit : LookUpEdit
    {
        internal DXPopupMenu _Menu;
        protected override DXPopupMenu Menu
        {
            get
            {
                if (_Menu == null)
                    _Menu = base.Menu;
                return _Menu;
            }
        }
    }
}
