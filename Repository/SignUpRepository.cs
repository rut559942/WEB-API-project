using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class SignUpRepository : ISignUpRepository
    {

        WebApiShopContext _webApiShopContext;
        public SignUpRepository(WebApiShopContext webApiShopContext)
        {
            _webApiShopContext = webApiShopContext;
        }

        public async Task<User?> SignUp(User user)
        {
           await _webApiShopContext.Users.AddAsync(user);
            await _webApiShopContext.SaveChangesAsync();
            return user;


        }
    }
}
