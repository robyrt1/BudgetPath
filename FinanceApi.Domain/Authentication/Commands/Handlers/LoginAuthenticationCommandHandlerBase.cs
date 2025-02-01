using FinanceApi.Domain.Authentication.Commands.Requests;
using FinanceApi.Domain.Authentication.Commands.Responses;
using FinanceApi.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Authentication.Commands.Handlers
{
    public abstract class LoginAuthenticationCommandHandlerBase : HandlerBaseShared<AuthenticationResponse,AuthenticationRequest>
    {
    }
}
