using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; set; }
    public string Domain { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Order> Orders { get; set; }
}
