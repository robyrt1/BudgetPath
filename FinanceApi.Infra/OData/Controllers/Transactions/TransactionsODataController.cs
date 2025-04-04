using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.Transactions;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using FinanceApi.Infra.Shared.Http.Filter;
using FinanceApi.Infra.Shared.Http.Helper;
using FinanceApi.Infra.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using FinanceApi.Domain.Transactions.Commands.Handlers;
using FinanceApi.Domain.Transactions.Commands.Requests;

namespace FinanceApi.Infra.OData.Controllers.Transactions
{
    [ApiVersion("1.0")]
    [Route("api/odata/v{version:apiVersion}/Transactions")]
    [ApiController]
    public class TransactionsODataController: ODataController
    {

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 3)]
        public async Task<IActionResult> FindTransactionOData([FromServices] FindTransactionsQueryHandlerBase findTransactionsQueryHandler, ODataQueryOptions<TransactionsEntity> queryOptions)
        {
            try
            {
                IQueryable<TransactionsEntity> transactions = findTransactionsQueryHandler.Handle();
                int totalRecords = await transactions.CountAsync();
                int skip = queryOptions.Skip?.Value ?? 0;
                int top = queryOptions.Top?.Value ?? totalRecords;
                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var pagedData = await transactions.Skip(filter.Skip).Take(filter.Top).ToListAsync();

                var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateTransactionRequest request , 
            [FromServices] CreateTransactionCommandHandlerBase createTransaction
         )
        {
            try
            {
                var created = await createTransaction.Handle(request);
                return ResponseHelper.CreateResponse(created, StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;

                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }
    }
}
