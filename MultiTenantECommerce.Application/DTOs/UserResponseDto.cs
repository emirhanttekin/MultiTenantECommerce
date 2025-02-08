namespace MultiTenantECommerce.Application.DTOs
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public Guid TenantID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
