using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.Collections.Generic;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IInputLevelService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyInputLevelInputerEntity[] GetInputLevelsByDlyTypeId(int DlyTypeId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void SaveInputLevel(int DlyTypeId, short inputlevel, List<DlyInputLevelInputerEntity> inputlevels);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        bool CheckInputLevel(int DlyTypeId, short inputlevel);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void SHDJ(int DlyTypeId, short inputlevel, string dlyNdxId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void FSDJ(int DlyTypeId, short inputlevel, string dlyNdxId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        short GetTotalInputLevel(int DlyTypeId);
    }
}
