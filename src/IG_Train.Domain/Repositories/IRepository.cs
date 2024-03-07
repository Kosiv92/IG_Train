using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories.Common;

namespace IG_Train.Domain.Repositories;

public interface IRepository<TEntity, TKey> : IRepository
    where TEntity : BaseEntity<TKey>
{
    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<TEntity?> GetByIdAsync(int id);

    public Task<TKey> CreateAsync(TEntity entity);

    public Task DeleteAsync(TKey id);

    public Task SaveChangesAsync();

    public Task<TKey> UpdateAsync(TEntity entity);
}
