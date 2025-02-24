
namespace FinanceApi.Domain.Accounts.Commands.Responses
{
    public class UpdateAccountResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public Decimal? Balance { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
