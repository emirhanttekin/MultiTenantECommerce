using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly DataContext _context;
        public OrderItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
           return await _context.OrderItems.Where(oi => oi.OrderID == orderId).ToListAsync();
        }
    }
}
