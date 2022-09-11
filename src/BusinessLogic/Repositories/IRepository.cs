using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task <TEntity> FetchAsync(int id);
        Task <List<TEntity>> FetchAsync();
        Task<List<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(int id);
        void Update(TEntity entity);
        Task SaveAsync();
    }
}
