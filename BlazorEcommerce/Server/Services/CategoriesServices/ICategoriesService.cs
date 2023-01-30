namespace BlazorEcommerce.Server.Services.CategoriesServices
{
    public interface ICategoriesService
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
