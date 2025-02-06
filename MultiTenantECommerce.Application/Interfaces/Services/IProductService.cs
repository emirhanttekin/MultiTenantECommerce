using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string languageCode = "en");
        Task<ProductDto> GetProductByIdAsync(Guid id, string languageCode = "en");
        Task<Product> CreateProductAsync(ProductDto productDto, string languageCode, string description);
        Task<Product> UpdateProductAsync(Guid id, ProductDto productDto, string languageCode, string description);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
