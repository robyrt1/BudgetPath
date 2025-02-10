using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Application.Accounts.Mappers
{
    public class GetAccountByUserMapper : IGetAccountByUserMapperBase
    {
        public IEnumerable<GetAccountByUserQueryHandlerResponse> To(IEnumerable<AccountEntity> mapper)
        {
            return mapper.ToList()
                .Select(m => new GetAccountByUserQueryHandlerResponse
                {
                    Id = m.Id,
                    Balance = m.Balance ?? 0,
                    CreatedAt = m.CreateAt,
                    Name = m.Name,
                });
        }
    }
}
