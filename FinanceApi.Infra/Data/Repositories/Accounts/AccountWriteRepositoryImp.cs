using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    public class AccountWriteRepositoryImp : IAccountWriteRepositoryBase
    {

        private readonly AppDbContext _context;

        public AccountWriteRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AccountEntity> Create(CreateAccountRequest account)
        {
            var newAccount = new AccountEntity()
            {
                Balance = account.Balance,
                Name = account.Name,
                UserId = account.UserId,
                CreateAt = DateTime.UtcNow,
                Id = new Guid()
            };
            await _context.Account.AddAsync(newAccount);
            await _context.SaveChangesAsync();

            return newAccount;
        }
    }
}
