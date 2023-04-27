using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SimpleApiExcercise.Repositories.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        
        public GenericRepository(DbContext context) => this._context = context;

        public IQueryable<TEntity> Table { get => _context.Set<TEntity>(); }

        //IQueryable<TEntity> IGenericRepository<TEntity>.Table => throw new NotImplementedException();

        public async Task Create(TEntity entity, string createdBy = null)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            TEntity entity = await FindAsync(id);
            await Delete(entity);
        }

        public async Task<TEntity> FindAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Delete(TEntity entity)
        {
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity, string modifiedBy = null)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }
        //public IEnumerable<TEntity> GetByRowQuery(string sqlQuery)
        //{
        //    return _context.Set<TEntity>().SqlQuery(sqlQuery).ToList();
        //}
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IQueryable<TEntity> GetQueryable(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null,
           int? skip = null,
           int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

    }
}
