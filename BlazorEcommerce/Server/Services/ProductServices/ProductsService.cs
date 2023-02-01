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

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _dataContext
                .Products
                .Include(p => p.Variants)
                .ThenInclude(pv => pv.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _dataContext
                .Products
                .Include(p => p.Variants)
                .ThenInclude(pv => pv.ProductType)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var products = await _dataContext
                .Products
                .Include(p => p.Variants)
                .ThenInclude(pv => pv.ProductType)
                .Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower())
                .ToListAsync();

            return products;
        }
    }
}
