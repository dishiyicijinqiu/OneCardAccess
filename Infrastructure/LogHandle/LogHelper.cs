using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public static class LogHelper
    {
        /// <summary>
        /// 获取数据库对象
        /// </summary>
        /// <param name="name">数据库实例名(默认name为空,调用默认数据库实例)</param>
        /// <returns>数据库对象</returns>
        public static LogWriter CreateLogWriter(string name = null)
        {
            return EnterpriseLibraryContainer.Current.GetInstance<LogWriter>(name);
        }
        private static void LogWriteMethod(Action<LogWriter> action, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                using (var logwrite = CreateLogWriter())
                {
                    action(logwrite);
                }
            }
            else
            {
                using (var logwrite = CreateLogWriter(name))
                {
                    action(logwrite);
                }
            }
        }
        public static void Write(object message, string category = "General", string title = null, TraceEventType severity = TraceEventType.Information, int priority = -1, string name = null)
        {
            LogWriteMethod((logwrite) =>
            {
                logwrite.Write(message, category, priority, 1, severity, title);
            }, name);
        }

        //public static void Write(object message, IEnumerable<string> categories, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, properties);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority);
        //    }, name);
        //}
        //public static void Write(object message, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, properties);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories);
        //    }, name);
        //}
        //public static void Write(object message, string category, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, properties);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority, properties);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority, int eventId, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority, eventId);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority, properties);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, int eventId, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority, eventId);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority, int eventId, TraceEventType severity, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority, eventId, severity);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, int eventId, TraceEventType severity, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority, eventId, severity);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority, int eventId, TraceEventType severity, string title, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority, eventId, severity, title);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, int eventId, TraceEventType severity, string title, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority, eventId, severity, title);
        //    }, name);
        //}
        //public static void Write(object message, IEnumerable<string> categories, int priority,
        //    int eventId, TraceEventType severity, string title, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, categories, priority, eventId, severity, title, properties);
        //    }, name);
        //}
        //public static void Write(object message, string category, int priority, int eventId, TraceEventType severity, string title, IDictionary<string, object> properties, string name = null)
        //{
        //    LogWriteMethod((logwrite) =>
        //    {
        //        logwrite.Write(message, category, priority, eventId, severity, title, properties);
        //    }, name);
        //}
    }
}
