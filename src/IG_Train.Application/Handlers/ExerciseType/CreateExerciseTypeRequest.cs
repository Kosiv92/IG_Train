using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record CreateExerciseTypeRequest(string Name, string Description) : IRequest<CreateExerciseTypeResponse>;