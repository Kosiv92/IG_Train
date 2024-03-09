using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace IG_Train.Infrastructure.Data
{
    public class ExerciseTypeRepository : IRepository<ExerciseTypeEntity, int>
    {
        ApplicationDbContext _context;
        DbSet<ExerciseTypeEntity> _exerciseTypes;

        public ExerciseTypeRepository(ApplicationDbContext context)
        {
            _context = context;
            _exerciseTypes = _context.ExerciseTypes;
        }

        public async Task<int> CreateAsync(ExerciseTypeEntity entity, CancellationToken cancellationToken = default)
        {
            await _exerciseTypes.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _exerciseTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
                throw new Exception($"ExerciseType with ID:{id} not found");

            _exerciseTypes.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ExerciseTypeEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _exerciseTypes
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<ExerciseTypeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _exerciseTypes
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(ExerciseTypeEntity entity, CancellationToken cancellationToken = default)
        {
            await _exerciseTypes
                .Where(et => et.Id == entity.Id)
                .ExecuteUpdateAsync(et => et
                .SetProperty(b => b.Name, b => entity.Name)
                .SetProperty(b => b.Description, b => entity.Description), 
                cancellationToken);
                
            return entity.Id;
        }
    }
}
