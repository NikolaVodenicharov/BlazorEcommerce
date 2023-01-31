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
    }
}
