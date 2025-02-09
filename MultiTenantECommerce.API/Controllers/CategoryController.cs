using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromQuery] Guid tenantId, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Category data is required.");

            var newCategory = await _categoryService.CreateCategoryAsync(tenantId, categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }

        [HttpGet("tenant/{tenantId:guid}/{languageCode}")]
        public async Task<IActionResult> GetCategoriesByTenantId(Guid tenantId, string languageCode)
        {
            var categories = await _categoryService.GetCategoriesByTenantIdAsync(tenantId, languageCode);
            return Ok(categories);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId, string languageCode)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId, languageCode);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            if (updatedCategory == null) return NotFound();
            return Ok(updatedCategory);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("subcategories/{parentCategoryId:guid}")]
        public async Task<IActionResult> GetSubCategories(Guid parentCategoryId, string languageCode)
        {
            var subCategories = await _categoryService.GetSubCategoriesAsync(parentCategoryId , languageCode);
            return Ok(subCategories);
        }
    }
}
