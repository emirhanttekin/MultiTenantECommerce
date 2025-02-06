using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTranslation(
            [FromQuery] Guid tenantID,
 
             [FromBody] TranslationDto translationDto)
        {
            var newTranslation = await _translationService.CrateTranslationAsync(tenantID , translationDto);
            return CreatedAtAction(nameof(GetTranslationById), new { id = newTranslation.Id }, newTranslation);
        }

        [HttpGet("{id:guid}")]
        
        public async Task<IActionResult>GetTranslationById(Guid id)
        {
            var translation = await _translationService.GetTranslationByIdAsync(id);
            if (translation == null) return NotFound();
            return Ok(translation);
        }
        [HttpGet("tenant/{tenantId:Guid}")]
        public async Task<IActionResult> GetTranslationByTenant(Guid tenantId)
        {
            var translation = await _translationService.GetTranslationByTenantAsync(tenantId);
            if (translation == null) return NotFound();
            return Ok(translation);
        }

        [HttpGet("product/{productId:Guid}")]
        public async Task<IActionResult> GetTranslationByProduct(Guid productId)
        {
            var translation = await _translationService.GetTranslationByProductAsync(productId);
            if (translation == null) return NotFound();
            return Ok(translation);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTranslation(Guid id, [FromBody] TranslationDto translationDto)
        {
            var updateTranslation = await _translationService.UpdateTranslationAsync(id, translationDto);
            if (updateTranslation == null) return NotFound();
            return Ok(updateTranslation);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTranslation(Guid id)
        {
            var result = await _translationService.DeleteTranslationAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
