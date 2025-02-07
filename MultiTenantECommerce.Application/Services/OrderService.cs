using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;

namespace MultiTenantECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(Guid tenantId, OrderDto orderDto)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                TenantID = tenantId,
                UserID = orderDto.UserID,
                TotalAmount = 0,
                Status = "Pending",
                CreatedDate = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in orderDto.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductID);
                if (product == null)
                {
                    throw new Exception("Ürün Bulunamadı");
                }

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderID = order.Id,
                    ProductID = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                order.TotalAmount += orderItem.Quantity * orderItem.UnitPrice;
                order.OrderItems.Add(orderItem);
            }
            await _orderRepository.AddAsync(order);
            return new OrderResponseDto
            {
                Id = order.Id,
                TenantID = order.TenantID,
                UserID = order.UserID,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CreatedDate = order.CreatedDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    OrderID = oi.OrderID,
                    ProductID = oi.ProductID,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                }).ToList()
            };
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                TenantID = o.TenantID,
                UserID = o.UserID,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                OrderItems = o.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    OrderID = oi.OrderID,
                    ProductID = oi.ProductID,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                }).ToList()
            }).ToList();
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByTenantIdAsync(Guid tenantId)
        {
            var orders = await _orderRepository.GetOrderByTenantIdAsync(tenantId);
            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                TenantID = o.TenantID,
                UserID = o.UserID,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                OrderItems = o.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    OrderID = oi.OrderID,
                    ProductID = oi.ProductID,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                }).ToList()
            }).ToList();
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderByIdWithItemsAsync(orderId);
            if (order == null) return null;

            return new OrderResponseDto
            {
                Id = order.Id,
                TenantID = order.TenantID,
                UserID = order.UserID,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CreatedDate = order.CreatedDate,
                OrderItems = order.OrderItems?.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    OrderID = oi.OrderID,
                    ProductID = oi.ProductID,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList() ?? new List<OrderItemResponseDto>() 
            };
        }


        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            order.Status = status;
            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
