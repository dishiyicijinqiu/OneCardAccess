using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm
{
    public partial class ResourceMessages
    {
        private static System.Drawing.Image _PictureMenuPriview = new Bitmap(DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/show_16x16.png"));
        public static System.Drawing.Image PictureMenuPriview
        {
            get
            {
                return _PictureMenuPriview;
            }
        }
    }
}
