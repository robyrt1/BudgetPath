using FinanceApi.Domain.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Abstract
{
    public abstract class QueryHandlerBase<TEntity> where TEntity: class
    {
        public abstract IQueryable<TEntity> Handle();

        public abstract Task<IQueryable<TEntity>> HandleAsync();
    }
}
