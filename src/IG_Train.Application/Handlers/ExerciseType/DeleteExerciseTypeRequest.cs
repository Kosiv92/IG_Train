using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record DeleteExerciseTypeRequest : IRequest<DeleteExerciseTypeResponse>;
