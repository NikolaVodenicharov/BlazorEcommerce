using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsService.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetProducts(string categoryUrl)
        {
            var products = await _productsService.GetProductsByCategoryAsync(categoryUrl);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            var product = await _productsService.GetProductAsync(id);

            return Ok(product);
        }
    }
}
 