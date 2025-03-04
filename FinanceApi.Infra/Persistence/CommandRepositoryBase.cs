using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Infra.Persistence
{
    public class CommandRepositoryBase<TEntity> : ICommandRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public CommandRepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IQueryable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
