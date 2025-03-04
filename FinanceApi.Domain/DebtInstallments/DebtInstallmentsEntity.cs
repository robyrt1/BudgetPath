namespace FinanceApi.Domain.DebtInstallments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FinanceApi.Domain.Debts;

    public class DebtInstallmentsEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DebtId { get; set; }

        [Required]
        public int InstallmentNumber { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [StringLength(50)]
        public string Status { get; set; }


        public virtual DebtsEntity Debt { get; set; }
    }
}
