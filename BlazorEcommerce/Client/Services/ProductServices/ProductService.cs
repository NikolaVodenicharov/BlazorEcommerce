using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<Product> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Product>($"api/Products/{id}");

            return result;
        }

        public async Task GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Product>>("api/Products");

            if (result != null)
            {
                Products = result;
            }
        }
    }
}
