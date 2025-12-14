using Microsoft.AspNetCore.Mvc;
using Service;
using DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts(
        [FromQuery] int? categoryId,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] string? search)
    {
        var products = await _service.GetProductsAsync(categoryId, minPrice, maxPrice, search);
        return Ok(products);
    }
}
