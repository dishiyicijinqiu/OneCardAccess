using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Versioning;
using System.Configuration.Internal;
using System.Diagnostics.CodeAnalysis;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    public class MyLocalFileSettingsProvider : SettingsProvider, IApplicationSettingsProvider
    {
        private string _appName = String.Empty;
        private ClientSettingsStore _store = null;
        private string _prevLocalConfigFileName = null;
        private string _prevRoamingConfigFileName = null;
        private XmlEscaper _escaper = null;

        /// <devdoc>
        ///     Abstract SettingsProvider property.
        /// </devdoc>
        public override string ApplicationName
        {
            get
            {
                return _appName;
            }
            set
            {
                _appName = value;
            }
        }

        private XmlEscaper Escaper
        {
            get
            {
                if (_escaper == null)
                {
                    _escaper = new XmlEscaper();
                }

                return _escaper;
            }
        }

        /// <devdoc>
        ///     We maintain a single instance of the ClientSettingsStore per instance of provider.
        /// </devdoc>
        private ClientSettingsStore Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new ClientSettingsStore();
                }

                return _store;
            }
        }

        /// <devdoc>
        ///     Abstract ProviderBase method.
        /// </devdoc>
        public override void Initialize(string name, NameValueCollection values)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = "LocalFileSettingsProvider";
            }

            base.Initialize(name, values);
        }

        /// <devdoc>
        ///     Abstract SettingsProvider method
        /// </devdoc>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection properties)
        {
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();
            string sectionName = GetSectionName(context);

            //<--Look for this section in both applicationSettingsGroup and userSettingsGroup-->
            IDictionary appSettings = Store.ReadSettings(sectionName, false);
            IDictionary userSettings = Store.ReadSettings(sectionName, true);
            ConnectionStringSettingsCollection connStrings = Store.ReadConnectionStrings();

            //<--Now map each SettingProperty to the right StoredSetting and deserialize the value if found.-->
            foreach (SettingsProperty setting in properties)
            {
                string settingName = setting.Name;
                SettingsPropertyValue value = new SettingsPropertyValue(setting);

                // First look for and handle "special" settings
                SpecialSettingAttribute attr = setting.Attributes[typeof(SpecialSettingAttribute)] as SpecialSettingAttribute;
                bool isConnString = (attr != null) ? (attr.SpecialSetting == SpecialSetting.ConnectionString) : false;

                if (isConnString)
                {
                    string connStringName = sectionName + "." + settingName;
                    if (connStrings != null && connStrings[connStringName] != null)
                    {
                        value.PropertyValue = connStrings[connStringName].ConnectionString;
                    }
                    else if (setting.DefaultValue != null && setting.DefaultValue is string)
                    {
                        value.PropertyValue = setting.DefaultValue;
                    }
                    else
                    {
                        //No value found and no default specified 
                        value.PropertyValue = String.Empty;
                    }

                    value.IsDirty = false; //reset IsDirty so that it is correct when SetPropertyValues is called 
                    values.Add(value);
                    continue;
                }

                // Not a "special" setting
                bool isUserSetting = IsUserSetting(setting);

                if (isUserSetting && !ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
                {
                    // We encountered a user setting, but the current configuration system does not support
                    // user settings.
                    throw new ConfigurationErrorsException("不支持");
                }

                IDictionary settings = isUserSetting ? userSettings : appSettings;

                if (settings.Contains(settingName))
                {
                    StoredSetting ss = (StoredSetting)settings[settingName];
                    string valueString = ss.Value.InnerXml;

                    // We need to un-escape string serialized values
                    if (ss.SerializeAs == SettingsSerializeAs.String)
                    {
                        valueString = Escaper.Unescape(valueString);
                    }

                    value.SerializedValue = valueString;
                }
                else if (setting.DefaultValue != null)
                {
                    value.SerializedValue = setting.DefaultValue;
                }
                else
                {
                    //No value found and no default specified 
                    value.PropertyValue = null;
                }

                value.IsDirty = false; //reset IsDirty so that it is correct when SetPropertyValues is called 
                values.Add(value);
            }

            return values;
        }

        /// <devdoc>
        ///     Abstract SettingsProvider method
        /// </devdoc>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection values)
        {
            string sectionName = GetSectionName(context);
            IDictionary roamingUserSettings = new Hashtable();
            IDictionary localUserSettings = new Hashtable();

            foreach (SettingsPropertyValue value in values)
            {
                SettingsProperty setting = value.Property;
                bool isUserSetting = IsUserSetting(setting);

                if (value.IsDirty)
                {
                    if (isUserSetting)
                    {
                        bool isRoaming = IsRoamingSetting(setting);
                        StoredSetting ss = new StoredSetting(setting.SerializeAs, SerializeToXmlElement(setting, value));

                        if (isRoaming)
                        {
                            roamingUserSettings[setting.Name] = ss;
                        }
                        else
                        {
                            localUserSettings[setting.Name] = ss;
                        }

                        value.IsDirty = false; //reset IsDirty
                    }
                    else
                    {
                        // This is an app-scoped or connection string setting that has been written to. 
                        // We don't support saving these.
                    }
                }
            }

            // Semi-hack: If there are roamable settings, let's write them before local settings so if a handler 
            // declaration is necessary, it goes in the roaming config file in preference to the local config file.
            if (roamingUserSettings.Count > 0)
            {
                Store.WriteSettings(sectionName, true, roamingUserSettings);
            }

            if (localUserSettings.Count > 0)
            {
                Store.WriteSettings(sectionName, false, localUserSettings);
            }
        }

        /// <devdoc>
        ///     Implementation of IClientSettingsProvider.Reset. Resets user scoped settings to the values 
        ///     in app.exe.config, does nothing for app scoped settings.
        /// </devdoc>
        public void Reset(SettingsContext context)
        {
            string sectionName = GetSectionName(context);

            // First revert roaming, then local
            Store.RevertToParent(sectionName, true);
            Store.RevertToParent(sectionName, false);
        }

        /// <devdoc>
        ///    Implementation of IClientSettingsProvider.Upgrade.
        ///    Tries to locate a previous version of the user.config file. If found, it migrates matching settings.
        ///    If not, it does nothing.
        /// </devdoc>
        public void Upgrade(SettingsContext context, SettingsPropertyCollection properties)
        {
            // Separate the local and roaming settings and upgrade them separately.

            SettingsPropertyCollection local = new SettingsPropertyCollection();
            SettingsPropertyCollection roaming = new SettingsPropertyCollection();

            foreach (SettingsProperty sp in properties)
            {
                bool isRoaming = IsRoamingSetting(sp);

                if (isRoaming)
                {
                    roaming.Add(sp);
                }
                else
                {
                    local.Add(sp);
                }
            }

            if (roaming.Count > 0)
            {
                Upgrade(context, roaming, true);
            }

            if (local.Count > 0)
            {
                Upgrade(context, local, false);
            }
        }

        /// <devdoc>
        ///     Encapsulates the Version constructor so that we can return null when an exception is thrown.
        /// </devdoc>
        private Version CreateVersion(string name)
        {
            Version ver = null;

            try
            {
                ver = new Version(name);
            }
            catch (ArgumentException)
            {
                ver = null;
            }
            catch (OverflowException)
            {
                ver = null;
            }
            catch (FormatException)
            {
                ver = null;
            }

            return ver;
        }

        /// <devdoc>
        ///    Implementation of IClientSettingsProvider.GetPreviousVersion.
        /// </devdoc>
        //  Security Note: Like Upgrade, GetPreviousVersion involves finding a previous version user.config file and 
        //  reading settings from it. To support this in partial trust, we need to assert file i/o here. We believe 
        //  this to be safe, since the user does not have a way to specify the file or control where we look for it. 
        //  So it is no different than reading from the default user.config file, which we already allow in partial trust.
        //  BTW, the Link/Inheritance demand pair here is just a copy of what's at the class level, and is needed since
        //  we are overriding security at method level.
        [
         FileIOPermission(SecurityAction.Assert, AllFiles = FileIOPermissionAccess.PathDiscovery | FileIOPermissionAccess.Read),
         PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust"),
         PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")
        ]
        public SettingsPropertyValue GetPreviousVersion(SettingsContext context, SettingsProperty property)
        {
            bool isRoaming = IsRoamingSetting(property);
            string prevConfig = GetPreviousConfigFileName(isRoaming);

            if (!String.IsNullOrEmpty(prevConfig))
            {
                SettingsPropertyCollection properties = new SettingsPropertyCollection();
                properties.Add(property);
                SettingsPropertyValueCollection values = GetSettingValuesFromFile(prevConfig, GetSectionName(context), true, properties);
                return values[property.Name];
            }
            else
            {
                SettingsPropertyValue value = new SettingsPropertyValue(property);
                value.PropertyValue = null;
                return value;
            }
        }

        /// <devdoc>
        ///     Locates the previous version of user.config, if present. The previous version is determined
        ///     by walking up one directory level in the *UserConfigPath and searching for the highest version
        ///     number less than the current version.
        ///     SECURITY NOTE: Config path information is privileged - do not directly pass this on to untrusted callers.
        ///     Note this is meant to be used at installation time to help migrate 
        ///     config settings from a previous version of the app.
        /// </devdoc>
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        private string GetPreviousConfigFileName(bool isRoaming)
        {
            if (!ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
            {
                throw new ConfigurationErrorsException("不支持");
            }

            string prevConfigFile = isRoaming ? _prevRoamingConfigFileName : _prevLocalConfigFileName;

            if (String.IsNullOrEmpty(prevConfigFile))
            {
                string userConfigPath = isRoaming ? ConfigurationManagerInternalFactory.Instance.ExeRoamingConfigDirectory : ConfigurationManagerInternalFactory.Instance.ExeLocalConfigDirectory;
                Version curVer = CreateVersion(ConfigurationManagerInternalFactory.Instance.ExeProductVersion);
                Version prevVer = null;
                DirectoryInfo prevDir = null;
                string file = null;

                if (curVer == null)
                {
                    return null;
                }

                DirectoryInfo parentDir = Directory.GetParent(userConfigPath);

                if (parentDir.Exists)
                {
                    foreach (DirectoryInfo dir in parentDir.GetDirectories())
                    {
                        Version tempVer = CreateVersion(dir.Name);

                        if (tempVer != null && tempVer < curVer)
                        {
                            if (prevVer == null)
                            {
                                prevVer = tempVer;
                                prevDir = dir;
                            }
                            else if (tempVer > prevVer)
                            {
                                prevVer = tempVer;
                                prevDir = dir;
                            }
                        }
                    }

                    if (prevDir != null)
                    {
                        file = Path.Combine(prevDir.FullName, ConfigurationManagerInternalFactory.Instance.UserConfigFilename);
                    }

                    if (File.Exists(file))
                    {
                        prevConfigFile = file;
                    }
                }

                //Cache for future use.
                if (isRoaming)
                {
                    _prevRoamingConfigFileName = prevConfigFile;
                }
                else
                {
                    _prevLocalConfigFileName = prevConfigFile;
                }
            }

            return prevConfigFile;
        }

        /// <devdoc>
        ///     Gleans information from the SettingsContext and determines the name of the config section.
        /// </devdoc>
        private string GetSectionName(SettingsContext context)
        {
            string groupName = (string)context["GroupName"];
            string key = (string)context["SettingsKey"];

            Debug.Assert(groupName != null, "SettingsContext did not have a GroupName!");

            string sectionName = groupName;

            if (!String.IsNullOrEmpty(key))
            {
                sectionName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", sectionName, key);
            }

            return XmlConvert.EncodeLocalName(sectionName);
        }

        /// <devdoc>
        ///     Retrieves the values of settings from the given config file (as opposed to using 
        ///     the configuration for the current context)
        /// </devdoc>
        private SettingsPropertyValueCollection GetSettingValuesFromFile(string configFileName, string sectionName, bool userScoped, SettingsPropertyCollection properties)
        {
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();
            IDictionary settings = ClientSettingsStore.ReadSettingsFromFile(configFileName, sectionName, userScoped);

            // Map each SettingProperty to the right StoredSetting and deserialize the value if found.
            foreach (SettingsProperty setting in properties)
            {
                string settingName = setting.Name;
                SettingsPropertyValue value = new SettingsPropertyValue(setting);

                if (settings.Contains(settingName))
                {
                    StoredSetting ss = (StoredSetting)settings[settingName];
                    string valueString = ss.Value.InnerXml;

                    // We need to un-escape string serialized values
                    if (ss.SerializeAs == SettingsSerializeAs.String)
                    {
                        valueString = Escaper.Unescape(valueString);
                    }

                    value.SerializedValue = valueString;
                    value.IsDirty = true;
                    values.Add(value);
                }
            }

            return values;
        }

        /// <devdoc>
        ///     Indicates whether a setting is roaming or not.
        /// </devdoc>
        private static bool IsRoamingSetting(SettingsProperty setting)
        {
            // Roaming is not supported in Clickonce deployed apps, since they don't have roaming config files.
            bool roamingSupported = !ApplicationSettingsBase.IsClickOnceDeployed(AppDomain.CurrentDomain);
            bool isRoaming = false;

            if (roamingSupported)
            {
                SettingsManageabilityAttribute manageAttr = setting.Attributes[typeof(SettingsManageabilityAttribute)] as SettingsManageabilityAttribute;
                isRoaming = manageAttr != null && ((manageAttr.Manageability & SettingsManageability.Roaming) == SettingsManageability.Roaming);
            }

            return isRoaming;
        }

        /// <devdoc>
        ///     This provider needs settings to be marked with either the UserScopedSettingAttribute or the
        ///     ApplicationScopedSettingAttribute. This method determines whether this setting is user-scoped
        ///     or not. It will throw if none or both of the attributes are present.
        /// </devdoc>
        private bool IsUserSetting(SettingsProperty setting)
        {
            bool isUser = setting.Attributes[typeof(UserScopedSettingAttribute)] is UserScopedSettingAttribute;
            bool isApp = setting.Attributes[typeof(ApplicationScopedSettingAttribute)] is ApplicationScopedSettingAttribute;

            if (isUser && isApp)
            {
                throw new ConfigurationErrorsException(SR.GetString(SR.BothScopeAttributes));
            }
            else if (!(isUser || isApp))
            {
                throw new ConfigurationErrorsException(SR.GetString(SR.NoScopeAttributes));
            }

            return isUser;
        }

        private XmlNode SerializeToXmlElement(SettingsProperty setting, SettingsPropertyValue value)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement valueXml = doc.CreateElement("value");

            string serializedValue = value.SerializedValue as string;

            if (serializedValue == null && setting.SerializeAs == SettingsSerializeAs.Binary)
            {
                // SettingsPropertyValue returns a byte[] in the binary serialization case. We need to
                // encode this - we use base64 since SettingsPropertyValue understands it and we won't have
                // to special case while deserializing.
                byte[] buf = value.SerializedValue as byte[];
                if (buf != null)
                {
                    serializedValue = Convert.ToBase64String(buf);
                }
            }

            if (serializedValue == null)
            {
                serializedValue = String.Empty;
            }

            // We need to escape string serialized values
            if (setting.SerializeAs == SettingsSerializeAs.String)
            {
                serializedValue = Escaper.Escape(serializedValue);
            }

            valueXml.InnerXml = serializedValue;

            // Hack to remove the XmlDeclaration that the XmlSerializer adds. 
            XmlNode unwanted = null;
            foreach (XmlNode child in valueXml.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.XmlDeclaration)
                {
                    unwanted = child;
                    break;
                }
            }
            if (unwanted != null)
            {
                valueXml.RemoveChild(unwanted);
            }

            return valueXml;
        }

        /// <devdoc>
        ///    Private version of upgrade that uses isRoaming to determine which config file to use.
        /// </devdoc> 
        // Security Note: Upgrade involves finding a previous version user.config file and reading settings from it. To
        // support this in partial trust, we need to assert file i/o here. We believe this to be safe, since the user
        // does not have a way to specify the file or control where we look for it. As such, it is no different than
        // reading from the default user.config file, which we already allow in partial trust.
        // The following suppress is okay, since the Link/Inheritance demand pair at the class level are not needed for
        // this method, since it is private.
        [SuppressMessage("Microsoft.Security", "CA2114:MethodSecurityShouldBeASupersetOfType")]
        [FileIOPermission(SecurityAction.Assert, AllFiles = FileIOPermissionAccess.PathDiscovery | FileIOPermissionAccess.Read)]
        private void Upgrade(SettingsContext context, SettingsPropertyCollection properties, bool isRoaming)
        {
            string prevConfig = GetPreviousConfigFileName(isRoaming);

            if (!String.IsNullOrEmpty(prevConfig))
            {
                //Filter the settings properties to exclude those that have a NoSettingsVersionUpgradeAttribute on them.
                SettingsPropertyCollection upgradeProperties = new SettingsPropertyCollection();
                foreach (SettingsProperty sp in properties)
                {
                    if (!(sp.Attributes[typeof(NoSettingsVersionUpgradeAttribute)] is NoSettingsVersionUpgradeAttribute))
                    {
                        upgradeProperties.Add(sp);
                    }
                }

                SettingsPropertyValueCollection values = GetSettingValuesFromFile(prevConfig, GetSectionName(context), true, upgradeProperties);
                SetPropertyValues(context, values);
            }
        }
        private class XmlEscaper
        {
            private XmlDocument doc;
            private XmlElement temp;

            internal XmlEscaper()
            {
                doc = new XmlDocument();
                temp = doc.CreateElement("temp");
            }

            internal string Escape(string xmlString)
            {
                if (String.IsNullOrEmpty(xmlString))
                {
                    return xmlString;
                }

                temp.InnerText = xmlString;
                return temp.InnerXml;
            }

            internal string Unescape(string escapedString)
            {
                if (String.IsNullOrEmpty(escapedString))
                {
                    return escapedString;
                }

                temp.InnerXml = escapedString;
                return temp.InnerText;
            }
        }
    }


    /// <devdoc>
    ///     This class abstracts the details of config system away from the LocalFileSettingsProvider. It talks to 
    ///     the configuration API and the relevant Sections to read and write settings. 
    ///     It understands sections of type ClientSettingsSection.
    ///
    ///     NOTE: This API supports reading from app.exe.config and user.config, but writing only to 
    ///           user.config.
    /// </devdoc>
    internal sealed class ClientSettingsStore
    {
        private const string ApplicationSettingsGroupName = "applicationSettings";
        private const string UserSettingsGroupName = "userSettings";
        private const string ApplicationSettingsGroupPrefix = ApplicationSettingsGroupName + "/";
        private const string UserSettingsGroupPrefix = UserSettingsGroupName + "/";

        private Configuration GetUserConfig(bool isRoaming)
        {
            ConfigurationUserLevel userLevel = isRoaming ? ConfigurationUserLevel.PerUserRoaming :
                                                           ConfigurationUserLevel.PerUserRoamingAndLocal;

            return ClientSettingsConfigurationHost.OpenExeConfiguration(userLevel);
        }

        private ClientSettingsSection GetConfigSection(Configuration config, string sectionName, bool declare)
        {
            string fullSectionName = UserSettingsGroupPrefix + sectionName;
            ClientSettingsSection section = null;

            if (config != null)
            {
                section = config.GetSection(fullSectionName) as ClientSettingsSection;

                if (section == null && declare)
                {
                    // Looks like the section isn't declared - let's declare it and try again.
                    DeclareSection(config, sectionName);
                    section = config.GetSection(fullSectionName) as ClientSettingsSection;
                }
            }

            return section;
        }

        // Declares the section handler of a given section in its section group, if a declaration isn't already
        // present. 
        private void DeclareSection(Configuration config, string sectionName)
        {
            ConfigurationSectionGroup settingsGroup = config.GetSectionGroup(UserSettingsGroupName);

            if (settingsGroup == null)
            {
                //Declare settings group
                ConfigurationSectionGroup group = new UserSettingsGroup();
                config.SectionGroups.Add(UserSettingsGroupName, group);
            }

            settingsGroup = config.GetSectionGroup(UserSettingsGroupName);

            Debug.Assert(settingsGroup != null, "Failed to declare settings group");

            if (settingsGroup != null)
            {
                ConfigurationSection section = settingsGroup.Sections[sectionName];
                if (section == null)
                {
                    section = new ClientSettingsSection();
                    section.SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
                    section.SectionInformation.RequirePermission = false;
                    settingsGroup.Sections.Add(sectionName, section);
                }
            }
        }

        internal IDictionary ReadSettings(string sectionName, bool isUserScoped)
        {
            IDictionary settings = new Hashtable();

            if (isUserScoped && !ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
            {
                return settings;
            }

            string prefix = isUserScoped ? UserSettingsGroupPrefix : ApplicationSettingsGroupPrefix;
            ConfigurationManager.RefreshSection(prefix + sectionName);
            ClientSettingsSection section = ConfigurationManager.GetSection(prefix + sectionName) as ClientSettingsSection;

            if (section != null)
            {
                foreach (SettingElement setting in section.Settings)
                {
                    settings[setting.Name] = new StoredSetting(setting.SerializeAs, setting.Value.ValueXml);
                }
            }

            return settings;
        }

        internal static IDictionary ReadSettingsFromFile(string configFileName, string sectionName, bool isUserScoped)
        {
            IDictionary settings = new Hashtable();

            if (isUserScoped && !ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
            {
                return settings;
            }

            string prefix = isUserScoped ? UserSettingsGroupPrefix : ApplicationSettingsGroupPrefix;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();

            // NOTE: When isUserScoped is true, we don't care if configFileName represents a roaming file or
            //       a local one. All we want is three levels of configuration. So, we use the PerUserRoaming level. 
            ConfigurationUserLevel userLevel = isUserScoped ? ConfigurationUserLevel.PerUserRoaming : ConfigurationUserLevel.None;

            if (isUserScoped)
            {
                fileMap.ExeConfigFilename = ConfigurationManagerInternalFactory.Instance.ApplicationConfigUri;
                fileMap.RoamingUserConfigFilename = configFileName;
            }
            else
            {
                fileMap.ExeConfigFilename = configFileName;
            }

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, userLevel);
            ClientSettingsSection section = config.GetSection(prefix + sectionName) as ClientSettingsSection;

            if (section != null)
            {
                foreach (SettingElement setting in section.Settings)
                {
                    settings[setting.Name] = new StoredSetting(setting.SerializeAs, setting.Value.ValueXml);
                }
            }

            return settings;
        }

        internal ConnectionStringSettingsCollection ReadConnectionStrings()
        {
            return PrivilegedConfigurationManager.ConnectionStrings;
        }

        internal void RevertToParent(string sectionName, bool isRoaming)
        {
            if (!ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
            {
                throw new ConfigurationErrorsException("不支持");
            }

            Configuration config = GetUserConfig(isRoaming);
            ClientSettingsSection section = GetConfigSection(config, sectionName, false);

            // If the section is null, there is nothing to revert.
            if (section != null)
            {
                section.SectionInformation.RevertToParent();
                config.Save();
            }
        }

        internal void WriteSettings(string sectionName, bool isRoaming, IDictionary newSettings)
        {
            if (!ConfigurationManagerInternalFactory.Instance.SupportsUserConfig)
            {
                throw new ConfigurationErrorsException("不支持");
            }

            Configuration config = GetUserConfig(isRoaming);
            ClientSettingsSection section = GetConfigSection(config, sectionName, true);

            if (section != null)
            {
                SettingElementCollection sec = section.Settings;
                foreach (DictionaryEntry entry in newSettings)
                {
                    SettingElement se = sec.Get((string)entry.Key);

                    if (se == null)
                    {
                        se = new SettingElement();
                        se.Name = (string)entry.Key;
                        sec.Add(se);
                    }

                    StoredSetting ss = (StoredSetting)entry.Value;
                    se.SerializeAs = ss.SerializeAs;
                    se.Value.ValueXml = ss.Value;
                }

                try
                {
                    config.Save();
                }
                catch (ConfigurationErrorsException ex)
                {
                    // We wrap this in an exception with our error message and throw again.
                    throw new ConfigurationErrorsException(ex.Message);
                }
            }
            else
            {
                throw new ConfigurationErrorsException("保存失败");
            }
        }

        /// <devdoc>
        ///     A private configuration host that we use to write settings to config. We need this so we
        ///     can enforce a quota on the size of stuff written out.
        /// </devdoc>
        private sealed class ClientSettingsConfigurationHost : DelegatingConfigHost
        {
            private const string ClientConfigurationHostTypeName = "System.Configuration.ClientConfigurationHost," + AssemblyRef.SystemConfiguration;
            private const string InternalConfigConfigurationFactoryTypeName = "System.Configuration.Internal.InternalConfigConfigurationFactory," + AssemblyRef.SystemConfiguration;
            private static volatile IInternalConfigConfigurationFactory s_configFactory;

            /// <devdoc>
            ///     ClientConfigurationHost implements this - a way of getting some info from it without
            ///     depending too much on its internals.
            /// </devdoc>
            private IInternalConfigClientHost ClientHost
            {
                get
                {
                    return (IInternalConfigClientHost)Host;
                }
            }

            internal static IInternalConfigConfigurationFactory ConfigFactory
            {
                get
                {
                    if (s_configFactory == null)
                    {
                        s_configFactory = (IInternalConfigConfigurationFactory)
                                            TypeUtil.CreateInstanceWithReflectionPermission(InternalConfigConfigurationFactoryTypeName);
                    }
                    return s_configFactory;
                }
            }

            private ClientSettingsConfigurationHost() { }

            public override void Init(IInternalConfigRoot configRoot, params object[] hostInitParams)
            {
                Debug.Fail("Did not expect to get called here");
            }

            /// <devdoc>
            ///     We delegate this to the ClientConfigurationHost. The only thing we need to do here is to 
            ///     build a configPath from the ConfigurationUserLevel we get passed in.
            /// </devdoc>
            public override void InitForConfiguration(ref string locationSubPath, out string configPath, out string locationConfigPath,
                    IInternalConfigRoot configRoot, params object[] hostInitConfigurationParams)
            {

                ConfigurationUserLevel userLevel = (ConfigurationUserLevel)hostInitConfigurationParams[0];
                string desiredConfigPath = null;
                Host = (IInternalConfigHost)TypeUtil.CreateInstanceWithReflectionPermission(ClientConfigurationHostTypeName);

                switch (userLevel)
                {
                    case ConfigurationUserLevel.None:
                        desiredConfigPath = ClientHost.GetExeConfigPath();
                        break;

                    case ConfigurationUserLevel.PerUserRoaming:
                        desiredConfigPath = ClientHost.GetRoamingUserConfigPath();
                        break;

                    case ConfigurationUserLevel.PerUserRoamingAndLocal:
                        desiredConfigPath = ClientHost.GetLocalUserConfigPath();
                        break;

                    default:
                        throw new ArgumentException("未知的用户级别");
                }


                Host.InitForConfiguration(ref locationSubPath, out configPath, out locationConfigPath, configRoot, null, null, desiredConfigPath);
            }

            private bool IsKnownConfigFile(string filename)
            {
                return
                  String.Equals(filename, ConfigurationManagerInternalFactory.Instance.MachineConfigPath, StringComparison.OrdinalIgnoreCase) ||
                  String.Equals(filename, ConfigurationManagerInternalFactory.Instance.ApplicationConfigUri, StringComparison.OrdinalIgnoreCase) ||
                  String.Equals(filename, ConfigurationManagerInternalFactory.Instance.ExeLocalConfigPath, StringComparison.OrdinalIgnoreCase) ||
                  String.Equals(filename, ConfigurationManagerInternalFactory.Instance.ExeRoamingConfigPath, StringComparison.OrdinalIgnoreCase);

            }

            internal static Configuration OpenExeConfiguration(ConfigurationUserLevel userLevel)
            {
                return ConfigFactory.Create(typeof(ClientSettingsConfigurationHost), userLevel);
            }

            /// <devdoc>
            ///     If the stream we are asked for represents a config file that we know about, we ask 
            ///     the host to assert appropriate permissions.
            /// </devdoc>
            public override Stream OpenStreamForRead(string streamName)
            {
                if (IsKnownConfigFile(streamName))
                {
                    return Host.OpenStreamForRead(streamName, true);
                }
                else
                {
                    return Host.OpenStreamForRead(streamName);
                }
            }

            /// <devdoc>
            ///     If the stream we are asked for represents a user.config file that we know about, we wrap it in a
            ///     QuotaEnforcedStream, after asking the host to assert appropriate permissions.///     
            /// </devdoc>
            public override Stream OpenStreamForWrite(string streamName, string templateStreamName, ref object writeContext)
            {
                Stream stream = null;

                if (String.Equals(streamName, ConfigurationManagerInternalFactory.Instance.ExeLocalConfigPath, StringComparison.OrdinalIgnoreCase))
                {
                    stream = new QuotaEnforcedStream(
                                   Host.OpenStreamForWrite(streamName, templateStreamName, ref writeContext, true),
                                   false);
                }
                else if (String.Equals(streamName, ConfigurationManagerInternalFactory.Instance.ExeRoamingConfigPath, StringComparison.OrdinalIgnoreCase))
                {
                    stream = new QuotaEnforcedStream(
                                   Host.OpenStreamForWrite(streamName, templateStreamName, ref writeContext, true),
                                   true);
                }
                else
                {
                    stream = Host.OpenStreamForWrite(streamName, templateStreamName, ref writeContext);
                }

                return stream;
            }

            /// <devdoc>
            ///     If this is a stream that represents a user.config file that we know about, we ask 
            ///     the host to assert appropriate permissions.
            /// </devdoc>
            public override void WriteCompleted(string streamName, bool success, object writeContext)
            {
                if (String.Equals(streamName, ConfigurationManagerInternalFactory.Instance.ExeLocalConfigPath, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(streamName, ConfigurationManagerInternalFactory.Instance.ExeRoamingConfigPath, StringComparison.OrdinalIgnoreCase))
                {

                    Host.WriteCompleted(streamName, success, writeContext, true);
                }
                else
                {
                    Host.WriteCompleted(streamName, success, writeContext);
                }
            }
        }

        /// <devdoc>
        ///     A private stream class that wraps a stream and enforces a quota. The quota enforcement uses
        ///     IsolatedStorageFilePermission. We override nearly all methods on the Stream class so we can
        ///     forward to the wrapped stream. In the methods that affect stream length, we verify that the
        ///     quota is respected before forwarding.
        /// </devdoc>
        private sealed class QuotaEnforcedStream : Stream
        {
            private Stream _originalStream;
            private bool _isRoaming;

            internal QuotaEnforcedStream(Stream originalStream, bool isRoaming)
            {
                _originalStream = originalStream;
                _isRoaming = isRoaming;

                Debug.Assert(_originalStream != null, "originalStream was null.");
            }

            public override bool CanRead
            {
                get { return _originalStream.CanRead; }
            }

            public override bool CanWrite
            {
                get { return _originalStream.CanWrite; }
            }

            public override bool CanSeek
            {
                get { return _originalStream.CanSeek; }
            }

            public override long Length
            {
                get { return _originalStream.Length; }
            }

            public override long Position
            {

                get { return _originalStream.Position; }

                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("value","超出索引");
                    }

                    Seek(value, SeekOrigin.Begin);
                }
            }

            public override void Close()
            {
                _originalStream.Close();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_originalStream != null)
                    {
                        ((IDisposable)_originalStream).Dispose();
                        _originalStream = null;
                    }

                }

                base.Dispose(disposing);
            }

            public override void Flush()
            {
                _originalStream.Flush();
            }

            public override void SetLength(long value)
            {
                long oldLen = _originalStream.Length;
                long newLen = value;

                EnsureQuota(Math.Max(oldLen, newLen));
                _originalStream.SetLength(value);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _originalStream.Read(buffer, offset, count);
            }

            public override int ReadByte()
            {
                return _originalStream.ReadByte();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                if (!CanSeek)
                {
                    throw new NotSupportedException();
                }

                long oldLen = _originalStream.Length;
                long newLen;

                switch (origin)
                {
                    case SeekOrigin.Begin:
                        newLen = offset;
                        break;
                    case SeekOrigin.Current:
                        newLen = _originalStream.Position + offset;
                        break;
                    case SeekOrigin.End:
                        newLen = oldLen + offset;
                        break;
                    default:
                        throw new ArgumentException("UnknownSeekOrigin", "origin");
                }

                EnsureQuota(Math.Max(oldLen, newLen));
                return _originalStream.Seek(offset, origin);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                if (!CanWrite)
                {
                    throw new NotSupportedException();
                }

                long oldLen = _originalStream.Length;
                long newLen = _originalStream.CanSeek ? _originalStream.Position + (long)count :
                                                        _originalStream.Length + (long)count;
                EnsureQuota(Math.Max(oldLen, newLen));
                _originalStream.Write(buffer, offset, count);
            }

            public override void WriteByte(byte value)
            {
                if (!CanWrite)
                {
                    throw new NotSupportedException();
                }

                long oldLen = _originalStream.Length;
                long newLen = _originalStream.CanSeek ? _originalStream.Position + 1 : _originalStream.Length + 1;
                EnsureQuota(Math.Max(oldLen, newLen));

                _originalStream.WriteByte(value);
            }

            public override IAsyncResult BeginRead(byte[] buffer, int offset, int numBytes,
                                                   AsyncCallback userCallback, Object stateObject)
            {
                return _originalStream.BeginRead(buffer, offset, numBytes, userCallback, stateObject);
            }

            public override int EndRead(IAsyncResult asyncResult)
            {
                return _originalStream.EndRead(asyncResult);

            }

            public override IAsyncResult BeginWrite(byte[] buffer, int offset, int numBytes,
                                                    AsyncCallback userCallback, Object stateObject)
            {
                if (!CanWrite)
                {
                    throw new NotSupportedException();
                }

                long oldLen = _originalStream.Length;
                long newLen = _originalStream.CanSeek ? _originalStream.Position + (long)numBytes :
                                                        _originalStream.Length + (long)numBytes;
                EnsureQuota(Math.Max(oldLen, newLen));
                return _originalStream.BeginWrite(buffer, offset, numBytes, userCallback, stateObject);
            }

            public override void EndWrite(IAsyncResult asyncResult)
            {
                _originalStream.EndWrite(asyncResult);
            }

            // 
            private void EnsureQuota(long size)
            {
                IsolatedStoragePermission storagePerm = new IsolatedStorageFilePermission(PermissionState.None);
                storagePerm.UserQuota = size;
                storagePerm.UsageAllowed = _isRoaming ? IsolatedStorageContainment.DomainIsolationByRoamingUser :
                                                       IsolatedStorageContainment.DomainIsolationByUser;
                storagePerm.Demand();
            }
        }
    }

    /// <devdoc>
    ///     The ClientSettingsStore talks to the LocalFileSettingsProvider through a dictionary which maps from
    ///     setting names to StoredSetting structs. This struct contains the relevant information.
    /// </devdoc>
    internal struct StoredSetting
    {
        internal StoredSetting(SettingsSerializeAs serializeAs, XmlNode value)
        {
            SerializeAs = serializeAs;
            Value = value;
        }
        internal SettingsSerializeAs SerializeAs;
        internal XmlNode Value;
    }

    internal static class ConfigurationManagerInternalFactory
    {
        private const string ConfigurationManagerInternalTypeString = "System.Configuration.Internal.ConfigurationManagerInternal, " + AssemblyRef.SystemConfiguration;

        static private volatile IConfigurationManagerInternal s_instance;

        static internal IConfigurationManagerInternal Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = (IConfigurationManagerInternal)TypeUtil.CreateInstanceWithReflectionPermission(ConfigurationManagerInternalTypeString);
                }

                return s_instance;
            }
        }
    }
    internal static class TypeUtil
    {
        [ReflectionPermission(SecurityAction.Assert, Flags = ReflectionPermissionFlag.MemberAccess)]
        static internal object CreateInstanceWithReflectionPermission(string typeString)
        {
            Type type = Type.GetType(typeString, true);           // catch the errors and report them
            object result = Activator.CreateInstance(type, true); // create non-public types
            return result;
        }
    }
    [ConfigurationPermission(SecurityAction.Assert, Unrestricted = true)]
    internal static class PrivilegedConfigurationManager
    {
        internal static ConnectionStringSettingsCollection ConnectionStrings
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            get
            {
                return ConfigurationManager.ConnectionStrings;
            }
        }

        internal static object GetSection(string sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }
    }
}
