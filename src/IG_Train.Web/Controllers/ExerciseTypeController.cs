using FluentValidation;
using IG_Train.Application.Handlers.ExerciseType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading;

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
        /// Get collection of exercise types
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Collection of exercise types</returns>
        [SwaggerResponse(200, "Collection of exercise types", typeof(GetExerciseTypesResponse))]
        [SwaggerResponse(400, "The exercise type data is invalid")]
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
        [HttpPost]
        [SwaggerResponse(201, "The exercise type was created", typeof(CreateExerciseTypeResponse))]
        [SwaggerResponse(400, "The exercise type data is invalid")]
        public async Task<ActionResult<CreateExerciseTypeResponse>> CreateExerciseTypeAsync(
            [FromBody] CreateExerciseTypeRequest request,
            CancellationToken cancellationToken)
            //=> await _mediator.Send(request, cancellationToken);
        => CreatedAtAction(nameof(CreateExerciseTypeAsync), request, await _mediator.Send(request, cancellationToken));

        /// <summary>
        /// Update exist exercise type
        /// </summary>
        /// <param name="request">Data for update exist exercise type</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UpdateExerciseTypeResponse>> UpdateExerciseType(
            [FromBody] UpdateExerciseTypeRequest request,
            CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
        
        [HttpDelete]
        public Task<DeleteExerciseTypeResponse> DeleteExerciseType(
            [FromBody] DeleteExerciseTypeRequest request,
            CancellationToken cancellationToken) =>
            _mediator.Send(request, cancellationToken);
    }
}
