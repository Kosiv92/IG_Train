using FluentValidation;
using IG_Train.Application.Handlers.ExerciseType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IG_Train.Application.Validators;

public class CreateExerciseTypeRequestValidator 
    : AbstractValidator<CreateExerciseTypeRequest>
{
    public CreateExerciseTypeRequestValidator()
    {
        RuleFor(x => x.Name)        
        .NotEmpty()
            .WithMessage("{PropertyName} must not be null or empty");
    }
}
