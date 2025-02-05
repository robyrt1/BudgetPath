using FinanceApi.Domain.Categories.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Categories.Port
{
    public interface ICategoriesQueriesRespositoryBase
    {
        Task<IEnumerable<GetCategoriesResponse>> GetCategories();
    }
}
