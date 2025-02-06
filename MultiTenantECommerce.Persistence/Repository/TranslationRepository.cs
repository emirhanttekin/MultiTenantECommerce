using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using MultiTenantECommerce.Persistence.Context;
using System;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Persistence.Repository
{
    public class TranslationRepository : GenericRepository<Translation>, ITranslationRepository
    {
        private readonly DataContext _context;

        public TranslationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetTranslationAsync(Guid productId, string languageCode)
        {
            var translation = await _context.Translations
                .FirstOrDefaultAsync(t => t.ProductId == productId
                    && t.EntityType == "Product"
                    && t.FieldName == "Description"
                    && t.LanguageCode == languageCode);

            return translation?.TranslatedText;
        }

        public async Task AddOrUpdateTranslationAsync(Guid productId, string languageCode, string translatedText)
        {
            var translation = await _context.Translations
                .FirstOrDefaultAsync(t => t.ProductId == productId
                    && t.EntityType == "Product"
                    && t.FieldName == "Description"
                    && t.LanguageCode == languageCode);

            if (translation == null)
            {
  
                translation = new Translation
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    EntityType = "Product",
                    FieldName = "Description",
                    LanguageCode = languageCode,
                    TranslatedText = translatedText
                };
                await AddAsync(translation); 
            }
            else
            {
                // Mevcut çeviriyi güncelle
                translation.TranslatedText = translatedText;
                await UpdateAsync(translation); 
            }
        }

        public async Task DeleteTranslationAsync(Guid productId, string languageCode)
        {
            var translation = await _context.Translations
                .FirstOrDefaultAsync(t => t.ProductId == productId
                    && t.EntityType == "Product"
                    && t.FieldName == "Description"
                    && t.LanguageCode == languageCode);

            if (translation != null)
            {
                await DeleteAsync(translation.Id); 
            }
        }
    }
}
