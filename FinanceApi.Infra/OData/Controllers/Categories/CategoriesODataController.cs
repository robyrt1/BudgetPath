using FinanceApi.Domain.Categories;
using FinanceApi.Domain.Categories.Queries.Handlers;
using FinanceApi.Infra.Shared.Http.Filter;
using FinanceApi.Infra.Shared.Http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Infra.OData.Controllers.Categories
{
    [Route("api/odata/v1/[controller]")]
    [ApiController]
    public class CategoriesODataController : ODataController
    {
        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] GetCategoriesQueryhandlerBase getCategoriesQueryhandler,
            ODataQueryOptions<CategoryEntity> queryOptions)
        {
            var categories = getCategoriesQueryhandler.Handle();

            int totalRecords = await categories.CountAsync();
            int skip = queryOptions.Skip?.Value ?? 0;
            int top = queryOptions.Top?.Value ?? totalRecords;
            int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

            var filter = new PaginationFilter(skip, top);

            var pagedData = await categories.Skip(filter.Skip).Take(filter.Top).ToListAsync();

            var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

            return Ok(response);
        }

    }
}
