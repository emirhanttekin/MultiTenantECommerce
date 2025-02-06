using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITranslationRepository _translationRepository;

        public ProductService(IProductRepository productRepository, ITranslationRepository translationRepository)
        {
            _productRepository = productRepository;
            _translationRepository = translationRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(string languageCode = "tr")
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                var translatedDescription = await _translationRepository.GetTranslationAsync(product.Id, languageCode);
                productDtos.Add(new ProductDto
                {
                    Name = product.Name,
                    Description = translatedDescription ?? "", 
                    Price = product.Price,
                    Stock = product.Stock
                });
            }
            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id, string languageCode = "tr")
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            var translatedDescription = await _translationRepository.GetTranslationAsync(id, languageCode);

            return new ProductDto
            {
                Name = product.Name,
                Description = translatedDescription ?? "",
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<Product> CreateProductAsync(ProductDto productDto, string languageCode, string description)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(), 
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            };

            await _productRepository.AddAsync(product);

          
            await _translationRepository.AddOrUpdateTranslationAsync(product.Id, languageCode, description);

            return product;
        }

        public async Task<Product> UpdateProductAsync(Guid id, ProductDto productDto, string languageCode, string description)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;

            await _productRepository.UpdateAsync(product);

            await _translationRepository.AddOrUpdateTranslationAsync(product.Id, languageCode, description);

            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteAsync(id);

            await _translationRepository.DeleteTranslationAsync(id, "tr"); 

            return true;
        }
    }
}
