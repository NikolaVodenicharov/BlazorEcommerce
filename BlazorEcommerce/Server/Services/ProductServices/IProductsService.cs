namespace BlazorEcommerce.Server.Services.ProductServices
{
    public interface IProductsService
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl);

        public Task<List<Product>> GetProductsBySearchAsync(string searchText);
        public Task<List<string>> GetSearchSuggestionsAsync(string searchText);

        public Task<Product> GetProductAsync(int id);

    }
}
