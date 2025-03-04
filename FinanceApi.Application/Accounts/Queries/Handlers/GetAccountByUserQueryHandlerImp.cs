using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Accounts.Queries.Requests;
using FinanceApi.Domain.Accounts.Queries.Responses;
using FinanceApi.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Application.Accounts.Queries.Handlers
{
    public class GetAccountByUserQueryHandlerImp : GetAccountByUserQueryHandlerBase
    {
        private IGetAccountMapperBase _getAccountByUserMapperImp;
        private readonly IQueriesRepositoryBase<AccountEntity> _accountQueriesRepositoryImp;

        public GetAccountByUserQueryHandlerImp(IGetAccountMapperBase getAccountByUserMapperImp, IQueriesRepositoryBase<AccountEntity> accountQueriesRepositoryImp) {
            _accountQueriesRepositoryImp = accountQueriesRepositoryImp;
            _getAccountByUserMapperImp = getAccountByUserMapperImp;
        }

        public override async Task<IEnumerable<GetAccountQueryHandlerResponse>> Handle(GetAccountByUserQueryHandlerRequest command)
        {
            var accounts = await _accountQueriesRepositoryImp.Find(a => a.UserId == command.UserId).ToListAsync();

            return _getAccountByUserMapperImp.To(accounts);
        }
    }
}
