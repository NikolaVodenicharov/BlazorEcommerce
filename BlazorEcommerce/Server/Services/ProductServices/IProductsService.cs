namespace BlazorEcommerce.Server.Services.ProductServices
{
    public interface IProductsService
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl);

        public Task<Product> GetProductAsync(int id);

    }
}
