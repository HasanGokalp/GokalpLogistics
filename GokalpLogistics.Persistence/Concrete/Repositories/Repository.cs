using GokalpLogistics.Domain.Abstract;
using GokalpLogistics.Persistence.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GokalpLogistics.Persistence.Concrete.Repositories
{
    /// <summary>
    /// Veri tabanı CRUD işlemlerinin implementasyonu.
    /// </summary>
    /// <typeparam name="T">Nesnelerden bağımsız dinamik bir yapı.</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> Table;
        public Repository(GokalpLogisticsContext context)
        {
            Table = context.Set<T>();
        }

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Table.AnyAsync(filter);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = Table.Find(id);
            if (entity != null)
            {
                Table.Remove(entity);
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(params string[] includeColumns)
        {
            IQueryable<T> query = Table;

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
            IQueryable<T> query = Table;
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<T> GetById(object id)
        {
            var entity = await Table.FindAsync(id);
            return entity;
        }

        public async Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Table;
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
