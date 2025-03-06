using FinanceApi.Application.Transactions.Queries.Handlers;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class TransactionsIdentify
    {
        public static IServiceCollection AddTransactionsDepency(IServiceCollection services)
        {
            services.AddScoped<FindTransactionsQueryHandlerBase, FindTransactionsQueryHandlerImp>();   
            return services;
        }
    }
}
