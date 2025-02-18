using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Commands.Responses
{
    public class CreateCreditCardResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AccountId { get; set; }

        public decimal? Limit { get; set; } = 0;

        public int Maturity { get; set; }

        public int Closing { get; set; }
    }
}
