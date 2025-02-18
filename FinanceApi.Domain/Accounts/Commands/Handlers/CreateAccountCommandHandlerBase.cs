using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.Accounts.Commands.Responses;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Handlers
{
    public abstract class CreateAccountCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<CreatedAccountResponse>, CreateAccountRequest>
    {

    }
}
