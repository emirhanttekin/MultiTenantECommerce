using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITranslationRepository _translationRepository;

        public CategoryService(ICategoryRepository categoryRepository, ITranslationRepository translationRepository)
        {
            _categoryRepository = categoryRepository;
            _translationRepository = translationRepository;
        }
        public async Task<IEnumerable<CategoryResponseDto>> GetCategoriesByTenantIdAsync(Guid tenantId, string languageCode)
        {
            var categories = await _categoryRepository.GetCategoriesByTenantIdAsync(tenantId);

            if (categories == null || !categories.Any())
                return new List<CategoryResponseDto>();

            var categoryDtos = new List<CategoryResponseDto>();

            foreach (var category in categories)
            {
                // ✅ Ana kategorileri (ParentCategoryID NULL olanları) da dahil etmeliyiz!
                var translatedName = await GetTranslatedTextAsync(category.TenantID, category.Id, "Category", "Name", languageCode);

                categoryDtos.Add(new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = translatedName ?? "No Translation",
                    ParentCategoryID = category.ParentCategoryID
                });
            }

            return categoryDtos;
        }



        public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, string languageCode)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null) return null;

            var translatedName = await GetTranslatedTextAsync(category.TenantID, category.Id, "Category", "Name", languageCode);

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = translatedName ?? "No Translation",
                ParentCategoryID = category.ParentCategoryID,
            };
        }

        public async Task<Category> CreateCategoryAsync(Guid tenantId, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                TenantID = tenantId,
                ParentCategoryID = categoryDto.ParentCategoryID
            };

            await _categoryRepository.AddAsync(category);

            if (!string.IsNullOrEmpty(categoryDto.Name))
            {
                var translation = new Translation
                {
                    TenantID = tenantId,
                    EntityId = category.Id,
                    EntityType = "Category",
                    FieldName = "Name",
                    LanguageCode = categoryDto.LanguageCode,  // ✅ Kullanıcının gönderdiği languageCode kullanılacak.
                    TranslatedText = categoryDto.Name
                };

                await _translationRepository.AddAsync(translation);
            }

            return category;
        }


        public async Task<Category> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null) return null;

            if (categoryDto.ParentCategoryID.HasValue)
            {
                category.ParentCategoryID = categoryDto.ParentCategoryID;
            }

            if (!string.IsNullOrEmpty(categoryDto.Name))
            {
                var existingTranslation = await _translationRepository.GetTranslationAsync(category.TenantID, category.Id, "Category", "Name", "en");

                if (existingTranslation != null)
                {
                    existingTranslation.TranslatedText = categoryDto.Name;
                    await _translationRepository.UpdateAsync(existingTranslation);
                }
                else
                {
                    var newTranslation = new Translation
                    {
                        TenantID = category.TenantID,
                        EntityId = category.Id,
                        EntityType = "Category",
                        FieldName = "Name",
                        LanguageCode = "en",
                        TranslatedText = categoryDto.Name
                    };
                    await _translationRepository.AddAsync(newTranslation);
                }
            }

            await _categoryRepository.UpdateAsync(category);
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null) return false;

            await _categoryRepository.DeleteAsync(id);

            var translations = await _translationRepository.GetTranslationsByEntityAsync(category.TenantID, category.Id, "Category");
            foreach (var translation in translations)
            {
                await _translationRepository.DeleteAsync(translation.Id);
            }

            return true;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetSubCategoriesAsync(Guid parentCategoryId, string languageCode)
        {
            var subCategories = await _categoryRepository.GetSubCategoriesAsync(parentCategoryId);
            var categoryDtos = new List<CategoryResponseDto>();

            foreach (var category in subCategories)
            {
                var translatedName = await GetTranslatedTextAsync(category.TenantID, category.Id, "Category", "Name", languageCode);
                categoryDtos.Add(new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = translatedName ?? "No Translation",
                    ParentCategoryID = category.ParentCategoryID,
                });
            }

            return categoryDtos;
        }

        private async Task<string> GetTranslatedTextAsync(Guid tenantId, Guid entityId, string entityType, string fieldName, string languageCode)
        {
            var translation = await _translationRepository.GetTranslationAsync(tenantId, entityId, entityType, fieldName, languageCode);

            return translation?.TranslatedText ?? "No Translation"; 
        }

    }
}
