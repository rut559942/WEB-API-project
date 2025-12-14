using Entity;

namespace Repository;

public interface IProductRepository
{
    IQueryable<Product> GetProducts();
    Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);

}
