using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class SignInRepository : ISignInRepository
    {
        WebApiShopContext _webApiShopContext;
        public SignInRepository(WebApiShopContext webApiShopContext)
        {
            _webApiShopContext = webApiShopContext;
        }

        public async Task<User?> SignIn(SignIn user1)
        {
            User? user = await _webApiShopContext.Users
                .FirstOrDefaultAsync(u => u.UserName == user1.UserName1 && u.Password == user1.Password1);
            return user;
        }
    }
}
