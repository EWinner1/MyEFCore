using Microsoft.EntityFrameworkCore;
using MyEFCore.Infrastrcture.Interface.Repositories;
using System.Linq.Expressions;

namespace MyEFCore.Infrastrcture.Repositories
{
    public abstract class EntityFrameworkRepository<TEntry, TDBContext> : IEntityFrameworkRepository<TEntry> where TEntry : class where TDBContext : DbContext
    {
        protected TDBContext Context;
        public EntityFrameworkRepository(TDBContext context)
        {
            Context = context;
        }
        public virtual void Add(TEntry entity)
        {
            Context.Set<TEntry>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntry> entities)
        {
            Context.Set<TEntry>().AddRange(entities);
        }

        public virtual int Count(Expression<Func<TEntry, bool>> predicate)
        {
            return Context.Set<TEntry>().Count(predicate);
        }

        public virtual IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Context.Set<T>().Where<T>(predicate).AsQueryable();
        }

        public virtual IEnumerable<TEntry> Find(Expression<Func<TEntry, bool>> predicate)
        {
            return Context.Set<TEntry>().Where(predicate);
        }

        public virtual async Task<List<TEntry>> FindAsync(Expression<Func<TEntry, bool>> predicate)
        {
            return await Context.Set<TEntry>().Where(predicate).ToListAsync();
        }

        public virtual IEnumerable<TEntry> GetAll()
        {
            return Context.Set<TEntry>().ToList();
        }

        public virtual async Task<IEnumerable<TEntry>> GetAllAsync()
        {
            return await Context.Set<TEntry>().ToListAsync();
        }

        public virtual async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await this.Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual void MarkEntityAsAdded<T>(T entity) where T : class
        {
            this.Context.Entry(entity).State = EntityState.Added;
        }

        public virtual void MarkEntityAsDeleted<T>(T entity) where T : class
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void MarkEntityAsDetached<T>(T entity) where T : class
        {
            this.Context.Entry(entity).State = EntityState.Detached;
        }

        public virtual void MarkEntityAsModified<T>(T entity) where T : class
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntry entity)
        {
            Context.Set<TEntry>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntry> entities)
        {
            Context.Set<TEntry>().RemoveRange(entities);
        }
    }
}
