namespace FinanceApi.Infra.Data.Repositories.Accounts
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Accounts.Commands.Requests;
    using FinanceApi.Domain.Accounts.Port;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="AccountWriteRepositoryImp" />
    /// </summary>
    public class AccountWriteRepositoryImp : IAccountWriteRepositoryBase
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWriteRepositoryImp"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="AppDbContext"/></param>
        public AccountWriteRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="account">The account<see cref="CreateAccountRequest"/></param>
        /// <returns>The <see cref="Task{AccountEntity}"/></returns>
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
