using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class CreateExerciseTypeHandler : IRequestHandler<CreateExerciseTypeRequest, CreateExerciseTypeResponse>
{
    private readonly IExerciseTypeService _exerciseTypeService;

    public CreateExerciseTypeHandler(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    public async Task<CreateExerciseTypeResponse> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        return new CreateExerciseTypeResponse(await _exerciseTypeService.CreateExerciseType
            (new ExerciseTypeEntity(default, request.Name, request.Description), cancellationToken));        
    }
}