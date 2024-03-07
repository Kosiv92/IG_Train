namespace IG_Train.Contracts.Requests
{
    public record class ExerciseTypeCreateRequest
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
