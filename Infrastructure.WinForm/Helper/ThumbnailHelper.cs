using System.Drawing;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm
{
    public static class ThumbnailHelper
    {

        public static Image FormToBitmap(Control form, Size size)
        {
            Size formSize = form.Size;
            Rectangle rect = new Rectangle(new Point(0, 0), formSize);
            Bitmap bitmap = new Bitmap(formSize.Width, formSize.Height);
            form.DrawToBitmap(bitmap, rect);
            Bitmap result = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(result);
            rect.Size = size;
            g.DrawImage(bitmap, rect);
            return result;
        }
    }
}
