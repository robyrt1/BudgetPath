using FinanceApi.Domain.Shared.Execptions;
using FinanceApi.Domain.Users.Commands.Handlers;
using FinanceApi.Domain.Users.Commands.Requests;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Domain.Users.Queries.Requests;
using FinanceApi.Infra.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.OData.Controllers.User
{
    [ApiVersion("1.0")]
    [Route("api/odata/v{version:apiVersion}/User")]
    [ApiController]
    class UserController : ODataController
    {
        [HttpPost]
        public async Task<IActionResult> GetUserByEmail([FromBody] GetUserByEmailRequest Email, [FromServices] GetUserByEmailHandlerBase GetUserByEmailHandler)
        {
            try
            {
                var request = new GetUserByEmailRequest
                {
                    Email = Email.Email
                };

                var response = await GetUserByEmailHandler.Handle(request);

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { StatusCode = StatusCodes.Status404NotFound, Details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = StatusCodes.Status500InternalServerError, Details = ex.Message });
            }
        }

        [HttpPost("registerSystem")]
        public async Task<IActionResult> RegisterUserSystem([FromBody] RegisterUserSystemRequest requestUser, [FromServices] RegisterUserSystemCommandHandlerBase registerUserSystemCommandHandler)
        {
            try
            {
                var request = new RegisterUserSystemRequest
                {
                    Email = requestUser.Email,
                    Name = requestUser.Name,
                    Password = requestUser.Password
                };

                var userCreated = await registerUserSystemCommandHandler.Handle(request);
                var location = Url.Action(nameof(RegisterUserSystem), new { id = userCreated.Id });

                return ResponseHelper.CreateResponse(userCreated, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = StatusCodes.Status500InternalServerError, Details = ex.Message });
            }
        }

        [HttpPost("registerFirebase")]
        public async Task<IActionResult> RegisterUserFirebae([FromBody] RegisterUserFirebaseRequest requestUser, [FromServices] RegisterUserFirebaseCommandHandlerBase registerUserFirebaseCommandHandler, CancellationToken cancellationToken)
        {
            try
            {
                var request = new RegisterUserFirebaseRequest
                {
                    Email = requestUser.Email,
                    Name = requestUser.Name,
                    IdToken = requestUser.IdToken,
                };

                var userCreated = await registerUserFirebaseCommandHandler.Handle(request, cancellationToken);
                var location = Url.Action(nameof(RegisterUserSystem), new { id = userCreated.Id });

                return ResponseHelper.CreateResponse(userCreated, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = StatusCodes.Status500InternalServerError, Details = ex.Message });
            }
        }
    }
}

