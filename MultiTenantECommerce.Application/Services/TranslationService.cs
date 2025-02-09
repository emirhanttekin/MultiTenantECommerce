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
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationService(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public async Task<TranslationResponseDto> GetTranslationByIdAsync(Guid id)
        {
            var translation = await _translationRepository.GetByIdAsync(id);
            if (translation == null) return null;

            return new TranslationResponseDto
            {
                Id = translation.Id,
                TenantID = translation.TenantID,
                EntityId = translation.EntityId,
                EntityType = translation.EntityType,
                FieldName = translation.FieldName,
                LanguageCode = translation.LanguageCode,
                TranslatedText = translation.TranslatedText
            };
        }

        public async Task<IEnumerable<TranslationResponseDto>> GetTranslationsByEntityAsync(Guid tenantId, Guid entityId, string entityType)
        {
            var translations = await _translationRepository.GetTranslationsByEntityAsync(tenantId,entityId, entityType);
            return translations.Select(t => new TranslationResponseDto
            {
                Id = t.Id,
                TenantID = t.TenantID,
                EntityId = t.EntityId,
                EntityType = t.EntityType,
                FieldName = t.FieldName,
                LanguageCode = t.LanguageCode,
                TranslatedText = t.TranslatedText
            }).ToList();
        }

        public async Task<string> GetTranslatedFieldAsync(Guid tenantId, Guid entityId, string entityType, string fieldName, string languageCode)
        {
            var translation = await _translationRepository.GetTranslationAsync(tenantId, entityId, entityType, fieldName, languageCode);
            return translation?.TranslatedText ?? "No Translation";
        }

        public async Task<TranslationResponseDto> CreateTranslationAsync(Guid tenantId, TranslationDto translationDto)
        {
            var translation = new Translation
            {
                Id = Guid.NewGuid(),
                TenantID = tenantId,
                EntityId = translationDto.EntityId,
                EntityType = translationDto.EntityType,
                FieldName = translationDto.FieldName,
                LanguageCode = translationDto.LanguageCode,
                TranslatedText = translationDto.TranslatedText
            };

            await _translationRepository.AddAsync(translation);

            return new TranslationResponseDto
            {
                Id = translation.Id,
                TenantID = translation.TenantID,
                EntityId = translation.EntityId,
                EntityType = translation.EntityType,
                FieldName = translation.FieldName,
                LanguageCode = translation.LanguageCode,
                TranslatedText = translation.TranslatedText
            };
        }

        public async Task<TranslationResponseDto> UpdateTranslationAsync(Guid id, TranslationDto translationDto)
        {
            var translation = await _translationRepository.GetByIdAsync(id);
            if (translation == null) return null;

            translation.TranslatedText = translationDto.TranslatedText;
            translation.LanguageCode = translationDto.LanguageCode;

            await _translationRepository.UpdateAsync(translation);

            return new TranslationResponseDto
            {
                Id = translation.Id,
                TenantID = translation.TenantID,
                EntityId = translation.EntityId,
                EntityType = translation.EntityType,
                FieldName = translation.FieldName,
                LanguageCode = translation.LanguageCode,
                TranslatedText = translation.TranslatedText
            };
        }

        public async Task<bool> DeleteTranslationAsync(Guid id)
        {
            var translation = await _translationRepository.GetByIdAsync(id);
            if (translation == null) return false;

            await _translationRepository.DeleteAsync(id);
            return true;
        }
    }
}
