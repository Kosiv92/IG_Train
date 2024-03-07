using IG_Train.Domain.Entities;
using IG_Train.Domain.Services.Common;

namespace IG_Train.Domain.Services;

public interface IExerciseTypeService : ITransientService
{
    Task<int> CreateExerciseType(ExerciseTypeEntity exerciseType);

    Task DeleteExerciseType(int id);

    Task<IEnumerable<ExerciseTypeEntity>> GetAllExerciseTypes();

    Task<ExerciseTypeEntity?> GetExerciseType(int id);

    Task<int> UpdateExerciseType(ExerciseTypeEntity exerciseType);
}