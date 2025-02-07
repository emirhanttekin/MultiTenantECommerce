namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId);
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryIdAsync(Guid categoryId);
        Task RemoveProductCategoryAsync(Guid productId, Guid categoryId);

    }
}
