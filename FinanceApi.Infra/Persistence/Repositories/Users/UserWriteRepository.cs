using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinanceApi.Infra.Persistence.Repositories.Users
{
    public class UserWriteRepository : IUserWriteRepositoryBase
    {
        private readonly AppDbContext _context;

        public UserWriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> Create(UserEntity userEntity)
        {

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }
    }
}
