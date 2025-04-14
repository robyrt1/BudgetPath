using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions.Queries.Responses;
using FinanceApi.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FinanceApi.Application.Transactions.Queries.Handlers
{
    public class GetExpensesByWeekHandlerImp : GetAggregatedExpensesQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<TransactionsEntity> _queryRepositoryBase;

        public GetExpensesByWeekHandlerImp(IQueriesRepositoryBase<TransactionsEntity> queryRepositoryBase)
        {
            _queryRepositoryBase = queryRepositoryBase;
        }

        public override async Task<List<AggregatedExpenseResponse>> HandleAsync(Guid userId)
        {
            var data = await _queryRepositoryBase.GetAll()
                .AsNoTracking()
                .Include(a => a.Account)
                .Include(c => c.CreditCard)
                .Include(t => t.Category)
                .ThenInclude(c => c.Group)
                .Where(t => t.UserId == userId && t.Category.Group.Descript == "DESPESA")
                .ToListAsync();

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var calendar = culture.Calendar;
            var weekRule = System.Globalization.CalendarWeekRule.FirstFourDayWeek;
            var firstDayOfWeek = DayOfWeek.Monday;

            var grouped = data
                .GroupBy(t => new
                {
                    AccountId = t.AccountId ?? t.CreditCardId,
                    Year = t.TransactionDate.Year,
                    Week = calendar.GetWeekOfYear(t.TransactionDate, weekRule, firstDayOfWeek)
                })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Week)
                .Select(g =>
                {
                    var firstDateOfWeek = FirstDateOfWeekISO8601(g.Key.Year, g.Key.Week);
                    var lastDateOfWeek = firstDateOfWeek.AddDays(6);

                    return new AggregatedExpenseResponse
                    {
                        Account = g.First().Account?.Name ?? g.First().CreditCard?.Name,
                        Period = $"{firstDateOfWeek:dd} a {lastDateOfWeek:dd/MM/yyyy}",
                        Total = g.Sum(x => x.Amount)
                    };
                })
                .ToList();  

            return grouped;
        }

        private  DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            var jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            var firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

    }



}
