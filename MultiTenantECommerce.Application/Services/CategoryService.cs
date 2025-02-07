using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesByTenantIdAsync(Guid tenantId)
        {
            return await _categoryRepository.GetCategoriesByTenantIdAsync(tenantId);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task<Category> CreateCategoryAsync(Guid tenantId, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                TenantID = tenantId,
                Name = categoryDto.Name,
                ParentCategoryID = categoryDto.ParentCategoryID
            };

            await _categoryRepository.AddAsync(category);
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Guid id, CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null) return null;

            category.Name = categoryDto.Name;
            category.ParentCategoryID = categoryDto.ParentCategoryID;

            await _categoryRepository.UpdateAsync(category);
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null) return false;

            await _categoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Category>> GetSubCategoriesAsync(Guid parentCategoryId)
        {
            return await _categoryRepository.GetSubCategoriesAsync(parentCategoryId);
        }
    }
}
