namespace MultiTenantECommerce.Application.DTOs
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }  
    }
}
