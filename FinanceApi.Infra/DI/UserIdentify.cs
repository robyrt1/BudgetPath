using FinanceApi.Application.User.Queries.Handlers;
using FinanceApi.Domain.Users.Port;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Infra.Data.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class UserIdentify
    {
        public static IServiceCollection AddUserDepency(IServiceCollection services)
        {
            /* REPOSITORIES */
            services.AddTransient<IUserQueriesRepositoryBase, UserQueriesRepository>();

            /* COMMANDS */

            /* QUERIES */
            services.AddTransient<GetUserByEmailHandlerBase, GetUserByEmailHandlerImp>();
            return services;
        }
    }
}
