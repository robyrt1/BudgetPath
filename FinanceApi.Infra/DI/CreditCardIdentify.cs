using FinanceApi.Application.Accounts.Commands.Handlers;
using FinanceApi.Application.Accounts.Mappers;
using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Application.CreditCards.Commands.Handlers;
using FinanceApi.Application.CreditCards.Queries.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Port;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Infra.Persistence.Repositories.CreditCard;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class CreditCardIdentify
    {
        public static IServiceCollection AddCreditCartDepency(IServiceCollection services)
        {
            /* QUERY REPOSITORY */
            services.AddTransient<ICreditCardsQueriesRepositoryBase, CreditCardsQueriesRepositoryImp>();
            services.AddTransient<ICreditCardsWriteRepositoryBase, CreditCardsWriteRepositoryImp>();
            /* MAPPERS */
            /* Queries */
            services.AddTransient<GetCreditCardsQueryHandlerBase, GetCreditCardsQueryHandlerImp>();
            /* COMMANDS */
            services.AddTransient<CreateCreditCardCommandHandlerBase, CreateCreditCardCommandHandlerImp>();
            services.AddTransient<UpdateCreditCardCommandHandlerBase, UpdateCreditCardCommandHandlerImp>();
            services.AddTransient<DeleteCreditCardCommandHandlerBase, DeleteCreaditCardCommandHandlerImp>();
            return services;
        }
    }
}
