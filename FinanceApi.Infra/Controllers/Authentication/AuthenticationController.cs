namespace FinanceApi.Infra.Controllers.Authentication
{
    using FinanceApi.Domain.Authentication.Commands.Handlers;
    using FinanceApi.Domain.Authentication.Commands.Requests;
    using FinanceApi.Domain.Authentication.Commands.Responses;
    using FinanceApi.Domain.Shared.Execptions;
    using FinanceApi.Infra.Shared.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="AuthenticationController" />
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        public AuthenticationController()
        {
        }

        /// <summary>
        /// The SignIn
        /// </summary>
        /// <param name="authenticationRequest">The authenticationRequest<see cref="AuthenticationRequest"/></param>
        /// <param name="loginAuthenticationCommandHandler">The loginAuthenticationCommandHandler<see cref="LoginAuthenticationCommandHandlerBase"/></param>
        /// <param name="loginAuthenticationByFirebaseCommandHandler">The loginAuthenticationByFirebaseCommandHandler<see cref="LoginAuthenticationByFirebaseCommandHandlerBase"/></param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        public async Task<IActionResult> SignIn(
            [FromBody] AuthenticationRequest authenticationRequest, 
            [FromServices] LoginAuthenticationCommandHandlerBase loginAuthenticationCommandHandler, 
            [FromServices] LoginAuthenticationByFirebaseCommandHandlerBase loginAuthenticationByFirebaseCommandHandler, 
            CancellationToken cancellationToken
         )
        {

            try
            {
                var response = new AuthenticationResponse();
                if (authenticationRequest.FirebaseUid == null)
                {
                    var request = new AuthenticationRequest() { Email = authenticationRequest.Email, Password = authenticationRequest.Password };
                    response = await loginAuthenticationCommandHandler.Handle(request);

                }
                else
                {
                    var request = new AuthenticationFirebaseRequest() { Token = authenticationRequest.FirebaseUid };
                    response = await loginAuthenticationByFirebaseCommandHandler.Handle(request);
                }

                return ResponseHelper.CreateResponse(response,StatusCodes.Status200OK);
            }
            catch (UnauthorizedException ex)
            {
                return StatusCode(500, new { StatusCode = StatusCodes.Status401Unauthorized, Details = ex.Message });

            }
            catch(OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest, new { StatusCode = StatusCodes.Status499ClientClosedRequest, Details = "A operação foi cancelada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = StatusCodes.Status500InternalServerError, Details = ex.Message });

            }
        }
    }
}
