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
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddAutoMapping();
        serviceCollection.AddDbContexts(_configuration);
        serviceCollection.AddServices();
        serviceCollection.AddRepositories();
        serviceCollection.AddValidation();
        serviceCollection.AddMediatr();
    }

    public void Configure(IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseRouting();
        applicationBuilder.UseSwagger();
        applicationBuilder.UseSwaggerUI();
        applicationBuilder.UseHttpsRedirection();
        applicationBuilder.UseAuthorization();
    }
}