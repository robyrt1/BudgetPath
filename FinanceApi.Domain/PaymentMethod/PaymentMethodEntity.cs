using FinanceApi.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.PaymentMethod
{
    public class PaymentMethodEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DescriptionLower { get; private set; }

        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
    }
}
