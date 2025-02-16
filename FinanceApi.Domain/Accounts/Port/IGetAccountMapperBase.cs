using FinanceApi.Domain.Accounts.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Port
{
    public interface IGetAccountMapperBase
    {
        public IEnumerable<GetAccountQueryHandlerResponse> To(IEnumerable<AccountEntity> mapper);
    }
}
