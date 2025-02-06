using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities;

public class User : BaseEntity
{
    public Guid TenantID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } = "User"; 
    public Tenant Tenant { get; set; }
}
