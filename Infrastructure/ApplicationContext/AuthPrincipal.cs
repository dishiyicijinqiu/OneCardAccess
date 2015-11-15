﻿using System;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Infrastructure
{
    [Serializable]
    //[DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class AuthPrincipal
    {
        //[DataMember]
        public AuthIdentity Identity
        {
            get;
            private set;
        }
        //[DataMember]
        public string Ticket
        {
            get;
            private set;
        }
        public AuthPrincipal(AuthIdentity iidentity, string ticket)
        {
            this.Identity = iidentity;
            this.Ticket = ticket;
        }
    }
    [Serializable]
    //[DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class AuthIdentity
    {
        public AuthIdentity(string userno, string password)
        {
            this.UserNo = userno;
            this.PassWord = password;
        }
        public AuthIdentity(string userid, string userno, string username, string password)
        {
            this.UserId = userid;
            this.UserNo = userno;
            this.UserName = username;
            this.PassWord = password;
        }

        //[DataMember]
        public string UserId { get; private set; }
        //[DataMember]
        public string UserNo { get; private set; }
        //[DataMember]
        public string UserName { get; private set; }
        //[DataMember]
        public string PassWord { get; private set; }
    }
}