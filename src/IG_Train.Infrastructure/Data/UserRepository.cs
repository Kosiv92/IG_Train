using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IG_Train.Infrastructure.Data
{
    public class UserRepository : IRepository<UserEntity, int>
    {
        ApplicationDbContext _context;
        DbSet<UserEntity> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public async Task<int> CreateAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            await _users.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
                throw new Exception($"User with ID:{id} not found");

            _users.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _users
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _users
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            await _users
                .Where(et => et.Id == entity.Id)
                .ExecuteUpdateAsync(et => et
                .SetProperty(b => b.Name, b => entity.Name)
                .SetProperty(b => b.PasswordHash, b => entity.PasswordHash)
                .SetProperty(b => b.Email, b => entity.Email),
                cancellationToken);
            return entity.Id;
        }
    }
}
