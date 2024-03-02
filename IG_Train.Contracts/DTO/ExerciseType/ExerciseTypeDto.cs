﻿namespace IG_Train.Contracts.DTO.ExerciseType
{
    public record ExerciseTypeDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
