using Entity;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public interface ISignInService
    {
         Task<User?> SignIn(SignIn user);
    }
}