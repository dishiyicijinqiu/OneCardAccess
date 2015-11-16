using System;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Infrastructure
{
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class AuthPrincipal
    {
        [DataMember]
        public AuthIdentity AuthIdentity
        {
            get;
            private set;
        }
        public AuthPrincipal(AuthIdentity authIdentity)
        {
            this.AuthIdentity = authIdentity;
        }
        public static AuthPrincipal CurrentAuthPrincipal { get; set; }
    }
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class AuthIdentity
    {
        public AuthIdentity(string userid, string userno, string username)
        {
            this.UserId = userid;
            this.UserNo = userno;
            this.UserName = username;
        }

        [DataMember]
        public string UserId { get; private set; }
        [DataMember]
        public string UserNo { get; private set; }
        [DataMember]
        public string UserName { get; private set; }
    }
}
