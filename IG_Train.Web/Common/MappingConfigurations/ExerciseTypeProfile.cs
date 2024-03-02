using AutoMapper;
using IG_Train.Contracts.DTO.ExerciseType;
using IG_Train.Domain.Entities;

namespace IG_Train.Web.Common.MappingConfigurations
{
    public class ExerciseTypeProfile : Profile
    {
        public ExerciseTypeProfile()
        {
            CreateMap<ExerciseType, ExerciseTypeDto>();
        }        
    }
}
