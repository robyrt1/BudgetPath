using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Authentication.Commands.Responses
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
