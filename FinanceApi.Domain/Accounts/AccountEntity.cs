using FinanceApi.Domain.CreditCard;
using FinanceApi.Domain.GroupCategory;
using FinanceApi.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApi.Domain.Accounts
{
    public class AccountEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId {  get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? Balance {  get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
    }
}
