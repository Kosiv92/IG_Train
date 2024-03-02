using System.Reflection;

namespace IG_Train.Web.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
