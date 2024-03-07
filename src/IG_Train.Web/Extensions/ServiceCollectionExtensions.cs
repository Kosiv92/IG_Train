using FluentValidation;
using IG_Train.Application;
using IG_Train.Domain;
using IG_Train.Domain.Repositories.Common;
using IG_Train.Domain.Services.Common;
using IG_Train.Infrastructure;
using IG_Train.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IG_Train.Web.Extensions;

public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAutoMapping(this IServiceCollection services) 
    {
        services.AddAutoMapper(
            typeof(IApplicationAssembly).Assembly,
            typeof(IInfrastructureAssembly).Assembly,
            typeof(IDomainAssembly).Assembly);

        return services;
    }

    internal static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
        });

        return services;
    }

    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(
                    typeof(IApplicationAssembly).Assembly,
                    typeof(IInfrastructureAssembly).Assembly,
                    typeof(IDomainAssembly).Assembly)
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

        return services;
    }

    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(
                    typeof(IApplicationAssembly).Assembly,
                    typeof(IInfrastructureAssembly).Assembly,
                    typeof(IDomainAssembly).Assembly)
                .AddClasses(classes => classes.AssignableTo<IRepository>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

        return services;
    }

    internal static IServiceCollection AddValidation(this IServiceCollection services) 
    {
        services.AddValidatorsFromAssemblies([
            typeof(IApplicationAssembly).Assembly,
            typeof(IInfrastructureAssembly).Assembly,
            typeof(IDomainAssembly).Assembly]);

        return services;
    }

    internal static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(IApplicationAssembly).Assembly,
            typeof(IInfrastructureAssembly).Assembly,
            typeof(IDomainAssembly).Assembly));

        return services;
    }
}
