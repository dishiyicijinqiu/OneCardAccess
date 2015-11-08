using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using DevExpress.XtraEditors;
namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Helper
{
    public class PopupContainerEditPopupListBoxHelper
    {
        public PopupContainerEditPopupListBoxHelper(RepositoryItemPopupContainerEdit popupContainerEdit)
        {
            RepositoryItem = popupContainerEdit;
            RepositoryItem.Popup += RepositoryItem_Popup;
            PopuControl = CreatePopuControl();
            ListBox = CreateListBoxControl();
            ListBox.SelectionMode = System.Windows.Forms.SelectionMode.One;
            ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            ListBox.Click += ListBox_Click;
            PopuControl.Controls.Add(ListBox);
            RepositoryItem.TextEditStyle = TextEditStyles.Standard;
            RepositoryItem.PopupControl = PopuControl;
            SubscribeEditor();
        }

        void RepositoryItem_Popup(object sender, System.EventArgs e)
        {
            var popupContainerEdit = ((DevExpress.XtraEditors.Repository.RepositoryItemPopupBase)(RepositoryItem)).OwnerEdit;
            ListBox.SelectedValue = popupContainerEdit.EditValue;
        }
        void ListBox_Click(object sender, System.EventArgs e)
        {
            int itemindex = ListBox.IndexFromPoint(ListBox.PointToClient(System.Windows.Forms.Control.MousePosition));
            if (itemindex < 0)
                return;
            var popupContainerEdit = ((DevExpress.XtraEditors.Repository.RepositoryItemPopupBase)(RepositoryItem)).OwnerEdit;
            popupContainerEdit.EditValue = GetSelectedValue();
            popupContainerEdit.ClosePopup();
        }


        #region Methods
        private void SubscribeEditor()
        {
            RepositoryItem.QueryResultValue += new QueryResultValueEventHandler(RepositoryItem_QueryResultValue);
            RepositoryItem.QueryDisplayText += new QueryDisplayTextEventHandler(RepositoryItem_QueryDisplayText);
        }
        void RepositoryItem_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            if (this.autoBind)
            {
                if (ListBox.SelectedIndices.Count > 0)
                {
                    e.DisplayText = GetSelectedText();
                }
            }
        }
        void RepositoryItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            if (this.autoBind)
            {
                e.Value = GetSelectedValue();
            }
        }

        private string GetSelectedText()
        {
            if (ListBox.SelectedIndices.Count > 0)
            {
                return ListBox.GetItemText(ListBox.SelectedIndices[0]);
            }
            return string.Empty;
        }

        private object GetSelectedValue()
        {
            if (ListBox.SelectedIndices.Count > 0)
            {
                return ListBox.GetItemValue(ListBox.SelectedIndices[0]);
            }
            return null;
        }

        protected virtual PopupContainerControl CreatePopuControl()
        {
            return new PopupContainerControl();
        }

        protected virtual ListBoxControl CreateListBoxControl()
        {
            return new ListBoxControl();
        }
        #endregion

        #region Properties
        public string ValueMember
        {
            get
            {
                return ListBox.ValueMember;
            }
            set
            {
                ListBox.ValueMember = value;
            }
        }
        public string DisplayMember
        {
            get { return ListBox.DisplayMember; }
            set
            {
                ListBox.DisplayMember = value;
            }
        }
        public TextEditStyles TextEditStyle
        {
            get
            {
                return this.RepositoryItem.TextEditStyle;
            }
            set
            {
                this.RepositoryItem.TextEditStyle = value;
            }
        }


        public object DataSource
        {
            get { return ListBox.DataSource; }
            set { ListBox.DataSource = value; }
        }

        public ListBoxItemCollection Items
        {
            get
            {
                return ListBox.Items;
            }
        }
        private bool autoBind = false;
        public bool AutoBind
        {
            get
            {
                return autoBind;
            }
            set
            {
                autoBind = value;
            }
        }
        private bool closeOnClick = true;
        public bool CloseOnClick
        {
            get
            {
                return closeOnClick;
            }
            set
            {
                closeOnClick = value;
            }
        }

        public ListBoxControl ListBox { get; private set; }
        public PopupContainerControl PopuControl { get; private set; }
        public RepositoryItemPopupContainerEdit RepositoryItem { get; private set; }
        #endregion
    }
}
