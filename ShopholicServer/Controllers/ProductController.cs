using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopholiSharedLibrary.Contracts;
using ShopholiSharedLibrary.Models;
using ShopholiSharedLibrary.Responses;

namespace ShopholicServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productService;

        public ProductController(IProduct productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(bool featured)
        {
            var products = await productService.getAllProducts(featured);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> addProduct(Product model)
        {
            if (model is null) return BadRequest("Model is null");
            var response = await productService.AddProduct(model);
            return Ok(response);
        }
    }
}
