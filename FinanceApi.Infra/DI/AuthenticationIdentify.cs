using FinanceApi.Application.Authentication.Commands.Handlers;
using FinanceApi.Domain.Authentication.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class AuthenticationIdentify
    {
        public static IServiceCollection AddAuthenticationDepency(IServiceCollection services) {
            /*COMMANDS*/
            services.AddTransient<LoginAuthenticationCommandHandlerBase, LoginAuthenticationCommandHandlerImp>();

            return services;
        }

    }
}
