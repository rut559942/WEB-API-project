using Entity;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);

    }
}
