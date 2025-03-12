namespace FinanceApi.Infra.OData.Controllers.Account
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.Accounts.Commands.Handlers;
    using FinanceApi.Domain.Accounts.Commands.Requests;
    using FinanceApi.Domain.Accounts.Port;
    using FinanceApi.Domain.Accounts.Queries.Handler;
    using FinanceApi.Domain.CreditCards.Commands.Handlers;
    using FinanceApi.Domain.CreditCards.Commands.Requests;
    using FinanceApi.Infra.Shared.Http;
    using FinanceApi.Infra.Shared.Http.Filter;
    using FinanceApi.Infra.Shared.Http.Helper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;

    [ApiVersion("1.0")]
    [Route("api/odata/v{version:apiVersion}/Account")]
    [ApiController]
    public class AccountODataController : ODataController
    {
        [HttpGet()]
        [EnableQuery]
        public async Task<IActionResult> GetAccountByUser(
            [FromServices] GetAccountQueryHandlerBase getAccountQueryHandler,
            [FromServices] IGetAccountMapperBase getAccountMapperImp,
            ODataQueryOptions<AccountEntity> queryOptions)
        {
            try
            {
                IQueryable<AccountEntity> accounts = getAccountQueryHandler.Handle();
                int totalRecords = await accounts.CountAsync();
                int skip = queryOptions.Skip?.Value ?? 0;
                int top = queryOptions.Top?.Value ?? totalRecords;
                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var pagedData = await accounts.Skip(filter.Skip).Take(filter.Top).ToListAsync();

                var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
          [FromBody] CreateAccountRequest request,
          [FromServices] CreateAccountCommandHandlerBase createAccountCommandHandler,
          CancellationToken cancellationToken
       )
        {
            try
            {
                var created = await createAccountCommandHandler.Handle(request, cancellationToken);

                return ResponseHelper.CreateResponse(created, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.StackTrace);
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAccountRequest request, [FromServices] UpdateAccountCommandHandlerBase updateAccountCommandHandler)
        {
            try
            {
                var updated = await updateAccountCommandHandler.Handle(request);
                if (updated.StatusCode > 299)
                {
                    return ResponseHelper.CreateResponse(updated, updated.StatusCode);
                }
                var location = Url.Action(nameof(Create), new { id = updated.Details.Id });

                return ResponseHelper.CreateResponse(updated, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAccountRequest request, [FromServices] DeleteAccountCommandHandlerBase deleteAccountCommandHandler)
        {
            try
            {
                var deleted = await deleteAccountCommandHandler.Handle(request);
                if (deleted.StatusCode > 299)
                {
                    return ResponseHelper.CreateResponse(deleted, deleted.StatusCode);
                }

                return ResponseHelper.CreateResponse(deleted, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }
    }
}
