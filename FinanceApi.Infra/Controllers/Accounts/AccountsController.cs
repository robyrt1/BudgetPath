using FinanceApi.Application.Accounts.Queries.Handlers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Accounts.Queries.Requests;
using FinanceApi.Infra.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Controllers.Accounts
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public AccountsController() { }

        [HttpGet("ByUser")]
        public async Task<IActionResult> GetAccountByUser([FromQuery] Guid userId, [FromServices] GetAccountByUserQueryHandlerBase getAccountByUserQueryHandler)
        {
            try { 
                var accounts = await getAccountByUserQueryHandler.Handle(new GetAccountByUserQueryHandlerRequest { UserId = userId });
                return ResponseHelper.CreateResponse(accounts, StatusCodes.Status200OK);
            }
            catch(Exception ex) {
                return ResponseHelper.CreateResponse(ex.Message,StatusCodes.Status500InternalServerError);

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
            catch (Exception ex) {
                return ResponseHelper.CreateResponse(ex.Message, StatusCodes.Status500InternalServerError);
            }

        }
    }
}
