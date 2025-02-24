using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FinanceApi.Domain.Accounts;

namespace FinanceApi.Domain.CreditCards
{
    public class CreditCardEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? Limit { get; set; }

        [Required]
        public int Maturity { get; set; }

        [Required]
        public int Closing { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountEntity Account { get; set; }

        [Required]
        public Guid AccountId { get; set; }
    }
}
