using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entity;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    public class UpdateService : IUpdateService
    {
        private readonly IUpdateRepository _repo;

        public UpdateService(IUpdateRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool?> Update(User user)
        {
            var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (result.Score < 3)
                return null;
            return await _repo.Update(user);
        }
    }
}
