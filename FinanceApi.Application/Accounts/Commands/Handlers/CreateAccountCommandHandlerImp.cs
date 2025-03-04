using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class CreateAccountCommandHandlerImp : CreateAccountCommandHandlerBase
    {
        private ICommandRepositoryBase<AccountEntity> _accountWriteRepositoryBase;

        public CreateAccountCommandHandlerImp(ICommandRepositoryBase<AccountEntity> accountWriteRepositoryBase) {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
        }

        public override async Task<ResponseWrapperBase<CreatedAccountResponse>> Handle(CreateAccountRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            AccountEntity created = new AccountEntity
            {
                Balance = command.Balance,
                Name = command.Name,
                UserId = command.UserId,
                CreateAt = DateTime.UtcNow,
                Id = new Guid()
            };

            await _accountWriteRepositoryBase.AddAsync(created);

            return new ResponseWrapper<CreatedAccountResponse>(
                    data: new CreatedAccountResponse
                    {
                        Id = created.Id,
                        Name = created.Name,
                        Balance = created.Balance,
                        CreateAt = created.CreateAt,
                        UserId = created.UserId
                    },
                    statusCode: (int)HttpStatusCode.Created,
                    message: "Sucesso ao cadastrar"
                );
        }

        public override async Task<ResponseWrapperBase<CreatedAccountResponse>> Handle(CreateAccountRequest command)
        {

            AccountEntity created = new AccountEntity
            {
                Balance = command.Balance,
                Name = command.Name,
                UserId = command.UserId,
                CreateAt = DateTime.UtcNow,
                Id = new Guid()
            };

            await _accountWriteRepositoryBase.AddAsync(created);

            return new ResponseWrapper<CreatedAccountResponse>(
                    data: new CreatedAccountResponse
                    {
                        Id = created.Id,
                        Name = created.Name,
                        Balance = created.Balance,
                        CreateAt = created.CreateAt,
                        UserId = created.UserId
                    },
                    statusCode: (int)HttpStatusCode.Created,
                    message: "Sucesso ao cadastrar"
                );
        }
    }
}
