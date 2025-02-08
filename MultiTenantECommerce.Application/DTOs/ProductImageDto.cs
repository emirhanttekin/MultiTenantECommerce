namespace MultiTenantECommerce.Application.DTOs
{
    public class ProductImageDto
    {
        public Guid ProductID { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
