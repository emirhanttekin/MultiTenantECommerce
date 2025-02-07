namespace MultiTenantECommerce.Application.DTOs
{
    public class TranslationDto
    {

        public Guid ProductId { get; set; }  
        public string LanguageCode { get; set; } 
        public string TranslatedText { get; set; } 

        public string EntityType { get; set; }

        public string FieldName { get; set; }  
 
    }

}
