using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductServices
{
    public interface IProductService
    {
        public List<Product> Products { get; set; }

        public Task GetProducts();
        public Task<Product> GetById(int id);
    }
}
