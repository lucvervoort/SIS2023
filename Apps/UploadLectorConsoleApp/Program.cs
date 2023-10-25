using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SIS.Domain.Interfaces;
using SuperConvert.Abstraction.Extensions;
using SIS.Infrastructure;
using Microsoft.Extensions.Configuration;
using Serilog;
using SIS.Infrastructure.EFRepository.Context;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        // We identify the path of our running application
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
                  .AddHostedService<ConsoleHostedService>() // generic host integrated in console app
                  .AddDbContext<SisDbContext>()
// -------------------------------------------------------
                  .AddSingleton<IImporter, TeacherImporterService>()
                  // classes using DbContext should have lifetime Scoped... (esp. ASP.NET Core)
                  .AddScoped<ISISTeacherTypeRepository, EFSISTeacherTypeRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISRegistrationStateRepository, EFSISRegistrationStateRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISPersonRepository, EFSISPersonRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISTeacherRepository, EFSISTeacherRepository>() // here I could pick the ADO.NET alternative
// -------------------------------------------------------
                  .UseSuperConvertExcelService(); // SuperConvert is integrated through its own service
            })
            .RunConsoleAsync();
    }
}