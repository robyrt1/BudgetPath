using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Domain.CreditCards.Commands.Handlers
{
    public abstract class CreateCreditCardCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<CommandHandlerCreditCardResponse>, CreateCreditCardRequest>
    {
    }
}
