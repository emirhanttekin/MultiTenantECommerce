namespace MultiTenantECommerce.Application.DTOs
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}
