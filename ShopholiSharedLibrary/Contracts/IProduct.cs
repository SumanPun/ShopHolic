using ShopholiSharedLibrary.Models;
using ShopholiSharedLibrary.Responses;

namespace ShopholiSharedLibrary.Contracts
{
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> getAllProducts(bool featuredProduct);
    }
}
