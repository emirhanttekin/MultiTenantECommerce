using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(Guid tenantID, ProductDto productDto)
        {
            var product = new Product
            {
                TenantID = tenantID,
      
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            await _productRepository.AddAsync(product);
            return product;
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByTenantAsync(Guid tenantId)
        {
            return await _productRepository.GetProductsByTenantIdAsync(tenantId);
        }

        public async Task<Product> UpdateProductAsync(Guid productId, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;

            await _productRepository.UpdateAsync(product);
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return false;

            await _productRepository.DeleteAsync(productId);
            return true;
        }
    }
}
