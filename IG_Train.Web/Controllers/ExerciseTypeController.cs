using AutoMapper;
using IG_Train.Contracts.DTO.ExerciseType;
using IG_Train.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IG_Train.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IExerciseTypeService _exerciseTypeService;
        private readonly IMapper _mapper;

        public ExerciseTypeController(IExerciseTypeService exerciseTypeService, IMapper mapper)
        {
            _exerciseTypeService = exerciseTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseTypeResponse>>> GetExerciseTypes()
        {
            var exerciseTypes = await _exerciseTypeService.GetAllExerciseTypes();
            var exerciseTypesDtos = _mapper
                .Map<IEnumerable<ExerciseTypeResponse>>(exerciseTypes);
            return Ok(exerciseTypesDtos);
        }
    }
}
