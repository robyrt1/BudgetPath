using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Commands.Requests
{
    public class DeleteCreditCardRequest
    {
        public Guid Id { get; set; }
    }
}
