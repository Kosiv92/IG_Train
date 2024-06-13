using IG_Train.Domain.Entities;

namespace IG_Train.Application.Handlers.ExerciseType;

public record GetExerciseTypesResponse(IEnumerable<ExerciseTypeEntity> ExerciseTypes);