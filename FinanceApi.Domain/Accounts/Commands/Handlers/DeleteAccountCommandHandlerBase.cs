using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Domain.Accounts.Commands.Handlers
{
    public abstract class DeleteAccountCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<object>, DeleteAccountRequest>
    {

    }
}
