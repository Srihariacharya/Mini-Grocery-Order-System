using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
