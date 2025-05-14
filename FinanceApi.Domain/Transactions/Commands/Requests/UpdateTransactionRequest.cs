using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Transactions.Commands.Requests
{
    public class UpdateTransactionRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? CreditCardId { get; set; }
        public Guid? DebtId { get; set; }
        public Guid? InstallmentId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid PaymentMethod { get; set; }
    }
}
