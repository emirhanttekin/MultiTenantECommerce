using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;
using MultiTenantECommerce.Persistence.Repository;

namespace MultiTenantECommerce.Persistence.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DataContext _context;

        public ProductCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId)
        {
            return await _context.ProductCategories
                .Where(pc => pc.ProductID == productId)
                .Include(pc => pc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryIdAsync(Guid categoryId)
        {
            return await _context.ProductCategories
                .Where(pc => pc.CategoryID == categoryId)
                .Include(pc => pc.Product)
                .ToListAsync();
        }

        public async Task RemoveProductCategoryAsync(Guid productId, Guid categoryId)
        {
            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductID == productId && pc.CategoryID == categoryId);

            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
