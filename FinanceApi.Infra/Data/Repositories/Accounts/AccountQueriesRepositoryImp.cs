namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Accounts.Port;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="AccountQueriesRepositoryImp" />
    /// </summary>
    public class AccountQueriesRepositoryImp : IAccountQueriesRepositoryBase
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountQueriesRepositoryImp"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="AppDbContext"/></param>
        public AccountQueriesRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The GetByUser
        /// </summary>
        /// <param name="UserId">The UserId<see cref="Guid"/></param>
        /// <returns>The <see cref="Task{IEnumerable{AccountEntity}}"/></returns>
        public async Task<IEnumerable<AccountEntity>> GetByUser(Guid UserId)
        {
            return await _context.Account.Where(a => a.UserId == UserId).ToListAsync();
        }

        /// <summary>
        /// The GetAccount
        /// </summary>
        /// <returns>The <see cref="IQueryable{AccountEntity}"/></returns>
        public IQueryable<AccountEntity> GetAccount()
        {
            return _context.Account.Include(a => a.User).AsNoTracking();
        }
    }
}
