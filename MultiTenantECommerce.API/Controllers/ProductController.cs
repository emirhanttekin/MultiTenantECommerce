using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromQuery] Guid tenantID,
            [FromBody] ProductDto productDto)
        {
            var newProduct = await _productService.CreateProductAsync(tenantID, productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("tenant/{tenantId:guid}")]
        public async Task<IActionResult> GetProductsByTenant(Guid tenantId)
        {
            var products = await _productService.GetProductsByTenantAsync(tenantId);
            return Ok(products);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, productDto);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
