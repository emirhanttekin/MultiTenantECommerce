using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class TenantRepository : GenericRepository<Tenant> , ITenantRepository
    {
        private readonly DataContext _context;

        public TenantRepository(DataContext context) : base(context)
        {
        _context = context;
        }

        public async Task<Tenant> GetTenantByDomainAsync(string domain)
        {
            return await _context.Tenants.FirstOrDefaultAsync(t => t.Domain == domain);
        }
    }
}
