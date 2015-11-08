using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IRawMateService
    {
        [OperationContract]
        RawMateCMCateEntity[] GetRawMateTree(int pid);
        [OperationContract]
        RawMateEntity GetRawMateById(int entityid);
        [OperationContract]
        int CreateRawMate(RawMateEntity entity);
        [OperationContract]
        void UpdateRawMate(RawMateEntity entity);
        [OperationContract]
        void DeleteRawMates(int[] entityids);
    }
}
