using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Commands.Requests
{
    public class CreateCreditCardRequest
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O limite não pode ser negativo.")]
        public decimal? Limit { get; set; } = 0;

        [Required]
        [Range(1, 31, ErrorMessage = "O vencimento deve estar entre 1 e 31.")]
        public int Maturity { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "O fechamento deve estar entre 1 e 31.")]
        public int Closing { get; set; }
    }
}
