using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ITenantRepository : IGenericRepository<Tenant>
    {
        Task<Tenant> GetTenantByDomainAsync(string domain);
    }
}
