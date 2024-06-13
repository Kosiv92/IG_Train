using IG_Train.Domain.Entities;
using IG_Train.Domain.Services.Common;

namespace IG_Train.Domain.Services;

public interface IExerciseTypeService : ITransientService
{
    Task<int> CreateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken);

    Task DeleteExerciseType(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ExerciseTypeEntity>> GetAllExerciseTypes(CancellationToken cancellationToken);

    Task<ExerciseTypeEntity?> GetExerciseType(int id, CancellationToken cancellationToken);

    Task<int> UpdateExerciseType(ExerciseTypeEntity exerciseType, CancellationToken cancellationToken);
}