
namespace FinanceApi.Domain.Accounts.Queries.Responses
{
    public class GetAccountQueryHandlerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserMapper? User { get; set; }

        public List<CreditCardMapper> CreditCards { get; set; }
    }

    public class UserMapper
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
