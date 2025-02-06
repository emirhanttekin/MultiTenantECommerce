namespace MultiTenantECommerce.Application.DTOs
{
    public class TranslationDto
    {

        public Guid ProductId { get; set; }  
        public string LanguageCode { get; set; } // "en", "tr", "de" gibi dil kodları
        public string TranslatedText { get; set; } // Çeviri metni

        public string EntityType { get; set; }

        public string FieldName { get; set; }  
 
    }

}
