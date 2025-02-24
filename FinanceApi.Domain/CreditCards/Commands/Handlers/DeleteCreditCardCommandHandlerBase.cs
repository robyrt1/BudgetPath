
namespace FinanceApi.Domain.CreditCards.Commands.Handlers
{
    using FinanceApi.Domain.CreditCards.Commands.Requests;
    using FinanceApi.Domain.Shared.Interfaces;

    public abstract class DeleteCreditCardCommandHandlerBase
    {
        public abstract Task<ResponseWrapperBase<object>> Handle(DeleteCreditCardRequest command);
    }
}
