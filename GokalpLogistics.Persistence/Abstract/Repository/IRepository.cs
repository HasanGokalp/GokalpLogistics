using System.Linq.Expressions;

namespace GokalpLogistics.Persistence.Abstract.Repository
{
    /// <summary>
    /// Veri tabanı CRUD işlemlerinin şema hali.
    /// </summary>
    /// <typeparam name="T">Nesnelerden bağımsız dinamik bir yapı.</typeparam>
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(params string[] includeColumns);
        Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
