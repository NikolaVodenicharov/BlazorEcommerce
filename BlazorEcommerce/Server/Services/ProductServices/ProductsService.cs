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

        public async Task<List<Product>> GetProductsBySearchAsync(string searchText)
        {
            List<Product> products = await FindProdutsBySearchAsync(searchText);

            return products;
        }

        public async Task<List<string>> GetSearchSuggestionsAsync(string searchText)
        {
            List<Product> products = await FindProdutsBySearchAsync(searchText);

            List<string> result = new();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product
                        .Description
                        .Where(char.IsPunctuation)
                        .Distinct()
                        .ToArray();

                    var words = product
                        .Description
                        .Split()
                        .Select(w => w.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && 
                            !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return result;
        }

        private async Task<List<Product>> FindProdutsBySearchAsync(string searchText)
        {
            var products = await _dataContext
                .Products
                .Include(p => p.Variants)
                .ThenInclude(pv => pv.ProductType)
                .Where(p => (
                    p.Title.ToLower().Contains(searchText.ToLower())) ||
                    p.Description.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();

            return products;
        }
    }
}
