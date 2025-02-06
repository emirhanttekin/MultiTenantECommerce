using MultiTenantECommerce.Domain.Common;

public class Category : BaseEntity
{
    public Guid TenantID { get; set; }
    public string Name { get; set; }

    public Guid? ParentCategoryID { get; set; }  // ✅ Bunu int? yerine Guid? yap

    public Category ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
