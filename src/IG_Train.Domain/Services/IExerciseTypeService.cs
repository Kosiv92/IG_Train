using IG_Train.Domain.Entities;
using IG_Train.Domain.Services.Common;

namespace IG_Train.Domain.Services;

public interface IExerciseTypeService : ITransientService
{
    Task<int> CreateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken = default);

    Task DeleteExerciseType(int id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ExerciseTypeEntity>> GetAllExerciseTypes(CancellationToken cancellationToken = default);

    Task<ExerciseTypeEntity?> GetExerciseType(int id, CancellationToken cancellationToken = default);

    Task<int> UpdateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken = default);
}