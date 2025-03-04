namespace FinanceApi.Infra.Persistence
{
    using FinanceApi.Domain.Shared.Interfaces;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class QueriesRepositoryBase<TEntity> : IQueriesRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public QueriesRepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<TEntity>().AsQueryable());
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// The Find
        /// </summary>
        /// <param name="predicate">The predicate<see cref="Expression{Func{TEntity, bool}}"/></param>
        /// <returns>The <see cref="IQueryable{TEntity}"/></returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}
