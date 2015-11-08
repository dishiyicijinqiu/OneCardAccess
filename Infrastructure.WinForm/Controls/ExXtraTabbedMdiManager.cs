using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public partial class ExXtraTabbedMdiManager : XtraTabbedMdiManager
    {
        private bool useDefaultImageSize;
        private Size pageImageSize;
        public ExXtraTabbedMdiManager(IContainer container)
            : this()
        {
            container.Add(this);
        }
        public ExXtraTabbedMdiManager()
        {
            InitializeComponent();
            useDefaultImageSize = true;
            pageImageSize = new Size(16, 16);
        }
        protected override XtraMdiTabPage CreateNewPage(Form child)
        {
            XtraMdiTabPage createdPage = base.CreateNewPage(child);
            if (!useDefaultImageSize)
            {
                var icon = child.Icon;
                if (icon != null)
                {
                    var bitmap = icon.ToBitmap();
                    if (PageImageSize.IsEmpty || bitmap.Size == PageImageSize)
                        return createdPage;

                    Bitmap scaledImage = new Bitmap(PageImageSize.Width, PageImageSize.Height);
                    scaledImage.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
                    using (Graphics gr = Graphics.FromImage(scaledImage))
                    {
                        gr.Clear(Color.Transparent);
                        Rectangle dstRect = new Rectangle(0, 0, PageImageSize.Width, pageImageSize.Height);
                        Rectangle srcRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                        gr.DrawImage(bitmap, dstRect, srcRect, GraphicsUnit.Pixel);
                    }

                    createdPage.Image = scaledImage;
                }
            }

            return createdPage;
        }
        [DefaultValue(typeof(Size), "16,16")]
        public Size PageImageSize
        {
            get { return pageImageSize; }
            set
            {
                if (pageImageSize == value)
                    return;

                pageImageSize = value;
            }
        }

        [DefaultValue(true)]
        public bool UseDefaultPageImageSize
        {
            get { return useDefaultImageSize; }
            set
            {
                if (useDefaultImageSize == value)
                    return;

                useDefaultImageSize = value;
            }
        }
    }
}
