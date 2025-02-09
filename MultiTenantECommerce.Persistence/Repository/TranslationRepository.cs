using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class TranslationRepository : GenericRepository<Translation>, ITranslationRepository
    {
        private readonly DataContext _context;

        public TranslationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Translation> GetTranslationAsync(Guid tenantId, Guid entityId, string entityType, string fieldName, string languageCode)
        {
            return await _context.Translations
                .FirstOrDefaultAsync(t => t.TenantID == tenantId &&
                                          t.EntityId == entityId &&
                                          t.EntityType == entityType &&
                                          t.FieldName == fieldName &&
                                          t.LanguageCode == languageCode);
        }

        public async Task<IEnumerable<Translation>> GetTranslationsByEntityAsync(Guid tenantId, Guid entityId, string entityType)
        {
            return await _context.Translations
                .Where(t => t.TenantID == tenantId &&
                            t.EntityId == entityId &&
                            t.EntityType == entityType)
                .ToListAsync();
        }
    }
}
