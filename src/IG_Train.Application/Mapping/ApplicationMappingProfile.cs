using AutoMapper;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Entities;

namespace IG_Train.Application.Mapping;

internal class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<UpdateExerciseTypeRequest, ExerciseTypeEntity>();
    }
}
