using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScraperAlura.DI;
using ScraperAlura.Domain.Interfaces;

namespace ScraperAlura.ConsoleApp
{
    static class Program
    {
        static async Task Main(string[] args) 
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection()
                .AddModuleRpa(config)
                .BuildServiceProvider();

            var domainService = services.GetRequiredService<ICursoService>();

            Console.Write("Termo de busca: ");
            var termo = Console.ReadLine() ?? "csharp";

            var titulos = await domainService.ExecutarAsync(termo);

            Console.WriteLine("\nResultados:");     
            foreach (var t in titulos)
                Console.WriteLine($"- {t}");

            Console.ReadKey();
        }
    }
}
