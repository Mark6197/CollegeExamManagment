using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetEntityWithEagerLoad(Expression<Func<TEntity, bool>> filter, string[] children);
        Task<int> Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<int> Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
