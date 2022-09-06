using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task <TEntity> GetAsync(int id);
        Task <List<TEntity>> GetAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(int id);
        void Update(TEntity entity);
        Task SaveAsync();
    }
}
