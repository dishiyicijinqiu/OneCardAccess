using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public static class ServiceLoader
    {
        private const string unityconfigname = "unity";
        private static IUnityContainer Container
        { get; set; }
        #region ctor
        static ServiceLoader()
        {

            Container = new UnityContainer();
            ConfigurationManager.GetSection(unityconfigname);
            UnityConfigurationSection unitySection = ConfigurationManager.GetSection(unityconfigname) as UnityConfigurationSection;
            if (unitySection != null)
            {
                foreach (var container in unitySection.Containers)
                {
                    Container.LoadConfiguration(container.Name);
                }
            }
        }
        #endregion
        #region LoadService
        public static object LoadService(System.Type type, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Container.Resolve(type);
            return Container.Resolve(type, name);
        }
        public static T LoadService<T>()
        {
            return Container.Resolve<T>();
        }
        public static T LoadService<T>(string serviceName)
        {
            return Container.Resolve<T>(serviceName);
        }
        #endregion
    }
}
