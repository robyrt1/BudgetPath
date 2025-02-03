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
    public class RegisterUserFirebaseCommandHandlerImp : RegisterUserFirebaseCommandHandlerBase
    {
        private IUserWriteRepositoryBase _userWriteRepositoryBase;
        private IFirebase _firebase;
        public RegisterUserFirebaseCommandHandlerImp(IUserWriteRepositoryBase userWriteRepositoryBase, IFirebase firebase) { 
            _userWriteRepositoryBase = userWriteRepositoryBase;
            _firebase = firebase;
        }
        public override async Task<RegisterUserFirebaseResponse> Handle(RegisterUserFirebaseRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var firebaseUid = await _firebase.VerifyGoogleTokenAsync(command.IdToken,cancellationToken);
            
            if (firebaseUid == null)
            {
                throw new Exception("Invalid Firebase token.");
            }

            UserEntity user = new UserEntity
            {
                Email = command.Email,
                Name = command.Name,
                FirebaseUid = firebaseUid,
                AuthProvider = "firebase",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            UserEntity userCreated = await _userWriteRepositoryBase.Create(user);
            
            return new RegisterUserFirebaseResponse()
            {
               Id = userCreated.Id,
               Email = userCreated.Email,
               Name = userCreated.Name,
               FirebaseUid  = userCreated.FirebaseUid,
               CreatedAt = userCreated.CreatedAt,
               UpdatedAt = userCreated.UpdatedAt,
               PasswordHash = userCreated.PasswordHash
            };
        }
    }
}
