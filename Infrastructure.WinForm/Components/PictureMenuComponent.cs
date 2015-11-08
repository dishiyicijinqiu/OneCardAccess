using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("右键菜单配置")]
    [ProvideProperty("EnableMenu", typeof(MyPictureEdit))]
    [ProvideProperty("EnableUpLoadMenu", typeof(MyPictureEdit))]
    [ProvideProperty("EnableDeleteMenu", typeof(MyPictureEdit))]
    [ProvideProperty("EnableSaveMenu", typeof(MyPictureEdit))]
    [ProvideProperty("CustomClickUpLoad", typeof(MyPictureEdit))]
    [ProvideProperty("CustomClickDelete", typeof(MyPictureEdit))]
    [ProvideProperty("CustomClickSave", typeof(MyPictureEdit))]
    public partial class PictureMenuComponent : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<MyPictureEdit, PictureMenuPara> list = null;
        #endregion
        #region ctor
        public PictureMenuComponent()
        {
            InitializeComponent();
            list = new Dictionary<MyPictureEdit, PictureMenuPara>();
        }

        public PictureMenuComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<MyPictureEdit, PictureMenuPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            return extendee is MyPictureEdit;
        }
        private PictureMenuPara GetDefaultMenupara()
        {
            return new PictureMenuPara()
                {
                    EnableMenu = false,
                    EnableUpLoadMenu = false,
                    EnableDeleteMenu = false,
                    EnableSaveMenu = false,
                    CustomClickUpLoad = null,
                    CustomClickSave = null,
                    CustomClickDelete = null,
                };
        }
        [Category("右键菜单配置")]
        [Description("是否启用菜单")]
        public bool GetEnableMenu(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].EnableMenu;
            }
            return false;
        }
        public void SetEnableMenu(MyPictureEdit mypictureedit, bool enablemenu)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.EnableMenu = enablemenu;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].EnableMenu = enablemenu;
            }
            DoStyle(mypictureedit);
        }

        [Category("右键菜单配置")]
        [Description("是否启用上传菜单")]
        public bool GetEnableUpLoadMenu(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].EnableUpLoadMenu;
            }
            return false;
        }
        public void SetEnableUpLoadMenu(MyPictureEdit mypictureedit, bool enableuploadmenu)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.EnableUpLoadMenu = enableuploadmenu;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].EnableUpLoadMenu = enableuploadmenu;
            }
            DoStyle(mypictureedit);
        }

        [Category("右键菜单配置")]
        [Description("是否启用删除菜单")]
        public bool GetEnableDeleteMenu(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].EnableDeleteMenu;
            }
            return false;
        }
        public void SetEnableDeleteMenu(MyPictureEdit mypictureedit, bool enabledeletemenu)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.EnableDeleteMenu = enabledeletemenu;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].EnableDeleteMenu = enabledeletemenu;
            }
            DoStyle(mypictureedit);
        }

        [Category("右键菜单配置")]
        [Description("是否启用保存菜单")]
        public bool GetEnableSaveMenu(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].EnableSaveMenu;
            }
            return false;
        }
        public void SetEnableSaveMenu(MyPictureEdit mypictureedit, bool enablesavemenu)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.EnableSaveMenu = enablesavemenu;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].EnableSaveMenu = enablesavemenu;
            }
            DoStyle(mypictureedit);
        }

        [Category("扩展")]
        [Description("自定义上传事件")]
        public EventHandler GetCustomClickUpLoad(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].CustomClickUpLoad;
            }
            return null;
        }
        public void SetCustomClickUpLoad(MyPictureEdit mypictureedit, EventHandler customclickupload)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.CustomClickUpLoad = customclickupload;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].CustomClickUpLoad = customclickupload;
            }
            DoStyle(mypictureedit);
        }


        [Category("扩展")]
        [Description("自定义删除事件")]
        public EventHandler GetCustomClickDelete(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].CustomClickDelete;
            }
            return null;
        }
        public void SetCustomClickDelete(MyPictureEdit mypictureedit, EventHandler customclickdelete)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.CustomClickDelete = customclickdelete;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].CustomClickDelete = customclickdelete;
            }
            DoStyle(mypictureedit);
        }

        [Category("扩展")]
        [Description("自定义保存事件")]
        public EventHandler GetCustomClickSave(MyPictureEdit mypictureedit)
        {
            if (this.list.ContainsKey(mypictureedit))
            {
                return list[mypictureedit].CustomClickSave;
            }
            return null;
        }
        public void SetCustomClickSave(MyPictureEdit mypictureedit, EventHandler customclicksave)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                var para = GetDefaultMenupara();
                para.CustomClickSave = customclicksave;
                this.list.Add(mypictureedit, para);
            }
            else
            {
                this.list[mypictureedit].CustomClickSave = customclicksave;
            }
            DoStyle(mypictureedit);
        }


        private void DoStyle(MyPictureEdit mypictureedit)
        {
            if (!this.list.ContainsKey(mypictureedit))
            {
                return;
            }
            var para = this.list[mypictureedit];
            if (para.EnableMenu)
            {
                var mypicturemenu = new MyPictureMenu(mypictureedit);
                mypicturemenu.EnableUpLoad = para.EnableUpLoadMenu;
                mypicturemenu.EnableDelete = para.EnableDeleteMenu;
                mypicturemenu.EnableSave = para.EnableSaveMenu;

                mypicturemenu.UpLoadClicked -= para.CustomClickUpLoad;
                mypicturemenu.UpLoadClicked += para.CustomClickUpLoad;

                mypicturemenu.DeleteClicked -= para.CustomClickDelete;
                mypicturemenu.DeleteClicked += para.CustomClickDelete;

                mypicturemenu.SaveClicked -= para.CustomClickSave;
                mypicturemenu.SaveClicked += para.CustomClickSave;

                mypictureedit._Menu = mypicturemenu;
            }
        }
    }
    internal class PictureMenuPara
    {
        public bool EnableMenu { get; set; }
        public bool EnableUpLoadMenu { get; set; }
        public bool EnableDeleteMenu { get; set; }
        public bool EnableSaveMenu { get; set; }
        public EventHandler CustomClickUpLoad { get; set; }
        public EventHandler CustomClickDelete { get; set; }
        public EventHandler CustomClickSave { get; set; }
    }
}
