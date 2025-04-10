using FinanceApi.Application.Transactions.Commands.Handlers;
using FinanceApi.Application.Transactions.Factory;
using FinanceApi.Application.Transactions.Queries.Handlers;
using FinanceApi.Domain.Transactions.Commands.Handlers;
using FinanceApi.Domain.Transactions.Factory;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class TransactionsIdentify
    {
        public static IServiceCollection AddTransactionsDepency(IServiceCollection services)
        {
            services.AddScoped<CreateTransactionCommandHandlerBase, CreateTransactionCommandHandlerImp>();
            services.AddScoped<TransactionsFactory>();
            services.AddScoped<FindTransactionsQueryHandlerBase, FindTransactionsQueryHandlerImp>();
            services.AddScoped<GetExpensesByMonthHandlerImp>();
            services.AddScoped<GetExpensesByWeekHandlerImp>();
            services.AddScoped<GetExpensesByYearHandlerImp>();
            services.AddScoped<AggregatedExpensesHandlerFactory>();
            return services;
        }
    }
}
