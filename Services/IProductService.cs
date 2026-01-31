using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
