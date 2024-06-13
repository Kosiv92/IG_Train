using IG_Train.Application.Handlers.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IG_Train.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
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
        ///        "email": "example@mail.com"
        ///        "password": "DifficultPassword2024$#@"              
        ///     }
        ///
        /// </remarks>        
        [SwaggerResponse(201, "The user was registered", typeof(CreateUserResponse))]
        [SwaggerResponse(400, "The user data is invalid")]        
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateUserResponse>> RegisterUserAsync(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        => CreatedAtAction(nameof(RegisterUserAsync), request, await _mediator.Send(request, cancellationToken));


        /// <summary>
        /// Authenticate existing user (get security token)
        /// </summary>
        /// <param name="request">Existing user authentication information</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Security token</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /LoginUser
        ///     {
        ///        "email": "example@mail.com"
        ///        "password": "DifficultPassword2024$#@"              
        ///     }
        ///
        /// </remarks>        
        [SwaggerResponse(200, "User authenticated successfully", typeof(CreateUserResponse))]
        [SwaggerResponse(404, "User not found")]
        [HttpPost("[action]")]        
        public Task<LoginUserResponse> LoginUser(LoginUserRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }


    }
}
