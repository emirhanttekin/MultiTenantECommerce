namespace MultiTenantECommerce.Application.DTOs
{
    public class CategoryDto
    {
        public Guid? ParentCategoryID { get; set; } // Ana kategori varsa
        public string Name { get; set; } // Çeviri için kullanılacak (sadece ekleme/güncelleme için)
        public string LanguageCode { get; set; } // "en", "tr" gibi
    }
}
