using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IProductImageRepository :IGenericRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId);
    }
}
