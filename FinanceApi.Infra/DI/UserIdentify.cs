using FinanceApi.Application.User.Commands.Handlers;
using FinanceApi.Application.User.Queries.Handlers;
using FinanceApi.Domain.Users.Commands.Handlers;
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
            services.AddTransient<IUserWriteRepositoryBase, UserWriteRepository>();
            /* COMMANDS */
            services.AddTransient<RegisterUserFirebaseCommandHandlerBase, RegisterUserFirebaseCommandHandlerImp>();
            services.AddTransient<RegisterUserSystemCommandHandlerBase, RegisterUserSystemCommandHandlerImp>();

            /* QUERIES */
            services.AddTransient<GetUserByEmailHandlerBase, GetUserByEmailHandlerImp>();
            services.AddTransient<GetUserByFirebaseUidHandlerBase, GetUserByFirebaseUidHandlerImp>();
            
            return services;
        }
    }
}
