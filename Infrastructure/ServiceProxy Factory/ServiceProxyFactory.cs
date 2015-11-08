using System;
namespace FengSharp.OneCardAccess.Infrastructure
{
    public static class ServiceProxyFactory
    {
        public static T Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new ServiceRealProxy<T>(endpointName).GetTransparentProxy());
        }
        public static T Create<T>()
        {
            string endpointName = typeof(T).Name.Remove(0, 1);
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new ServiceRealProxy<T>(endpointName).GetTransparentProxy());
        }
    }
}
