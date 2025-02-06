using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return await _tenantRepository.GetAllAsync();
        }

        public async Task<Tenant> GetTenantByIdAsync(Guid id)
        {
            return await _tenantRepository.GetByIdAsync(id);
        }

        public async Task<Tenant> CreateTenantAsync(TenantDto tenantDto)
        {
            var tenant = new Tenant
            {
                Name = tenantDto.Name,
                Domain = tenantDto.Domain
            };
            await _tenantRepository.AddAsync(tenant);
            return tenant;
        }

        public async Task<Tenant> UpdateTenantAsync(Guid id, TenantDto tenantDto)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant == null) return null;

            tenant.Name = tenantDto.Name;
            tenant.Domain = tenantDto.Domain;
            await _tenantRepository.UpdateAsync(tenant);
            return tenant;
        }

        public async Task<bool> DeleteTenantAsync(Guid id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant == null) return false;

            await _tenantRepository.DeleteAsync(id);
            return true;
        }
    }
}
