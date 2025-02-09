using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<Translation> GetTranslationAsync(Guid tenantId, Guid entityId, string entityType, string fieldName, string languageCode);
        Task<IEnumerable<Translation>> GetTranslationsByEntityAsync(Guid tenantId, Guid entityId, string entityType);
    }
}
