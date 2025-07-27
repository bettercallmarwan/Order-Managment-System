using Data_Access_Layer.Models.Generic;
using Data_Access_Layer.Repositories.Interfaces;

namespace Data_Access_Layer.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>;
            
        Task<int> CompleteAsync();
    }
}
