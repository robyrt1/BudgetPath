using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions;
using FinanceApi.Domain.Transactions.Queries.Handlers;

namespace FinanceApi.Application.Transactions.Queries.Handlers
{
    public class FindTransactionsQueryHandlerImp : FindTransactionsQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<TransactionsEntity> _queryRepositoryBase;

        public FindTransactionsQueryHandlerImp(IQueriesRepositoryBase<TransactionsEntity> queryRepositoryBase)
        {
            _queryRepositoryBase = queryRepositoryBase;
        }

        public override IQueryable<TransactionsEntity> Handle()
        {
            return _queryRepositoryBase.GetAll();
        }

        public override Task<IQueryable<TransactionsEntity>> HandleAsync()
        {
            return _queryRepositoryBase.GetAllAsync();
        }
    }
}
