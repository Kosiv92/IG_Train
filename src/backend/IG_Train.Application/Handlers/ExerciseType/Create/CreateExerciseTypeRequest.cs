using MediatR;

namespace IG_Train.Application.Handlers.ExerciseType;

/// <summary>
/// Data for create new exercise type
/// </summary>
/// <param name="Name">Name of exercise type (required)</param>
/// <param name="Description">Description of exercise type</param>
public record CreateExerciseTypeRequest(string Name, string Description) : IRequest<CreateExerciseTypeResponse>;