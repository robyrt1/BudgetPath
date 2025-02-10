using FinanceApi.Application.Accounts.Commands.Handlers;
using FinanceApi.Application.Accounts.Mappers;
using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Infra.Data.Repositories.Accounts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class AccountIdentify
    {
        public static IServiceCollection AddAccountDepency(IServiceCollection services)
        {
            /* QUERY REPOSITORY */
            services.AddTransient<IAccountWriteRepositoryBase, AccountWriteRepositoryImp>();
            services.AddTransient<IAccountQueriesRepositoryBase, AccountQueriesRepositoryImp>();
            /* MAPPERS */
            services.AddTransient<IGetAccountByUserMapperBase, GetAccountByUserMapper>();
            /* Queries */
            services.AddTransient<GetAccountByUserQueryHandlerBase,GetAccountByUserQueryHandlerImp>();
            /* COMMANDS */
            services.AddTransient<CreateAccountCommandHandlerBase, CreateAccountCommandHandlerImp>();
            return services;
        }
    }
}
