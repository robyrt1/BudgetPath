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
    public class LoginAuthenticationByFirebaseCommandHandlerImp : LoginAuthenticationByFirebaseCommandHandlerBase
    {
        private readonly GetUserByFirebaseUidHandlerBase _getUserByFirebaseUidHandler;
        private IFirebase _firebase;
        private readonly ITokenService _tokenService;

        public LoginAuthenticationByFirebaseCommandHandlerImp(GetUserByFirebaseUidHandlerBase getUserByFirebaseUidHandler, ITokenService tokenService , IFirebase firebase = null)
        {
            _getUserByFirebaseUidHandler = getUserByFirebaseUidHandler;
            _tokenService = tokenService;
            _firebase = firebase;
        }

        public override async Task<AuthenticationResponse> Handle(AuthenticationFirebaseRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            GetUserByFirebaseUidRequest userByFirebaseUidRequest = new GetUserByFirebaseUidRequest
            {
                FirebaseUid = command.Token,
            };

            GetUserByFirebaseUidResponse user = await _getUserByFirebaseUidHandler.Handle(userByFirebaseUidRequest);

            string validateTokenFirbase = await _firebase.VerifyGoogleTokenAsync(userByFirebaseUidRequest.FirebaseUid, cancellationToken);

            if (validateTokenFirbase == null)
            {
                throw new OperationCanceledException("Invalid Firebase token.");
            }

            var input = new UserInput { Name = user.Name };

            return new AuthenticationResponse
            {
                Name = user.Name,
                Token = _tokenService.Generate(
                        input
                    )
            };
        }

        public override async Task<AuthenticationResponse> Handle(AuthenticationFirebaseRequest command) {
            GetUserByFirebaseUidRequest userByFirebaseUidRequest = new GetUserByFirebaseUidRequest
            {
                FirebaseUid = command.Token,
            };

            GetUserByFirebaseUidResponse user = await _getUserByFirebaseUidHandler.Handle(userByFirebaseUidRequest);

            string validateTokenFirbase = await _firebase.VerifyGoogleTokenAsync(userByFirebaseUidRequest.FirebaseUid);

            if (validateTokenFirbase == null)
            {
                throw new Exception("Invalid Firebase token.");
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
