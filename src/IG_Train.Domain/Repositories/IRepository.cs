using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories.Common;

namespace IG_Train.Domain.Repositories;

public interface IRepository<TEntity, TKey> : IRepository
    where TEntity : BaseEntity<TKey>
{
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    public Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);

    public Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task DeleteAsync(TKey id, CancellationToken cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken);

    public Task<TKey> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
