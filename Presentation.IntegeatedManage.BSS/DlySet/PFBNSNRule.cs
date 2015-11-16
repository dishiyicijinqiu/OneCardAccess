using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class PFBNSNRule : IPFBNSNRule
    {
        static PFBNSNRuleEntity[] _PFBNRuleEntitys;
        internal static PFBNSNRuleEntity[] PFBNRuleEntitys
        {
            get
            {
                if (_PFBNRuleEntitys == null)
                {
                    _PFBNRuleEntitys = ServiceProxyFactory.Create<IPFBNSNRuleService>().GetPFBNSNRules().ToList().Where(t => !t.IsSNOrFBN).ToArray();
                }
                return _PFBNRuleEntitys;
            }
        }
        public PFBNSNRuleEntity[] PFBNRules()
        {
            return PFBNRuleEntitys;
        }

        static PFBNSNRuleEntity[] _PSNRuleEntitys;
        internal static PFBNSNRuleEntity[] PSNRuleEntitys
        {
            get
            {
                if (_PSNRuleEntitys == null)
                {
                    _PSNRuleEntitys = ServiceProxyFactory.Create<IPFBNSNRuleService>().GetPFBNSNRules().ToList().Where(t => t.IsSNOrFBN).ToArray();
                }
                return _PSNRuleEntitys;
            }
        }
        public PFBNSNRuleEntity[] PSNRules()
        {
            return PSNRuleEntitys;
        }
    }
}
