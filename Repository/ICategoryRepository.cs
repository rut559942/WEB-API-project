using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
