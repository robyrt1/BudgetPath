using FinanceApi.Domain.Shared.Execptions;
using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Port;
using FinanceApi.Domain.Users.Queries.Handlers;
using FinanceApi.Domain.Users.Queries.Requests;
using FinanceApi.Domain.Users.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.User.Queries.Handlers
{
    public class GetUserByFirebaseUidHandlerImp : GetUserByFirebaseUidHandlerBase
    {
        private readonly IUserQueriesRepositoryBase _userQueriesRepositoryBase;

        public GetUserByFirebaseUidHandlerImp(IUserQueriesRepositoryBase userQueriesRepositoryBase)
        {
            _userQueriesRepositoryBase = userQueriesRepositoryBase;
        }

        public override async Task<GetUserByFirebaseUidResponse> Handle(GetUserByFirebaseUidRequest command)
        {
            if (string.IsNullOrWhiteSpace(command.FirebaseUid))
                throw new ArgumentException("FirebaseUid cannot be empty.");

            UserEntity user = await _userQueriesRepositoryBase.GetByFirebaseUid(command.FirebaseUid);

            if (user is null)
                throw new NotFoundException($"User with FirebaseUid({command.FirebaseUid}) not found.");

            return new GetUserByFirebaseUidResponse()
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
