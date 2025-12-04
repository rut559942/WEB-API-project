using Entity;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    public interface IUpdateService
    {
        Task<bool?> Update(User user);
    }
}