using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Application.CreditCards.Queries.Handlers
{
    public class GetCreditCardsQueryHandlerImp : GetCreditCardsQueryHandlerBase
    {
        private readonly IQueriesRepositoryBase<CreditCardEntity> _creditCardsQueriesRepository;

        public GetCreditCardsQueryHandlerImp(IQueriesRepositoryBase<CreditCardEntity> creditCardsQueriesRepository) {
            _creditCardsQueriesRepository = creditCardsQueriesRepository;
        }

        public override IQueryable<CreditCardEntity> Handle()
        {
            return _creditCardsQueriesRepository.GetAll();
        }

        public override Task<IQueryable<CreditCardEntity>> HandleAsync()
        {
            return _creditCardsQueriesRepository.GetAllAsync();
        }
    }
}
