using MultiTenantECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<IEnumerable<Translation>> GetTranslationByTenantIdAsync(Guid tenantId);

        Task<IEnumerable<Translation>> GetTranslationByProductIdAsync(Guid productId);
    }
}
