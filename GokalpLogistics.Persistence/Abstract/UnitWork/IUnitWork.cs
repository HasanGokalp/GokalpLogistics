using GokalpLogistics.Domain.Abstract;
using GokalpLogistics.Persistence.Abstract.Repository;

namespace GokalpLogistics.Persistence.Abstract.UnitWork
{
    public interface IUnitWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> CommitAsync();
    }
}
/// <summary>
