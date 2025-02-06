using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderID { get; set; }
    public Guid ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}
