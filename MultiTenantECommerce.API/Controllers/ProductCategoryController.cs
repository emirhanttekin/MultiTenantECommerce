using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.Interfaces;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
       private  readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }


        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetProductByProductId(Guid id)
        {
            var categories = await _productCategoryService.GetProductCategoriesByProductIdAsync(id);
            return Ok(categories);
        }

        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId) 
        {
            var products = await _productCategoryService.GetProductCategoriesByCategoryIdAsync(categoryId);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCategory([FromQuery] Guid productId, [FromQuery] Guid categoryId)
        {
            await _productCategoryService.AddProductToCategoryAsync(productId, categoryId);
            return Ok("Product added from category successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProductFromCategory([FromQuery] Guid productId, [FromQuery] Guid categoryId)
        {
             await _productCategoryService.RemoveProductFromCategoryAsync(productId, categoryId);
            return Ok("Product removed from category successfully");

        }





    }
}
