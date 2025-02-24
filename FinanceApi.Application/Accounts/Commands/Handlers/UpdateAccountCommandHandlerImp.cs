
using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;

namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class UpdateAccountCommandHandlerImp : UpdateAccountCommandHandlerBase
    {
        private IAccountWriteRepositoryBase _accountWriteRepositoryBase;
        private GetAccountQueryHandlerBase _getAccountQueryHandler;

        public UpdateAccountCommandHandlerImp(IAccountWriteRepositoryBase accountWriteRepositoryBase , GetAccountQueryHandlerBase getAccountQueryHandler)
        {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
            _getAccountQueryHandler = getAccountQueryHandler;
        }

        public override async Task<ResponseWrapperBase<UpdateAccountResponse>> Handle(UpdateAccountRequest command)
        {
            var account = await _getAccountQueryHandler.HandleAsync();
            var shouldCreditCard = account
                .SingleOrDefault(c => c.Id == command.Id);

            if (shouldCreditCard is null)
            {
                return new ResponseWrapper<UpdateAccountResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Conta não cadastrado."
                );
            }


            var updated = await _accountWriteRepositoryBase.Update(command);

            return new ResponseWrapper<UpdateAccountResponse>(
                  data: new UpdateAccountResponse
                  {
                      Id = updated.Id,
                      Balance = updated.Balance,
                      CreateAt = updated.CreateAt,
                      Name = updated.Name,
                      UserId = updated.UserId
                  },
                  statusCode: (int)HttpStatusCode.OK,
                  message: "Sucesso"
                );
        }
    }
}
