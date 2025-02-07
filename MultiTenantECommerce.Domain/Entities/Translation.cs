using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Translation : BaseEntity
    {
        public Guid TenantID { get; set; }
        public Guid ProductId { get; set; } 
        public string EntityType { get; set; }  
        public string LanguageCode { get; set; }  
        public string FieldName { get; set; }  
        public string TranslatedText { get; set; }

        public Tenant Tenant { get; set; }
        public Product Product { get; set; }  
    }
}
