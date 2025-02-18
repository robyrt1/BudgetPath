using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public override async Task<ResponseWrapperBase<CreatedAccountResponse>> Handle(CreateAccountRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var created = await _accountWriteRepositoryBase.Create(command);

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

            var created = await _accountWriteRepositoryBase.Create(command);

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
