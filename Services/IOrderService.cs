namespace MiniGroceryOrderSystem.Services
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(int productId, int quantity);
    }
}
