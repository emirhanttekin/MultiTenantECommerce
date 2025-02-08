using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetImagesByProductId(Guid productId)
        {
            var images = await _productImageService.GetImagesByProductIdAsync(productId);
            return Ok(images);
        }

        [HttpGet("product/{productId:guid}/main")]
        public async Task<IActionResult> GetMainImageByProductId(Guid productId)
        {
            var image = await _productImageService.GetMainImageByProductIdAsync(productId);
            if (image == null) return NotFound();
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductImage([FromBody] ProductImageDto productImageDto)
        {
            var image = await _productImageService.AddProductImageAsync(productImageDto);
            return CreatedAtAction(nameof(GetImagesByProductId), new { productId = image.ProductID }, image);
        }

        [HttpDelete("{imageId:guid}")]
        public async Task<IActionResult> DeleteProductImage(Guid imageId)
        {
            var success = await _productImageService.DeleteProductImageAsync(imageId);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
