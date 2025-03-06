using FinanceApi.Application.Accounts.Commands.Handlers;
using FinanceApi.Application.Accounts.Mappers;
using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Application.CreditCards.Commands.Handlers;
using FinanceApi.Application.CreditCards.Queries.Handlers;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class CreditCardIdentify
    {
        public static IServiceCollection AddCreditCartDepency(IServiceCollection services)
        {
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
