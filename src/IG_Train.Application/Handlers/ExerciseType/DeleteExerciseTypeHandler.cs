using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class DeleteExerciseTypeHandler : IRequestHandler<DeleteExerciseTypeRequest, DeleteExerciseTypeResponse>
{
    public Task<DeleteExerciseTypeResponse> Handle(DeleteExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
