using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Application.Accounts.Queries.Handlers
{
    public class GetAccountQueryHandlerImp : GetAccountQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<AccountEntity> _accountQueriesRepositoryImp;

        public GetAccountQueryHandlerImp(IQueriesRepositoryBase<AccountEntity> accountQueriesRepositoryImp)
        {
            _accountQueriesRepositoryImp = accountQueriesRepositoryImp;
        }

        public override  IQueryable<AccountEntity> Handle()
        {
            var accounts = _accountQueriesRepositoryImp.GetAll()
                .AsNoTracking()
                .Include(a => a.CreditCard);
            return accounts;
        }

        public override Task<IQueryable<AccountEntity>> HandleAsync()
        {
            return _accountQueriesRepositoryImp.GetAllAsync();
        }
    }
}
