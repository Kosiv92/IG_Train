namespace IG_Train.Contracts.Responses;

public record ExerciseTypeResponse
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }
}
