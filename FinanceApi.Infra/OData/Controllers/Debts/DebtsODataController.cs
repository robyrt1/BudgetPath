using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.PaymentMethod.Queries.Handlers;
using FinanceApi.Domain.PaymentMethod;
using FinanceApi.Infra.Shared.Http.Filter;
using FinanceApi.Infra.Shared.Http.Helper;
using FinanceApi.Infra.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApi.Domain.Debts.Queries.Handlers;
using FinanceApi.Domain.Debts;

namespace FinanceApi.Infra.OData.Controllers.Debts
{
    [ApiVersion("1.0")]
    [Route("api/odata/v{version:apiVersion}/Debts")]
    [ApiController]
    public class DebtsODataController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCreditOdata([FromServices] FindDebtsQueryHandlerBase findDebtsQueryHandler, ODataQueryOptions<DebtsEntity> queryOptions)
        {

            try
            {
                IQueryable<DebtsEntity> debts = findDebtsQueryHandler.Handle();
                int totalRecords = await debts.CountAsync();
                int skip = queryOptions.Skip?.Value ?? 0;
                int top = queryOptions.Top?.Value ?? totalRecords;
                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var pagedData = await debts.OrderBy(d => d.DueDate).Skip(filter.Skip).Take(filter.Top).ToListAsync();

                var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }
    }
}
