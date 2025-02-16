using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Accounts.Queries.Requests;
using FinanceApi.Domain.Accounts.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Accounts.Queries.Handlers
{
    public class GetAccountByUserQueryHandlerImp : GetAccountByUserQueryHandlerBase
    {
        private IGetAccountMapperBase _getAccountByUserMapperImp;
        private IAccountQueriesRepositoryBase _accountQueriesRepositoryImp;

        public GetAccountByUserQueryHandlerImp(IGetAccountMapperBase getAccountByUserMapperImp, IAccountQueriesRepositoryBase accountQueriesRepositoryImp) {
            _accountQueriesRepositoryImp = accountQueriesRepositoryImp;
            _getAccountByUserMapperImp = getAccountByUserMapperImp;
        }

        public override async Task<IEnumerable<GetAccountQueryHandlerResponse>> Handle(GetAccountByUserQueryHandlerRequest command)
        {
            var accounts = await _accountQueriesRepositoryImp.GetByUser(command.UserId);

            return _getAccountByUserMapperImp.To(accounts);
        }
    }
}
