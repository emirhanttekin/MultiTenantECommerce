using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using System;
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
        public async Task<IActionResult> CreateTranslation([FromQuery] Guid tenantId, [FromBody] TranslationDto translationDto)
        {
            var translation = await _translationService.CreateTranslationAsync(tenantId, translationDto);
            return CreatedAtAction(nameof(GetTranslationById), new { id = translation.Id }, translation);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTranslationById(Guid id)
        {
            var translation = await _translationService.GetTranslationByIdAsync(id);
            if (translation == null) return NotFound();
            
            return Ok(translation);
        }

        [HttpGet("entity/{entityId:guid}/{entityType}")]
        public async Task<IActionResult> GetTranslationsByEntity(Guid tenantId,Guid entityId, string entityType)
        {
            var translations = await _translationService.GetTranslationsByEntityAsync(tenantId,entityId, entityType);
            return Ok(translations);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTranslation(Guid id)
        {
            var result = await _translationService.DeleteTranslationAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}
