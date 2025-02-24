using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Requests
{
    public class DeleteAccountRequest
    {
        public Guid Id { get; set; }
    }
}
