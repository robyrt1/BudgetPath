using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data.Repositories.Users
{
    public class UserQueriesRepository : IUserQueriesRepositoryBase
    {
        private readonly AppDbContext _context;

        public UserQueriesRepository(AppDbContext context) { 
            _context = context;
        }


        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.User.Where(user => user.Email.Equals(email)).FirstOrDefaultAsync(null);
        }
    }
}
