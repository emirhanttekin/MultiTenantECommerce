using MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(Guid tenantId , OrderDto orderDto);
        Task<IEnumerable<OrderResponseDto>>GetOrdersByUserIdAsync(Guid userId);
        Task<IEnumerable<OrderResponseDto>> GetOrdersByTenantIdAsync(Guid tenantId);
        Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId);
        Task<bool>UpdateOrderStatusAsync(Guid orderId , string status);

    }
}
