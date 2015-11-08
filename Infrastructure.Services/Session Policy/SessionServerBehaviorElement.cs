using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Services.Session_Policy
{
    public class SessionServerBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(SessionServerBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            //return new SessionAttribute(this.ContainerName);
            return new SessionServerBehavior();
        }
    }
}
