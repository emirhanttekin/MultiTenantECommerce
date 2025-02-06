using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId);
    }
}
