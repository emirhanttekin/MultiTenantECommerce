namespace MultiTenantECommerce.Application.DTOs
{
    public class ProductDto
    {
        public Guid TenantID { get; set; }
        public Guid ProductId { get; set; }  // ✅ ProductId eklendi

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }
        public int Stock { get; set; }
    }

}

