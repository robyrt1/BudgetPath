﻿using FinanceApi.Domain.Accounts;
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
using FinanceApi.Domain.Transactions.Queries.Types;
using FinanceApi.Application.Transactions.Factory;

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
                bool isPaging = queryOptions.Skip != null || queryOptions.Top != null;

                int skip = isPaging ? queryOptions.Skip?.Value ?? 0 : 0;
                int top = isPaging ? queryOptions.Top?.Value ?? totalRecords : totalRecords;

                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var query = transactions.OrderByDescending(t => t.TransactionDate);

                var pagedData = isPaging
                    ? await query.Skip(skip).Take(top).ToListAsync()
                    : await query.ToListAsync();


                var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet("aggregated")]
        public async Task<IActionResult> GetAggregatedExpenses([FromServices] AggregatedExpensesHandlerFactory _factory, Guid userId, GroupByOption groupBy)
        {
            try
            {
                var handler = _factory.GetHandler(groupBy);
                var result = await handler.HandleAsync(userId);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
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
