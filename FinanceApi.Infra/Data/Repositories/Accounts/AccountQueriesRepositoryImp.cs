namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Accounts.Port;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;


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

        public IQueryable<AccountEntity> GetAccount()
        {
            return _context.Account.Include(a => a.User).AsNoTracking();
        }

        public async Task<IQueryable<AccountEntity>> GetAccountAsync()
        {
            return await Task.FromResult(_context.Account.Include(a => a.User).AsNoTracking());
        }
    }
}
