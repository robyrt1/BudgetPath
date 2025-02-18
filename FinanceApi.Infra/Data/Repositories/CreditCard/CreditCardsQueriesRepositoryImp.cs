namespace FinanceApi.Infra.Data.Repositories.CreditCard
{
    using FinanceApi.Domain.CreditCard;
    using FinanceApi.Domain.CreditCards.Port;
    using Microsoft.EntityFrameworkCore;

    public class CreditCardsQueriesRepositoryImp : ICreditCardsQueriesRepositoryBase
    {

        private readonly AppDbContext _context;

        public CreditCardsQueriesRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<CreditCardEntity> GetAll()
        {
            return _context.CreditCard.Include(cc => cc.Account).AsNoTracking();
        }

        public async Task<IQueryable<CreditCardEntity>> GetAllAsync()
        {
            return await Task.FromResult(_context.CreditCard.Include(c => c.Account).AsNoTracking());
        }
    }
}
