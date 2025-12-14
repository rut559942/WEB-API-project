using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ProductRepository : IProductRepository
{
    private readonly WebApiShopContext _context;

    public ProductRepository(WebApiShopContext context)
    {
        _context = context;
    }

    public IQueryable<Product> GetProducts()
    {
        return _context.Products.Include(p => p.Category);
    }

    public async Task<List<Product>> GetProductsByIdsAsync(List<int> productIds)
    {
        return await _context.Products
            .Where(p => productIds.Contains(p.ProductId))
            .ToListAsync();
    }
}
