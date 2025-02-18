using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Commands.Requests
{
    public class UpdateCreditCardRequest
    {
        [Required]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid? AccountId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O limite não pode ser negativo.")]
        public decimal? Limit { get; set; } = 0;

        [Range(1, 31, ErrorMessage = "O vencimento deve estar entre 1 e 31.")]
        public int? Maturity { get; set; }

        [Range(1, 31, ErrorMessage = "O fechamento deve estar entre 1 e 31.")]
        public int? Closing { get; set; }
    }
}
