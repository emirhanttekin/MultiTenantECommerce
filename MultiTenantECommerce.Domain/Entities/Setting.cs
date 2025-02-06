using MultiTenantECommerce.Domain.Common;

namespace MultiTenantECommerce.Domain.Entities
{
    public class Setting : BaseEntity
    {
        public Guid TenantID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Tenant Tenant { get; set; }
    }
}
