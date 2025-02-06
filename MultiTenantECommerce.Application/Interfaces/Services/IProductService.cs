using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Guid tenantID, ProductDto productDto);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsByTenantAsync(Guid tenantId);
        Task<Product> UpdateProductAsync(Guid productId, ProductDto productDto);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
