using FinanceApi.Domain.Authentication.Commands.Handlers;
using FinanceApi.Domain.Authentication.Commands.Requests;
using FinanceApi.Domain.Authentication.Commands.Responses;
using FinanceApi.Domain.Shared.Execptions;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Domain.Users.Queries.Requests;
using FinanceApi.Domain.Users.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Authentication.Commands.Handlers
{
    public class LoginAuthenticationCommandHandlerImp : LoginAuthenticationCommandHandlerBase
    {
        private readonly GetUserByEmailHandlerBase _getUserByEmailHandler;
        private readonly ICryptHash _bcryptPasswordHasher;
        private readonly ITokenService _tokenService;

        public LoginAuthenticationCommandHandlerImp(GetUserByEmailHandlerBase getUserByEmailHandler, ICryptHash bcryptPasswordHasher, ITokenService tokenService) {
            _getUserByEmailHandler = getUserByEmailHandler;
            _bcryptPasswordHasher = bcryptPasswordHasher;
            _tokenService = tokenService;
        }

        public override async Task<AuthenticationResponse> Handle(AuthenticationRequest command)
        {
            GetUserByEmailRequest userByEmailRequest = new GetUserByEmailRequest
            {
                Email = command.Email,
            };
            GetUserByEmailResponse user = await _getUserByEmailHandler.Handle(userByEmailRequest);

            bool validatePasswordHash = _bcryptPasswordHasher.VerifyPassword(command.Password, user.PasswordHash);

            if (!validatePasswordHash) {
                throw new UnauthorizedException("Unauthorized: Verifique seu Email e senha");
            }

            var input = new UserInput { Name = user.Name };

            return new AuthenticationResponse
            {
                Name = user.Name,
                Token = _tokenService.Generate(
                        input
                    ),
                UserId = user.Id,
            };
        }
    }
}
