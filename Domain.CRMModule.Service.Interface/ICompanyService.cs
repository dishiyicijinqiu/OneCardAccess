using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        CompanyEntity GetCompanyById(int companyid);
        [OperationContract]
        int CreateCompany(CompanyEntity entity);
        [OperationContract]
        void UpdateCompany(CompanyEntity entity);
        [OperationContract]
        void DeleteCompanys(int[] companyids);
        [OperationContract]
        CompanyCMCateEntity[] GetCompanyCMCateTree(int pid);

    }
}
