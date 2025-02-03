using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Authentication.Commands.Requests
{
    public class AuthenticationRequest
    {
        public string Password { get; set; }

        public string Email { get; set; }

        public string? FirebaseUid { get; set; } = null;
    }
}
