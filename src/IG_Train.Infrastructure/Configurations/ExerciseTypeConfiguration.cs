using IG_Train.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IG_Train.Infrastructure.Configurations
{
    internal class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired(false);
        }
    }
}
