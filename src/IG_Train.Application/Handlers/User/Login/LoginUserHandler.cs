using IG_Train.Domain.Services;
using IG_Train.Domain;
using MediatR;
using IG_Train.Application.Exceptions;
using IG_Train.Domain.Entities;
using IG_Train.Application.Identity;

namespace IG_Train.Application.Handlers.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginUserHandler(IUserService userService, IPasswordHasher passwordHasher, 
            ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmail(request.Email, cancellationToken);
            if (user == null) throw new NotFoundException(nameof(UserEntity), request.Email);

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash)) throw new WrongPasswordException();

            var token = _tokenGenerator.Generate();

            return new LoginUserResponse(token);
        }
    }
}
