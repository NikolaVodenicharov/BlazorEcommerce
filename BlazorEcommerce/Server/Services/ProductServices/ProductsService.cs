using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.ProductServices
{
    public class ProductsService : IProductsService
    {
        private readonly DataContext _dataContext;

        public ProductsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _dataContext.Products.ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var products = await _dataContext
                .Products
                .Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower())
                .ToListAsync();

            return products;
        }
    }
}
