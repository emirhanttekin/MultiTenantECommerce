using MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.Interfaces.Services
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageDto>> GetImagesByProductIdAsync(Guid productId);
        Task<ProductImageDto> GetMainImageByProductIdAsync(Guid productId);
        Task<ProductImageDto> AddProductImageAsync(ProductImageDto productImageDto);
        Task<bool> DeleteProductImageAsync(Guid imageId);
    }
}
