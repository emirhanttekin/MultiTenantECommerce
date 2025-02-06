using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } = false; 

        public Product Product { get; set; }
    }
}
