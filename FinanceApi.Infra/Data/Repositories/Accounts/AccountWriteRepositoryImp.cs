namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    using Azure.Core;
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Accounts.Commands.Requests;
    using FinanceApi.Domain.Accounts.Port;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

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

        public async Task Delete(Guid Id)
        {
            var accountOrigin = await _context.Account.SingleAsync(cc => cc.Id == Id);
            _context.Remove(accountOrigin);

            await _context.SaveChangesAsync();
        }

        public async Task<AccountEntity> Update(UpdateAccountRequest account)
        {
            var accountOrigin = await _context.Account.SingleAsync(cc => cc.Id == account.Id);
            
            accountOrigin.Balance = account.Balance ?? accountOrigin.Balance;
            accountOrigin.Name = account.Name ?? accountOrigin.Name;

            await _context.SaveChangesAsync();
            return accountOrigin;
        }
    }
}
