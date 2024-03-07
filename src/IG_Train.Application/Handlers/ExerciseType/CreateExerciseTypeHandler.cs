using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class CreateExerciseTypeHandler : IRequestHandler<CreateExerciseTypeRequest, CreateExerciseTypeResponse>
{
    public Task<CreateExerciseTypeResponse> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}