using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ExceptionHandlingBehaviorElement: BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ExceptionHandlingBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ExceptionHandlingBehavior();
        }
    }
}
