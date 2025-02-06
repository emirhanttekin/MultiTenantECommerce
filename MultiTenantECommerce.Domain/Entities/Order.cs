using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities;

public class Order : BaseEntity
{
    public Guid TenantID { get; set; }
    public Guid UserID { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";

    public Tenant Tenant { get; set; }
    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
