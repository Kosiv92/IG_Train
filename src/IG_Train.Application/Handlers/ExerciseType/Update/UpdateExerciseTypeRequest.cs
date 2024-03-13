using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record UpdateExerciseTypeRequest(int id, string Name, string Description) : IRequest<UpdateExerciseTypeResponse>;
