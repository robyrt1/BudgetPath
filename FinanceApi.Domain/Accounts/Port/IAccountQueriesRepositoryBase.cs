using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Port
{
    public interface IAccountQueriesRepositoryBase
    {
        Task<IEnumerable<AccountEntity>> GetByUser(Guid UserId);
        IQueryable<AccountEntity> GetAccount();
        Task<IQueryable<AccountEntity>> GetAccountAsync();

    }
}
    