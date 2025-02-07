namespace MultiTenantECommerce.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId);
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryIdAsync(Guid categoryId);
        Task AddProductToCategoryAsync(Guid productId, Guid categoryId);
        Task RemoveProductFromCategoryAsync(Guid productId, Guid categoryId);
    }
}
