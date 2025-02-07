using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCategoryService(
            IProductCategoryRepository productCategoryRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId)
        {
            return await _productCategoryRepository.GetProductCategoriesByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryIdAsync(Guid categoryId)
        {
            return await _productCategoryRepository.GetProductCategoriesByCategoryIdAsync(categoryId);
        }

        public async Task AddProductToCategoryAsync(Guid productId, Guid categoryId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (product == null || category == null)
                throw new InvalidOperationException("Product or Category not found");

            var productCategory = new ProductCategory
            {
                ProductID = productId,
                CategoryID = categoryId
            };

            await _productCategoryRepository.AddAsync(productCategory);
        }

        public async Task RemoveProductFromCategoryAsync(Guid productId, Guid categoryId)
        {
            await _productCategoryRepository.RemoveProductCategoryAsync(productId, categoryId);
        }
    }
}
