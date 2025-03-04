using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Shared.Interfaces
{
    public interface ICommandRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IQueryable<TEntity> entities);
    }
}
