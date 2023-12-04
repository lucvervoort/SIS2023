
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SIS.API;
using SIS.API.Extensions;
using SIS.Domain.Interfaces;
using SIS.Infrastructure;
using SIS.Infrastructure.EFRepository.Context;
using SISApi.Extensions;
using System.Text.Json;

namespace SISApi
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly SqlConnection _connection;

        public string Name => "sql";

        public SqlServerHealthCheck(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                _connection.Open();
            }
            catch (SqlException)
            {
                return HealthCheckResult.Unhealthy();
            }

            return HealthCheckResult.Healthy();
        }
    }

    public class DbContextHealthCheck<TContext>: IHealthCheck where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public DbContextHealthCheck(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Perform a test query or operation on your DbContext
                // For example, you can execute a simple query like this:
                await _dbContext.Database.CanConnectAsync(cancellationToken);

                // DbContext is healthy
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                // If an exception is thrown, return an unhealthy result with the error details
                return HealthCheckResult.Unhealthy("DbContext connection test failed", ex);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddLogging(loggingBuilder =>
            {
                var configuration = new ConfigurationBuilder()
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();
                var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
                loggingBuilder.AddSerilog(logger, dispose: true);
            });

            builder.Services.AddDbContext<SisDbContext>()
                  .AddScoped<ISISTeacherTypeRepository, EFSISTeacherTypeRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISRegistrationStateRepository, EFSISRegistrationStateRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISPersonRepository, EFSISPersonRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISTeacherRepository, EFSISTeacherRepository>() // here I could pick the ADO.NET alternative
                  .AddScoped<ISISTeacherPreferenceRepository, EFSISTeacherPreferenceRepository>() // BertEnErnie

                  .AddScoped<ISISRoomRepository, EFSISRoomRepository>() // Da engineering
                  .AddScoped<ISISRoomTypeRepository, EFSISRoomTypeRepository>() // Da engineering
                  .AddScoped<ISISRoomKindRepository, EFSISRoomKindRepository>() // Da engineering
                  .AddScoped<ISISBuildingRepository, EFSISBuildingRepository>() // Da engineering
                  .AddScoped<ISISLocationRepository, EFSISLocationRepository>() // Da engineering
                  .AddScoped<ISISCampusRepository, EFSISCampusRepository>(); // Da engineering

            builder.Services.AddHealthChecks().AddDbContextCheck<SisDbContext>();
            // AddCheck<DbContextHealthCheck<SisDbContext>>("SisDbContextHealthCheck");

            builder.Services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.DisableDatabaseMigrations();
                //setup.SetEvaluationTimeInSeconds(5); // Configures the UI to poll for health checks updates every 5 seconds
                //setup.SetApiMaxActiveRequests(1); //Only one active request will be executed at a time. All the excedent requests will result in 429 (Too many requests)            
                setup.MaximumHistoryEntriesPerEndpoint(50); // Set the maximum history entries by endpoint that will be served by the UI api middleware
                //setup.SetNotifyUnHealthyOneTimeUntilChange(); // You will only receive one failure notification until the status changes

                setup.AddHealthCheckEndpoint("EFCore connection", "/working");

            }).AddInMemoryStorage();


            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            // Configure the API versioning properties of the project. 
            builder.Services.AddApiVersioningConfigured();

            // Add a Swagger generator and Automatic Request and Response annotations:
            builder.Services.AddSwaggerSwashbuckleConfigured();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // to print json:
            var options = new HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    c.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = r.Status.ToString(),
                        errors = r.Entries.Select(e => new { key = e.Key, value = e.Value.Status.ToString() })
                    });
                    await c.Response.WriteAsync(result);
                }
            };

            app.UseHealthChecks("/working", options);

            // url: /healthchecks-ui
            app.UseRouting().UseEndpoints(config =>
            {
                config.MapHealthChecksUI();
            });


            // Specific middleware to check if HTTP status codes are specified
            app.UseSwaggerResponseCheck();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}