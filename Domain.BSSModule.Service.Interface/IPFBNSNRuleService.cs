using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IPFBNSNRuleService
    {
        [OperationContract]
        PFBNSNRuleEntity[] GetPFBNSNRules();
    }
}
