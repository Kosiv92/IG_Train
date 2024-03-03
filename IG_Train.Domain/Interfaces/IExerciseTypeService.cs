using IG_Train.Domain.Entities;

namespace IG_Train.Domain.Interfaces
{
    public interface IExerciseTypeService
    {
        Task<int> CreateExerciseType(ExerciseType exerciseType);
        Task DeleteExerciseType(int id);
        Task<IEnumerable<ExerciseType>> GetAllExerciseTypes();
        Task<ExerciseType?> GetExerciseType(int id);
    }
}