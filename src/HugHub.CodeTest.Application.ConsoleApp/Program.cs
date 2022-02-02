using HugHub.CodeTest.Application.DependencyInjection;
using HugHub.CodeTest.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public static async Task Main(string[] args)
    {

        // create service collection
        var services = new ServiceCollection();
        ConfigureServices(services);

        // create service provider
        var serviceProvider = services.BuildServiceProvider();

        // entry to run app
        await serviceProvider.GetService<App>().Run(args);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // build config
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        //add services:
        services.AddApplicationDependencies();
        services.AddInfrastructureDependencies(configuration);

        // add app
        services.AddTransient<App>();
    }
}
