using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Translation : BaseEntity
    {
        public Guid TenantID { get; set; } // Hangi tenant'a ait olduğu
        public Guid EntityId { get; set; } // Product veya Category ID (hangi entity'ye ait olduğu)
        public string EntityType { get; set; } // "Product" veya "Category"
        public string LanguageCode { get; set; } 
        public string FieldName { get; set; } 
        public string TranslatedText { get; set; } 

        public Tenant Tenant { get; set; } 
    }
}
