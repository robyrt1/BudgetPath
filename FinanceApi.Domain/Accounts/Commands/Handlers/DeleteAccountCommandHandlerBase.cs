using FinanceApi.Domain.Accounts.Commands.Requests;
using FinanceApi.Domain.CreditCards.Commands.Requests;
using FinanceApi.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Commands.Handlers
{
    public abstract class DeleteAccountCommandHandlerBase
    {
        public abstract Task<ResponseWrapperBase<object>> Handle(DeleteAccountRequest command);

    }
}
