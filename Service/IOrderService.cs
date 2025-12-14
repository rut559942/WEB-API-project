using DTOs;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(OrderCreateDto orderDto);
    }
}
