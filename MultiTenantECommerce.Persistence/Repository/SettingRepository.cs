using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class SettingRepository : GenericRepository<Setting> ,ISettingRepository 
    {
        private readonly DataContext _context;

        public SettingRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Setting> GetSettingByKeyAsync(Guid tenantId, string key)
        {
            return await _context.Settings
                  .FirstOrDefaultAsync(s => s.TenantID == tenantId && s.Key == key);
        }
    }
}
