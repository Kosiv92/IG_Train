using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record DeleteExerciseTypeRequest(int id) : IRequest<DeleteExerciseTypeResponse>;
