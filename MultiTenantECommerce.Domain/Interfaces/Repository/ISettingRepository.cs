using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ISettingRepository : IGenericRepository<Setting>
    {
        Task<Setting> GetSettingByKeyAsync(Guid tenantId, string key);
    }
}
