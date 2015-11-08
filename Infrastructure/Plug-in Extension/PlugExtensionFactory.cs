using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace FengSharp.OneCardAccess.Infrastructure.Plug_in_Extension
{
    public class PluginExtension
    {
        public int Order { get; internal set; }
        public List<XmlNode> Data
        {
            get;
            internal set;
        }
    }
    public class PlugExtensionFactory
    {
        private const string ConfigName = "Manifest.xml";
        public static List<PluginExtension> GetExtensions(string extensionpoint)
        {
            List<PluginExtension> pluginextensions = new List<PluginExtension>();
            string pluginsPath = ApplicationConfig.PluginsPath;
            var dirs = System.IO.Directory.GetDirectories(System.IO.Path.GetFullPath(pluginsPath));
            foreach (var dir in dirs)
            {
                string configFile = Path.Combine(dir, ConfigName);
                if (File.Exists(configFile))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(configFile);
                    var node = xml.SelectSingleNode(string.Format("/configuration/Extension[@Point='{0}']", extensionpoint));
                    if (node != null)
                    {
                        PluginExtension pluginextension = new PluginExtension();
                        if (node.Attributes["Order"] == null)
                        {
                            pluginextension.Order = int.MaxValue;
                        }
                        else
                        {
                            if (node.Attributes["Order"].Value == null)
                                pluginextension.Order = int.MaxValue;
                            else
                                pluginextension.Order = Convert.ToInt32(node.Attributes["Order"].Value);
                        }
                        pluginextension.Data = new List<XmlNode>();
                        pluginextension.Data.AddRange(node.ChildNodes.Cast<XmlNode>());
                        pluginextensions.Add(pluginextension);
                    }
                }
            }
            return pluginextensions.OrderBy(t => t.Order).ToList();
        }
        public static List<string> GetConfigs()
        {
            List<string> plugineconfigs = new List<string>();
            string pluginsPath = System.Configuration.ConfigurationManager.AppSettings["pluginsPath"];
            if (string.IsNullOrWhiteSpace(pluginsPath))
                return plugineconfigs;
            var dirs = System.IO.Directory.GetDirectories(System.IO.Path.GetFullPath(pluginsPath));
            foreach (var dir in dirs)
            {
                string configFile = Path.Combine(dir, ConfigName);
                if (File.Exists(configFile))
                    plugineconfigs.Add(configFile);
            }
            return plugineconfigs;
        }
        public static void AppendPrivatePath()
        {
            string fullpath = System.IO.Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["pluginsPath"]);
            if (!Directory.Exists(fullpath))
                return;
            var dirs = System.IO.Directory.GetDirectories(fullpath);
            foreach (var dir in dirs)
            {
                AppDomain.CurrentDomain.AppendPrivatePath(dir);
            }
        }
    }
}
