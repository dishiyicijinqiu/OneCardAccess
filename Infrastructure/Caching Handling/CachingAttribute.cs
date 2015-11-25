using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Caching_Handling
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CachingAttribute : HandlerAttribute
    {
        /// <summary>
        /// 初始化一个新的<c>CachingAttribute</c>类型。
        /// </summary>
        /// <param name="method">缓存方式。</param>
        public CachingAttribute(bool cachingenable)
        {
            CachingEnable = cachingenable;
            Hours = Minutes = Seconds = 0;
            Method = CachingMethod.Get;
            CorrespondingMethodNames = null;
            Force = false;
        }
        public bool CachingEnable { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        /// <summary>
        /// 获取或设置缓存方式。
        /// </summary>
        public CachingMethod Method { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值表示当缓存方式为Put时，是否强制将值写入缓存中。
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// 获取或设置与当前缓存方式相关的方法名称。注：此参数仅在缓存方式为Remove时起作用。
        /// </summary>
        public string[] CorrespondingMethodNames { get; set; }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CachingCallHandler(this.Hours, this.Minutes, this.Seconds, this.CachingEnable, this.Method, this.Force, this.CorrespondingMethodNames) { Order = this.Order, };
        }
    }

    public enum CachingMethod
    {
        /// <summary>
        /// 表示需要从缓存中获取对象。如果缓存中不存在所需的对象，系统则会调用实际的方法获取对象，
        /// 然后将获得的结果添加到缓存中。
        /// </summary>
        Get,
        /// <summary>
        /// 表示需要将对象存入缓存。此方式会调用实际方法以获取对象，然后将获得的结果添加到缓存中，
        /// 并直接返回方法的调用结果。
        /// </summary>
        Put,
        /// <summary>
        /// 表示需要将对象从缓存中移除。
        /// </summary>
        Remove,
    }

    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class CachingCallHandler : ICallHandler
    {
        int Hours = 0; int Minutes = 0; int Seconds = 0; bool CachingEnable = true; CachingMethod CachingMethod = CachingMethod.Get; bool Force = false; string[] CorrespondingMethodNames;
        public int Order { get; set; }

        public CachingCallHandler(int hours = 0, int minutes = 0, int seconds = 0, bool cachingenable = true,
            CachingMethod cachingmethod = CachingMethod.Get, bool force = false, string[] correspondingmethodnames = null)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            CachingEnable = cachingenable;
            CachingMethod = cachingmethod;
            Force = force;
            CorrespondingMethodNames = correspondingmethodnames;
        }

        public CachingCallHandler()
        {
        }

        /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public CachingCallHandler(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            this.Hours = string.IsNullOrEmpty(attributes["Hours"]) ? 0 : Convert.ToInt32(attributes["Hours"]);
            this.Minutes = string.IsNullOrEmpty(attributes["Minutes"]) ? 0 : Convert.ToInt32(attributes["Minutes"]);
            this.Seconds = string.IsNullOrEmpty(attributes["Seconds"]) ? 0 : Convert.ToInt32(attributes["Seconds"]);
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (CachingEnable)
            {
                var method = input.MethodBase;
                var key = method.DeclaringType.FullName + "." + method.Name; ;
                var valKey = GetValueKey(input);
                switch (CachingMethod)
                {
                    case CachingMethod.Get:
                        #region Get
                        try
                        {
                            bool isexists = false;
                            var obj = ExtraCacheManager.Instance.TryGet(key, valKey, ref isexists, this.Hours, this.Minutes, this.Seconds);
                            if (isexists)
                            {
                                var arguments = new object[input.Arguments.Count];
                                input.Arguments.CopyTo(arguments, 0);
                                return input.CreateMethodReturn(obj);
                            }
                            else
                            {
                                var methodReturn = getNext().Invoke(input, getNext);
                                ExtraCacheManager.Instance.Put(key, valKey, methodReturn.ReturnValue, this.Hours, this.Minutes, this.Seconds, true);
                                return methodReturn;
                            }
                        }
                        catch (Exception ex)
                        {
                            return input.CreateMethodReturn(ex);
                        }
                        #endregion
                    case CachingMethod.Put:
                        #region Put
                        try
                        {
                            var methodReturn = getNext().Invoke(input, getNext);
                            if (Force)
                            {
                                ExtraCacheManager.Instance.Put(key, valKey, methodReturn.ReturnValue, this.Hours, this.Minutes, this.Seconds, true);
                            }
                            else
                            {
                                ExtraCacheManager.Instance.Add(key, valKey, methodReturn.ReturnValue, this.Hours, this.Minutes, this.Seconds);
                            }
                            return methodReturn;
                        }
                        catch (Exception ex)
                        {
                            return input.CreateMethodReturn(ex);
                        }
                        #endregion
                    case CachingMethod.Remove:
                        #region Remove
                        try
                        {
                            if (CorrespondingMethodNames != null && CorrespondingMethodNames.Length > 0)
                                foreach (var removeKey in CorrespondingMethodNames)
                                {
                                    ExtraCacheManager.Instance.Clear(removeKey);
                                }
                            var methodReturn = getNext().Invoke(input, getNext);
                            return methodReturn;
                        }
                        catch (Exception ex)
                        {
                            return input.CreateMethodReturn(ex);
                        }
                        #endregion
                    default:
                        break;
                }
            }
            return getNext().Invoke(input, getNext);
        }
        #region Private Methods
        /// <summary>
        /// 根据指定的<see cref="CachingAttribute"/>以及<see cref="IMethodInvocation"/>实例，
        /// 获取与某一特定参数值相关的键名。
        /// </summary>
        /// <param name="input"><see cref="IMethodInvocation"/>实例。</param>
        /// <returns>与某一特定参数值相关的键名。</returns>
        private string GetValueKey(IMethodInvocation input)
        {
            switch (CachingMethod)
            {
                //产生一个针对特定参数值的键名
                case CachingMethod.Remove:
                case CachingMethod.Get:
                case CachingMethod.Put:
                    if (input.Arguments != null && input.Arguments.Count > 0)
                    {
                        var sb = new StringBuilder();
                        for (int i = 0; i < input.Arguments.Count; i++)
                        {
                            var argument = input.Arguments[i];
                            if (argument == null)
                            {
                                sb.Append("null");
                            }
                            else
                            {
                                string valuekeystring;
                                if (argument is IArgumentValueKey)
                                    valuekeystring = (argument as IArgumentValueKey).CreateValueKey();
                                else
                                    valuekeystring = argument.ToString();
                                if (string.IsNullOrEmpty(valuekeystring))
                                    sb.Append(string.Empty);
                                else
                                    sb.Append(GetMd5(valuekeystring));
                            }
                            sb.Append("_");
                        }
                        return GetMd5(sb.ToString());
                    }
                    else
                    {
                        return GetMd5("null");
                    }
                default:
                    throw new InvalidOperationException("无效的缓存方式。");
            }
        }
        #endregion

        public string GetMd5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string a = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str)));
            a = a.Replace("-", "");
            return a;
        }
    }
    public interface IArgumentValueKey
    {
        string CreateValueKey();
    }
    /// <summary>
    /// 缓存持久化工厂类
    /// </summary>
    public sealed class ExtraCacheManager
    {
        object lockobj = new object();
        private static readonly ExtraCacheManager _instance = new ExtraCacheManager();
        private readonly ICacheManager _cacheManager = CacheFactory.GetCacheManager();
        #region Public Properties
        /// <summary>
        /// 获取<c>CacheManager</c>类型的单件（Singleton）实例。
        /// </summary>
        public static ExtraCacheManager Instance
        {
            get { return _instance; }
        }
        #endregion

        private void InterAdd(string key, string valKey, object value, int hours = 0, int minutes = 0, int seconds = 0)
        {
            Dictionary<string, object> dict = null;
            if (_cacheManager.Contains(key))
            {
                dict = (Dictionary<string, object>)_cacheManager[key];
                dict[valKey] = value;
            }
            else
            {
                dict = new Dictionary<string, object>();
                dict.Add(valKey, value);
            }
            if (hours != 0 || minutes != 0 || seconds != 0)
                _cacheManager.Add(key, dict, CacheItemPriority.Normal, new RemoveCacheItemRefreshAction(), new SlidingTime(new TimeSpan(hours, minutes, seconds)));
            else
                _cacheManager.Add(key, dict);
        }
        private void InterRemove(string key, string valkey)
        {
            Dictionary<string, object> dict = null;
            if (_cacheManager.Contains(key))
            {
                dict = (Dictionary<string, object>)_cacheManager[key];
                dict.Remove(valkey);
            }
        }
        private void InterClear(string key)
        {
            if (_cacheManager.Contains(key))
                _cacheManager.Remove(key);
        }
        private void InterPut(string key, string valKey, object value, int hours = 0, int minutes = 0, int seconds = 0, bool force = false)
        {
            if (force)
            {
                InterRemove(key, valKey);
            }
            InterAdd(key, valKey, value, hours, minutes, seconds);
        }
        private object InterGet(string key, string valKey, int hours = 0, int minutes = 0, int seconds = 0)
        {
            if (_cacheManager.Contains(key))
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)_cacheManager[key];
                if (dict != null && dict.ContainsKey(valKey))
                {
                    this.InterAdd(key, valKey, dict[valKey], hours, minutes, seconds);
                    return dict[valKey];
                }
                else
                    return null;
            }
            return null;
        }
        #region ICacheProvider Members
        /// <summary>
        /// 向缓存中添加一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Add(string key, string valKey, object value, int hours = 0, int minutes = 0, int seconds = 0)
        {
            lock (lockobj)
            {
                InterAdd(key, valKey, value, hours, minutes, seconds);
            }
        }
        /// <summary>
        /// 向缓存中更新一个对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
        /// <param name="value">需要缓存的对象。</param>
        public void Put(string key, string valKey, object value, int hours = 0, int minutes = 0, int seconds = 0, bool force = false)
        {
            lock (lockobj)
            {
                InterPut(key, valKey, value, hours, minutes, seconds, force);
            }
        }
        /// <summary>
        /// 从缓存中读取对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        /// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
        /// <returns>被缓存的对象。</returns>
        public object Get(string key, string valKey, int hours = 0, int minutes = 0, int seconds = 0)
        {
            lock (lockobj)
            {
                return InterGet(key, valKey, hours, minutes, seconds);
            }
        }
        /// <summary>
        /// 从缓存中移除对象。
        /// </summary>
        /// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
        public void Remove(string key, string valkey)
        {
            lock (lockobj)
            {
                InterRemove(key, valkey);
            }
        }

        public void Clear(string key)
        {
            lock (lockobj)
            {
                this.InterClear(key);
            }
        }
        public object TryGet(string key, string valKey, ref bool isexists, int hours = 0, int minutes = 0, int seconds = 0)
        {
            lock (lockobj)
            {
                isexists = _cacheManager.Contains(key);
                if (isexists)
                {
                    Dictionary<string, object> dict = (Dictionary<string, object>)_cacheManager[key];
                    if (dict != null && dict.ContainsKey(valKey))
                    {
                        return dict[valKey];
                    }
                    else
                    {
                        isexists = false;
                        return null;
                    }
                }
                else
                    return null;
            }
        }
        #endregion

        /// <summary>
        /// 自定义缓存刷新操作
        /// </summary>
        [Serializable]
        public class RemoveCacheItemRefreshAction : ICacheItemRefreshAction
        {
            #region ICacheItemRefreshAction 成员
            /// <summary>
            /// 自定义刷新操作
            /// </summary>
            /// <param name="removedKey">移除的键</param>
            /// <param name="expiredValue">过期的值</param>
            /// <param name="removalReason">移除理由</param>
            void ICacheItemRefreshAction.Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
            {
            }
            #endregion
        }

    }
}
