using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Users;
using FinanceApi.Domain.Users.Commands.Handlers;
using FinanceApi.Domain.Users.Commands.Requests;
using FinanceApi.Domain.Users.Commands.Responses;
using FinanceApi.Domain.Users.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.User.Commands.Handlers
{
    public class RegisterUserSystemCommandHandlerImp : RegisterUserSystemCommandHandlerBase
    {
        private IUserWriteRepositoryBase _userWriteRepositoryBase;
        private IUserQueriesRepositoryBase _userQueriesRepositoryBase;
        private ICryptHash _bcryptPasswordHasher;
        public RegisterUserSystemCommandHandlerImp(IUserWriteRepositoryBase userWriteRepositoryBase, IUserQueriesRepositoryBase userQueriesRepositoryBase, ICryptHash bcryptPasswordHasher)
        {
            _userWriteRepositoryBase = userWriteRepositoryBase;
            _userQueriesRepositoryBase = userQueriesRepositoryBase;
            _bcryptPasswordHasher = bcryptPasswordHasher;
        }
        public override async Task<RegisterUserSystemResponse> Handle(RegisterUserSystemRequest command)
        {
            var shouldUser = await _userQueriesRepositoryBase.GetByEmail(command.Email);
            
            if (shouldUser != null) {
                throw new Exception("Email already registered.");
            }

            UserEntity user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                Name = command.Name,
                AuthProvider = "system",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                PasswordHash = _bcryptPasswordHasher.HashPassword(command.Password)
            };
            UserEntity userCreated = await _userWriteRepositoryBase.Create(user);

            return new RegisterUserSystemResponse { 
                Id = userCreated.Id,
                Email = command.Email,
                Name = command.Name,
                CreatedAt = userCreated.CreatedAt
            };
        }
    }
}
