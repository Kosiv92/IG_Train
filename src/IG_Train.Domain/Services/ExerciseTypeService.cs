using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories;
using System.Threading;

namespace IG_Train.Domain.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IRepository<ExerciseTypeEntity, int> _repositoryET;

        public ExerciseTypeService(IRepository<ExerciseTypeEntity, int> repository)
        {
            _repositoryET = repository;
        }

        public async Task<IEnumerable<ExerciseTypeEntity>> GetAllExerciseTypes(CancellationToken cancellationToken)
        {
            return await _repositoryET.GetAllAsync(cancellationToken);
        }

        public async Task<ExerciseTypeEntity?> GetExerciseType(int id, CancellationToken cancellationToken)
        {
            return await _repositoryET.GetByIdAsync(id, cancellationToken);
        }

        public async Task<int> CreateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken)
        {
            return await _repositoryET.CreateAsync(exerciseType, cancellationToken);
        }

        public async Task DeleteExerciseType(int id, CancellationToken cancellationToken)
        {
            await _repositoryET.DeleteAsync(id, cancellationToken);
        }

        public async Task<int> UpdateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken)
        {
            return await _repositoryET.UpdateAsync(exerciseType, cancellationToken);
        }
    }
}
