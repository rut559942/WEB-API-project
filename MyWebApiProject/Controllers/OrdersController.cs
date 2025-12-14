using Microsoft.AspNetCore.Mvc;
using Service;
using DTOs;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateOrder([FromBody] OrderCreateDto orderDto)
    {
        var orderId = await _orderService.CreateOrderAsync(orderDto);
        return CreatedAtAction(nameof(CreateOrder), new { id = orderId }, orderId);
    }
}
