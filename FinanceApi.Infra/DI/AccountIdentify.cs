using FinanceApi.Application.Accounts.Commands.Handlers;
using FinanceApi.Application.Accounts.Mappers;
using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceApi.Infra.DI
{
    public static class AccountIdentify
    {
        public static IServiceCollection AddAccountDepency(IServiceCollection services)
        {
            /* MAPPERS */
            services.AddTransient<IGetAccountMapperBase, GetAccountMapper>();
            /* Queries */
            services.AddTransient<GetAccountByUserQueryHandlerBase,GetAccountByUserQueryHandlerImp>();
            services.AddTransient<GetAccountQueryHandlerBase, GetAccountQueryHandlerImp>();
            /* COMMANDS */
            services.AddTransient<CreateAccountCommandHandlerBase, CreateAccountCommandHandlerImp>();
            services.AddTransient<UpdateAccountCommandHandlerBase, UpdateAccountCommandHandlerImp>();
            services.AddTransient<DeleteAccountCommandHandlerBase,DeleteAccountCommandHandlerImp>();
            return services;
        }
    }
}
