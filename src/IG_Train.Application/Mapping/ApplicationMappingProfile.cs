using AutoMapper;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Entities;

namespace IG_Train.Application.Mapping;

internal class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<UpdateExerciseTypeRequest, ExerciseTypeEntity>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
    }
}
