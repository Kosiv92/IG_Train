using IG_Train.Domain.Entities;

namespace IG_Train.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);

        public Task<int> CreateAsync(T entity);

        public Task DeleteAaync(int id);

        public Task SaveChangesAsync();

    }
}
