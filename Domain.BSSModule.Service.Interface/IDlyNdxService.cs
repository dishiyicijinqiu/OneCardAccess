using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IDlyNdxService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string GetNewDlyNo(int DlyTypeId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string GetDlyDate();
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyNdxFullNameEntity[] GetCGList();
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyNdxFullNameEntity[] GetJYLCList();
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string CopyDlyAs(string dlyNdxId, int dlyTypeId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteCGs(string[] DlyNdxIds);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyNdxFullNameEntity FindEntity(string dlyndx);

        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string SavPBak(PDlyNdxCGEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string SavePDly(PDlyNdxCGEntity entity);
        #region 商品入库单
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        SPRKDlyCGNdxEntity GetSPRKDlyCGNdxEntity(string dlyNdxId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        SPRKDlyYGZNdxEntity GetSPRKDlyYGZNdxEntity(string ndxId);
        #endregion
        #region 商品返工单
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        SPFGDlyCGNdxEntity GetSPFGDlyCGNdxEntity(string ndxId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        SPFGDlyYGZNdxEntity GetSPFGDlyYGZNdxEntity(string ndxId);
        #endregion
    }
}
