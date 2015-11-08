using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.Collections.Generic;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IInputLevelService
    {
        [OperationContract]
        DlyInputLevelInputerEntity[] GetInputLevelsByDlyTypeId(int DlyTypeId);
        [OperationContract]
        void SaveInputLevel(int DlyTypeId, short inputlevel, List<DlyInputLevelInputerEntity> inputlevels);
    }
}
