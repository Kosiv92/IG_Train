using AutoMapper;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

public class UpdateExerciseTypeHandler : IRequestHandler<UpdateExerciseTypeRequest, UpdateExerciseTypeResponse>
{
    private readonly IExerciseTypeService _exerciseTypeService;
    private readonly IMapper _mapper;

    public UpdateExerciseTypeHandler(IExerciseTypeService exerciseTypeService, IMapper mapper)
    {
        _exerciseTypeService = exerciseTypeService;
        _mapper = mapper;
    }

    public async Task<UpdateExerciseTypeResponse> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ExerciseTypeEntity>(request);

        return new UpdateExerciseTypeResponse(await _exerciseTypeService.UpdateExerciseType(entity, cancellationToken));
    }
}
