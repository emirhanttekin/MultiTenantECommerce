using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
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

        public async Task<Translation> CrateTranslationAsync(Guid tenantId, TranslationDto translationDto)
        {
            var translation = new Translation
            {
                TenantID = tenantId,
                ProductId = translationDto.ProductId,
                EntityType = "Product",
                LanguageCode = translationDto.LanguageCode,
                FieldName = translationDto.FieldName,
                TranslatedText = translationDto.TranslatedText
            };

            await _translationRepository.AddAsync(translation);
            return translation;
        }

        public async Task<bool> DeleteTranslationAsync(Guid Id)
        {
            var translation = await _translationRepository.GetByIdAsync(Id);
            if (translation == null) return false;
            await _translationRepository.DeleteAsync(Id);
            return true;
        }

        public async Task<Translation> GetTranslationByIdAsync(Guid Id)
        {
            return await _translationRepository.GetByIdAsync(Id);

        }

        public async Task<IEnumerable<Translation>> GetTranslationByProductAsync(Guid productId)
        {
            return await _translationRepository.GetTranslationByProductIdAsync(productId);
        }

        public async Task<IEnumerable<Translation>> GetTranslationByTenantAsync(Guid tenantId)
        {
            return await _translationRepository.GetTranslationByTenantIdAsync(tenantId);

        }

        public async Task<Translation> UpdateTranslationAsync(Guid productId, TranslationDto translationDto)
        {
            var translation = await _translationRepository.GetByIdAsync(productId);
            if (translation == null) return null;

            translation.TranslatedText = translationDto.TranslatedText;
            translation.LanguageCode = translationDto.LanguageCode;

            await _translationRepository.UpdateAsync(translation);
            return translation;
        }

      



    }
}
