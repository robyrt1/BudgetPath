using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Queries.Handlers
{
    public abstract class GetCreditCardsQueryHandlerBase
    {
        public abstract IQueryable<CreditCardEntity> Handle();

        public abstract Task<IQueryable<CreditCardEntity>> HandleAsync();

    }
}
