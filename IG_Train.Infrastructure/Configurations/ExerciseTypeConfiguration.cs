﻿using IG_Train.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IG_Train.Infrastructure.Configurations
{
    internal class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ExerciseType.MAX_NAME_LENGTH);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(ExerciseType.MAX_DESCRIPTION_LENGTH);
        }
    }
}