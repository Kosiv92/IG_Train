using FluentValidation;
using IG_Train.Application.Handlers.User;
using System.Text.RegularExpressions;

namespace IG_Train.Application.Validators
{
    public class CreateUserRequestValidator 
        : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");

            RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
                .WithMessage("{PropertyName} must be valid email address");
                        
            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
                .WithMessage("{PropertyName} must have -minimum 8 character; -at least 1 uppercase letter; -at least 1 lowercase letter; -at least 1 digit; -at least 1 special character;");

        }
    }
}
