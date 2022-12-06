using System.Linq.Expressions;

namespace MyEFCore.Infrastrcture.Interface.Repositories
{
    public interface IEntityFrameworkRepository<TEntity> where TEntity : class
    {
        void MarkEntityAsDetached<T>(T entity) where T : class;
        void MarkEntityAsModified<T>(T entity) where T : class;
        void MarkEntityAsAdded<T>(T entity) where T : class;
        void MarkEntityAsDeleted<T>(T entity) where T : class;
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<T> GetOneAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
