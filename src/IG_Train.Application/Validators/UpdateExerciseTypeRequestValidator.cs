
using FluentValidation;
using IG_Train.Application.Handlers.ExerciseType;

namespace IG_Train.Application.Validators
{
    public class UpdateExerciseTypeRequestValidator
        : AbstractValidator<UpdateExerciseTypeRequest>
    {
        public UpdateExerciseTypeRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => "{PropertyName} must not be null or empty");

            RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage(x => "{PropertyName} must be greater than zero");

            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => "{PropertyName} must not be null or empty");
        }
    }
}
