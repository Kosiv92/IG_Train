using IG_Train.Domain.Entities;
using IG_Train.Domain.Interfaces;
using System.Security.Principal;

namespace IG_Train.Application.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IRepository<ExerciseType> _repositoryET;

        public ExerciseTypeService(IRepository<ExerciseType> repositoryET)
        {
            _repositoryET = repositoryET;
        }

        public async Task<IEnumerable<ExerciseType>> GetAllExerciseTypes()
        {
            return await _repositoryET.GetAllAsync();
        }

        public async Task<ExerciseType?> GetExerciseType(int id)
        {
            return await _repositoryET.GetByIdAsync(id);
        }

        public async Task<int> CreateExerciseType(ExerciseType exerciseType)
        {
            return await _repositoryET.CreateAsync(exerciseType);
        }

        public async Task DeleteExerciseType(int id)
        {
            await _repositoryET.DeleteAsync(id);
        }

        public async Task<int> UpdateExerciseType(ExerciseType exerciseType)
        {
            return await _repositoryET.UpdateAsync(exerciseType);
        }
    }
}
