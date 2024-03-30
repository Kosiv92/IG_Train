using AutoMapper;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Application.Handlers.User;
using IG_Train.Domain.Entities;

namespace IG_Train.Application.Mapping;

internal class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // ExerciseType map
        CreateMap<UpdateExerciseTypeRequest, ExerciseTypeEntity>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));

        //User map
        CreateMap<CreateUserRequest, UserEntity>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(d => d.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));
    }
}
