using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ServiceRealProxy<T> : RealProxy
    {
        private string _endpointName;

        public ServiceRealProxy(string endpointName)
            : base(typeof(T))
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            this._endpointName = endpointName;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodReturnMessage methodReturn = null;
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
        LoginTimeOutDo:
            T channel = ChannelFactoryCreator.Create<T>(this._endpointName).CreateChannel();
            try
            {
                object[] copiedArgs = Array.CreateInstance(typeof(object), methodCall.Args.Length) as object[];
                methodCall.Args.CopyTo(copiedArgs, 0);
                object returnValue = methodCall.MethodBase.Invoke(channel, copiedArgs);
                methodReturn = new ReturnMessage(returnValue,
                                                copiedArgs,
                                                copiedArgs.Length,
                                                methodCall.LogicalCallContext,
                                                methodCall);
                (channel as ICommunicationObject).Close();
            }
            catch (CommunicationException ex)
            {
                (channel as ICommunicationObject).Abort();
                methodReturn = new ReturnMessage(ex, methodCall);
            }
            catch (TimeoutException ex)
            {
                (channel as ICommunicationObject).Abort();
                methodReturn = new ReturnMessage(ex, methodCall);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CommunicationException || ex.InnerException is TimeoutException)
                {
                    (channel as ICommunicationObject).Abort();
                }
                string errmsg = ex.InnerException.Message;
                if(errmsg.Contains("FengSharp.OneCardAccess.Infrastructure.Exceptions.LoginTimeOutException"))
                {
                    var timeOutLogin = ServiceLoader.LoadService<ITimeOutLogin>();
                    if (timeOutLogin != null && timeOutLogin.TimeOutLogin())
                        goto LoginTimeOutDo;
                }
                if (ex.InnerException != null)
                {
                    methodReturn = new ReturnMessage(ex.InnerException, methodCall);
                }
                else
                {
                    methodReturn = new ReturnMessage(ex, methodCall);
                }
            }

            return methodReturn;
        }
    }
}