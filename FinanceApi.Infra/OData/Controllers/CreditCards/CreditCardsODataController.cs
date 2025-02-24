namespace FinanceApi.Infra.OData.Controllers.CreditCards
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.CreditCards;
    using FinanceApi.Domain.CreditCards.Commands.Handlers;
    using FinanceApi.Domain.CreditCards.Commands.Requests;
    using FinanceApi.Domain.CreditCards.Queries.Handlers;
    using FinanceApi.Infra.Shared.Http;
    using FinanceApi.Infra.Shared.Http.Filter;
    using FinanceApi.Infra.Shared.Http.Helper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    [Route("odata/v{version:apiVersion}/CreditCards")]
    [ApiController]
    public class CreditCardsODataController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCreditOdata([FromServices] GetCreditCardsQueryHandlerBase getCreditCardsQueryHandler, ODataQueryOptions<AccountEntity> queryOptions)
        {

            try
            {
                IQueryable<CreditCardEntity> creditCard = getCreditCardsQueryHandler.Handle();
                int totalRecords = await creditCard.CountAsync();
                int skip = queryOptions.Skip?.Value ?? 0;
                int top = queryOptions.Top?.Value ?? totalRecords;
                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var pagedData = await creditCard.Skip(filter.Skip).Take(filter.Top).ToListAsync();

                var response = PaginationHelper.CreatePagedResponse(pagedData, filter, totalRecords);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditCardRequest request, [FromServices] CreateCreditCardCommandHandlerBase createCreditCardCommandHandler)
        {
            try
            {
                var created = await createCreditCardCommandHandler.Handle(request);
                if (created.StatusCode > 299)
                {
                    return ResponseHelper.CreateResponse(created, created.StatusCode);
                }
                var location = Url.Action(nameof(Create), new { id = created.Details.Id });

                return ResponseHelper.CreateResponse(created, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCreditCardRequest request, [FromServices] UpdateCreditCardCommandHandlerBase updateCreditCardCommandHandler)
        {
            try
            {
                var created = await updateCreditCardCommandHandler.Handle(request);
                if (created.StatusCode > 299)
                {
                    return ResponseHelper.CreateResponse(created, created.StatusCode);
                }
                var location = Url.Action(nameof(Create), new { id = created.Details.Id });

                return ResponseHelper.CreateResponse(created, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCreditCardRequest request, [FromServices] DeleteCreditCardCommandHandlerBase deleteCreditCardCommandHandler)
        {
            try
            {
                var created = await deleteCreditCardCommandHandler.Handle(request);
                if (created.StatusCode > 299)
                {
                    return ResponseHelper.CreateResponse(created, created.StatusCode);
                }

                return ResponseHelper.CreateResponse(created, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);

            }
        }
    }
}
