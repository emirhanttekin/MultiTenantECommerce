using MultiTenantECommerce.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Task<string> GetTranslationAsync(Guid productId, string languageCode);
        Task AddOrUpdateTranslationAsync(Guid productId, string languageCode, string translatedText);
        Task DeleteTranslationAsync(Guid productId, string languageCode);
    }
}
