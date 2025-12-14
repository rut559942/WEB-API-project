using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
