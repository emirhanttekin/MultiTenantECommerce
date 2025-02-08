using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<IEnumerable<ProductImageDto>> GetImagesByProductIdAsync(Guid productId)
        {
            var images = await _productImageRepository.GetImagesByProductIdAsync(productId);
            return images.Select(img => new ProductImageDto
            {
                ProductID = img.ProductID,
                ImageUrl = img.ImageUrl,
                IsMain = img.IsMain
            }).ToList();
        }

        public async Task<ProductImageDto> GetMainImageByProductIdAsync(Guid productId)
        {
            var image = await _productImageRepository.GetMainImageByProductIdAsync(productId);
            if (image == null) return null;

            return new ProductImageDto
            {
                ProductID = image.ProductID,
                ImageUrl = image.ImageUrl,
                IsMain = image.IsMain
            };
        }

        public async Task<ProductImageDto> AddProductImageAsync(ProductImageDto productImageDto)
        {
            var image = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductID = productImageDto.ProductID,
                ImageUrl = productImageDto.ImageUrl,
                IsMain = productImageDto.IsMain
            };

            await _productImageRepository.AddAsync(image);

            return new ProductImageDto
            {
                ProductID = image.ProductID,
                ImageUrl = image.ImageUrl,
                IsMain = image.IsMain
            };
        }

        public async Task<bool> DeleteProductImageAsync(Guid imageId)
        {
            var image = await _productImageRepository.GetByIdAsync(imageId);
            if (image == null) return false;

            await _productImageRepository.DeleteAsync(imageId);
            return true;
        }
    }
}
