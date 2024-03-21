using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record UpdateExerciseTypeRequest(int Id, string Name, string Description) : IRequest<UpdateExerciseTypeResponse>;
