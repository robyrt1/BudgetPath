using FinanceApi.Application.Categories.Queries;
using FinanceApi.Domain.Categories.Port;
using FinanceApi.Domain.Categories.Queries.Handlers;
using FinanceApi.Infra.Data.Repositories.Categories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.DI
{
    public static class CategoriesIdentify
    {
        public static IServiceCollection AddCategoryDepency(IServiceCollection services)
        {
            /* REPOSITORIES */
            services.AddTransient<ICategoriesQueriesRespositoryBase, CategoriesQueriesRespositoryImp>();

            /* QUERIES */
            services.AddTransient<GetCategoriesQueryhandlerBase, GetCategoriesCommandHandlerImp>();
            services.AddTransient<GetCategoriesByUserQueryhandlerBase, GetCategoriesByUserQueryhandlerImp>();
            return services;
        }
    }

}