
namespace FinanceApi.Domain.CreditCards.Commands.Handlers
{
    using FinanceApi.Domain.CreditCards.Commands.Requests;
    using FinanceApi.Domain.Shared.Interfaces;

    public abstract class DeleteCreaditCardCommandHandlerBase
    {
        public abstract Task<ResponseWrapperBase<object>> Handle(DeleteCreditCardRequest command);
    }
}
