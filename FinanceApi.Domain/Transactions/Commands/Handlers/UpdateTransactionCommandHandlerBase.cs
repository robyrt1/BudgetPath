using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions.Commands.Requests;

namespace FinanceApi.Domain.Transactions.Commands.Handlers
{
    public abstract class UpdateTransactionCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<TransactionsEntity>, UpdateTransactionRequest>
    {
    }
}
