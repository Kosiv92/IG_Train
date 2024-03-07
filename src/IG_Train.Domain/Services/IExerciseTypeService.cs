using IG_Train.Domain.Entities;
using IG_Train.Domain.Services.Common;

namespace IG_Train.Domain.Services;

public interface IExerciseTypeService : ITransientService
{
    Task<int> CreateExerciseType(ExerciseType exerciseType);

    Task DeleteExerciseType(int id);

    Task<IEnumerable<ExerciseType>> GetAllExerciseTypes();

    Task<ExerciseType?> GetExerciseType(int id);

    Task<int> UpdateExerciseType(ExerciseType exerciseType);
}