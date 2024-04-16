
using MediatR;

namespace IG_Train.Application.Handlers.User
{
    public record LoginUserRequest(string Email, string Password) : IRequest<LoginUserResponse>
    {
    }
}
