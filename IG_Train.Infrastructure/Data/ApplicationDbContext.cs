using IG_Train.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IG_Train.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ExerciseType> ExerciseTypes { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
