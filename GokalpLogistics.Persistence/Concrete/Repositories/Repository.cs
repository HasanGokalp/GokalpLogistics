using GokalpLogistics.Persistence.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GokalpLogistics.Persistence.Concrete.Repositories
{
    /// <summary>
    /// Veri tabanı CRUD işlemlerinin implementasyonu.
    /// </summary>
    /// <typeparam name="T">Nesnelerden bağımsız dinamik bir yapı.</typeparam>
    public class Repository<T> : IRepository<T> 
        where T : class
    {
        private readonly DbSet<T> _dbset;
        private readonly GokalpLogisticsContext _context;
        public Repository(GokalpLogisticsContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbset.AnyAsync(filter);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbset.Find(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(params string[] includeColumns)
        {
            IQueryable<T> query = _dbset;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query);
        }

        public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbset;
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<T> GetById(object id)
        {
            var entity = await _dbset.FindAsync(id);
            return entity;
        }

        public async Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbset;
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
