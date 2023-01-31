using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductServices
{
    public interface IProductsService
    {
        event Action ProductsChanged;

        public List<Product> Products { get; set; }

        public Task LoadProducts(string? categoryUrl = null);

        public Task<Product> GetById(int id);
    }
}
