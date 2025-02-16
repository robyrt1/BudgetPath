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
    public abstract class GetAccountQueryHandlerBase: HandlerBaseShared<IQueryable<AccountEntity>, object>
    {
        public virtual IQueryable<AccountEntity> Handle()
        {
            throw new NotImplementedException("This method is not implemented.");
        }
    }
}
