using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class MyPictureEdit : PictureEdit
    {
        public string ImageURL { get; set; }
        internal PictureMenu _Menu;
        protected override PictureMenu Menu
        {
            get
            {
                if (_Menu == null)
                    _Menu = new PictureMenu(this);
                return _Menu;
            }
        }
    }
    sealed public class MyPictureMenu : PictureMenu
    {
        private static ImageCollection imageList;
        private DXMenuItem miUpLoad;
        private DXMenuItem miDelete;
        private DXMenuItem miSave;
        public EventHandler UpLoadClicked;
        public EventHandler DeleteClicked;
        public EventHandler SaveClicked;
        public bool EnableUpLoad
        {
            get
            {
                if (miUpLoad != null)
                    return miUpLoad.Visible;
                return false;
            }
            set
            {
                if (miUpLoad != null)
                    miUpLoad.Visible = value;
            }
        }
        public bool EnableDelete
        {
            get
            {
                if (miDelete != null)
                    return miDelete.Visible;
                return false;
            }
            set
            {
                if (miDelete != null)
                    miDelete.Visible = value;
            }
        }
        public bool EnableSave
        {
            get
            {
                if (miSave != null)
                    return miSave.Visible;
                return false;
            }
            set
            {
                if (miSave != null)
                    miSave.Visible = value;
            }
        }
        public MyPictureMenu(IPictureMenu menuControl)
            : base(menuControl)
        {
        }

        private static void LoadImages()
        {
            if (imageList == null)
            {
                imageList = ImageHelper.CreateImageCollectionFromResources("DevExpress.XtraEditors.Images.PictureMenu.png",
                    typeof(PictureMenu).Assembly, new Size(0x10, 0x10), Color.Empty);
            }
        }

        protected override void LocalizatorChanged(object sender, EventArgs e)
        {
            LoadImages();
            this.Items.Clear();
            this.miUpLoad = this.CreateMenuItem("上传", new EventHandler(this.OnClickedLoad), imageList.Images[4], null);
            this.Items.Add(this.miUpLoad);
            this.miDelete = this.CreateMenuItem(Localizer.Active.GetLocalizedString(StringId.PictureEditMenuDelete),
                new EventHandler(this.OnClickedDelete), imageList.Images[3], StringId.PictureEditMenuDelete);
            this.Items.Add(this.miDelete);
            this.miSave = this.CreateMenuItem(Localizer.Active.GetLocalizedString(StringId.PictureEditMenuSave),
                new EventHandler(this.OnClickedSave), imageList.Images[5], StringId.PictureEditMenuSave);
            this.Items.Add(this.miSave);
        }
        protected override void OnClickedLoad(object sender, EventArgs e)
        {
            if (UpLoadClicked != null)
                this.UpLoadClicked(sender, e);
        }
        protected override void OnClickedDelete(object sender, EventArgs e)
        {
            if (DeleteClicked != null)
                this.DeleteClicked(sender, e);
            else
                base.OnClickedDelete(sender, e);
        }
        protected override void OnClickedSave(object sender, EventArgs e)
        {
            if (SaveClicked != null)
                this.SaveClicked(sender, e);
            else
                base.OnClickedSave(sender, e);
        }
        protected override void OnBeforePopup()
        {
        }
    }
}
