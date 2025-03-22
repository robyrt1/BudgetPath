using FinanceApi.Domain.Transactions.Commands.Requests;

namespace FinanceApi.Domain.Transactions.Factory
{
    public sealed class TransactionsFactory
    {
        public TransactionsFactory()
        {

        }
        public TransactionsEntity prepareForAppend(CreateTransactionRequest request)
        {
            return new TransactionsEntity
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CategoryId = request.CategoryId,
                CreditCardId = request.CreditCardId,
                DebtId = request.DebtId,
                Description = request.Description,
                PaymentMethodId = request.PaymentMethod,
                InstallmentId = request.InstallmentId,
                UserId = request.UserId,
                TransactionDate = new DateTime(),
                Status = "confirmado"
            };
        }
    }
}
