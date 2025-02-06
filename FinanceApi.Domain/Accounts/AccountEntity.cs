using FinanceApi.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts
{
    public class AccountEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid UserID {  get; set; }

        [Required]
        public string Name { get; set; }

        public Decimal? Balance {  get; set; }

        public DateTime CreatAt { get; set; }

        [ForeignKey("UserID")]
        public UserEntity User { get; set; }
    }
}
