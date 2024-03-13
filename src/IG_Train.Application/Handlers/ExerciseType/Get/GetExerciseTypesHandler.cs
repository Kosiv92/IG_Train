using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class GetExerciseTypesHandler : IRequestHandler<GetExerciseTypesRequest, GetExerciseTypesResponse>
{
    private readonly IExerciseTypeService _exerciseTypeService;

    public GetExerciseTypesHandler(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    public async Task<GetExerciseTypesResponse> Handle(GetExerciseTypesRequest request, CancellationToken cancellationToken)
    {
        var exerciseTypes = await _exerciseTypeService.GetAllExerciseTypes(cancellationToken);
        return new GetExerciseTypesResponse(exerciseTypes);
    }
}
