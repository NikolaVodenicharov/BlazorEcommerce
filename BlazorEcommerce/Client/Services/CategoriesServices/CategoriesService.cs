using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.CategoriesServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient _httpClient;

        public CategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task LoadCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Category>>("api/Categories");

            if (response != null)
            {
                Categories = response;
            }
        }
    }
}
