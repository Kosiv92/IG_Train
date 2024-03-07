﻿namespace IG_Train.Contracts.Requests
{
    public record class ExerciseTypeEditRequest
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}