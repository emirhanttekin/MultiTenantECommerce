namespace MultiTenantECommerce.Application.DTOs
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}
