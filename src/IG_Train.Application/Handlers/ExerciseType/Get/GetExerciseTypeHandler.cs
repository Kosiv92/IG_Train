using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class GetExerciseTypeHandler : IRequestHandler<GetExerciseTypeRequest, GetExerciseTypeResponse>
{
    private readonly IExerciseTypeService _exerciseTypeService;

    public GetExerciseTypeHandler(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    public async Task<GetExerciseTypeResponse> Handle(GetExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        var exerciseType = await _exerciseTypeService.GetExerciseType(request.Id, cancellationToken);
        return new GetExerciseTypeResponse(exerciseType);
    }
}
