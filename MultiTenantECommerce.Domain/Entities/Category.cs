using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid TenantID { get; set; }
        public Guid? ParentCategoryID { get; set; }  // Ana kategori varsa
        public Category ParentCategory { get; set; } // Parent ile ilişki
        public ICollection<Category> SubCategories { get; set; } // Alt kategoriler
        public ICollection<ProductCategory> ProductCategories { get; set; } // Ürün ilişkisi
    }
}
