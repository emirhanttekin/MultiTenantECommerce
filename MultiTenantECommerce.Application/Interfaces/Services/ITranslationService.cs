using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.Interfaces
{
    public interface ITranslationService
    {
        Task<Translation> CrateTranslationAsync( Guid tenantId ,TranslationDto translationDto);

        Task<Translation> GetTranslationByIdAsync(Guid Id);
        Task<IEnumerable<Translation>> GetTranslationByTenantAsync(Guid tenantId);
        Task<IEnumerable<Translation>> GetTranslationByProductAsync(Guid productId);
        Task<Translation> UpdateTranslationAsync(Guid productId, TranslationDto translationDto);
        Task<bool> DeleteTranslationAsync(Guid Id);


    }
}
