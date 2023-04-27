using System.Linq.Expressions;

namespace SimpleApiExcercise.Repositories.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(object id);
        Task Create(TEntity entity, string createdBy = null);
        Task<int> Update(TEntity entity, string modifiedBy = null);
        Task Delete(TEntity entity);

        //IEnumerable<TEntity> GetByRowQuery(string sqlQuery);

        Task Delete(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        IQueryable<TEntity> Table { get; }

        void Save();
    }
}
