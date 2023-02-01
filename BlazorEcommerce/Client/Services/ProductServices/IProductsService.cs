using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductServices
{
    public interface IProductsService
    {
        event Action ProductsChanged;

        public string Message { get; set; }

        public List<Product> Products { get; set; }

        public Task LoadProducts(string? categoryUrl = null);

        public Task LoadSearchProductsAsync(string searchText);

        public Task<List<string>> GetSearchSuggestionsAsync(string searchText);

        public Task<Product> GetById(int id);
    }
}
