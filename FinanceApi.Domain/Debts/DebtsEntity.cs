namespace FinanceApi.Domain.Debts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using FinanceApi.Domain.Users;
    using FinanceApi.Domain.Accounts;
    using FinanceApi.Domain.CreditCards;
    using FinanceApi.Domain.Categories;
    using FinanceApi.Domain.DebtInstallments;

    public class DebtsEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CreditCardId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public int Installments { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingAmount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountEntity Account { get; set; }

        [ForeignKey("CreditCardId")]
        public virtual CreditCardEntity CreditCard { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category { get; set; }


        public virtual ICollection<DebtInstallmentsEntity> DebtInstallments { get; set; }
    }
}
