using GokalpLogistics.Domain.Abstract;
using GokalpLogistics.Persistence.Abstract.Repository;
using GokalpLogistics.Persistence.Abstract.UnitWork;
using GokalpLogistics.Persistence.Concrete.Repositories;

namespace GokalpLogistics.Persistence.Concrete.UnitWork
{
    /// <summary>
    /// => Repositoryleri tek ele toplamamızı sağlıyor.
    /// </summary>
    public class UnitWork : IUnitWork
    {
        //Fields
        private bool disposedValue;
        private readonly GokalpLogisticsContext _context;
        private readonly Dictionary<Type, object> repos;

        /// <summary>
        /// => Constructorımız Depency injection yapılan yer.
        /// </summary>
        /// <param name="context">Veri tabanımızın sorumluluğunu alan sınıfımız.</param>
        public UnitWork(GokalpLogisticsContext context)
        {
            repos = new Dictionary<Type, object>();
            _context = context;
        }

        /// <summary>
        /// => Veri tabanı kayıt işlemi için repoları çağırır.
        /// </summary>
        /// <returns></returns>
        #region CommitAsync
        public async Task<bool> CommitAsync()
        {
            var result = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// => CRUD işlemleri için repositoryler oluşturulur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Fırlatılan hata.</exception>
        #region GetRepository
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (repos.ContainsKey(typeof(IRepository<T>)))
            {
                return (IRepository<T>)repos[typeof(IRepository<T>)];
            }

            var repository = new Repository<T>(_context);
            repos.Add(typeof(IRepository<T>), repository);
            return repository;
        }
        #endregion

        /// <summary>
        /// => Garbage collection için
        /// </summary>
        /// <param name="disposing">Heapteki newlenen sınıfımızı temizler.</param>
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: yönetilen durumu (yönetilen nesneleri) atın
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve sonlandırıcıyı geçersiz kılın
                // TODO: büyük alanları null olarak ayarlayın
                disposedValue = true;
            }
        }

        // // TODO: sonlandırıcıyı yalnızca 'Dispose(bool disposing)' içinde yönetilmeyen kaynakları serbest bırakacak kod varsa geçersiz kılın
        // ~UnitWork()
        // {
        //     // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
