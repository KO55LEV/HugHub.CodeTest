using HugHub.CodeTest.Infrastructure.Interfaces;
using HugHub.CodeTest.Infrastructure.Models.Configuration;
using HugHub.CodeTest.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HugHub.CodeTest.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddOptions<QuotationSystem1Settings>().Bind(configuration.GetSection(nameof(QuotationSystem1Settings))).ValidateDataAnnotations();
            //services.AddOptions<QuotationSystem2Settings>().Bind(configuration.GetSection(nameof(QuotationSystem2Settings))).ValidateDataAnnotations();
            //services.AddOptions<QuotationSystem3Settings>().Bind(configuration.GetSection(nameof(QuotationSystem3Settings))).ValidateDataAnnotations();

            services.AddTransient<IQuotationSystem1Service, QuotationSystem1Service>();
            services.AddTransient<IQuotationSystem2Service, QuotationSystem2Service>();
            services.AddTransient<IQuotationSystem3Service, QuotationSystem3Service>();

            return services;
        }
    }
}
