using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions.Commands.Requests;

namespace FinanceApi.Domain.Transactions.Commands.Handlers
{
    public abstract class CreateTransactionCommandHandlerBase: HandlerBaseShared<ResponseWrapperBase<TransactionsEntity>, CreateTransactionRequest>
    {
    }
}
