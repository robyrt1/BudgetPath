using FinanceApi.Application.User.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Users.Port;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Infra.Data.Repositories.Users;
using FinanceApi.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class InfraIdentify
    {
        public static IServiceCollection AddInfraDepency(IServiceCollection services)
        {
            services.AddTransient<ICryptHash, BCryptPasswordHasher>();
            services.AddTransient<IFirebase, FirebaseService>();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            return services;
        }
    }
}
