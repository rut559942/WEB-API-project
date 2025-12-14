using DTOs;
using Entity;
using Repository;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<int> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var productIds = orderDto.Items.Select(i => i.ProductId).ToList();
            var products = await _productRepository.GetProductsByIdsAsync(productIds);

            var orderItems = orderDto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList();

            decimal orderSum = 0;
            foreach (var item in orderItems)
            {
                var product = products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    orderSum += product.Price * item.Quantity;
                }
            }

            var order = new Order
            {
                UserId = orderDto.UserId,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderSum = orderSum,
                OrderItems = orderItems
            };

            var createdOrder = await _orderRepository.AddOrderAsync(order);
            return createdOrder.OrderId;
        }
    }
}
