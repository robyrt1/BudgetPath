using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Queries.Requests
{
    public class GetAccountByUserQueryHandlerRequest
    {
        public Guid UserId { get; set; }    
    }
}
