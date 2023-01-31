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
        private readonly DataContext db;
        private readonly IProductsService _productsService;

        public ProductsController(DataContext db, IProductsService productsService)
        {
            this.db = db;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await db.Products.ToListAsync();

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
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);

            return Ok(product);
        }
    }
}
 