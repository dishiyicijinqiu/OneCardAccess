using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("鼠标所在列快速查找")]
    [ProvideProperty("EnableFocusedColumnQuickQuery", typeof(TreeList))]
    public partial class TreeListQuickFindStyle : Component, IExtenderProvider
    {
        private Dictionary<TreeList, bool> TreeListList = null;
        public TreeListQuickFindStyle()
        {
            InitializeComponent();
            TreeListList = new Dictionary<TreeList, bool>();
        }

        public TreeListQuickFindStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            TreeListList = new Dictionary<TreeList, bool>();
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is TreeList);
        }

        [Category("扩展")]
        [Description("是否在鼠标所在列快速查找")]
        public bool GetEnableFocusedColumnQuickQuery(TreeList treelist)
        {
            if (TreeListList.ContainsKey(treelist))
            {
                return (bool)TreeListList[treelist];
            }
            return false;
        }
        public void SetEnableFocusedColumnQuickQuery(TreeList treelist, bool isEnable)
        {
            if (!TreeListList.ContainsKey(treelist))
            {
                TreeListList.Add(treelist, isEnable);
            }
            else
            {
                TreeListList[treelist] = isEnable;
            }
            treelist.KeyPress -= treeList_KeyPress;
            if (isEnable)
            {
                treelist.KeyPress += treeList_KeyPress;
            }
        }

        private void treeList_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar > 31)
            {
                var treelist = sender as TreeList;
                string fullName = treelist.FindForm().GetType().FullName + "." + treelist.Name;
                string lastInput = MemoryCacheEx.GetCacheItem<string>(fullName, new Func<string>(() =>
                     {
                         return string.Empty;
                     }), new TimeSpan(0, 0, 1));
                MemoryCacheEx.RemoveCache(fullName);
                string nowInput = MemoryCacheEx.GetCacheItem<string>(fullName, new Func<string>(() =>
                    {
                        return lastInput + e.KeyChar.ToString(); ;
                    }), new TimeSpan(0, 0, 1));

                TreeListOperationFindNodeByText op = new TreeListOperationFindNodeByText(treelist.FocusedColumn, lastInput + e.KeyChar.ToString());
                treelist.NodesIterator.DoOperation(op);
                if (op.Node != null)
                    treelist.FocusedNode = op.Node;
            }
        }

        internal class TreeListOperationFindNodeByText : TreeListOperation
        {
            private TreeListNode foundNode;
            private TreeListColumn column;
            private string substr;
            public TreeListOperationFindNodeByText(TreeListColumn column, string substr)
            {
                this.foundNode = null;
                this.column = column;
                this.substr = substr;
            }
            public override void Execute(TreeListNode node)
            {
                string s = node[column].ToString();
                if (s.StartsWith(substr))
                    this.foundNode = node;
            }
            public override bool NeedsVisitChildren(TreeListNode node) { return foundNode == null; }
            public TreeListNode Node { get { return foundNode; } }
        }

        static class MemoryCacheEx
        {
            private static readonly Object _locker = new object();

            public static T GetCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
            {
                if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
                if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
                if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

                if (MemoryCache.Default[key] == null)
                {
                    lock (_locker)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            var resultValue = cachePopulate();
                            if (resultValue != null)
                            {
                                var item = new CacheItem(key, resultValue);
                                var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                                MemoryCache.Default.Add(item, policy);
                            }
                        }
                    }
                }
                return (T)MemoryCache.Default[key];
            }
            public static T GetCacheItem<T>(String key, Func<T> cachePopulate)
            {
                return GetCacheItem<T>(key, cachePopulate, null, DateTime.MaxValue);
            }
            public static bool HasCache(string key)
            {
                if (MemoryCache.Default[key] != null)
                    return true;
                return false;
            }
            public static T GetCache<T>(string Key)
            {
                return (T)MemoryCache.Default[Key];
            }
            public static void RemoveCache(String key)
            {
                if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
                if (MemoryCache.Default[key] != null)
                {
                    lock (_locker)
                    {
                        if (MemoryCache.Default[key] != null)
                        {
                            MemoryCache.Default.Remove(key);
                        }
                    }
                }
            }
            public static void ClearCache()
            {
                ObjectCache cache = MemoryCache.Default;
                System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>
                    items = cache.AsEnumerable();
                foreach (KeyValuePair<string, object> item in items)
                {
                    MemoryCache.Default.Remove(item.Key);
                }
                //MemoryCache.Default.Trim(100);
            }
            private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
            {
                var policy = new CacheItemPolicy();

                if (absoluteExpiration.HasValue)
                {
                    policy.AbsoluteExpiration = absoluteExpiration.Value;
                }
                else if (slidingExpiration.HasValue)
                {
                    policy.SlidingExpiration = slidingExpiration.Value;
                }

                policy.Priority = CacheItemPriority.Default;

                return policy;
            }

        }
    }
}
