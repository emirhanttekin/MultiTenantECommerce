namespace MultiTenantECommerce.Application.DTOs
{
    public class OrderItemResponseDto
    {
        public Guid Id { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
