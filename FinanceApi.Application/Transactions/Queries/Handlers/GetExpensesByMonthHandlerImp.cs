namespace FinanceApi.Application.Transactions.Queries.Handlers
{
    using global::FinanceApi.Domain.Shared.Interfaces;
    using global::FinanceApi.Domain.Transactions;
    using global::FinanceApi.Domain.Transactions.Queries.Handlers;
    using global::FinanceApi.Domain.Transactions.Queries.Responses;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class GetExpensesByMonthHandlerImp : GetAggregatedExpensesQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<TransactionsEntity> _queryRepositoryBase;

        public GetExpensesByMonthHandlerImp(IQueriesRepositoryBase<TransactionsEntity> queryRepositoryBase)
        {
            _queryRepositoryBase = queryRepositoryBase;
        }

        public override async Task<List<AggregatedExpenseResponse>> HandleAsync(Guid userId)
        {
            var data = await _queryRepositoryBase.GetAll()
              .AsNoTracking()
              .Include(t => t.Account)
              .Include(c => c.CreditCard)
              .Include(t => t.Category)
              .ThenInclude(c => c.Group)
              .Where(t => t.UserId == userId && t.Category.Group.Descript == "DESPESA")
              .ToListAsync();

            var grouped = data
                .GroupBy(t => new
                {
                    AccountId = t.AccountId ?? t.CreditCardId,
                    Month = t.TransactionDate.Month,
                    Year = t.TransactionDate.Year
                })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month)
                .Select(g => new AggregatedExpenseResponse
                {
                    Account = g.First().Account?.Name ?? g.First().CreditCard?.Name,
                    Period = $"{g.Key.Month:00}/{g.Key.Year}",
                    Total = g.Sum(x => x.Amount)
                })
                .ToList();

            return grouped;
        }


    }
}
