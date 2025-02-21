using FinanceApi.Domain.Accounts.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Accounts.Port
{
    public interface IAccountWriteRepositoryBase
    {
        public Task<AccountEntity> Create(CreateAccountRequest account);
        public Task<AccountEntity> Update(UpdateAccountRequest account);
        public Task Delete(Guid Id);

    }
}
