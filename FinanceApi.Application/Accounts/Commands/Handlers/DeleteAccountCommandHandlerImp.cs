using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class DeleteAccountCommandHandlerImp : DeleteAccountCommandHandlerBase
    {
        private IAccountWriteRepositoryBase _accountWriteRepositoryBase;

        public DeleteAccountCommandHandlerImp(IAccountWriteRepositoryBase accountWriteRepositoryBase)
        {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
        }


        public override async Task<ResponseWrapperBase<object>> Handle(DeleteAccountRequest command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var deleted =  _accountWriteRepositoryBase.Delete(command.Id);

            return new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Atualizado com sucesso"
                );
        }

        public override async Task<ResponseWrapperBase<object>> Handle(DeleteAccountRequest command)
        {

            var deleted = _accountWriteRepositoryBase.Delete(command.Id);

            return new ResponseWrapper<object>(
                    data: null,
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Atualizado com sucesso"
             );
        }
    }
}
