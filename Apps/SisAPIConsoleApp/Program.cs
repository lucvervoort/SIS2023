using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;
using static Program;

namespace SisAPIConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // We create the generic host
            await Host.CreateDefaultBuilder(args)
                .UseContentRoot(dirName)
                .ConfigureLogging(loggingBuilder =>
                {
                    var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();
                    var logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
                    loggingBuilder.AddSerilog(logger, dispose: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                      .AddHostedService<ConsoleHostedService>(); // generic host integrated in console app                                                       // -------------------------------------------------------
                })
                .RunConsoleAsync();
        }
    }
}