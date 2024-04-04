using IG_Train.Application.Handlers.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IG_Train.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add/register new user
        /// </summary>
        /// <param name="request">Data for create new user</param>
        /// <param name="cancellationToken"></param>
        /// <returns>ID of the created user</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /RegisterUser
        ///     {                
        ///        "name": "John Hancook",
        ///        "password": "DifficultPassword2024$#@"
        ///     }
        ///
        /// </remarks>        
        [SwaggerResponse(201, "The user was registered", typeof(CreateUserResponse))]
        [SwaggerResponse(400, "The user data is invalid")]
        [HttpPost]
        public ActionResult<Task<CreateUserResponse>> RegisterUserAsync(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        => CreatedAtAction(nameof(RegisterUserAsync), request, _mediator.Send(request, cancellationToken));


    }
}
