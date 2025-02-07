using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromQuery] Guid TenantId, [FromBody] OrderDto orderDto)
        {
            var order = await _orderService.CreateOrderAsync(TenantId, orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = order.Id }, order);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null) {
                return NotFound();
            }
            
            return Ok(order);
          
        }
        [HttpGet("user/{userId:guid}")] 
        public async Task<IActionResult> getOrdersByUser(Guid userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);

        }
        [HttpPut("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromBody] string status)
        {
            var result = await _orderService.UpdateOrderStatusAsync(orderId, status);
            return result ? Ok() : NotFound();
        }
    }
}
