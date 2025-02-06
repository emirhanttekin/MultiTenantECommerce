using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Translation : BaseEntity
    {
        public Guid TenantID { get; set; }
        public Guid ProductId { get; set; }  // ✅ ProductId eklendi
        public string EntityType { get; set; }  // "Product" gibi değer alacak
        public string LanguageCode { get; set; }  // "en", "tr", "de" vb.
        public string FieldName { get; set; }  // "Description" gibi değer alacak
        public string TranslatedText { get; set; }

        public Tenant Tenant { get; set; }
        public Product Product { get; set; }  // ✅ Navigation Property eklendi
    }
}
