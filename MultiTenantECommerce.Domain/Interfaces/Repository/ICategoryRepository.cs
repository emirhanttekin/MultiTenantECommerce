namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesByTenantIdAsync(Guid tenantId);
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetSubCategoriesAsync(Guid parentCategoryId);
    }
}
