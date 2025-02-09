using MultiTenantECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface ITranslationService
    {
        Task<TranslationResponseDto> GetTranslationByIdAsync(Guid id);
        Task<IEnumerable<TranslationResponseDto>> GetTranslationsByEntityAsync(Guid tenantId, Guid entityId, string entityType);
        Task<string> GetTranslatedFieldAsync(Guid tenantId, Guid entityId, string entityType, string fieldName, string languageCode);
        Task<TranslationResponseDto> CreateTranslationAsync(Guid tenantId, TranslationDto translationDto);
        Task<TranslationResponseDto> UpdateTranslationAsync(Guid id, TranslationDto translationDto);
        Task<bool> DeleteTranslationAsync(Guid id);
    }
}
