using FinanceApi.Domain.Shared.Interfaces;
using FinanceApi.Domain.Transactions;
using FinanceApi.Domain.Transactions.Queries.Handlers;
using Microsoft.EntityFrameworkCore;

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
            return _queryRepositoryBase.GetAll()
                .AsNoTracking()
                .Include(t => t.Account)
                .Include(t => t.User)
                .Include(t => t.CreditCard)
                .Include(t => t.Category)
                    .ThenInclude(di => di.Group)
                .Include(t => t.DebtInstallment)
                    .ThenInclude(di => di.Debt); 
        }

        public override Task<IQueryable<TransactionsEntity>> HandleAsync()
        {
            return _queryRepositoryBase.GetAllAsync();
        }
    }
}
