using MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesByTenantIdAsync(Guid tenantId);
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
        Task<Category> CreateCategoryAsync(Guid tenantId, CategoryDto categoryDto);
        Task<Category> UpdateCategoryAsync(Guid id, CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<IEnumerable<Category>> GetSubCategoriesAsync(Guid parentCategoryId);
    }
}
