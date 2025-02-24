using FinanceApi.Domain.CreditCards;
using FinanceApi.Domain.CreditCards.Port;
using FinanceApi.Domain.CreditCards.Queries.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.CreditCards.Queries.Handlers
{
    public class GetCreditCardsQueryHandlerImp : GetCreditCardsQueryHandlerBase
    {
        private ICreditCardsQueriesRepositoryBase _creditCardsQueriesRepository;

        public GetCreditCardsQueryHandlerImp(ICreditCardsQueriesRepositoryBase creditCardsQueriesRepository) {
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
