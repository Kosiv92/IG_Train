using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public record GetExerciseTypeRequest(int Id) : IRequest<GetExerciseTypeResponse>
{
}
