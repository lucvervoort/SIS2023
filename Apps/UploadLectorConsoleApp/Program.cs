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
        // We identify the path of our running application
        var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        // We create the generic host
        await Host.CreateDefaultBuilder(args)
            .UseContentRoot(dirName)
            .ConfigureLogging(logging =>
            {
                // Add any 3rd party loggers like NLog or Serilog
            })
            .ConfigureServices((hostContext, services) =>
            {
                services
                  .AddHostedService<ConsoleHostedService>() // generic host integrated in console app
                  .AddSingleton<IImporter, TeacherImporterService>()
                  .AddSingleton<ISISRepository, EFSISRepository>() // here I could pick the ADO.NET alternative
                  .UseSuperConvertExcelService(); // SuperConvert is integrated through its own service
            })
            .RunConsoleAsync();

        // Enable Logging and RAW SQL demo
        // Install Seq en SeriLog
    }
}