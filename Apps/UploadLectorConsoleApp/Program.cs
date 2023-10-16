using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SIS.Domain.Interfaces;
using SuperConvert.Abstraction.Extensions;
using SIS.Infrastructure;

internal partial class Program
{

    private static async Task Main(string[] args)
    {
        var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        await Host.CreateDefaultBuilder(args)
            .UseContentRoot(dirName)
            .ConfigureLogging(logging =>
            {
                // Add any 3rd party loggers like NLog or Serilog
            })
            .ConfigureServices((hostContext, services) =>
            {
                services
                  .AddHostedService<ConsoleHostedService>()
                  .AddSingleton<IImporter, TeacherImporterService>()
                  .AddSingleton<ISISRepository, SISRepository>()
                  .UseSuperConvertExcelService();
            })
            .RunConsoleAsync();

        // Add MS Host and configure DI
        // Enable Logging and RAW SQL demo
        // Install Seq en SeriLog
        // Import lector
    }
}