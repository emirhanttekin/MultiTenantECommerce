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

        [HttpGet("tenant/{tenantId:guid}")]
        public async Task<IActionResult> GetCategoriesByTenantId(Guid tenantId)
        {
            var categories = await _categoryService.GetCategoriesByTenantIdAsync(tenantId);
            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryDto categoryDto)
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
        public async Task<IActionResult> GetSubCategories(Guid parentCategoryId)
        {
            var subCategories = await _categoryService.GetSubCategoriesAsync(parentCategoryId);
            return Ok(subCategories);
        }
    }
}
