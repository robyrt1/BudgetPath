using System.ComponentModel.DataAnnotations;

namespace FinanceApi.Domain.Transactions.Commands.Requests
{
    public class CreateTransactionRequest
    {
        public Guid UserId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? CreditCardId { get; set; }
        public Guid? DebtId { get; set; }
        public Guid? InstallmentId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
    }
}
