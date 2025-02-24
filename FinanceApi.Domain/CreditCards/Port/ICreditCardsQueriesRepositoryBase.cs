using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.CreditCards.Port
{
    public interface ICreditCardsQueriesRepositoryBase
    {
        public IQueryable<CreditCardEntity> GetAll();
        public Task<IQueryable<CreditCardEntity>> GetAllAsync();
    }
}
