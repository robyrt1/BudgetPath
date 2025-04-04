using FinanceApi.Domain.PaymentMethod;
using FinanceApi.Domain.PaymentMethod.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Application.PaymentMethod.Queries.Handlers
{
    public class FindPaymentMethodQueryHandlerImp : FindPaymentMethodQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<PaymentMethodEntity> _queryRepositoryBase;

        public FindPaymentMethodQueryHandlerImp(IQueriesRepositoryBase<PaymentMethodEntity> queryRepositoryBase) 
        {
            _queryRepositoryBase = queryRepositoryBase;
        }



        public override IQueryable<PaymentMethodEntity> Handle()
        {
            return _queryRepositoryBase.GetAll()
                .AsNoTracking();
        }

        public override Task<IQueryable<PaymentMethodEntity>> HandleAsync()
        {
            return _queryRepositoryBase.GetAllAsync();
        }
    }
}
