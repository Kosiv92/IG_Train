using AutoMapper;
using IG_Train.Contracts.DTO.ExerciseType;
using IG_Train.Domain.Entities;
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

        [HttpPost]
        public async Task<ActionResult<int?>> CreateExerciseType([FromBody] ExerciseTypeCreateRequest request)
        {
            var (error, exerciseType) = ExerciseType.Create(request.Name, request.Description!);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            int newExerciseTypeId = await _exerciseTypeService.CreateExerciseType(exerciseType);

            return Ok(newExerciseTypeId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateExerciseType(ExerciseTypeEditRequest request)
        {
            var exerciseType = _mapper
                .Map<ExerciseType>(request);
            
            return await _exerciseTypeService.UpdateExerciseType(exerciseType);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteExerciseType(int id)
        {
            await _exerciseTypeService.DeleteExerciseType(id);
            return Ok();
        }
    }
}
