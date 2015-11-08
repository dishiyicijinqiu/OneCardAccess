using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        StockEntity GetStockById(int entityid);
        [OperationContract]
        void DeleteStocks(int[] entityids);
        [OperationContract]
        StockCMEntity[] GetStockCMList();
        [OperationContract]
        int CreateStock(StockEntity entity);
        [OperationContract]
        void UpdateStock(StockEntity entity);

    }
}
