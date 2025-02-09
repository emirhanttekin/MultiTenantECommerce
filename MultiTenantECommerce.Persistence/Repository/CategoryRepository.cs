using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context) {

            _context = context;
        
        }

        public async Task<IEnumerable<Category>> GetCategoriesByTenantIdAsync(Guid tenantId)
        {
            return await _context.Categories
                .Where(c => c.TenantID == tenantId)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetSubCategoriesAsync(Guid parentCategoryId)
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryID == parentCategoryId)
                .ToListAsync();
        }
    }
}
