using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("按钮的编辑样式")]
    [ProvideProperty("Style", typeof(SimpleButton))]
    [ProvideProperty("UseDefaultText", typeof(SimpleButton))]
    [ProvideProperty("EnableStyle", typeof(SimpleButton))]
    public partial class ButtonStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<SimpleButton, EditButtonStylePara> list = null;
        #endregion
        #region ctor
        public ButtonStyle()
        {
            InitializeComponent();
            list = new Dictionary<SimpleButton, EditButtonStylePara>();
        }

        public ButtonStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<SimpleButton, EditButtonStylePara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            return extendee is SimpleButton;
        }

        [Category("扩展")]
        [Description("按钮的编辑样式")]
        public ButtonStyleKind GetStyle(SimpleButton button)
        {
            if (this.list.ContainsKey(button))
            {
                return list[button].ButtonStyleKind;
            }
            return ButtonStyleKind.AddWithLargeImage;
        }
        public void SetStyle(SimpleButton button, ButtonStyleKind buttonStyleKind)
        {

            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].ButtonText = button.Text;
            this.list[button].ButtonStyleKind = buttonStyleKind;
            SetButtonStyle(button);
        }
        [Category("扩展")]
        [Description("是否使用默认的文字")]
        public bool GetUseDefaultText(SimpleButton button)
        {
            if (this.list.ContainsKey(button))
            {
                return this.list[button].UseDefaultText;
            }
            return true;
        }
        public void SetUseDefaultText(SimpleButton button, bool usedefaulttext)
        {
            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].ButtonText = button.Text;
            this.list[button].UseDefaultText = usedefaulttext;
            SetButtonStyle(button);
        }

        [Category("扩展")]
        [Description("是否应用按钮样式")]
        public bool GetEnableStyle(SimpleButton button)
        {
            if (this.list.ContainsKey(button))
            {
                return list[button].EnableStyle;
            }
            return false;
        }

        public void SetEnableStyle(SimpleButton button, bool enableStyle)
        {
            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].ButtonText = button.Text;
            this.list[button].EnableStyle = enableStyle;
            SetButtonStyle(button);
        }

        private void SetButtonStyle(SimpleButton button)
        {
            if (!this.list.ContainsKey(button))
                return;
            var para = this.list[button];
            if (!para.EnableStyle)
                return;
            button.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            switch (para.ButtonStyleKind)
            {
                case ButtonStyleKind.AddWithLargeImage:
                case ButtonStyleKind.AddWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnAdd : para.ButtonText;
                    break;
                case ButtonStyleKind.CopyAddWithLargeImage:
                case ButtonStyleKind.CopyAddWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnCopyAdd : para.ButtonText;
                    break;
                case ButtonStyleKind.EditWithLargeImage:
                case ButtonStyleKind.EditWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnEdit : para.ButtonText;
                    break;
                case ButtonStyleKind.DeleteWithLargeImage:
                case ButtonStyleKind.DeleteWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnDelete : para.ButtonText;
                    break;
                case ButtonStyleKind.OKWithLargeImage:
                case ButtonStyleKind.OKWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnOK : para.ButtonText;
                    break;
                case ButtonStyleKind.CancelWithLargeImage:
                case ButtonStyleKind.CancelWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnCancel : para.ButtonText;
                    break;
                case ButtonStyleKind.SaveWithLargeImage:
                case ButtonStyleKind.SaveWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnSave : para.ButtonText;
                    break;
                case ButtonStyleKind.CloseWithLargeImage:
                case ButtonStyleKind.CloseWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnClose : para.ButtonText;
                    break;
                case ButtonStyleKind.KindWithLargeImage:
                case ButtonStyleKind.KindWithSmallImage:
                    button.Text = para.UseDefaultText ? FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnKind : para.ButtonText;
                    break;
                default:
                    throw new Exception(FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.ErrorButtonStyle);
            }
            switch (para.ButtonStyleKind)
            {
                case ButtonStyleKind.AddWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png");
                    break;
                case ButtonStyleKind.AddWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png");
                    break;
                case ButtonStyleKind.CopyAddWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_32x32.png");
                    break;
                case ButtonStyleKind.CopyAddWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png");
                    break;
                case ButtonStyleKind.EditWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png");
                    break;
                case ButtonStyleKind.EditWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png");
                    break;
                case ButtonStyleKind.DeleteWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_32x32.png");
                    break;
                case ButtonStyleKind.DeleteWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png");
                    break;
                case ButtonStyleKind.OKWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
                    break;
                case ButtonStyleKind.OKWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
                    break;
                case ButtonStyleKind.CancelWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png");
                    break;
                case ButtonStyleKind.CancelWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png");
                    break;
                case ButtonStyleKind.SaveWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_32x32.png");
                    break;
                case ButtonStyleKind.SaveWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png");
                    break;
                case ButtonStyleKind.CloseWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_32x32.png");
                    break;
                case ButtonStyleKind.CloseWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png");
                    break;
                case ButtonStyleKind.KindWithLargeImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/Grid/cards_32x32.png");
                    break;
                case ButtonStyleKind.KindWithSmallImage:
                    button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/cards_16x16.png");
                    break;
                default:
                    throw new Exception(FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.ErrorButtonStyle);
            }
        }

        private EditButtonStylePara GetDefaultPara()
        {
            return new EditButtonStylePara()
            {
                ButtonStyleKind = ButtonStyleKind.AddWithLargeImage,
                EnableStyle = false,
                UseDefaultText = true                
                 
            };
        }
    }
    internal class EditButtonStylePara
    {
        private ButtonStyleKind buttonStyleKind = ButtonStyleKind.AddWithLargeImage;
        public ButtonStyleKind ButtonStyleKind
        {
            get
            {
                return buttonStyleKind;
            }
            set
            {
                buttonStyleKind = value;
            }
        }
        private bool enableStyle = false;
        public bool EnableStyle
        {
            get
            {
                return enableStyle;
            }
            set
            {
                enableStyle = value;
            }
        }
        private bool useDefaultText = true;
        public bool UseDefaultText
        {
            get
            {
                return useDefaultText;
            }
            set
            {
                useDefaultText = value;
            }
        }
        private string buttontext = string.Empty;
        public string ButtonText
        {
            get
            {
                return buttontext;
            }
            set
            {
                buttontext = value;
            }
        }
    }
    public enum ButtonStyleKind
    {
        AddWithLargeImage,
        AddWithSmallImage,
        CopyAddWithLargeImage,
        CopyAddWithSmallImage,
        EditWithLargeImage,
        EditWithSmallImage,
        DeleteWithLargeImage,
        DeleteWithSmallImage,
        OKWithLargeImage,
        OKWithSmallImage,
        CancelWithLargeImage,
        CancelWithSmallImage,
        SaveWithLargeImage,
        SaveWithSmallImage,
        CloseWithLargeImage,
        CloseWithSmallImage,
        KindWithLargeImage,
        KindWithSmallImage,
    }
}
