using DTOs;

namespace Service;

public interface IProductService
{
    Task<List<ProductDto>> GetProductsAsync(int? categoryId, decimal? minPrice, decimal? maxPrice, string? search);
}
