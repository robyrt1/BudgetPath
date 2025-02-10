using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Accounts.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class CreateAccountCommandHandlerImp : CreateAccountCommandHandlerBase
    {
        private IAccountWriteRepositoryBase _accountWriteRepositoryBase;
        
        public CreateAccountCommandHandlerImp(IAccountWriteRepositoryBase accountWriteRepositoryBase) {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
        }

        public override async Task<CreatedAccountResponse> Handle(CreateAccountRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var created = await _accountWriteRepositoryBase.Create(command);

            return new CreatedAccountResponse
            {
                Id = created.Id,
                Name = created.Name,
                Balance = created.Balance,
                CreateAt = created.CreateAt,
                UserId = created.UserId
            };
        }

        public override async Task<CreatedAccountResponse> Handle(CreateAccountRequest command)
        {

            var created = await _accountWriteRepositoryBase.Create(command);

            return new CreatedAccountResponse
            {
                Id = created.Id,
                Name = created.Name,
                Balance = created.Balance,
                CreateAt = created.CreateAt,
                UserId = created.UserId
            };
        }
    }
}
