using AutoMapper;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using MediatR;

namespace IG_Train.Application.Handlers.User;

public class CreateExerciseTypeHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateExerciseTypeHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<UserEntity>(request);
        
        return new CreateUserResponse(await _userService.CreateUser
            (newUser, cancellationToken));        
    }
}