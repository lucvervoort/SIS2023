
using Serilog;
using SIS.API;
using SIS.Domain.Interfaces;
using SIS.Infrastructure;
using SIS.Infrastructure.EFRepository.Context;

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
                  .AddScoped<ISISTeacherPreferenceRepository, EFSISTeacherPreferenceRepository>(); // BertEnErnie

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddControllers();
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}