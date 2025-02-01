using FinanceApi.Domain.Shared.Execptions;
using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Port;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Domain.Users.Queries.Requests;
using FinanceApi.Domain.Users.Queries.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.User.Queries.Handlers
{
    public class GetUserByEmailHandlerImp : GetUserByEmailHandlerBase
    {
        private readonly IUserQueriesRepositoryBase _userQueriesRepositoryBase;
        public GetUserByEmailHandlerImp(IUserQueriesRepositoryBase userQueriesRepositoryBase) {
            _userQueriesRepositoryBase=userQueriesRepositoryBase;
        }
        public override async Task<GetUserByEmailResponse> Handle(GetUserByEmailRequest command)
        {
            if (string.IsNullOrWhiteSpace(command.Email))
                throw new ArgumentException("Email cannot be empty.");

            UserEntity user = await _userQueriesRepositoryBase.GetByEmail(command.Email);

            if (user is null)
                throw new NotFoundException($"User with Email({command.Email}) not found.");

            return new GetUserByEmailResponse()
            {
                Id = user.Id,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Name = user.Name,
                FirebaseUid = user.FirebaseUid,
                PasswordHash = user.PasswordHash,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
