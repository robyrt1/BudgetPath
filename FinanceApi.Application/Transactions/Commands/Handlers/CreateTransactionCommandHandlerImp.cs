using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions;
using FinanceApi.Domain.Transactions.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Transactions.Commands.Handlers
{
    public class CreateTransactionCommandHandlerImp : CreateTransactionCommandHandlerBase
    {
        private readonly ICommandRepositoryBase<TransactionsEntity> _transactionsWriteRepository;
    }
}
