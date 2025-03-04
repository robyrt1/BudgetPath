namespace FinanceApi.Domain.Shared.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IQueriesRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
