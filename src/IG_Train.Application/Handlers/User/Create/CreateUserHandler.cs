using IG_Train.Domain;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _passwordHasher;
    

    public CreateUserHandler(IUserService userService, IPasswordHasher passwordHasher)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var hashedPassword = _passwordHasher.Generate(request.Password);                

        return new CreateUserResponse(await _userService.CreateUser
            (new UserEntity(default, request.Name, hashedPassword), cancellationToken));        
    }
}