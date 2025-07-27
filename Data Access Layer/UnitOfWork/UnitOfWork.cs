using Data_Access_Layer.Models.Generic;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace Data_Access_Layer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ConcurrentDictionary<string, object> _repositories;
        private readonly OrderManagementDbContext _orderManagementDbContext;


        public UnitOfWork(OrderManagementDbContext orderManagementDbContext)
        {
            _orderManagementDbContext = orderManagementDbContext;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>) _repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_orderManagementDbContext));
        }
        public async Task<int> CompleteAsync()
        {
            return await _orderManagementDbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync() => await _orderManagementDbContext.DisposeAsync();


    }
}
