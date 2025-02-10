using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    public class AccountQueriesRepositoryImp : IAccountQueriesRepositoryBase
    {

        private readonly AppDbContext _context;

        public AccountQueriesRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountEntity>> GetByUser(Guid UserId)
        {
            return await _context.Account.Where(a => a.UserId == UserId).ToListAsync();
        }
    }
}
