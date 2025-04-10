using FinanceApi.Application.Transactions.Queries.Handlers;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using FinanceApi.Domain.Transactions.Queries.Types;

namespace FinanceApi.Application.Transactions.Factory
{
    public class AggregatedExpensesHandlerFactory
    {
        public GetExpensesByMonthHandlerImp _getExpensesByMonthHandlerImp;
        public GetExpensesByWeekHandlerImp _getExpensesByWeekHandlerImp;
        public GetExpensesByYearHandlerImp _getExpensesByYearHandlerImp;

        public AggregatedExpensesHandlerFactory(
            GetExpensesByMonthHandlerImp getExpensesByMonthHandlerImp,
            GetExpensesByWeekHandlerImp getExpensesByWeekHandlerImp,
            GetExpensesByYearHandlerImp getExpensesByYearHandlerImp
            ) {
            _getExpensesByMonthHandlerImp= getExpensesByMonthHandlerImp;
            _getExpensesByWeekHandlerImp = getExpensesByWeekHandlerImp ;
            _getExpensesByYearHandlerImp = getExpensesByYearHandlerImp;
        }
        public GetAggregatedExpensesQueryHandlerBase GetHandler(GroupByOption option)
        {
            return option switch
            {
                GroupByOption.Month => _getExpensesByMonthHandlerImp,
                GroupByOption.Week =>  _getExpensesByWeekHandlerImp,
                GroupByOption.Year =>  _getExpensesByYearHandlerImp,
                _ => throw new ArgumentException("Agrupamento inválido.")
            };
        }
    }

}
