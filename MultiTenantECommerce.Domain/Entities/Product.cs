using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid TenantID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Tenant Tenant { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
