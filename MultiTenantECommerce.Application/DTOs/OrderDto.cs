using MultiTenantECommerce.Application.DTOs.MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.DTOs
{
    public class OrderDto
    {
        public Guid UserID { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
