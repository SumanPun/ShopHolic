using Microsoft.EntityFrameworkCore;
using ShopholicServer.Data;
using ShopholiSharedLibrary.Contracts;
using ShopholiSharedLibrary.Models;
using ShopholiSharedLibrary.Responses;

namespace ShopholicServer.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");

            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                appDbContext.Products.Add(model);
                await Comit();
                return new ServiceResponse(true, "Product saved");
            }
            return new ServiceResponse(false, message);

        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(x => x.Name.ToLower()!.Equals(name.ToLower()));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product already exists");

        }

        private async Task Comit() => await appDbContext.SaveChangesAsync();

        async Task<List<Product>> IProduct.getAllProducts(bool featuredProduct)
        {
            if(featuredProduct)
            {
                return await appDbContext.Products.Where(_=>_.Featured).ToListAsync();
            } else
            {
                return await appDbContext.Products.ToListAsync();
            }
        }
    }
}
