    namespace FinanceApi.Domain.Transactions
    {
        using System;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.ComponentModel.DataAnnotations;
        using FinanceApi.Domain.Users;
        using FinanceApi.Domain.Accounts;
        using FinanceApi.Domain.CreditCards;
        using FinanceApi.Domain.Debts;
        using FinanceApi.Domain.DebtInstallments;
        using FinanceApi.Domain.Categories;
        using FinanceApi.Domain.PaymentMethod;

        public class TransactionsEntity
        {
            [Key]
            public Guid Id { get; set; }

            [Required]
            public Guid UserId { get; set; }

            public Guid? AccountId { get; set; }

            public Guid? CreditCardId { get; set; }

            public Guid? DebtId { get; set; }

            public Guid? InstallmentId { get; set; }

            [Required]
            public Guid CategoryId { get; set; }

            [Required]
            [StringLength(255)]
            public string Description { get; set; }

            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal Amount { get; set; }

            [Required]
            [Column(TypeName = "date")]
            public DateTime TransactionDate { get; set; }

            [Required]
            public Guid PaymentMethodId { get; set; }

            [StringLength(50)]
            public string Status { get; set; }

            public DateTime CreatedAt { get; set; }

            // Relacionamentos

            public virtual UserEntity User { get; set; }

            public virtual AccountEntity Account { get; set; }

            public virtual CreditCardEntity CreditCard { get; set; }

            public virtual DebtsEntity Debt { get; set; }

            public virtual DebtInstallmentsEntity DebtInstallment { get; set; }

            public virtual CategoryEntity Category { get; set; }

            public virtual PaymentMethodEntity PaymentMethod { get; set; }

        }
    }
