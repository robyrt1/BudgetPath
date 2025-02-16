using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;

namespace FinanceApi.Application.Accounts.Queries.Handlers
{
    public class GetAccountQueryHandlerImp : GetAccountQueryHandlerBase
    {
        private IGetAccountMapperBase _getAccountMapperImp;
        private IAccountQueriesRepositoryBase _accountQueriesRepositoryImp;

        public GetAccountQueryHandlerImp(IGetAccountMapperBase getAccountByUserMapperImp, IAccountQueriesRepositoryBase accountQueriesRepositoryImp)
        {
            _accountQueriesRepositoryImp = accountQueriesRepositoryImp;
            _getAccountMapperImp = getAccountByUserMapperImp;
        }

        public override  IQueryable<AccountEntity> Handle()
        {
            var accounts =  _accountQueriesRepositoryImp.GetAccount();

            return accounts;
        }
    }
}
