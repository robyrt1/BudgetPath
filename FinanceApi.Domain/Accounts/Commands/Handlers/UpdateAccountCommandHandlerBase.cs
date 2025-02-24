using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Domain.Accounts.Commands.Handlers
{
    public abstract class UpdateAccountCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<UpdateAccountResponse>, UpdateAccountRequest>
    {
    }
}
