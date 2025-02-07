using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<IEnumerable<Translation>> GetTranslationByTenantIdAsync(Guid tenantId);

        Task<IEnumerable<Translation>> GetTranslationByProductIdAsync(Guid productId);
    }
}
