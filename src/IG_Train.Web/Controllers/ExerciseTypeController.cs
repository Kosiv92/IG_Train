using FluentValidation;
using IG_Train.Application.Handlers.ExerciseType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace IG_Train.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExerciseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<GetExerciseTypesResponse> GetExerciseTypes(CancellationToken cancellationToken) =>
            _mediator.Send(new GetExerciseTypesRequest(), cancellationToken);

        [HttpPost]
        public Task<CreateExerciseTypeResponse> CreateExerciseTypeAsync(
            [FromBody] CreateExerciseTypeRequest request,
            CancellationToken cancellationToken)
            => _mediator.Send(request, cancellationToken);
            
        [HttpPut]
        public Task<UpdateExerciseTypeResponse> UpdateExerciseType(
            [FromBody] UpdateExerciseTypeRequest request,
            CancellationToken cancellationToken)
            => _mediator.Send(request, cancellationToken);
        
        [HttpDelete]
        public Task<DeleteExerciseTypeResponse> DeleteExerciseType(
            [FromBody] DeleteExerciseTypeRequest request,
            CancellationToken cancellationToken) =>
            _mediator.Send(request, cancellationToken);
    }
}
