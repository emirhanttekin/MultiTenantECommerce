using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesByTenantIdAsync(Guid tenantId, string languageCode);
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, string languageCode);
        Task<Category> CreateCategoryAsync(Guid tenantId, CategoryDto categoryDto);
        Task<Category> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<IEnumerable<CategoryResponseDto>> GetSubCategoriesAsync(Guid parentCategoryId, string languageCode);
    }
}
