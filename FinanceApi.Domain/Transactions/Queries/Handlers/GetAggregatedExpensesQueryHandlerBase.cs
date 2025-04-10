using FinanceApi.Domain.Transactions.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Transactions.Queries.Handlers
{
    public abstract class GetAggregatedExpensesQueryHandlerBase
    {
        public abstract Task<List<AggregatedExpenseResponse>> HandleAsync(Guid userId);
    }

}
