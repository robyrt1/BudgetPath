using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Requests
{
    public class UpdateAccountRequest
    {
        public string? Name { get; set; }

        public decimal? Balance { get; set; }

        public Guid Id { get; set; }

    }
}
