using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class UpdateExerciseTypeHandler : IRequestHandler<UpdateExerciseTypeRequest, UpdateExerciseTypeResponse>
{
    public Task<UpdateExerciseTypeResponse> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
