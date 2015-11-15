using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Infrastructure
{
    //[KnownType(typeof(AuthPrincipal))]
    //[KnownType(typeof(AuthIdentity))]
    //[DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    [Serializable]
    public class ApplicationContext : Dictionary<string, object>
    {
        private const string CallContextKey = "__ApplicationContext";
        internal const string ContextHeaderLocalName = "__ApplicationContext";
        internal const string ContextHeaderNamespace = "www.fengsharp.com";
        private void EnsureSerializable(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (!value.GetType().IsSerializable)
            {
                throw new ArgumentException(string.Format("The argument of the type \"{0}\" is not serializable!", value.GetType().FullName));
            }
        }
        //[DataMember]
        public new object this[string key]
        {
            get
            {
                return base[key];
            }
            set
            {
                this.EnsureSerializable(value);
                base[key] = value;
            }
        }
        //[DataMember] 
        //[Serializable]
        public AuthPrincipal AuthPrincipal
        {
            get
            {
                return (AuthPrincipal)this["__AuthPrincipal"];
            }
            set
            {
                this["__AuthPrincipal"] = value;
            }
        }
        public static ApplicationContext Current
        {
            get
            {
                if (CallContext.GetData(CallContextKey) == null)
                {
                    CallContext.SetData(CallContextKey, new ApplicationContext());
                }

                return CallContext.GetData(CallContextKey) as ApplicationContext;
            }
            set
            {
                CallContext.SetData(CallContextKey, value);
            }
        }
    }
}
