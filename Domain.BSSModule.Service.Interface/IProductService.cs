using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductEntity GetProductById(int entityid);
        [OperationContract]
        int CreateProduct(ProductEntity entity);
        [OperationContract]
        void UpdateProduct(ProductEntity entity);
        [OperationContract]
        void DeleteProducts(int[] entityids);
        [OperationContract]
        Product_Register_Draw_CMCateEntity[] GetProduct_Register_Draw_CMCateTree(int pid);
    }
}
