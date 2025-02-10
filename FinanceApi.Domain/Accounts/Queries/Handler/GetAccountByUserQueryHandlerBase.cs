using FinanceApi.Domain.Accounts.Queries.Requests;
using FinanceApi.Domain.Accounts.Queries.Responses;
using FinanceApi.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Queries.Handler
{
    public abstract class GetAccountByUserQueryHandlerBase : HandlerBaseShared<IEnumerable<GetAccountByUserQueryHandlerResponse>, GetAccountByUserQueryHandlerRequest>
    {

    }
}
