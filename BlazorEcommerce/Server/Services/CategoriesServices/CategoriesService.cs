using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.CategoriesServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DataContext _db;

        public CategoriesService(DataContext db) 
        {
            _db= db; 
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await _db.Categories.ToListAsync();

            return categories;
        }
    }
}
