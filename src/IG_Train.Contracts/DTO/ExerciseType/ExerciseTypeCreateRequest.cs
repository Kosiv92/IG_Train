﻿namespace IG_Train.Contracts.DTO.ExerciseType
{
    public record class ExerciseTypeCreateRequest
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}