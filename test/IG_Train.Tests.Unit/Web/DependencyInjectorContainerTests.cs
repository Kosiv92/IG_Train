using Microsoft.Extensions.Hosting;
using Xunit;
using IG_Train.Web;
using Microsoft.AspNetCore.Hosting;

namespace IG_Train.Tests.Unit.Web
{
    public class DependencyInjectorContainerTests
    {
        [Fact]
        public void AllServicesShouldConstructSuccessfully()
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseDefaultServiceProvider((context, options) =>
                        {
                            options.ValidateOnBuild = true;
                        })
                        .UseStartup<Startup>();
                }).Build();
        }
    }
}
