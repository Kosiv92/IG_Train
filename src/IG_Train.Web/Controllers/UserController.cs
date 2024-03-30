using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IG_Train.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
