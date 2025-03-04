using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class DeleteAccountCommandHandlerImp : DeleteAccountCommandHandlerBase
    {
        private ICommandRepositoryBase<AccountEntity> _accountWriteRepositoryBase;

        public DeleteAccountCommandHandlerImp(ICommandRepositoryBase<AccountEntity> accountWriteRepositoryBase)
        {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
        }


        public override async Task<ResponseWrapperBase<object>> Handle(DeleteAccountRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _accountWriteRepositoryBase.DeleteAsync(command.Id);

            return new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Conta Deletada"
                );
        }

        public override async Task<ResponseWrapperBase<object>> Handle(DeleteAccountRequest command)
        {

            await _accountWriteRepositoryBase.DeleteAsync(command.Id);

            return new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.OK,
                   message: "Conta Deletada"
             );
        }
    }
}
