using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIS.Domain.Interfaces;

internal partial class Program
{
    internal sealed class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IImporter _lectorImporterService;
        private readonly ISISTeacherRepository _repository;
        private int? _exitCode;

        public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IConfiguration configuration,
            IHostApplicationLifetime appLifetime,
            IImporter lectorImporterService)
        {
            _logger = logger;
            _configuration = configuration;
            _appLifetime = appLifetime;
            _lectorImporterService = lectorImporterService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        /*
                        // Example - use Server Explorer to enter data in SQLServer and C# code to generate json input file:
                        var repository = new SISRepository(_logger, _configuration);
                        var lectoren = repository.Teachers;
                        var json = JsonSerializer.Serialize(lectoren.Values);
                        */

                        _logger.LogInformation("Importing...");

                        //TeacherImporterService lectorImporterService = new(_logger, _configuration, _repository);
                        _lectorImporterService.Import();

                        _exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                        _exitCode = 1;
                    }
                    finally
                    {
                        // Stop the application once the work is done
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Exiting with return code: {_exitCode}");

            // Exit code may be null if the user cancelled via Ctrl+C/SIGTERM
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}