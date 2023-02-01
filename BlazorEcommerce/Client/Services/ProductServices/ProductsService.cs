using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductServices
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _httpClient;

        public event Action ProductsChanged;

        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public string Message { get; set; }

        public async Task<Product> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"api/Products/{id}");

            return result;
        }

        public async Task LoadProducts(string? categoryUrl = null)
        {
            var url = 
                categoryUrl == null ? 
                "api/Products" : 
                $"api/Products/category/{categoryUrl}";

            var result = await _httpClient.GetFromJsonAsync<List<Product>>(url);

            if (result != null)
            {
                Products = result;
            }

            ProductsChanged.Invoke();
        }

        public async Task LoadSearchProductsAsync(string searchText)
        {
            var url = $"api/Products/search/{searchText}";

            var result = await _httpClient.GetFromJsonAsync<List<Product>>(url);

            if (result == null)
            {
                return;
            }

            if (result.Count == 0)
            {
                Message = "No products found";
            }

            if (result != null)
            {
                Products = result;
            }

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetSearchSuggestionsAsync(string searchText)
        {
            var url = $"api/Products/search-suggestions/{searchText}";

            var suggestions = await _httpClient.GetFromJsonAsync<List<string>>(url);

            return suggestions;
        }
    }
}
