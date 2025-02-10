using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Requests
{
    public class CreateAccountRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public Decimal? Balance { get; set; }
    }
}
