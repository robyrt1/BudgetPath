
using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Accounts.Queries.Handler;
using FinanceApi.Domain.Shared.Interfaces;
using System.Net;


namespace FinanceApi.Application.Accounts.Commands.Handlers
{
    public class UpdateAccountCommandHandlerImp : UpdateAccountCommandHandlerBase
    {
        private ICommandRepositoryBase<AccountEntity> _accountWriteRepositoryBase;
        private GetAccountQueryHandlerBase _getAccountQueryHandler;

        public UpdateAccountCommandHandlerImp(ICommandRepositoryBase<AccountEntity> accountWriteRepositoryBase , GetAccountQueryHandlerBase getAccountQueryHandler)
        {
            _accountWriteRepositoryBase = accountWriteRepositoryBase;
            _getAccountQueryHandler = getAccountQueryHandler;
        }

        public override async Task<ResponseWrapperBase<UpdateAccountResponse>> Handle(UpdateAccountRequest command)
        {
            var accounts = await _getAccountQueryHandler.HandleAsync();
            AccountEntity account = accounts.FirstOrDefault(c => c.Id == command.Id);

            if (account is null)
            {
                return new ResponseWrapper<UpdateAccountResponse>(
                    data: null,
                    statusCode: (int)HttpStatusCode.Conflict,
                    message: "Conta não cadastrado."
                );
            }

            account.Balance = command.Balance ?? account.Balance; 
            account.Name = command.Name ?? account.Name;

            await _accountWriteRepositoryBase.UpdateAsync(account);

            return new ResponseWrapper<UpdateAccountResponse>(
                  data: new UpdateAccountResponse
                  {
                      Id = account.Id,
                      Balance = account.Balance,
                      CreateAt = account.CreateAt,
                      Name = account.Name,
                      UserId = account.UserId
                  },
                  statusCode: (int)HttpStatusCode.OK,
                  message: "Sucesso"
                );
        }
    }
}
