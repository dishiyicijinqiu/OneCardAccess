using DevExpress.XtraEditors;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Base
{
    public class BasePictureEdit : PictureEdit
    {
        public BasePictureEdit()
            : base()
        {
            this.Properties.ErrorImage =
                FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.FileNotFound;
        }
    }
}
