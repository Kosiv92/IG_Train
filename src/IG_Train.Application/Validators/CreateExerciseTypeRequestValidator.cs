using FluentValidation;
using IG_Train.Application.Handlers.ExerciseType;

namespace IG_Train.Application.Validators;

public class CreateExerciseTypeRequestValidator : AbstractValidator<CreateExerciseTypeRequest>
{
    public CreateExerciseTypeRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} must not be null or empty");
    }
}
