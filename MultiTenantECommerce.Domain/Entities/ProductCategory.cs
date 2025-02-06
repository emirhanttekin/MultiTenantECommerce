using MultiTenantECommerce.Domain.Entities;

public class ProductCategory
{
    public Guid ProductID { get; set; }
    public Guid CategoryID { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}
