namespace FinanceApi.Infra.OData.Controllers.PaymentMethod
{
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.PaymentMethod;
    using FinanceApi.Domain.PaymentMethod.Queries.Handlers;
    using FinanceApi.Infra.Shared.Http;
    using FinanceApi.Infra.Shared.Http.Filter;
    using FinanceApi.Infra.Shared.Http.Helper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using Microsoft.EntityFrameworkCore;

        [ApiVersion("1.0")]
    [Route("api/odata/v{version:apiVersion}/PaymentMethod")]
    [ApiController]
    public class PaymentMethodODataController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCreditOdata([FromServices] FindPaymentMethodQueryHandlerBase findPaymentMethodQueryHandler, ODataQueryOptions<AccountEntity> queryOptions)
        {

            try
            {
                IQueryable<PaymentMethodEntity> paymentMethods = findPaymentMethodQueryHandler.Handle();
                int totalRecords = await paymentMethods.CountAsync();
                int skip = queryOptions.Skip?.Value ?? 0;
                int top = queryOptions.Top?.Value ?? totalRecords;
                int currentPage = (skip / (top == 0 ? 1 : top)) + 1;

                var filter = new PaginationFilter(skip, top);

                var pagedData = await paymentMethods.Skip(filter.Skip).Take(filter.Top).ToListAsync();

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
