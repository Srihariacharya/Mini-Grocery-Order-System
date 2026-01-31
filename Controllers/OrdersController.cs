using Microsoft.AspNetCore.Mvc;
using MiniGroceryOrderSystem.Services;

namespace MiniGroceryOrderSystem.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public class CreateOrderRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                await _orderService.PlaceOrderAsync(request.ProductId, request.Quantity);
                return Ok(new { message = "Order placed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
