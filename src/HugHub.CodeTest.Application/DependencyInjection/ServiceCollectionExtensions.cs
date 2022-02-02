using HugHub.CodeTest.Application.Factories;
using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Services;
using HugHub.CodeTest.Application.Services.QuotationServices;
using Microsoft.Extensions.DependencyInjection;

namespace HugHub.CodeTest.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<QuotationSystem1>();
            services.AddTransient<QuotationSystem2>();
            services.AddTransient<QuotationSystem3>();
            services.AddSingleton<IPriceEngine, PriceEngineService>();
            services.AddSingleton<IQuotationSystemFactory, QuotationSystemFactory>();

            return services;
        }
    }
}
