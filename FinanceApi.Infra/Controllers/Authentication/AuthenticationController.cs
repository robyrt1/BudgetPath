using FinanceApi.Domain.Authentication.Commands.Handlers;
using FinanceApi.Domain.Authentication.Commands.Requests;
using FinanceApi.Domain.Shared.Execptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Controllers.Authentication
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController() { }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationRequest authenticationRequest, [FromServices] LoginAuthenticationCommandHandlerBase loginAuthenticationCommandHandler) {

            try { 
                var request = new AuthenticationRequest() { Email = authenticationRequest.Email, Password = authenticationRequest.Password };
                var response = await loginAuthenticationCommandHandler.Handle(request);

                return Ok(response);
            }
            catch (UnauthorizedException ex){
                return StatusCode(500, new { StatusCode = StatusCodes.Status401Unauthorized, Details = ex.Message });

            }
            catch (Exception ex) {
                return StatusCode(500, new { StatusCode = StatusCodes.Status500InternalServerError, Details = ex.Message });

            }

        }
    }
}
