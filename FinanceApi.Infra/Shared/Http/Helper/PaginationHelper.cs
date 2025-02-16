using FinanceApi.Infra.Shared.Http.Filter;
using FinanceApi.Infra.Shared.Http.Wrapper;
using FinanceApi.Infra.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Shared.Http.Helper
{
    public static class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedResponse<T>(
            List<T> pagedData,
            PaginationFilter validFilter,
            int totalRecords)
        {
            var response = new PagedResponse<List<T>>(pagedData, validFilter.Skip, validFilter.Top);
            response.TotalRecords = totalRecords;
            response.TotalPages = (int)Math.Ceiling((double)totalRecords / validFilter.Top);
            return response;
        }
    }
}
