using IG_Train.Web.Extensions;

namespace IG_Train.Web;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();

        serviceCollection.AddApiExploreService();
        serviceCollection.AddAutoMapping();
        serviceCollection.AddDbContexts(_configuration);
        serviceCollection.AddServices();
        serviceCollection.AddRepositories();
        serviceCollection.AddValidation();
        serviceCollection.AddMediatr();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
    {
        applicationBuilder.UseRouting();
        if (env.IsDevelopment())
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI();
        }        
        applicationBuilder.UseHttpsRedirection();
        applicationBuilder.UseAuthorization();

        applicationBuilder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=ExerciseType}/{action=GetExerciseTypes}/{id?}");
        });
    }
}