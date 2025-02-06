using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByTenantIdAsync(Guid tenantId);
    }
}
