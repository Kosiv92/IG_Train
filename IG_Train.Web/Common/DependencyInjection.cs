using AutoMapper;
using IG_Train.Application.Services;
using IG_Train.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IG_Train.Web.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExerciseTypeService, ExerciseTypeService>();
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;                
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }                
    }
}
