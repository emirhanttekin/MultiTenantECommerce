using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class TranslationRepository : GenericRepository<Translation>, ITranslationRepository
    {
        private readonly DataContext _context;
        public TranslationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Translation>> GetTranslationByProductIdAsync(Guid productId)
        {
          return await _context.Translations
                .Where(p => p.Product.Id == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Translation>> GetTranslationByTenantIdAsync(Guid tenantId)
        {
            return await _context.Translations
                .Where(p => p.Id == tenantId)
                .ToListAsync();
        }
    }
}
