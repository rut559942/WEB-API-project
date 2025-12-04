using Entity;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    public interface ISignUpService
    {
        Task<User?> SignUp(User user);
        int StrongPassword(User user);
    }
}