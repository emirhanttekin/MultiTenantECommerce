using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllTenantsAsync();
        Task<Tenant> GetTenantByIdAsync(Guid id);
        Task<Tenant> CreateTenantAsync(TenantDto tenantDto);
        Task<Tenant> UpdateTenantAsync(Guid id, TenantDto tenantDto);
        Task<bool> DeleteTenantAsync(Guid id);
    }
}
