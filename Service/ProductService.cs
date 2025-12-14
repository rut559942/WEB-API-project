using DTOs;
using Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetProductsAsync(int? categoryId, decimal? minPrice, decimal? maxPrice, string? search)
    {
        var query = _repo.GetProducts();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lower = search.ToLower();
            query = query.Where(p =>
                p.ProductName.ToLower().Contains(lower) ||
                (p.Description != null && p.Description.ToLower().Contains(lower))
            );
        }

        return await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
