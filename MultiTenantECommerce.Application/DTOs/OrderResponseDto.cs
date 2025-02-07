using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.DTOs
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid TenantID { get; set; }
        public Guid UserID { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemResponseDto> OrderItems { get; set; }
    }
}
