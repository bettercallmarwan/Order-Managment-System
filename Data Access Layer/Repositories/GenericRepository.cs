using Data_Access_Layer.Models.Generic;
using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data_Access_Layer.Repositories
{
    internal class GenericRepository<TEntity, TKey>(OrderManagementDbContext _orderManagementDbContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public async Task AddAsync(TEntity entity) =>
            await _orderManagementDbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) => _orderManagementDbContext.Set<TEntity>().Remove(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _orderManagementDbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _orderManagementDbContext.Set<TEntity>().Where(expression).ToListAsync();
            return entities;
        }

        public async Task<TEntity?> GetAsync(TKey id) => await _orderManagementDbContext.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity) => _orderManagementDbContext.Set<TEntity>().Update(entity);
    }
}
