﻿using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IPFBNSNRule
    {
        PFBNSNRuleEntity[] PFBNRules();
        PFBNSNRuleEntity[] PSNRules();
    }
}
