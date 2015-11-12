using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    internal static class MenuHelper
    {
        static bool isloadmenu = false;
        static BarItem[] FixItems;
        static MenuEntity[] menus;
        #region LoadMenu
        //internal static void ReLoadMenu(RibbonControl ribbon)
        //{
        //    menus = null;
        //    LoadMenu(ribbon);
        //}
        internal static void LoadMenu(RibbonControl ribbon)
        {
            if (isloadmenu)
                return;
            if (FixItems == null)
                FixItems = ribbon.Items.Cast<BarItem>().ToArray();
            if (menus == null)
                menus = ServiceProxyFactory.Create<IMenuService>().GetAllEntity();
            ribbon.Pages.Clear();
            for (int i = ribbon.Items.Count - 1; i >= 0; i--)
            {
                if (!FixItems.Contains(ribbon.Items[i]))
                    ribbon.Items.Remove(ribbon.Items[i]);
            }
            //ribbon.Items.Clear();
            List<RibbonPageHolder> ribbonpageholders = new List<RibbonPageHolder>();
            var rpageEntitys = menus.Where(t => t.MenuControl.ToLower() == "ribbonpage").ToList();
            foreach (var rpageEntity in rpageEntitys)
            {
                RibbonPageHolder ribbonpageholder = ConvertMenuEntityToRibbonPage(rpageEntity);
                if (ribbonpageholder != null)
                {
                    CreateRibbonPageGroupFromMenuEntity(ribbon, ribbonpageholder, rpageEntity);
                }
                ribbonpageholders.Add(ribbonpageholder);
            }
            var ribbonpages = ribbonpageholders.OrderBy(t => t.Order).Select(t => t.RibbonPage).ToArray();
            ribbon.Invoke(new Action(() =>
            {
                ribbon.Pages.AddRange(ribbonpages);
            }));
            isloadmenu = true;
        }

        #region CreateChilds
        static void CreateRibbonPageGroupFromMenuEntity(RibbonControl ribbon, RibbonPageHolder ribbonpageholder, MenuEntity entity)
        {
            if (ribbonpageholder == null || entity == null || ribbonpageholder.RibbonPage == null)
            {
                return;
            }
            List<RibbonPageGroupHolder> ribbonpagegroupholders = new List<RibbonPageGroupHolder>();
            var childEntitys = menus.Where(t => t.PNo == entity.MenuNo);
            RibbonPageGroupHolder ribbonpagegroupholder;
            foreach (var childEntity in childEntitys)
            {
                ribbonpagegroupholder = ConvertMenuEntityToRibbonPageGroup(childEntity);
                if (ribbonpagegroupholder != null)
                {
                    CreateBarSubItemFromMenuEntity(ribbon, ribbonpagegroupholder, childEntity);
                    CreateBarItemFromMenuEntity(ribbon, ribbonpagegroupholder, childEntity);
                    ribbonpagegroupholders.Add(ribbonpagegroupholder);
                }
            }
            var groups = ribbonpagegroupholders.OrderBy(t => t.Order).Select(t => t.RibbonPageGroup).ToArray();
            ribbonpageholder.RibbonPage.Groups.AddRange(groups);
        }

        static void CreateBarItemFromMenuEntity(RibbonControl ribbon, RibbonPageGroupHolder ribbonpagegroupholder, MenuEntity entity)
        {
            if (ribbonpagegroupholder == null || entity == null || ribbonpagegroupholder.RibbonPageGroup == null)
                return;
            List<BarItemHolder> baritemholders = new List<BarItemHolder>();
            BarItemHolder baritemholder;
            var childEntitys = menus.Where(t => t.PNo == entity.MenuNo);
            foreach (var childEntity in childEntitys)
            {
                baritemholder = ConvertMenuEntityToBarItem(childEntity);
                if (baritemholder != null)
                {
                    ribbon.Items.Add(baritemholder.BarItem);
                    baritemholders.Add(baritemholder);
                }
            }
            var baritems = baritemholders.OrderBy(t => t.Order).Select(t => t.BarItem).ToArray();
            ribbonpagegroupholder.RibbonPageGroup.ItemLinks.AddRange(baritems);
        }

        static void CreateBarSubItemFromMenuEntity(RibbonControl ribbon, RibbonPageGroupHolder ribbonpagegroupholder, MenuEntity entity)
        {
            if (ribbonpagegroupholder == null || entity == null || ribbonpagegroupholder.RibbonPageGroup == null)
                return;
            var childEntitys = menus.Where(t => t.PNo == entity.MenuNo);
            List<BarSubItemHolder> barsubitemholders = new List<BarSubItemHolder>();
            BarSubItemHolder barsubitemholder;
            foreach (var childEntity in childEntitys)
            {
                barsubitemholder = ConvertMenuEntityToBarSubItem(childEntity);
                if (barsubitemholder != null)
                {
                    CreateBarItemFromMenuEntity(ribbon, barsubitemholder, childEntity);
                    barsubitemholders.Add(barsubitemholder);
                }
            }
            var barsubitems = barsubitemholders.OrderBy(t => t.Order).Select(t => t.BarSubItem).ToArray();
            ribbonpagegroupholder.RibbonPageGroup.ItemLinks.AddRange(barsubitems);
        }

        static void CreateBarItemFromMenuEntity(RibbonControl ribbon, BarSubItemHolder barsubitemholder, MenuEntity entity)
        {
            if (barsubitemholder == null || entity == null || barsubitemholder.BarSubItem == null)
                return;
            List<BarItemHolder> barsubitemholders = new List<BarItemHolder>();
            var childEntitys = menus.Where(t => t.PNo == entity.MenuNo);
            BarSubItemHolder cbarsubitemholder;
            BarItemHolder baritemholder;
            foreach (var childEntity in childEntitys)
            {
                cbarsubitemholder = ConvertMenuEntityToBarSubItem(childEntity);
                if (cbarsubitemholder != null)
                {
                    CreateBarItemFromMenuEntity(ribbon, cbarsubitemholder, childEntity);
                    barsubitemholders.Add(new BarItemHolder() { Order = cbarsubitemholder.Order, BarItem = cbarsubitemholder.BarSubItem });
                }
                else
                {
                    baritemholder = ConvertMenuEntityToBarItem(childEntity);
                    if (baritemholder != null)
                    {
                        ribbon.Items.Add(baritemholder.BarItem);
                        barsubitemholders.Add(baritemholder);
                    }
                }
            }
            var baritems = barsubitemholders.OrderBy(t => t.Order).Select(t => t.BarItem).ToArray();
            barsubitemholder.BarSubItem.ItemLinks.AddRange(baritems);
        }
        #endregion
        #region MenuEntityToHolder
        static RibbonPageHolder ConvertMenuEntityToRibbonPage(MenuEntity entity)
        {
            if (entity.MenuControl.ToLower() != "ribbonpage")
                return null;
            return new RibbonPageHolder()
            {
                Order = entity.Order,
                RibbonPage = new RibbonPage()
                {
                    Name = entity.MenuNo,
                    Text = entity.MenuName
                }
            };
        }

        static RibbonPageGroupHolder ConvertMenuEntityToRibbonPageGroup(MenuEntity entity)
        {
            if (entity.MenuControl.ToLower() != "ribbonpagegroup")
                return null;
            return new RibbonPageGroupHolder()
            {
                Order = entity.Order,
                RibbonPageGroup = new RibbonPageGroup()
                {
                    Name = entity.MenuNo,
                    Text = entity.MenuName
                }
            };
        }

        static BarSubItemHolder ConvertMenuEntityToBarSubItem(MenuEntity entity)
        {
            if (entity.MenuControl.ToLower() != "barsubitem")
                return null;
            var barsubitem = new BarSubItem()
            {
                Name = entity.MenuNo,
                Caption = entity.MenuName,
                RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
                    | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText))))
            };
            barsubitem.ItemClick += barItem_ItemClick;
            if (!string.IsNullOrWhiteSpace(entity.Glyph))
            {
                var image = FengSharp.OneCardAccess.Infrastructure.WinForm.Resources.ResourceHelper.GetResource<System.Drawing.Image>(entity.Glyph);
                if (image != null)
                    barsubitem.Glyph = image;
            }
            barsubitem.Tag = GetClickPara(entity.OnClick);
            return new BarSubItemHolder()
            {
                Order = entity.Order,
                BarSubItem = barsubitem
            };
        }

        static BarItemHolder ConvertMenuEntityToBarItem(MenuEntity entity)
        {
            if (entity.MenuControl.ToLower() != "baritem")
                return null;
            var baritem = new BarButtonItem()
            {
                Name = entity.MenuNo,
                Caption = entity.MenuName,
                RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
                    | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText))))
            };
            if (!string.IsNullOrWhiteSpace(entity.Glyph))
            {
                var image = FengSharp.OneCardAccess.Infrastructure.WinForm.Resources.ResourceHelper.GetResource<System.Drawing.Image>(entity.Glyph);
                if (image != null)
                    baritem.Glyph = image;
            }
            baritem.Tag = GetClickPara(entity.OnClick);
            baritem.ItemClick += barItem_ItemClick;
            return new BarItemHolder()
            {
                Order = entity.Order,
                BarItem = baritem
            };
        }
        #endregion
        #endregion
        private static ClickPara GetClickPara(string strOnClickInfo)
        {
            if (string.IsNullOrWhiteSpace(strOnClickInfo))
                return null;
            var para = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(strOnClickInfo).ToArray<object>().Select(t => (t as JProperty)).ToList();
            if (para.Count < 2)
                return null;
            string strClassPath = para[0].Value.ToString();
            string strMethodName = para[1].Value.ToString();
            var type = System.Type.GetType(strClassPath);
            if (type == null)
                return null;
            Type[] argtypes = para.Skip(2).Select(t => Type.GetType(t.Name)).ToArray();
            var Method = type.GetMethod(strMethodName, argtypes);
            if (Method == null)
                return null;
            return new ClickPara(type, Method, argtypes);
        }
        #region 菜单按钮事件
        static void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var barItem = e.Item as BarItem;
                if (barItem == null || barItem.Tag == null)
                    return;
                var ClickPara = barItem.Tag as ClickPara;
                if (ClickPara == null)
                    return;
                try
                {
                    var obj = System.Activator.CreateInstance(ClickPara.Type);
                    ClickPara.MethodInfo.Invoke(obj, ClickPara.MethodPara);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    throw new Exception(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.LoadFormFailure);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        #endregion
        class RibbonPageHolder
        {
            public int Order { get; set; }
            public RibbonPage RibbonPage { get; set; }
        }
        class RibbonPageGroupHolder
        {
            public int Order { get; set; }
            public RibbonPageGroup RibbonPageGroup { get; set; }
        }
        class BarSubItemHolder
        {
            public int Order { get; set; }
            public BarSubItem BarSubItem { get; set; }
        }
        class BarItemHolder
        {
            public int Order { get; set; }
            public BarItem BarItem { get; set; }
        }
        class ClickPara
        {
            public Type Type { get; set; }
            public MethodInfo MethodInfo { get; set; }
            public object[] MethodPara { get; set; }
            public ClickPara(Type type, MethodInfo methodinfo, object[] methodpara)
            {
                Type = type;
                MethodInfo = methodinfo;
                MethodPara = methodpara;
            }
        }

        internal static void SetUserMenu(RibbonControl ribbonControl)
        {
            AuthIdentity authidentity = AuthPrincipal.CurrentAuthPrincipal.Identity as AuthIdentity;
            var usermenus = ServiceProxyFactory.Create<IMenuService>().GetUserMenuNos(authidentity.UserId);

            for (int i = ribbonControl.Items.Count - 1; i >= 0; i--)
            {
                var item = ribbonControl.Items[i];
                if (!FixItems.Contains(item))
                {
                    if (usermenus.Contains(item.Name))
                        item.Visibility = BarItemVisibility.Always;
                    else
                        item.Visibility = BarItemVisibility.Never;
                    foreach (BarItemLink barItemLink in item.Links)
                    {
                        barItemLink.Visible = item.Visibility == BarItemVisibility.Always;
                    }
                }
            }

            foreach (RibbonPage page in ribbonControl.Pages)
            {
                foreach (RibbonPageGroup group in page.Groups)
                {
                    int visiblecount = group.ItemLinks.Cast<DevExpress.XtraBars.BarButtonItemLink>().Count(t => t.Visible);
                    if (visiblecount > 0)
                    {
                        group.Visible = true;
                    }
                    else
                    {
                        group.Visible = false;
                    }
                }
            }


            foreach (RibbonPage page in ribbonControl.Pages)
            {
                int visiblecount = page.Groups.Cast<RibbonPageGroup>().Count(t => t.Visible);
                if (visiblecount > 0)
                {
                    page.Visible = true;
                }
                else
                {
                    page.Visible = false;
                }
            }
        }
    }
}
