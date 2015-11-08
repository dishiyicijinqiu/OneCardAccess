using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Session_Policy
{
    public class SessionClientBehaviorElement : BehaviorExtensionElement
    {

        public override Type BehaviorType
        {
            get
            {
                return typeof(SessionClientBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            //return new SessionAttribute(this.ContainerName);
            return new SessionClientBehavior();
        }
    }
}
