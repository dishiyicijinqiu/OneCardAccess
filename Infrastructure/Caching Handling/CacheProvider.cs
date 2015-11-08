using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Caching_Handling
{
    public static class CacheProvider
    {
        public static object Get(string key, string cacheManagerName = null)
        {
            ICacheManager _cacheManager = GetCacheManager(cacheManagerName);
            return _cacheManager[key];
        }
        public static T Get<T>(string key, string cacheManagerName = null)
        {
            return (T)(Get(key, cacheManagerName));
        }
        public static void Add(string key, object value, string cacheManagerName = null)
        {
            Add(key, value, TimeSpan.Zero, null, cacheManagerName);
        }

        public static void Add(string key, object value, TimeSpan timespan, ICacheItemRefreshAction icacheitemrefreshaction = null, string cacheManagerName = null)
        {
            ICacheManager _cacheManager = GetCacheManager(cacheManagerName);
            if (timespan == TimeSpan.Zero)
            {
                _cacheManager.Add(key, value);
            }
            else
            {
                _cacheManager.Add(key, value, CacheItemPriority.Normal, icacheitemrefreshaction, new SlidingTime(timespan));
            }
        }
        public static void Remove(string key, string cacheManagerName = null)
        {
            ICacheManager _cacheManager = GetCacheManager(cacheManagerName);
            _cacheManager.Remove(key);
        }
        static ICacheManager GetCacheManager(string cacheManagerName = null)
        {
            ICacheManager _cacheManager;
            if (string.IsNullOrWhiteSpace(cacheManagerName))
                _cacheManager = CacheFactory.GetCacheManager();
            else
                _cacheManager = CacheFactory.GetCacheManager(cacheManagerName);
            return _cacheManager;
        }
    }
}
