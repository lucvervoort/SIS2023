
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using SIS.API;
using SIS.API.Extensions;
using SIS.Domain.Interfaces;
using SIS.Infrastructure;
using SIS.Infrastructure.EFRepository.Context;
using WebApiDocumentation.Extensions;

namespace SISApi
{
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

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            // Configure the API versioning properties of the project. 
            // builder.Services.AddApiVersioningConfigured();

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

            // Specific middleware to check if HTTP status codes are specified
            app.UseSwaggerResponseCheck();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}