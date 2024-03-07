using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories;

namespace IG_Train.Domain.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IRepository<ExerciseTypeEntity, int> _repositoryET;

        public ExerciseTypeService(IRepository<ExerciseTypeEntity, int> repository)
        {
            _repositoryET = repository;
        }

        public async Task<IEnumerable<ExerciseTypeEntity>> GetAllExerciseTypes()
        {
            return await _repositoryET.GetAllAsync();
        }

        public async Task<ExerciseTypeEntity?> GetExerciseType(int id)
        {
            return await _repositoryET.GetByIdAsync(id);
        }

        public async Task<int> CreateExerciseType(ExerciseTypeEntity exerciseType)
        {
            return await _repositoryET.CreateAsync(exerciseType);
        }

        public async Task DeleteExerciseType(int id)
        {
            await _repositoryET.DeleteAsync(id);
        }

        public async Task<int> UpdateExerciseType(ExerciseTypeEntity exerciseType)
        {
            return await _repositoryET.UpdateAsync(exerciseType);
        }
    }
}
