using FinanceApi.Application.Accounts.Commands.Handlers;
using FinanceApi.Application.Accounts.Mappers;
using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Application.CreditCards.Commands.Handlers;
using FinanceApi.Application.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.CreditCards.Commands.Handlers;
using FinanceApi.Domain.CreditCards.Port;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Infra.Data.Repositories.Accounts;
using FinanceApi.Infra.Data.Repositories.CreditCard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return services;
        }
    }
}
