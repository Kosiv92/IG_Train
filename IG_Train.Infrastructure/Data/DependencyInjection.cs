using IG_Train.Domain.Entities;
using IG_Train.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IG_Train.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
            });
            services.AddTransient<IRepository<ExerciseType>, ExerciseTypeRepository>();

            return services;
        }
    }
}
