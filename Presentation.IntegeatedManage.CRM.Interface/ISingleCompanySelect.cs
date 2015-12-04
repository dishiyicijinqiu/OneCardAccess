using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM.Interface
{
    public interface ISingleCompanySelect
    {
        event VEventHandler<CEventArgs<CompanyCMCateEntity[]>> BeforeBind;
        CompanyCMCateEntity GetResult();
        bool IsSelect { get; }
    }
    public interface IMultCompanySelect
    {
        event VEventHandler<CEventArgs<CompanyCMCateEntity[]>> BeforeBind;
        CompanyCMCateEntity[] GetResults();
        bool IsSelect { get; }
    }
}
