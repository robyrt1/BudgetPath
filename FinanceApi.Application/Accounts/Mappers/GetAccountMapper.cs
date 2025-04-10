using FinanceApi.Domain.Accounts;
using FinanceApi.Domain.Accounts.Port;
using FinanceApi.Domain.Accounts.Queries.Responses;
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
                    },
                    CreditCards = m.CreditCard?.Select(cc => new CreditCardMapper
                    {
                        Id = cc.Id,
                        Name = cc.Name,
                        Limit = cc.Limit ?? 0,
                    }).ToList()
                });
        }
    }
}
