using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ApplicationContextBehaviorElement : BehaviorExtensionElement
    {
        /// <summary>
        /// 是否双向绑定
        /// </summary>
        [ConfigurationProperty("isBidirectional", DefaultValue = false)]
        public bool IsBidirectional
        {
            get
            {
                return (bool)this["isBidirectional"];
            }
            set
            {
                this["isBidirectional"] = value;
            }
        }
        /// <summary>
        /// 是否检测会话状态
        /// </summary>
        [ConfigurationProperty("sessionCheck", DefaultValue = true)]
        public bool SessionCheck
        {
            get
            {
                return (bool)this["sessionCheck"];
            }
            set
            {
                this["sessionCheck"] = value;
            }
        }
        public override Type BehaviorType
        {
            get
            {
                return typeof(ApplicationContextBehavior);

            }
        }

        protected override object CreateBehavior()
        {
            return new ApplicationContextBehavior(this.IsBidirectional, this.SessionCheck);
        }
    }
}
