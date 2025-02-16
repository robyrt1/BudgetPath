using FinanceApi.Domain.Categories;
using FinanceApi.Domain.Categories.Port;
using FinanceApi.Domain.Categories.Queries.Handlers;
using FinanceApi.Domain.Categories.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Categories.Queries
{
    public class GetCategoriesCommandHandlerImp : GetCategoriesQueryhandlerBase
    {
        private readonly ICategoriesQueriesRespositoryBase _categoriesQueriesRespository;
        public GetCategoriesCommandHandlerImp(ICategoriesQueriesRespositoryBase categoriesQueriesRespository) {
            _categoriesQueriesRespository = categoriesQueriesRespository;
        }

        public override IQueryable<CategoryEntity> Handle()
        {
            return _categoriesQueriesRespository.GetCategoriesOData();
        }

    }
}
