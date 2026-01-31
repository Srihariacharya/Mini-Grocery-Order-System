using MiniGroceryOrderSystem.Data;
using MiniGroceryOrderSystem.Models;
using MiniGroceryOrderSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MiniGroceryOrderSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            AppDbContext context,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task PlaceOrderAsync(int productId, int quantity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Fetch product
                var product = await _productRepository.GetByIdAsync(productId);

                if (product == null)
                    throw new Exception("Product not found");

                // 2. Check stock
                if (product.Stock < quantity)
                    throw new Exception("Insufficient stock");

                // 3. Reduce stock
                product.Stock -= quantity;
                await _productRepository.UpdateAsync(product);

                // 4. Create order
                var order = new Order
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TotalPrice = product.Price * quantity,
                    CreatedAt = DateTime.UtcNow
                };

                await _orderRepository.AddAsync(order);

                // 5. Save changes
                await _context.SaveChangesAsync();

                // 6. Commit transaction
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
