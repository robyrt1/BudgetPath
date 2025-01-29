using FinanceApi.Domain.Users.Port;
using FinanceApi.Infra.Data.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Data.DI
{
    public static class UserIdentify
    {
        public static IServiceCollection AddUserDepency(IServiceCollection services)
        {
            /* REPOSITORIES */
            services.AddTransient<IUserQueriesRepositoryBase, UserQueriesRepository>();

            /* COMMANDS */

            /* QUERIES */

            return services;
        }
    }
}
