using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        private readonly  DataContext _context;
        public ProductImageRepository(DataContext context) : base(context)
        {
            _context  = context;
        }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductID == productId)
                .ToListAsync();
        }
    }
}
