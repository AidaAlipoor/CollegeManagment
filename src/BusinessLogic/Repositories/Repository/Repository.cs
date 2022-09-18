using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using DataAccess.EntitiesConfiguration;

namespace BusinessLogic.Repositories.Repositorey
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CollegeManagmentContext dbContext = CollegeManagmentContext.GetInstance();
        private readonly DbSet<TEntity> _dbSet;

        public Repository() => _dbSet = dbContext.Set<TEntity>();

        public virtual void Add(TEntity entity) => _dbSet.Add(entity);

        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            var entry = dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await FetchAsync(id);

            Delete(entity);
        }

        public virtual async Task<TEntity> FetchAsync(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> FetchAsync() => await _dbSet.ToListAsync();

        public virtual async Task<List<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task SaveAsync() => await dbContext.SaveChangesAsync();

    }
}
