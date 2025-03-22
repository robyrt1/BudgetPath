using FinanceApi.Application.Shared.Wrappers;
using FinanceApi.Domain.Accounts.Commands.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions;
using FinanceApi.Domain.Transactions.Commands.Handlers;
using FinanceApi.Domain.Transactions.Commands.Requests;
using FinanceApi.Domain.Transactions.Factory;
using System.Net;

namespace FinanceApi.Application.Transactions.Commands.Handlers
{
    public class CreateTransactionCommandHandlerImp : CreateTransactionCommandHandlerBase
    {
        private readonly ICommandRepositoryBase<TransactionsEntity> _transactionsWriteRepository;
        private readonly TransactionsFactory _transactionsFactory;

        public CreateTransactionCommandHandlerImp(
            ICommandRepositoryBase<TransactionsEntity> transactionsWriteRepository,
            TransactionsFactory transactionsFactory)
        {
            _transactionsWriteRepository = transactionsWriteRepository;
            _transactionsFactory = transactionsFactory;        }

        public async Task<ResponseWrapperBase<TransactionsEntity>> Handle(CreateTransactionRequest command)
        {

                var trasanction = _transactionsFactory.prepareForAppend(command);
                await _transactionsWriteRepository.AddAsync(trasanction);

                return new ResponseWrapper<TransactionsEntity>(
                    data: trasanction, 
                    statusCode: (int)HttpStatusCode.Created, 
                    message:"Success crate trasaction"
                );
        }
    }
}
