using IG_Train.Application.Handlers.ExerciseType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IG_Train.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get exercise type data
        /// </summary>
        /// <param name="id">ID of the exercise type that needs to be obtained </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [SwaggerResponse(200, "Exercise type data", typeof(GetExerciseTypeResponse))]
        [SwaggerResponse(404, "The exercise type is not found")]
        [SwaggerResponse(400, "The exercise type data is invalid")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetExerciseTypeResponse>> GetExerciseType(int id, 
            CancellationToken cancellationToken)
        {            
            var result = await _mediator.Send(new GetExerciseTypeRequest(id), cancellationToken);
            if (result.exerciseType is null) return NotFound();  
            return Ok(result); 
        }
            

        /// <summary>
        /// Get collection of exercise types
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection of exercise types</returns>
        [SwaggerResponse(200, "Collection of exercise types", typeof(GetExerciseTypesResponse))]
        [SwaggerResponse(400, "The exercise type data is invalid")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet]
        public Task<GetExerciseTypesResponse> GetExerciseTypes(CancellationToken cancellationToken) =>
            _mediator.Send(new GetExerciseTypesRequest(), cancellationToken);

        /// <summary>
        /// Add new exercise type
        /// </summary>
        /// <param name="request">Data for create new exercise type</param>
        /// <param name="cancellationToken"></param>
        /// <returns>ID of the created exercise type</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CreateExerciseType
        ///     {                
        ///        "name": "Push-Up",
        ///        "description": "The push-up is a push or press movement that works all the pressing muscles in the upper body"
        ///     }
        ///
        /// </remarks>        
        [SwaggerResponse(201, "The exercise type was created", typeof(CreateExerciseTypeResponse))]
        [SwaggerResponse(400, "The exercise type data is invalid")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<Task<CreateExerciseTypeResponse>> CreateExerciseTypeAsync(
            [FromBody] CreateExerciseTypeRequest request,
            CancellationToken cancellationToken)            
        => CreatedAtAction(nameof(CreateExerciseTypeAsync), request, _mediator.Send(request, cancellationToken));

        /// <summary>
        /// Update exist exercise type
        /// </summary>
        /// <param name="request">Data for update exist exercise type</param>
        /// <param name="cancellationToken"></param>
        /// <returns>ID of the created exercise type</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CreateExerciseType
        ///     {                
        ///        "id": "1"
        ///        "name": "Dip and flip",
        ///        "description": "The dip and flip is a fun move that works your triceps and biceps"
        ///     }
        ///
        /// </remarks>       
        [SwaggerResponse(200, "The exercise type was updated succefully", typeof(UpdateExerciseTypeResponse))]
        [SwaggerResponse(400, "The exercise type update is failed")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut]
        public Task<UpdateExerciseTypeResponse> UpdateExerciseType(
            [FromBody] UpdateExerciseTypeRequest request,
            CancellationToken cancellationToken)
            =>  _mediator.Send(request, cancellationToken);

        /// <summary>
        /// Delete exist exercise type
        /// </summary>
        /// <param name="request">Id of the object to be deleted</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [SwaggerResponse(200, "The exercise type was delete succefully", typeof(DeleteExerciseTypeResponse))]
        [SwaggerResponse(400, "The exercise type delete is failed")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete]
        public Task<DeleteExerciseTypeResponse> DeleteExerciseType(
            [FromBody] DeleteExerciseTypeRequest request,
            CancellationToken cancellationToken) =>
            _mediator.Send(request, cancellationToken);
    }
}
