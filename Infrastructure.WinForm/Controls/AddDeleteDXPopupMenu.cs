using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    sealed public class AddDeleteDXPopupMenu : DXPopupMenu
    {
        private static ImageCollection imageList;
        private DXMenuItem miAdd;
        private DXMenuItem miDelete;
        public EventHandler AddClicked;
        public EventHandler DeleteClicked;
        public bool EnableAdd
        {
            get
            {
                if (miAdd != null)
                    return miAdd.Visible;
                return false;
            }
            set
            {
                if (miAdd != null)
                    miAdd.Visible = value;
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

        public AddDeleteDXPopupMenu()
        {
            LoadImages();
            this.Items.Clear();
            this.miAdd = this.CreateMenuItem("新增(&A)",
                new EventHandler(this.OnClickedAdd), imageList.Images[0], "Add");
            this.Items.Add(this.miAdd);
            this.miDelete = this.CreateMenuItem(Localizer.Active.GetLocalizedString(StringId.TextEditMenuDelete),
                new EventHandler(this.OnClickedDelete), imageList.Images[1], "Delete");
            this.Items.Add(this.miDelete);
        }

        private static void LoadImages()
        {
            if (imageList == null)
            {
                imageList = new ImageCollection();
                imageList.AddImage(DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/additem_16x16.png"));
                imageList.AddImage(DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"));
            }
        }
        void OnClickedAdd(object sender, EventArgs e)
        {
            if (AddClicked != null)
                this.AddClicked(sender, e);
        }
        void OnClickedDelete(object sender, EventArgs e)
        {
            if (DeleteClicked != null)
                this.DeleteClicked(sender, e);
        }
        //protected override void OnBeforePopup()
        //{
        //}

        DXMenuItem CreateMenuItem(string caption, EventHandler clickHandler, Image image, object tag)
        {
            return this.CreateMenuItem(caption, clickHandler, image, tag, false);
        }

        DXMenuItem CreateMenuItem(string caption, EventHandler clickHandler, Image image, object tag, bool beginGroup)
        {
            return new DXMenuItem(caption, clickHandler, image) { BeginGroup = beginGroup, Tag = tag };
        }

    }
}
