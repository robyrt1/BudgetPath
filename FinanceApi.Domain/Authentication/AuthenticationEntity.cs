using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Authentication
{
    public class AuthenticationEntity
    {
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
