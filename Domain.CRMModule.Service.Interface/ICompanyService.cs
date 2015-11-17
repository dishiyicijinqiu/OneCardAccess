using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        CompanyEntity GetCompanyById(int companyid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        int CreateCompany(CompanyEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void UpdateCompany(CompanyEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteCompanys(int[] companyids);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        CompanyCMCateEntity[] GetCompanyCMCateTree(int pid);

    }
}
