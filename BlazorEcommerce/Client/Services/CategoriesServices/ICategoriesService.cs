using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CategoriesServices
{
    public interface ICategoriesService
    {
        public List<Category> Categories { get; set; }

        public Task LoadCategoriesAsync();
    }
}
