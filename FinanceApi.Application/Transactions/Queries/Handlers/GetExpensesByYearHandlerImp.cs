using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using FinanceApi.Domain.Transactions.Queries.Responses;
using FinanceApi.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Application.Transactions.Queries.Handlers
{
    public class GetExpensesByYearHandlerImp : GetAggregatedExpensesQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<TransactionsEntity> _queryRepositoryBase;

        public GetExpensesByYearHandlerImp(IQueriesRepositoryBase<TransactionsEntity> queryRepositoryBase)
        {
            _queryRepositoryBase = queryRepositoryBase;
        }

        public override async Task<List<AggregatedExpenseResponse>> HandleAsync(Guid userId)
        {
            var transactions = await _queryRepositoryBase.GetAll()
                .AsNoTracking()
                .Include(a => a.Account)
                .Include(c=>c.CreditCard)
                .Include(t => t.Category)
                .ThenInclude(c => c.Group)
                .Where(t => t.UserId == userId && t.Category.Group.Descript == "DESPESA")
                .ToListAsync();

            var result = transactions
                .GroupBy(t => new {
                    Account = t.AccountId ?? t.CreditCardId,
                    Year = t.TransactionDate.Year}
                )
                .OrderByDescending(g => g.Key.Year)
                .Select(g => new AggregatedExpenseResponse
                {
                    Account = g.First().Account?.Name ?? g.First().CreditCard?.Name,
                    Period = $"{g.Key.Year}",
                    Total = g.Sum(x => x.Amount)
                })
                .ToList();

            return result;
        }
    }
}
