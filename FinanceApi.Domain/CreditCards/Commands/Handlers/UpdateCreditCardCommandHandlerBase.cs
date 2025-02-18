using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Responses;
using FinanceApi.Domain.Shared.Abstract;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Commands.Handlers
{
    public abstract class UpdateCreditCardCommandHandlerBase : HandlerBaseShared<ResponseWrapperBase<CommandHandlerCreditCardResponse>, UpdateCreditCardRequest>
    {
    }
}
