using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScraperAlura.Domain.Interfaces;
using ScraperAlura.Domain.Services;
using ScraperAlura.Infra.Repositories;
using ScraperAlura.Rpa.Interfaces;
using ScraperAlura.Rpa.Options;
using ScraperAlura.Rpa.Selenium;

namespace ScraperAlura.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddModuleRpa(this IServiceCollection services, IConfiguration config)
        {
            // Configurações
            services.Configure<RpaOptions>(config.GetSection("RPA"));

            // Serviços de domínio
            services.AddSingleton<ICursoRepository, CursoRepositoryMemoria>();
            services.AddScoped<ICursoScraper, AluraScraper>();
            services.AddScoped<ICursoService, CursoService>();

            // Serviços de RPA/Selenium
            services.AddScoped<IWebDriverFactory, WebDriverFactory>();

            return services;
        }
    }
}
