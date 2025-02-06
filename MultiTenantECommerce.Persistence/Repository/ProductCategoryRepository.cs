using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DataContext _context;
        public ProductCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryIdAsync(Guid categoryId)
        {
            return await _context.ProductCategories.Where(pc => pc.CategoryID == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId)
        {
           return await _context.ProductCategories.Where(pc => pc.ProductID == productId).ToListAsync();
        }
    }
}
 