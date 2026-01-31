using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
    }
}
