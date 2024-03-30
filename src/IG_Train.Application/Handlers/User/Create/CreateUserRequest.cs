using MediatR;

namespace IG_Train.Application.Handlers.User
{
    public record class CreateUserRequest(string Name, string PasswordHash, string Email) : IRequest<CreateUserResponse>
    {

    }
}
