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
    public class UpdateRepository : IUpdateRepository
    {
        WebApiShopContext _webApiShopContext;
        public UpdateRepository(WebApiShopContext webApiShopContext)
        {
            _webApiShopContext = webApiShopContext;
        }

        public async Task<bool> Update(User user)
        {
            _webApiShopContext.Users.Update(user);
             await _webApiShopContext.SaveChangesAsync();
            return true;
        }
    }
}
