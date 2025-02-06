using FinanceApi.Domain.Categories.Port;
using FinanceApi.Domain.Categories.Queries.Handlers;
using FinanceApi.Domain.Categories.Queries.Requests;
using FinanceApi.Domain.Categories.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Categories.Queries
{
    public class GetCategoriesByUserQueryhandlerImp : GetCategoriesByUserQueryhandlerBase
    {
        private readonly ICategoriesQueriesRespositoryBase _categoriesQueriesRespository;
        public GetCategoriesByUserQueryhandlerImp(ICategoriesQueriesRespositoryBase categoriesQueriesRespository)
        {
            _categoriesQueriesRespository = categoriesQueriesRespository;
        }

        public override async Task<IEnumerable<GetCategoriesResponse>> Handle(GetCategoriesByUserQueryhandlerRequest command)
        {
            var categories = await _categoriesQueriesRespository.GetCategoriesByUser(command.Id);
            return categories;
        }
    }
}
