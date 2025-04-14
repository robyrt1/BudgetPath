using FinanceApi.Application.Debts.Queries.Handlers;
using FinanceApi.Domain.Debts.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class DebtsIdentify
    {
        public static IServiceCollection AddDebtsDepency(IServiceCollection services)
        {
            services.AddScoped<FindDebtsQueryHandlerBase, FindDebtsQueryHandlerImp>();
            return services;
        }
    }
}
