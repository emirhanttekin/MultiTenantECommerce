using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByTenantIdAsync(Guid tenantId)
        {
            return await _context.Products
                .Where(p => p.Id == tenantId)
                .ToListAsync();
        }
    }
}
