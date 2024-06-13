using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class DeleteExerciseTypeHandler : IRequestHandler<DeleteExerciseTypeRequest, DeleteExerciseTypeResponse>
{
    private readonly IExerciseTypeService _exerciseTypeService;

    public DeleteExerciseTypeHandler(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    public async Task<DeleteExerciseTypeResponse> Handle(DeleteExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        await _exerciseTypeService.DeleteExerciseType(request.id, cancellationToken);
        return new DeleteExerciseTypeResponse();
    }
}
