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
    public class GetAccountMapper : IGetAccountMapperBase
    {
        public IEnumerable<GetAccountQueryHandlerResponse> To(IEnumerable<AccountEntity> mapper)
        {
            return mapper.ToList()
                .Select(m => new GetAccountQueryHandlerResponse
                {
                    Id = m.Id,
                    Balance = m.Balance ?? 0,
                    CreatedAt = m.CreateAt,
                    Name = m.Name,
                    User = new UserMapper
                    {
                        Id = m.User.Id,
                        Name = m.User.Name,
                        CreatedAt = m.User.CreatedAt,
                        Email = m.User.Email
                    }
                });
        }
    }
}
